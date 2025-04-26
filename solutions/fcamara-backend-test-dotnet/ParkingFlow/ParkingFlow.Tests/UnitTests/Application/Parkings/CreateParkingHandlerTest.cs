using FluentAssertions;
using Moq;
using ParkingFlow.Domain.Parkings;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Features.Parkings.Commands.Create;
using FluentResults;

namespace ParkingFlow.Tests.UnitTests.Application.Parkings;

public class CreateParkingHandlerTest
{
    [Fact]
    public async Task Should_Result_Success_When_Handler_Creates_Parking_With_Valid_Command()
    {
        // Arrange
        var unitOfWork = new Mock<IUnitOfWork>();
        var parkingRepository = new Mock<IParkingRepository>();

        parkingRepository.Setup(r => r.ExistsParkingByNameAsync(It.IsAny<string>())).ReturnsAsync(false);
        unitOfWork.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var command = new CreateParkingCommand(
            Name: "Estacionamento Central",
            CNPJ: "12.345.678/0001-99",
            Street: "Rua Principal",
            Number: "123",
            District: "Centro",
            City: "São Paulo",
            State: "SP",
            Postcode: "01000-000",
            Phone: "(11) 99999-9999",
            CapacityCar: 50,
            CapacityMotorcycle: 20
        );

        var handler = new CreateParkingHandler(parkingRepository.Object, unitOfWork.Object);

        // Act
        var result = await handler.Handle(command);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Errors.Should().BeEmpty();
        result.Value.Should().NotBeNull();
        result.Value.Name.Should().Be(command.Name);
        result.Value.Street.Should().Be(command.Street);
        result.Value.CapacityCar.Should().Be(command.CapacityCar);

        parkingRepository.Verify(r => r.Add(It.Is<Parking>(p => p.Name == command.Name)), Times.Once());
        unitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task Should_Result_Failed_When_Handler_Creates_Parking_With_Existing_Name()
    {
        // Arrange
        var unitOfWork = new Mock<IUnitOfWork>();
        var parkingRepository = new Mock<IParkingRepository>();

        parkingRepository.Setup(r => r.ExistsParkingByNameAsync(It.IsAny<string>())).ReturnsAsync(true);

        var command = new CreateParkingCommand(
            Name: "Estacionamento Central",
            CNPJ: "12.345.678/0001-99",
            Street: "Rua Principal",
            Number: "123",
            District: "Centro",
            City: "São Paulo",
            State: "SP",
            Postcode: "01000-000",
            Phone: "(11) 99999-9999",
            CapacityCar: 50,
            CapacityMotorcycle: 20
        );

        var handler = new CreateParkingHandler(parkingRepository.Object, unitOfWork.Object);

        // Act
        var result = await handler.Handle(command);

        // Assert
        result.Should().NotBeNull();
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().NotBeEmpty();
        result.Errors.First().Message.Should().Be($"Parkings {command.Name} already exists");

        parkingRepository.Verify(r => r.Add(It.IsAny<Parking>()), Times.Never());
        unitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never());
    }

    [Fact]
    public async Task Should_Result_Failed_When_Handler_Creates_Parking_With_Invalid_CNPJ()
    {
        // Arrange
        var unitOfWork = new Mock<IUnitOfWork>();
        var parkingRepository = new Mock<IParkingRepository>();

        parkingRepository.Setup(r => r.ExistsParkingByNameAsync(It.IsAny<string>())).ReturnsAsync(false);

        var command = new CreateParkingCommand(
            Name: "Estacionamento Central",
            CNPJ: "invalid-cnpj", 
            Street: "Rua Principal",
            Number: "123",
            District: "Centro",
            City: "São Paulo",
            State: "SP",
            Postcode: "01000-000",
            Phone: "(11) 99999-9999",
            CapacityCar: 50,
            CapacityMotorcycle: 20
        );

        var handler = new CreateParkingHandler(parkingRepository.Object, unitOfWork.Object);

        // Act
        var result = await handler.Handle(command);

        // Assert
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().NotBeEmpty();

        parkingRepository.Verify(r => r.Add(It.IsAny<Parking>()), Times.Never());
        unitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never());
    }
}