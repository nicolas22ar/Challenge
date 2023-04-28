using TechnicalExercise.Core.Domain;

namespace TechnicalExercise.Core.Processor
{
    public interface IVehicleProcessor
    {
        Task<VehicleResult> AddAsync(VehicleRequest request);

        Task<Vehicle> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(Guid id, VehicleRequest auto);

        Task<IEnumerable<Vehicle>> GetAsync();
    }
}
