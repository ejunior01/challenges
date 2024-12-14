using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using ParkingFlow.Tests.Fixtures;
using ParkingFlow.WebApi.Common.Contracts;
using ParkingFlow.WebApi.Domain.Vehicles;
using ParkingFlow.WebApi.Features.Vehicles.CreateVehicle;

namespace ParkingFlow.Tests.IntegrationTests.Endpoints.Vehicles;

public class CreateVehicleEndpointTest(FixtureWebApplicationFactory<Program> factory)
    : IClassFixture<FixtureWebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient = factory.CreateClient();


    [Fact]
    public async Task Should_return_201_Created_when_post_vehicles_With_body_is_valid()
    {
        var command = new CreateVehicleCommand("Fiat", "Uno", "Preta", "AAA-1515", TypeVehicle.Car);
        var response = await _httpClient.PostAsJsonAsync($"api/v1/{ApiRoutes.Vehicles.Create}", command);
        
        response.Should().BeSuccessful();
        response.Should().HaveStatusCode(HttpStatusCode.Created);
    }
    
}