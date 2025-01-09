using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using ParkingFlow.Tests.Fixtures;
using ParkingFlow.WebApi.Common.Contracts;
using ParkingFlow.WebApi.Domain.Vehicles;
using ParkingFlow.WebApi.Features.Vehicles.CreateVehicle;
using Xunit.Abstractions;

namespace ParkingFlow.Tests.IntegrationTests.Endpoints.Vehicles;

public class DeleteVehicleEndpointTest(FixtureWebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper)
    : IClassFixture<FixtureWebApplicationFactory<Program>>
{

    private readonly HttpClient _httpClient = factory.CreateClient();

    [Fact]
    public async Task Should_return_200_Ok_when_delete_vehicles_With_param_is_valid()
    {
        
        var command = new CreateVehicleCommand("Fiat",
            "Uno",
            "Preta",
            "AAA-1515",
            TypeVehicle.Car);

        await _httpClient.PostAsJsonAsync($"api/v1/{ApiRoutes.Vehicles.Create}", command);
        
        var response = await _httpClient.DeleteAsync($"api/v1/vehicles/{command.Plate}");
        
        response.Should().BeSuccessful();
        response.Should().HaveStatusCode(HttpStatusCode.OK);
    }
    
    [Fact]
    public async Task Should_return_404_NotFound_when_delete_vehicles_With_not_existing_vehicle()
    {
        
        const string plate = "AAA-1515";
        
        var response = await _httpClient.DeleteAsync($"api/v1/vehicles/{plate}");
        
        response.Should().HaveClientError();
        response.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }
    
}