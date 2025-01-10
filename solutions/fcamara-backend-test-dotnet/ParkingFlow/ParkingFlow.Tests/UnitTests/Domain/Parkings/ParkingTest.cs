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
        var parking = new Parking("Shopping Acme",cnpj,address,"1105150215",15,10);
        
        parking.Should().NotBeNull();
        parking.Name.Should().Be("Shopping Acme");
        
    }
}