using Microsoft.EntityFrameworkCore;
using TechnicalExercise.Core.Data;
using TechnicalExercise.Core.DataInterface;
using TechnicalExercise.Core.Domain;

namespace TechnicalExercise.Core.DataAccess
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly TestDataContext _context;

        public VehicleRepository(TestDataContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> AddAsync(Vehicle auto)
        {
            var savedAuto = await _context.Vehicles.AddAsync(auto);
            _context.SaveChanges();

            return savedAuto.Entity;
        }

        public void Delete(Vehicle auto)
        {
            _context.Vehicles.Remove(auto);
            _context.SaveChanges();
        }

        public async Task<Vehicle> GetAsync(Guid id)
        {
            return await _context
                    .Vehicles
                    .Include(x=>x.Plate)
                    .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Invalid Id");
        }

        public async Task<IEnumerable<Vehicle>> GetAsync()
        {
            return await _context
                  .Vehicles
                  .Include(x => x.Plate)
                  .ToListAsync();
        }

        public void Update(Vehicle auto)
        {
            _context.Vehicles.Update(auto);
            _context.SaveChanges();
        }
    }
}
