using FluentAssertions;
using ParkingFlow.WebApi.Domain.Parkings;

namespace ParkingFlow.Tests.UnitTests.Domain.Parkings;

public class CNPJTest
{
    [Theory]
    [InlineData("12.345.678/0001-95")]
    [InlineData(" 12.345.678/0001-95")]
    [InlineData("12.345.678/0001-95 ")]
    [InlineData("12345678000195")]
    [InlineData(" 12345678000195")]
    [InlineData("12345678000195 ")]
    public void Should_create_cnpj_when_valid_input(string input)
    {
        var cnpj = CNPJ.Create(input);

        cnpj.Value.Should().NotBeNullOrEmpty();
    }

    [Theory]
    [InlineData("12.345.678/0001-9")]
    [InlineData("12.345.678/0001-950")]
    [InlineData("12.345.678/0001950")]
    [InlineData("12.345.6780001-950")]
    [InlineData("12.345678/0001-950")]
    [InlineData("12345.678/0001-950")]
    [InlineData("12345.6780001-950")]
    [InlineData("12.345.678/0001.95")]
    [InlineData("12.345.678/0001#95")]
    [InlineData("12.345@678/0001#95")]
    [InlineData("12.345_678/0001#95")]
    [InlineData("123456780001950")]
    [InlineData("1234567800019")]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Should_throw_exception_when_creating_plate_with_invalid_value(string input)
    {
        var act = () =>
        {
            var _ = CNPJ.Create(input);

        };

        act.Should().Throw<InvalidOperationException>();
    }
}