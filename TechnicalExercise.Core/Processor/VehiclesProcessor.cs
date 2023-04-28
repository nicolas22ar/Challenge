using TechnicalExercise.Core.DataInterface;
using TechnicalExercise.Core.Domain;

namespace TechnicalExercise.Core.Processor
{
    public class VehiclesProcessor : IVehicleProcessor
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IPlateRepository _plateRepository;
        public VehiclesProcessor(IVehicleRepository vehicleRepository, IPlateRepository plateRepository)
        {
            _vehicleRepository = vehicleRepository;
            _plateRepository = plateRepository;
        }

        public async Task<VehicleResult> AddAsync(VehicleRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var availablePlates = await _plateRepository.GetAvailablePatesAsync(request.CreationDate);

            if (availablePlates.FirstOrDefault() is Plate availablePlate)
            {
                var vehicle = new Vehicle
                {
                    Color = request.Color,
                    Type = request.Type,
                    PlateId = availablePlate.Id,
                    CreationDate = request.CreationDate
                };

                var vehicleAdded = await _vehicleRepository.AddAsync(vehicle);

                return new VehicleResult
                {
                    Color = vehicleAdded.Color,
                    Type = vehicleAdded.Type,
                    CreationDate = vehicleAdded.CreationDate,
                    Code = Domain.VehicleResultCode.Success,
                    PlateId = availablePlate.Id
                };
            }
            else
            {
                return new VehicleResult
                {
                    Code = Domain.VehicleResultCode.NoPlateAvailable,
                };
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var auto =await GetAsync(id);
            _vehicleRepository.Delete(auto);
        }

        public async Task UpdateAsync(Guid id, VehicleRequest auto)
        {
            var autoToUpdate = await GetAsync(id);

            autoToUpdate.Color = auto.Color;
            autoToUpdate.Type = auto.Type;

            _vehicleRepository.Update(autoToUpdate);
        }

        public async Task<Vehicle> GetAsync(Guid id)
        {
            return await _vehicleRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Vehicle>> GetAsync()
        {
            return await _vehicleRepository.GetAsync();
        }
    }
}