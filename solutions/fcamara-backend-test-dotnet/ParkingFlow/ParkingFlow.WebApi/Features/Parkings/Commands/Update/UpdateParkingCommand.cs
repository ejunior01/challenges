using FluentResults;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Parkings;

namespace ParkingFlow.WebApi.Features.Parkings.Commands.Update;

public record UpdateParkingCommand(
    Guid Id,
    string Name,
    string CNPJ,
    string Street,
    string Number,
    string District,
    string City,
    string State,
    string Postcode,
    string Phone,
    int CapacityCar,
    int CapacityMotorcycle
) : ICommand<Result<Parking>>;