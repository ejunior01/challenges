using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using ParkingFlow.WebApi.Domain.Vehicles;
using ParkingFlow.WebApi.Features.Vehicles.Queries.Get;
using ParkingFlow.WebApi.Persistence.Database;

namespace ParkingFlow.Tests.UnitTests.Application.Vehicles; 

public class GetVehicleByPlateHandlerTests
{
    private readonly Mock<ParkingFlowDbContext> _mockContext;
    private readonly GetVehicleByPlateHandler _handler;

    public GetVehicleByPlateHandlerTests()
    {
        _mockContext = new Mock<ParkingFlowDbContext>(new DbContextOptions<ParkingFlowDbContext>());

        var vehicles = new List<Vehicle>
        {
           new (
            "TestBrand",
            "TestMode",
            "Blue",
            Plate.Create("AAA-1515"),
            TypeVehicle.Car)
        };

        _mockContext.Setup(x => x.Set<Vehicle>())
                    .ReturnsDbSet(vehicles);

        _handler = new GetVehicleByPlateHandler(_mockContext.Object);
    }

    [Fact]
    public async Task Should_result_sucess_When_handler_vehicle_exists_plate()
    {
        var query = new GetVehicleByPlateQuery("AAA-1515");

        var result = await _handler.Handle(query, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
        result.Value.Plate.Value.Should().Be("AAA-1515");
    }
    [Fact]
    public async Task Should_result_fail_When_handler_vehicle_not_exists_plate()
    {
        var query = new GetVehicleByPlateQuery("AAA1B24");

        var result = await _handler.Handle(query, CancellationToken.None);

        result.IsFailed.Should().BeTrue();
        result.Errors.First().Message.Should().Be($"Vehicle AAA1B24 not found");
    }
}
