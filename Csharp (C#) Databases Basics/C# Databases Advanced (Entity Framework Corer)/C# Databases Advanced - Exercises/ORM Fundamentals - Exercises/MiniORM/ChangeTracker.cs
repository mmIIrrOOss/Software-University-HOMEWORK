namespace MiniORM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;


    internal class ChangeTracker<T> where T : class, new()
    {
        private readonly List<T> allEntities;

        private readonly List<T> added;

        private readonly List<T> removed;

        public ChangeTracker(IEnumerable<T> entites)
        {
            this.added = new List<T>();
            this.removed = new List<T>();

            this.allEntities = CloneEntites(entites);
        }

        public IReadOnlyCollection<T> AllEntinites => this.allEntities.AsReadOnly();

        public IReadOnlyCollection<T> Added => this.added.AsReadOnly();

        public IReadOnlyCollection<T> Removed => this.removed.AsReadOnly();


        private List<T> CloneEntites(IEnumerable<T> entities)
        {
            var clonedEntities = new List<T>();

            PropertyInfo[] propertiesToClone = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
                .ToArray();

            foreach (var entity in entities)
            {
                var clonedEntity = Activator.CreateInstance<T>();

                foreach (var property in propertiesToClone)
                {
                    var value = property.GetValue(entity);
                    property.SetValue(clonedEntity, value);
                }

                clonedEntities.Add(clonedEntity);
            }

            return clonedEntities;
        }

        public void Add(T item) => this.added.Add(item);

        public void Remove(T item) => this.added.Remove(item);

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            var modifiedEntities = new List<T>();

            var primaryKeys = typeof(T).GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (var proxyEntity in this.AllEntinites)
            {
                var primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity)
                    .ToArray();

                var entity = dbSet.Entities
                    .Single(e => GetPrimaryKeyValues(primaryKeys, e)
                    .SequenceEqual(primaryKeyValues));

                var isModified = IsModified(proxyEntity, entity);
                if (isModified)
                {
                    modifiedEntities.Add(entity);
                }
            }

            return modifiedEntities;
        }

        private bool IsModified(T proxyEntity, T entity)
        {
            var monitoredProperties = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType));

            var modifiedProperties = monitoredProperties
                .Where(pi => !Equals(pi.GetValue(entity), pi.GetValue(proxyEntity)))
                .ToArray();

            var isModified = modifiedProperties.Any();

            return isModified;
        }

        private IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys,T entity)
        {
            return primaryKeys.Select(pk => pk.GetValue(entity));
        }
    }
}