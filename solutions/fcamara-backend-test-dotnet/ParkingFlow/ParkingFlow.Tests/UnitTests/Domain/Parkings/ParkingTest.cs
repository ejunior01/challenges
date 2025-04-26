using FluentAssertions;
using ParkingFlow.Domain.Parkings;

namespace ParkingFlow.Tests.UnitTests.Domain.Parkings;

public class ParkingTest
{
    [Fact]
    public void Should_Sucess_When_Creating_Parking_With_Valid_Input()
    {
        // Arrange
        var cnpj = CNPJ.Create("12.345.678/0001-95");

        // Act
        var parking = new Parking("Shopping Acme",
                                  cnpj.Value,
                                  "R. dos Estudantes",
                                  "37",
                                  "Liberdade",
                                  "São Paulo",
                                  "SP",
                                  "01505-000",
                                  "1105150215",
                                  15,
                                  10);

        // Assert
        parking.Should().NotBeNull();
        parking.Name.Should().Be("Shopping Acme");
        parking.CNPJ.Value.Should().Be("12345678000195");

    }


    [Theory]
    [InlineData(null, typeof(ArgumentException))]
    [InlineData("", typeof(ArgumentException))]
    [InlineData(" ", typeof(ArgumentException))]
    [InlineData("a", typeof(ArgumentOutOfRangeException))]
    public void Should_Throw_Exception_When_Creating_Parking_With_Invalid_Name(
        string name,
        Type exceptionType
        )
    {
        // Arrange
        var cnpj = CNPJ.Create("12.345.678/0001-95");

        // Act
        var act = () =>
        {
            var _ = new Parking(name,
                                  cnpj.Value,
                                  "R. dos Estudantes",
                                  "37",
                                  "Liberdade",
                                  "São Paulo",
                                  "SP",
                                  "01505-000",
                                  "1105150215",
                                  15,
                                  10);

        };

        // Assert
        act.Should().Throw<Exception>().Which.Should().BeOfType(exceptionType);
    }

    [Theory]
    [InlineData(null, typeof(ArgumentException))]
    [InlineData("", typeof(ArgumentException))]
    [InlineData(" ", typeof(ArgumentException))]
    [InlineData("a", typeof(ArgumentOutOfRangeException))]
    public void Should_Throw_Exception_When_Creating_Parking_With_Invalid_Street(
    string street,
    Type exceptionType
    )
    {
        // Arrange
        var cnpj = CNPJ.Create("12.345.678/0001-95");

        // Act
        var act = () =>
        {
            var _ = new Parking("Shopping Acme",
                                  cnpj.Value,
                                  street,
                                  "37",
                                  "Liberdade",
                                  "São Paulo",
                                  "SP",
                                  "01505-000",
                                  "1105150215",
                                  15,
                                  10);

        };

        // Assert
        act.Should().Throw<Exception>().Which.Should().BeOfType(exceptionType);
    }

    [Theory]
    [InlineData(null, typeof(ArgumentException))]
    [InlineData("", typeof(ArgumentException))]
    [InlineData(" ", typeof(ArgumentException))]
    public void Should_Throw_Exception_When_Creating_Parking_With_Invalid_Number(
    string number,
    Type exceptionType
    )
    {
        // Arrange
        var cnpj = CNPJ.Create("12.345.678/0001-95");

        // Act
        var act = () =>
        {
            var _ = new Parking("Shopping Acme",
                                  cnpj.Value,
                                  "R. dos Estudantes",
                                  number,
                                  "Liberdade",
                                  "São Paulo",
                                  "SP",
                                  "01505-000",
                                  "1105150215",
                                  15,
                                  10);

        };

        // Assert
        act.Should().Throw<Exception>().Which.Should().BeOfType(exceptionType);
    }

    [Theory]
    [InlineData(null, typeof(ArgumentException))]
    [InlineData("", typeof(ArgumentException))]
    [InlineData(" ", typeof(ArgumentException))]
    [InlineData("a", typeof(ArgumentOutOfRangeException))]
    public void Should_Throw_Exception_When_Creating_Parking_With_Invalid_District(
        string district,
        Type exceptionType
        )
    {
        // Arrange
        var cnpj = CNPJ.Create("12.345.678/0001-95");

        // Act
        var act = () =>
        {
            var _ = new Parking("Shopping Acme",
                                  cnpj.Value,
                                  "R. dos Estudantes",
                                  "2a",
                                  district,
                                  "São Paulo",
                                  "SP",
                                  "01505-000",
                                  "1105150215",
                                  15,
                                  10);

        };

        // Assert
        act.Should().Throw<Exception>().Which.Should().BeOfType(exceptionType);
    }

    [Theory]
    [InlineData(null, typeof(ArgumentException))]
    [InlineData("", typeof(ArgumentException))]
    [InlineData(" ", typeof(ArgumentException))]
    [InlineData("a", typeof(ArgumentOutOfRangeException))]
    public void Should_Throw_Exception_When_Creating_Parking_With_Invalid_City(
     string city,
     Type exceptionType
     )
    {
        // Arrange
        var cnpj = CNPJ.Create("12.345.678/0001-95");

        // Act
        var act = () =>
        {
            var _ = new Parking("Shopping Acme",
                                  cnpj.Value,
                                  "R. dos Estudantes",
                                  "2a",
                                  "Liberdade",
                                  city,
                                  "SP",
                                  "01505-000",
                                  "1105150215",
                                  15,
                                  10);

        };

        // Assert
        act.Should().Throw<Exception>().Which.Should().BeOfType(exceptionType);
    }

