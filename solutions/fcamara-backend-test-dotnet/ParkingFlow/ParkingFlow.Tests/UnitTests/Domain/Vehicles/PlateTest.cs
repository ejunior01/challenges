using FluentAssertions;
using ParkingFlow.Domain.Vehicles;

namespace ParkingFlow.Tests.UnitTests.Domain.Vehicles;

public class PlateTest
{
    [Theory]
    [InlineData("AAA-1234")]
    [InlineData("aaa-1234")]
    [InlineData("aaa1a24")]
    [InlineData("AAA1B23")]
    public void Should_create_plate_when_valid_input(string value)
    {
        var plate = Plate.Create(value);
        plate.Should().NotBeNull();
        plate.Value.Should().Be(value.ToUpper());
    }

    [Theory]
    [InlineData("AAA")]
    [InlineData("1234")]
    [InlineData("BBB-12345")]
    [InlineData("BBBa-1234")]
    [InlineData("BBB-12")]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Should_throw_exception_when_creating_plate_with_invalid_value(string value)
    {
        var act = () =>
        {
            var _ = Plate.Create(value);
        };

        act.Should().Throw<InvalidOperationException>();
    }
}