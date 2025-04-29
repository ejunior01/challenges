using FluentAssertions;
using ParkingFlow.Domain.Vehicles;

namespace ParkingFlow.Tests.UnitTests.Domain.Vehicles;

public class VehicleTest
{
    [Fact]
    public void Should_create_vehicle_when_valid_input()
    {
        var vehicle = new Vehicle("Fiat", "Uno", "Preta", Plate.Create("AAA-1515"), TypeVehicle.Car);
        vehicle.Should().NotBeNull();
    }

    [Theory]
    [InlineData("f", "Uno", "Preta")]
    [InlineData("Fiat", "U", "Preta")]
    [InlineData("Fiat", "Uno", "P")]
    public void Should_throw_exception_when_creating_vehicle_with_values_are_less_than_acceptable(string brand,
        string model, string color)
    {
        var act = () =>
        {
            var _ = new Vehicle(brand, model, color, Plate.Create("AAA-1515"), TypeVehicle.Car);
        };

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(null, "Uno", "Preta")]
    [InlineData("Fiat", null, "Preta")]
    [InlineData("Fiat", "Uno", null)]
    [InlineData(" ", "Uno", "Preta")]
    [InlineData("Fiat", " ", "Preta")]
    [InlineData("Fiat", "Uno", " ")]
    [InlineData("", "Uno", "Preta")]
    [InlineData("Fiat", "", "Preta")]
    [InlineData("Fiat", "Uno", "")]
    public void Should_throw_exception_when_creating_vehicle_with_values_are_is_null_or_whiteSpace(string brand,
        string model, string color)
    {
        var act = () =>
        {
            var _ = new Vehicle(brand, model, color, Plate.Create("AAA-1515"), TypeVehicle.Car);
        };

        act.Should().Throw<ArgumentException>();
    }
}