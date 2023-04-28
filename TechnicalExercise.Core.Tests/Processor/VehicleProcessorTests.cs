using Moq;
using TechnicalExercise.Core.DataInterface;
using TechnicalExercise.Core.Domain;
using TechnicalExercise.Core.Processor.Domain;

namespace TechnicalExercise.Core.Processor
{

    public class VehicleProcessorTests
    {
        private readonly VehiclesProcessor _processor;
        private readonly VehicleRequest _request;
        private readonly Vehicle _vehicleAdded;
        private readonly Mock<IVehicleRepository> _vehicleRepositoryMock;
        private readonly Mock<IPlateRepository> _plateRepositoyMock;
        private readonly List<Plate> _availablePlates;

        public VehicleProcessorTests()
        {

            _request = new VehicleRequest
            {
                Color = "Red",
                Type = "Car",
                CreationDate = DateTime.Now,
            };

            var plateId = Guid.NewGuid();

            _availablePlates = new List<Plate>
            { 
                new Plate 
                { 
                    Id = plateId
                } 
            };

            _vehicleAdded = new Vehicle
            {
                Color = "Red",
                Type = "Car",
                CreationDate = DateTime.Now,
                PlateId = plateId
            };

            _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            _plateRepositoyMock = new Mock<IPlateRepository>();

            _plateRepositoyMock.Setup(x => x.GetAvailablePatesAsync(_request.CreationDate))
                .ReturnsAsync(_availablePlates);

            _vehicleRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Vehicle>()))
              .ReturnsAsync(_vehicleAdded);

            _processor = new VehiclesProcessor(_vehicleRepositoryMock.Object, _plateRepositoyMock.Object);
        }

        [Fact]
        public async Task ShouldReturnVehicleResultWithRequestValue()
        {

            // Act
            VehicleResult result = await _processor.AddAsync(_request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(_request.Color, result.Color);
            Assert.Equal(_request.Type, result.Type);

        }

        [Fact]
        public async Task ShouldThrowExceptionIfRequestValueIsNull()
        {
            var exception = Assert.ThrowsAsync<ArgumentNullException>(() =>  _processor.AddAsync(null));

            Assert.Equal("request", exception.Result.ParamName);
        }

        [Fact]
        public async Task ShouldSaveVehicle()
        {
            VehicleResult savedTestData = null;

            savedTestData = await _processor.AddAsync(_request);

            _vehicleRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Vehicle>()), Times.Once);

            Assert.NotNull(savedTestData);
            Assert.Equal(_request.Color, savedTestData.Color);
            Assert.Equal(_request.Type, savedTestData.Type);
            Assert.Equal(_availablePlates.First().Id, savedTestData.PlateId);
        }

        [Fact]
        public async Task ShouldNotAddVehicleIfNoPlateAvailable()
        {
            _availablePlates.Clear();

             await _processor.AddAsync(_request);

            _vehicleRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Vehicle>()), Times.Never);

        }

        [Theory]
        [InlineData(VehicleResultCode.Success, true)]
        [InlineData(VehicleResultCode.NoPlateAvailable, false)]
        public async Task ShouldReturnEspectedResultCode(VehicleResultCode expectedResultCode, bool isPlateAvailable)
        {
            if (!isPlateAvailable)
            {
                _availablePlates.Clear();
            }

            var result = await _processor.AddAsync(_request);

            Assert.Equal(expectedResultCode, result.Code);
        }

        [Fact]
        public async Task ShouldCallGetMethodWhenGetVehicle()
        {
            var result = await _processor.GetAsync(Guid.NewGuid());

            _vehicleRepositoryMock.Verify(x => x.GetAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task ShouldCallGetListMethodWhenGetListVehicle()
        {
            var result = await _processor.GetAsync();

            _vehicleRepositoryMock.Verify(x => x.GetAsync(), Times.Once);
        }

        [Fact]
        public  async Task ShouldCallDeleteMethodWhenDeleteVehicle()
        {
            await _processor.DeleteAsync(Guid.NewGuid());

            _vehicleRepositoryMock.Verify(x => x.GetAsync(It.IsAny<Guid>()), Times.Once);

            _vehicleRepositoryMock.Verify(x => x.Delete(It.IsAny<Vehicle>()), Times.Once);
        }

        [Fact]
        public async Task ShouldCallUpdateMethodWhenUpdateVehicle()
        {
            var Vehicle = new Vehicle
            {
                Id = Guid.NewGuid(),
                Color = "Red",
                Type = "Car",
                CreationDate = DateTime.Now,
            };

            var VehicleRequest = new VehicleRequest
            {
                Color = "Red",
                Type = "Car",
                CreationDate = DateTime.Now,
            };

            _vehicleRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(Vehicle);

            await _processor.UpdateAsync(Guid.NewGuid(), VehicleRequest);

            _vehicleRepositoryMock.Verify(x => x.GetAsync(It.IsAny<Guid>()), Times.Once);

            _vehicleRepositoryMock.Verify(x => x.Update(It.IsAny<Vehicle>()), Times.Once);
        }

    }
}
