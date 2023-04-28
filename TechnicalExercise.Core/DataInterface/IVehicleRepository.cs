using TechnicalExercise.Core.Domain;

namespace TechnicalExercise.Core.DataInterface
{
    public interface IVehicleRepository
    {
        Task<Vehicle> AddAsync(Vehicle auto);
        Task<Vehicle> GetAsync(Guid id);
        Task<IEnumerable<Vehicle>> GetAsync();
        void Delete(Vehicle id);
        void Update(Vehicle id);
    }
}
