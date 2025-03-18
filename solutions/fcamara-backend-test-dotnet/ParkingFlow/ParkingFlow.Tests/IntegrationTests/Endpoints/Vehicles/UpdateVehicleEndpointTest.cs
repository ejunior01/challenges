using FluentAssertions;
using ParkingFlow.Tests.Fixtures;
using ParkingFlow.WebApi.Common.Contracts;
using ParkingFlow.WebApi.Domain.Vehicles;
using System.Net;
using System.Net.Http.Json;
using ParkingFlow.WebApi.Features.Vehicles.Commands.Update;

namespace ParkingFlow.Tests.IntegrationTests.Endpoints.Vehicles;

public class UpdateVehicleEndpointTest(FixtureWebApplicationFactory<Program> factory)
    : IClassFixture<FixtureWebApplicationFactory<Program>>
{

    private readonly HttpClient _httpClient = factory.CreateClient();


    [Fact]
    public async Task Should_return_200_Ok_when_update_vehicles_With_param_is_valid()
    {

        var command = new UpdateVehicleRequest(
            "Fiat",
            "Uno",
            "Preta",
            "AAA-1515",
            TypeVehicle.Car);

        const string plate = "AAA-1515";

        await _httpClient.PostAsJsonAsync($"api/v1/{ApiRoutes.Vehicles.Create}", command);
        var response = await _httpClient.PutAsJsonAsync($"api/v1/vehicles/{plate}", command);

        response.Should().BeSuccessful();
        response.Should().HaveStatusCode(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Should_return_404_NotFound_when_update_vehicles_not_exists()
    {

        var command = new UpdateVehicleRequest("Fiat",
            "Uno",
            "Preta",
            "AAA-1515",
            TypeVehicle.Car);

        const string plate = "AAA-1515";

        var response = await _httpClient.PutAsJsonAsync($"api/v1/vehicles/{plate}", command);

        response.Should().HaveClientError();
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }
}