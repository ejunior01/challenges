using FluentAssertions;
using ParkingFlow.Domain.Parkings;
using ParkingFlow.Domain.Vehicles;
using ParkingFlow.Tests.Fixtures;
using ParkingFlow.WebApi.Common.Contracts;
using ParkingFlow.WebApi.Features.Parkings.Commands.Create;
using ParkingFlow.WebApi.Features.Vehicles.Commands.Create;
using System.Net;
using System.Net.Http.Json;

namespace ParkingFlow.Tests.IntegrationTests.Endpoints.Parkings;

public class CreateParkingEndpointTest(FixtureWebApplicationFactory<Program> factory)
    : IClassFixture<FixtureWebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient = factory.CreateClient();

    [Fact]
    public async Task Should_Return_201_Created_When_Post_Parking_With_Body_Is_Valid()
    {
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

        var response = await _httpClient.PostAsJsonAsync($"api/v1/{ApiRoutes.Parkings.Create}", command);

        response.Should().BeSuccessful();
        response.Should().HaveStatusCode(HttpStatusCode.Created);
    }

    [Fact]
    public async Task Should_Return_409_Conflict_When_Post_Create_Parking_With_Exists_Name()
    {

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

        await _httpClient.PostAsJsonAsync($"api/v1/{ApiRoutes.Parkings.Create}", command);

        var response = await _httpClient.PostAsJsonAsync($"api/v1/{ApiRoutes.Parkings.Create}", command);

        response.Should().HaveClientError();
        response.Should().HaveStatusCode(HttpStatusCode.Conflict);
    }

    [Fact]
    public async Task Should_Return_400_BadRequest_When_Post_Parking_With_BodY_Is_Empty()
    {

        var response = await _httpClient.PostAsJsonAsync($"api/v1/{ApiRoutes.Parkings.Create}", "");
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(null,
        "12.345.678/0001-99",
        "Rua Principal",
        "123",
        "Centro",
        "São Paulo",
        "SP",
        "01000-000",
        "(11) 99999-9999",
        20,
        2,
        1)]
    [InlineData("",
        "12.345.678/0001-99",
        "Rua Principal",
        "123",
        "Centro",
        "São Paulo",
        "SP",
        "01000-000",
        "(11) 99999-9999",
        20,
        2,
        2)]
    [InlineData(" ",
        "12.345.678/0001-99",
        "Rua Principal",
        "123",
        "Centro",
        "São Paulo",
        "SP",
        "01000-000",
        "(11) 99999-9999",
        20,
        2,
        2)]
    [InlineData("a",
        "12.345.678/0001-99",
        "Rua Principal",
        "123",
        "Centro",
        "São Paulo",
        "SP",
        "01000-000",
        "(11) 99999-9999",
        20,
        2,
        1)]
    public async Task Should_Return_400_BadRequest_When_Post_Parking_With_Validation_Error(
        string name,
        string cnpj,
        string street,
        string number,
        string district,
        string city,
        string state,
        string postcode,
        string phone,
        int capacityCar,
        int capacityMotorcycle,
        int expectedCountErrors)
    {
        var command = new CreateParkingCommand(
              Name: name,
              CNPJ: cnpj,
              Street: street,
              Number: number,
              District: district,
              City: city,
              State: state,
              Postcode: postcode,
              Phone: phone,
              CapacityCar: capacityCar,
              CapacityMotorcycle: capacityMotorcycle
          );

        var response = await _httpClient.PostAsJsonAsync($"api/v1/{ApiRoutes.Parkings.Create}", command);

        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
        response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");

        var errors = await response.Content.ReadFromJsonAsync<IEnumerable<string>>();
        errors.Should().HaveCount(expectedCountErrors);
    }
}