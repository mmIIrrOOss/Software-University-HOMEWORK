namespace MiniORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;

    public abstract class DbContext
    {
        private readonly DatabaseConnection connection;

        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

        internal static readonly Type[] AllowedSqlTypes =
        {
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(decimal),
            typeof(bool),
            typeof(DateTime),
        };

        protected DbContext(string connectionString)
        {
            this.connection = new DatabaseConnection(connectionString);

            this.dbSetProperties = this.DiscoverDbSets();

            using (new ConnectionManager(connection))
            {
                this.InitializeDbSets();
            }

            this.MapAllRealtions();
        }

        public void SaveChanges()
        {
            var dbSets = this.dbSetProperties
                .Select(pi => pi.Value.GetValue(this))
                .ToArray();

            foreach (IEnumerable<object> dbSet in dbSets)
            {
                var invalidEntities = dbSet
                    .Where(entity => !IsObjectValue(entity))
                    .ToArray();
                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException($"{invalidEntities.Length} Invalid Entities found is " +
                        $"{dbSet.GetType().Name}!");
                }
            }

            using (new ConnectionManager(connection))
            {
                using (var transaction = this.connection.StartTransaction())
                {
                    foreach (var dbSet in dbSets)
                    {
                        var dbSetType = dbSet.GetType().GetGenericArguments().First();

                        var persistMethod = typeof(DbContext)
                            .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
                            .MakeGenericMethod(dbSetType);

                        try
                        {
                            persistMethod.Invoke(this, new object[] { dbSet });
                        }
                        catch (TargetInvocationException tie)
                        {
                            throw tie.InnerException;
                        }
                        catch (InvalidOperationException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            var tableName = GetTableName(typeof(TEntity));

            var columns = this.connection.FetchColumnNames(tableName).ToArray();
            if (dbSet.ChangeTracker.Added.Any())
            {
                this.connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
            }

            var modidfiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();
            if (modidfiedEntities.Any())
            {
                this.connection.UpdateEntities(modidfiedEntities, tableName, columns);
            }
            if (dbSet.ChangeTracker.Removed.Any())
            {
                this.connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
            }
        }

        private void InitializeDbSets()
        {
            foreach (var dbSet in this.dbSetProperties)
            {
                var dbSeType = dbSet.Key;
                var dbSetProperty = dbSet.Value;

                var populateDbSeGeneric = typeof(DbContext)
                    .GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSeType);

                populateDbSeGeneric.Invoke(this, new object[] { dbSetProperty });
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
            where TEntity : class, new()
        {
            var entities = LoadTableEntities<TEntity>();

            var dbSetInstance = new DbSet<TEntity>(entities);
            ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
        }

        private void MapAllRealtions()
        {
            foreach (var dbSeProperty in dbSetProperties)
            {
                var dbSetType = dbSeProperty.Key;

                var mapRelationGeneric = typeof(DbContext)
                    .GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetType);
                var dbSet = dbSeProperty.Value.GetValue(this);
                mapRelationGeneric.Invoke(this, new object[] { dbSet });
            }
        }

        private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
             where TEntity : class, new()
        {
            var entityType = typeof(TEntity);

            MapNvigationProperties(dbSet);

            var collections = entityType
                .GetProperties()
                .Where(pi =>
                        pi.PropertyType.IsGenericType &&
                        pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToArray();

            foreach (var collection in collections)
            {
                var collectionType = collection.PropertyType.GenericTypeArguments.First();

                var mappCollectionMethod = typeof(DbContext)
                    .GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(entityType, collectionType);
                mappCollectionMethod.Invoke(this, new object[] { dbSet, collection });
            }
        }

        private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet, PropertyInfo collectionProperty)
            where TDbSet : class, new() where TCollection : class, new()
        {
            var entityType = typeof(TDbSet);
            var collectionType = typeof(TCollection);

            var primaryKeys = collectionType.GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            var primaryKey = primaryKeys.First();
            var foreignKey = entityType.GetProperties()
                .First(pi => pi.HasAttribute<KeyAttribute>());

            var isManyToMany = primaryKeys.Length >= 2;
            if (isManyToMany)
            {
                primaryKey = collectionType.GetProperties()
                    .First(pi => collectionType.
                                                GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>().Name)
                                                .PropertyType == entityType);
            }

            var navigationDbSet = (DbSet<TCollection>)this.dbSetProperties[collectionType].GetValue(this);

            foreach (var entity in dbSet)
            {
                var primaryKeyValue = foreignKey.GetValue(entity);

                var navigationEntities = navigationDbSet
                    .Where(navigationEntity => primaryKey.GetValue(navigationEntity).Equals(primaryKeyValue))
                    .ToArray();
                ReflectionHelper.ReplaceBackingField(entity, collectionProperty.Name, navigationEntities);
            }
        }

        private void MapNvigationProperties<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            var entityType = typeof(TEntity);
            var foreignKeys = entityType.GetProperties()
                .Where(pi => pi.HasAttribute<ForeignKeyAttribute>())
                .ToArray();

            foreach (var foreignKey in foreignKeys)
            {
                var navigationPropertyName =
                    foreignKey.GetCustomAttribute<ForeignKeyAttribute>().Name;
                var navigationProperty = entityType.GetProperty(navigationPropertyName);

                var navigationDbSet = this.dbSetProperties[navigationProperty.PropertyType]
                    .GetValue(this);

                var navigationPrimaryKey = navigationProperty.PropertyType.GetProperties()
                    .First(pi => pi.HasAttribute<KeyAttribute>());


                foreach (var entity in dbSet)
                {
                    var foreignKeyValue = foreignKey.GetValue(entity);

                    var navigationPropertyValue = ((IEnumerable<object>)navigationDbSet)
                        .First(currentNavigationProperty =>
                                    navigationPrimaryKey.GetValue(currentNavigationProperty).Equals(foreignKeyValue));

                    navigationProperty.SetValue(entity, navigationPropertyValue);
                }
            }
        }

        private static bool IsObjectValue(object e)
        {
            var validationContext = new ValidationContext(e);
            var validationErrors = new List<ValidationResult>();

            var validationResult =
                Validator.TryValidateObject(e, validationContext, validationErrors, validateAllProperties: true);
            return validationResult;
        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>()
            where TEntity : class
        {
            var table = typeof(TEntity);
            var columns = GetEntityColumnNames(table);
            var tableName = GetTableName(table);

            var fetchedRows = this.connection.FetchResultSet<TEntity>(tableName, columns).ToArray();

            return fetchedRows;
        }

        private string GetTableName(Type tableType)
        {
            string tableName = string.Empty;

            try
            {
                tableName = ((TableAttribute)Attribute.GetCustomAttribute(tableType, typeof(TableAttribute))).Name;
            }
            catch (NullReferenceException)
            {
                tableName = this.dbSetProperties[tableType].Name;
            }

            return tableName;
        }

        private Dictionary<Type, PropertyInfo> DiscoverDbSets()
        {
            var dbSets = this.GetType()
                .GetProperties()
                .Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .ToDictionary(pi => pi.PropertyType.GetGenericArguments().First(), pi => pi);

            return dbSets;
        }

        private string[] GetEntityColumnNames(Type table)
        {
            var tableName = this.GetTableName(table);
            var dbColumns = this.connection.FetchColumnNames(tableName);

            var columns = table.GetProperties()
                .Where(pi => dbColumns.Contains(pi.Name) &&
                        !pi.HasAttribute<NotMappedAttribute>() &&
                        AllowedSqlTypes.Contains(pi.PropertyType))
                .Select(pi => pi.Name)
                .ToArray();

            return columns;

        }
    }
}