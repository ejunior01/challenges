using FluentAssertions;
using ParkingFlow.WebApi.Domain.Parkings;

namespace ParkingFlow.Tests.UnitTests.Domain.Parkings;

public class CNPJTest
{
    [Fact]
    public void Should_create_cnpj_when_valid_input()
    {
        var cnpj = CNPJ.Create("12.345.678/0001-95");

        cnpj.Value.Should().NotBeNullOrEmpty();
    }

     [Theory]
    [InlineData("AAA")]
    [InlineData("1234")]
    [InlineData("12.345.678/000195")]
    [InlineData("12.345.678/0001-095")]
    [InlineData("1234567800019500")]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Should_throw_exception_when_creating_plate_with_invalid_value(string value)
    {
        var act = () =>
        {
            var _ =  CNPJ.Create(value);

        };

        act.Should().Throw<InvalidOperationException>();
    }
}