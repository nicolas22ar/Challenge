using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TechnicalExercise.Core.Domain;

namespace TechnicalExercise.Core.Data
{
    public class TestDataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public TestDataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureIdProperty(modelBuilder);

            modelBuilder.Entity<Plate>().Property(x => x.Value)
               .IsRequired()
               .HasColumnType("varchar(6)");

            modelBuilder.Entity<Vehicle>().Property(x => x.Color)
              .IsRequired()
              .HasColumnType("varchar(50)");

            modelBuilder.Entity<Vehicle>().Property(x => x.Type)
                .IsRequired()
                .HasColumnType("varchar(10)");

            modelBuilder.Entity<Vehicle>().HasIndex(x => x.Id);

            modelBuilder.Entity<Vehicle>().HasOne(x => x.Plate)
                .WithMany()
                .HasForeignKey(x => x.PlateId);

            new DbInitializer(modelBuilder).Seed();

        }

        private static void ConfigureIdProperty(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(t => t.ClrType.IsSubclassOf(typeof(Entity))))
            {
                modelBuilder.Entity(
                    entityType.Name,
                    x =>
                    {
                        x.Property("Id").HasDefaultValueSql("newid()");
                    });
            }
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Plate> Plates { get; set; }
    }
}
