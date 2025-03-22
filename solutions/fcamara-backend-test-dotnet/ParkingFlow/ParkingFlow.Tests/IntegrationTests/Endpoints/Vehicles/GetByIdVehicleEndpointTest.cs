using FluentAssertions;
using ParkingFlow.Tests.Fixtures;
using ParkingFlow.WebApi.Common.Contracts;
using ParkingFlow.WebApi.Domain.Vehicles;
using System.Net;
using System.Net.Http.Json;
using ParkingFlow.WebApi.Features.Vehicles.Commands.Create;

namespace ParkingFlow.Tests.IntegrationTests.Endpoints.Vehicles;

public class GetByIdVehicleEndpointTest(
    FixtureWebApplicationFactory<Program> factory)
    : IClassFixture<FixtureWebApplicationFactory<Program>>
{

    private readonly HttpClient _httpClient = factory.CreateClient();

    [Fact]
    public async Task Should_return_200_Ok_when_get_vehicle_With_plate_exist()
    {

        var plate = "AAA-1515";
        var command = new CreateVehicleCommand("Fiat",
            "Uno",
            "Preta",
            plate,
            TypeVehicle.Car);

        await _httpClient.PostAsJsonAsync($"api/v1/{ApiRoutes.Vehicles.Create}", command);

        var response = await _httpClient.GetAsync($"api/v1/vehicles/{plate}");

        response.Should().BeSuccessful();
        response.Should().HaveStatusCode(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Should_return_404_NotFound_when_get_vehicle_With_not_existing_plate()
    {

        const string plate = "AAA-1516";

        var response = await _httpClient.GetAsync($"api/v1/vehicles/{plate}");

        response.Should().HaveClientError();
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

}