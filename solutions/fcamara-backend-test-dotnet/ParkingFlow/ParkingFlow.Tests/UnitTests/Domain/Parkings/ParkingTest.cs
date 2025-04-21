using FluentAssertions;
using ParkingFlow.WebApi.Domain.Parkings;

namespace ParkingFlow.Tests.UnitTests.Domain.Parkings;

public class ParkingTest
{
    [Fact]
    public void Should_create_parking_when_valid_input()
    {
        var cnpj = CNPJ.Create("12.345.678/0001-95");
        var address = Address.Create("R. dos Estudantes", "37", "Liberdade", "São Paulo", "SP", "01505-000");
        var parking = new Parking("Shopping Acme", cnpj, address, "1105150215", 15, 10);

        parking.Should().NotBeNull();
        parking.Name.Should().Be("Shopping Acme");

    }

    [Theory]
    [InlineData("Shopping Acme", "1105150215", 15, 0, typeof(ArgumentOutOfRangeException))]
    [InlineData("Shopping Acme", "1105150215", 0, 10, typeof(ArgumentOutOfRangeException))]
    [InlineData(null, "1105150215", 15, 2, typeof(ArgumentNullException))]
    public void Should_throw_exception_when_creating_parking_with_invalid_values(string name, string phone, int capacityCar, int capacityMotorcycle, Type  exceptionType)
    {

        var cnpj = CNPJ.Create("12.345.678/0001-95");
        var address = Address.Create("R. dos Estudantes", "37", "Liberdade", "São Paulo", "SP", "01505-000");

        var act = () =>
        {
            var _ = new Parking(name, cnpj, address, phone, capacityCar, capacityMotorcycle);

        };

        act.Should().Throw<Exception>().Which.Should().BeOfType(exceptionType);
    }
}