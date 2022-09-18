namespace RealEstases.Data
{
    using Microsoft.EntityFrameworkCore;
    using RealEstases.Models;

    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
                
        }

        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Property> Properties { get; set; }

        public DbSet<BuildingType> Buildings { get; set; }

        public DbSet<District>  Districts { get; set; }

        public DbSet<PropertyType>  PropertyTypes { get; set; }

        public DbSet<Tag> Tags { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=RealEstates;Integrated Security=true");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        
    }
}
