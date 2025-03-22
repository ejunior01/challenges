using FluentAssertions;
using ParkingFlow.Tests.Fixtures;
using ParkingFlow.WebApi.Common.Contracts;
using ParkingFlow.WebApi.Domain.Vehicles;
using ParkingFlow.WebApi.Features.Vehicles.Commands.Create;
using System.Net;
using System.Net.Http.Json;

namespace ParkingFlow.Tests.IntegrationTests.Endpoints.Vehicles;

public class CreateVehicleEndpointTest(FixtureWebApplicationFactory<Program> factory)
    : IClassFixture<FixtureWebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient = factory.CreateClient();

    [Fact]
    public async Task Should_return_201_Created_when_post_vehicles_With_body_is_valid()
    {
        var command = new CreateVehicleCommand("Fiat",
            "Uno",
            "Preta",
            "AAA-1515",
            TypeVehicle.Car);

        var response = await _httpClient.PostAsJsonAsync($"api/v1/{ApiRoutes.Vehicles.Create}", command);

        response.Should().BeSuccessful();
        response.Should().HaveStatusCode(HttpStatusCode.Created);
    }

    [Fact]
    public async Task Should_return_409_Conflict_when_post_create_vehicle_with_exists_plate()
    {

        var command = new CreateVehicleCommand("Fiat",
            "Uno",
            "Preta",
            "AAA-1515",
            TypeVehicle.Car);

        await _httpClient.PostAsJsonAsync($"api/v1/{ApiRoutes.Vehicles.Create}", command);

        var response = await _httpClient.PostAsJsonAsync($"api/v1/{ApiRoutes.Vehicles.Create}", command);

        response.Should().HaveClientError();
        response.Should().HaveStatusCode(HttpStatusCode.Conflict);
    }

    [Fact]
    public async Task Should_return_400_BadRequest_when_post_vehicles_With_body_is_invalid()
    {

        var response = await _httpClient.PostAsJsonAsync($"api/v1/{ApiRoutes.Vehicles.Create}", "");
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData("", "", "", "", TypeVehicle.Car, 8)]
    [InlineData("F", "f", "f", "f", TypeVehicle.Car, 4)]
    [InlineData("F", "Uno", "Preta", "AAA-1515", TypeVehicle.Car, 1)]
    [InlineData("Fiat", "U", "Preta", "AAA-1515", TypeVehicle.Car, 1)]
    [InlineData("Fiat", "Uno", "P", "AAA-1515", TypeVehicle.Car, 1)]
    [InlineData("Fiat", "Uno", "Preta", "AAA", TypeVehicle.Car, 1)]
    [InlineData("Fiat", "Uno", "Preta", "AAA-1515", null, 2)]
    [InlineData(
        "fffffffffffffffffffffffffffffffffffffffffffffffffff",
        "Uno",
        "Preta",
        "AAA-1515",
        TypeVehicle.Car,
        1)]
    [InlineData(
        "Fiat",
        "fffffffffffffffffffffffffffffffffffffffffffffffffff",
        "Preta",
        "AAA-1515",
        TypeVehicle.Car,
        1)]
    [InlineData(
        "Fiat",
        "Uno",
        "fffffffffffffffffffffffffffffffffffffffffffffffffff",
        "AAA-1515",
        TypeVehicle.Car,
        1)]
    [InlineData(" ", "Uno", "Preta", "AAA-1515", TypeVehicle.Car, 2)]
    [InlineData("Fiat", " ", "Preta", "AAA-1515", TypeVehicle.Car, 2)]
    [InlineData("Fiat", "Uno", " ", "AAA-1515", TypeVehicle.Car, 2)]
    [InlineData("Fiat", "Uno", "Preta", " ", TypeVehicle.Car, 2)]
    [InlineData("", "Uno", "Preta", "AAA-1515", TypeVehicle.Car, 2)]
    [InlineData("Fiat", "", "Preta", "AAA-1515", TypeVehicle.Car, 2)]
    [InlineData("Fiat", "Uno", "", "AAA-1515", TypeVehicle.Car, 2)]
    [InlineData("Fiat", "Uno", "Preta", "", TypeVehicle.Car, 2)]
    [InlineData(null, "Uno", "Preta", "AAA-1515", TypeVehicle.Car, 2)]
    [InlineData("Fiat", null, "Preta", "AAA-1515", TypeVehicle.Car, 2)]
    [InlineData("Fiat", "Uno", null, "AAA-1515", TypeVehicle.Car, 2)]
    [InlineData("Fiat", "Uno", "Preta", null, TypeVehicle.Car, 2)]
    public async Task Should_return_400_BadRequest_when_post_vehicles_With_validation_error(
        string brand,
        string model,
        string color,
        string plate,
        TypeVehicle type,
        int expectedCountErrors)
    {
        var command = new CreateVehicleCommand(brand, model, color, plate, type);
        var response = await _httpClient.PostAsJsonAsync($"api/v1/{ApiRoutes.Vehicles.Create}", command);

        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
        response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");

        var errors = await response.Content.ReadFromJsonAsync<IEnumerable<string>>();
        errors.Should().HaveCount(expectedCountErrors);
    }
}