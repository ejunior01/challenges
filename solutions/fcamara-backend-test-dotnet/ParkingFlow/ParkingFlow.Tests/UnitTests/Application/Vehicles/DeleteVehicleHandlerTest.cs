using FluentAssertions;
using Moq;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Vehicles;
using ParkingFlow.WebApi.Features.Vehicles.DeleteVehicle;

namespace ParkingFlow.Tests.UnitTests.Application.Vehicles;

public class DeleteVehicleHandlerTest
{
    [Fact]
    public async Task Should_result_success_when_handler_delete_vehicle_with_valid_command_and_exists_vehicle()
    {
        var unitOfWork = new Mock<IUnitOfWork>();
        var vehicleRepository = new Mock<IVehicleRepository>();
        var vehicle = new Vehicle("Fiat", "Uno", "Preta", Plate.Create("AAA-1515"), TypeVehicle.Car);
        vehicleRepository.Setup((v) => v.GetByPlateAsync(It.IsAny<string>())).ReturnsAsync(vehicle);

        var command = new DeleteVehicleCommand("AAA-1515");
        var handler = new DeleteVehicleHandler(vehicleRepository.Object, unitOfWork.Object);
        var result = await handler.Handle(command);

        result.Should().NotBeNull();
        result.Errors.Should().BeEmpty();
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Should_result_failed_when_handler_delete_vehicle_with_not_exists_vehicle()
    {
        var unitOfWork = new Mock<IUnitOfWork>();
        var vehicleRepository = new Mock<IVehicleRepository>();

        vehicleRepository.Setup((v) => v.GetByPlateAsync(It.IsAny<string>())).ReturnsAsync(value: null);

        var command = new DeleteVehicleCommand("AAA-1515");
        var handler = new DeleteVehicleHandler(vehicleRepository.Object, unitOfWork.Object);
        var result = await handler.Handle(command);

        result.Should().NotBeNull();
        result.Errors.Should().NotBeNullOrEmpty();
        result.IsFailed.Should().BeTrue();
    }
}