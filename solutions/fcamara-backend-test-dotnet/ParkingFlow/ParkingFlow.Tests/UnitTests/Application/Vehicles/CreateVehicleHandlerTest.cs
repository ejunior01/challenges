using FluentAssertions;
using Moq;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Vehicles;
using ParkingFlow.WebApi.Features.Vehicles.CreateVehicle;

namespace ParkingFlow.Tests.UnitTests.Application.Vehicles;

public class CreateVehicleHandlerTest
{
    [Fact]
    public async Task Should_result_success_when_handler_create_vehicle_with_valid_command()
    {
        var unitOfWork = new Mock<IUnitOfWork>();
        var vehicleRepository = new Mock<IVehicleRepository>();

        vehicleRepository.Setup((v) => v.ExistsVehicleByPlateAsync(It.IsAny<string>())).ReturnsAsync(false);

        var command = new CreateVehicleCommand("Fiat", "Uno", "Preta", "AAA-1515", TypeVehicle.Car);
        var handler = new CreateVehicleHandler(vehicleRepository.Object, unitOfWork.Object);
        var result = await handler.Handle(command);

        result.Should().NotBeNull();
        result.Errors.Should().BeEmpty();
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Should_result_failed_when_handler_create_vehicle_with_exists_plate()
    {
        var unitOfWork = new Mock<IUnitOfWork>();
        var vehicleRepository = new Mock<IVehicleRepository>();

        vehicleRepository.Setup((v) => v.ExistsVehicleByPlateAsync(It.IsAny<string>())).ReturnsAsync(true);

        var command = new CreateVehicleCommand("Fiat", "Uno", "Preta", "AAA-1515", TypeVehicle.Car);
        var handler = new CreateVehicleHandler(vehicleRepository.Object, unitOfWork.Object);
        var result = await handler.Handle(command);

        result.Should().NotBeNull();
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().NotBeNullOrEmpty();
    }
}