using Microsoft.EntityFrameworkCore;
using TechnicalExercise.Core.Domain;

namespace TechnicalExercise.Core.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            var date = DateTime.Now;
            var plate1 = Guid.NewGuid();
            modelBuilder.Entity<Plate>().HasData(
                   new Plate() { Id = plate1, Value = "LSK658", Date = date },
                   new Plate() { Id = Guid.NewGuid(), Value = "KSI695", Date = date.AddDays(1) },
                   new Plate() { Id = Guid.NewGuid(), Value = "USJ726", Date = date.AddDays(2) },
                   new Plate() { Id = Guid.NewGuid(), Value = "IEK659", Date = date.AddDays(3) },
                   new Plate() { Id = Guid.NewGuid(), Value = "KSI654", Date = date.AddDays(4) });

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle() { Id = Guid.NewGuid(), Color = "RED", Type = "CAR", CreationDate = date, PlateId = plate1 });
        }
    }
}