    [Theory]
    [InlineData(null, typeof(ArgumentException))]
    [InlineData("", typeof(ArgumentException))]
    [InlineData(" ", typeof(ArgumentException))]
    [InlineData("a", typeof(ArgumentOutOfRangeException))]
    public void Should_Throw_Exception_When_Creating_Parking_With_Invalid_State(
       string state,
       Type exceptionType
       )
    {
        // Arrange
        var cnpj = CNPJ.Create("12.345.678/0001-95");

        // Act
        var act = () =>
        {
            var _ = new Parking("Shopping Acme",
                                  cnpj.Value,
                                  "R. dos Estudantes",
                                  "2a",
                                  "Liberdade",
                                 "São Paulo",
                                  state,
                                  "01505-000",
                                  "1105150215",
                                  15,
                                  10);

        };

        // Assert
        act.Should().Throw<Exception>().Which.Should().BeOfType(exceptionType);
    }

    [Theory]
    [InlineData(null, typeof(ArgumentException))]
    [InlineData("", typeof(ArgumentException))]
    [InlineData(" ", typeof(ArgumentException))]
    [InlineData("0448416", typeof(ArgumentOutOfRangeException))]
    [InlineData("0447416900", typeof(ArgumentOutOfRangeException))]
    public void Should_Throw_Exception_When_Creating_Parking_With_Invalid_Postcode(
      string postcode,
      Type exceptionType
      )
    {
        // Arrange
        var cnpj = CNPJ.Create("12.345.678/0001-95");

        // Act
        var act = () =>
        {
            var _ = new Parking("Shopping Acme",
                                  cnpj.Value,
                                  "R. dos Estudantes",
                                  "2a",
                                  "Liberdade",
                                 "São Paulo",
                                   "SP",
                                  postcode,
                                  "1105150215",
                                  15,
                                  10);

        };

        // Assert
        act.Should().Throw<Exception>().Which.Should().BeOfType(exceptionType);
    }

    [Theory]
    [InlineData(null, typeof(ArgumentException))]
    [InlineData("", typeof(ArgumentException))]
    [InlineData(" ", typeof(ArgumentException))]
    [InlineData("0448416", typeof(ArgumentOutOfRangeException))]
    public void Should_Throw_Exception_When_Creating_Parking_With_Invalid_Phone(
      string phone,
      Type exceptionType
      )
    {
        // Arrange
        var cnpj = CNPJ.Create("12.345.678/0001-95");

        // Act
        var act = () =>
        {
            var _ = new Parking("Shopping Acme",
                                  cnpj.Value,
                                  "R. dos Estudantes",
                                  "2a",
                                  "Liberdade",
                                 "São Paulo",
                                   "SP",
                                  "01505-000",
                                  phone,
                                  15,
                                  10);

        };

        // Assert
        act.Should().Throw<Exception>().Which.Should().BeOfType(exceptionType);
    }

    [Theory]
    [InlineData(0, typeof(ArgumentException))]
    [InlineData(-1, typeof(ArgumentOutOfRangeException))]
    [InlineData(int.MinValue, typeof(ArgumentOutOfRangeException))]
    public void Should_Throw_Exception_When_Creating_Parking_With_Invalid_CapacityCar(
    int capacityCar,
    Type exceptionType
    )
    {
        // Arrange
        var cnpj = CNPJ.Create("12.345.678/0001-95");

        // Act
        var act = () =>
        {
            var _ = new Parking("Shopping Acme",
                                  cnpj.Value,
                                  "R. dos Estudantes",
                                  "2a",
                                  "Liberdade",
                                 "São Paulo",
                                   "SP",
                                  "01505-000",
                                  "1105150215",
                                  capacityCar,
                                  10);

        };

        // Assert
        act.Should().Throw<Exception>().Which.Should().BeOfType(exceptionType);
    }

    [Theory]
    [InlineData(0, typeof(ArgumentException))]
    [InlineData(-1, typeof(ArgumentOutOfRangeException))]
    [InlineData(int.MinValue, typeof(ArgumentOutOfRangeException))]
    public void Should_Throw_Exception_When_Creating_Parking_With_Invalid_CapacityMotorcycle(
       int capacityMotorcycle,
       Type exceptionType
       )
    {
        // Arrange
        var cnpj = CNPJ.Create("12.345.678/0001-95");

        // Act
        var act = () =>
        {
            var _ = new Parking("Shopping Acme",
                                  cnpj.Value,
                                  "R. dos Estudantes",
                                  "2a",
                                  "Liberdade",
                                 "São Paulo",
                                   "SP",
                                  "01505-000",
                                  "1105150215",
                                  10,
                                  capacityMotorcycle);

        };

        // Assert
        act.Should().Throw<Exception>().Which.Should().BeOfType(exceptionType);
    }
}