using FluentAssertions;
using ParkingFlow.Domain.Parkings;

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
    public void Should_Result_Sucess_When_Creating_CNPJ_With_Valid_Input(string input)
    {
        // Arrange & Act
        var cnpj = CNPJ.Create(input);

        // Assert
        cnpj.IsSuccess.Should().BeTrue();
        cnpj.Value.Should().NotBeNull();
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
    public void Should_Result_Failed_When_Creating_CNPJ_With_Invalid_Value(string input)
    {
        // Arrange & Act
        var cnpj = CNPJ.Create(input);

        // Assert
        cnpj.IsFailed.Should().BeTrue();
        cnpj.Errors.Should().HaveCount(1);
    
    }
}