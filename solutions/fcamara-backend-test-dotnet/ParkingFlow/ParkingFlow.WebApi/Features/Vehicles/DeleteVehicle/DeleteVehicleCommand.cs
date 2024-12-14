﻿using FluentResults;
using MediatR;
using ParkingFlow.WebApi.Common.Abstracts;

namespace ParkingFlow.WebApi.Features.Vehicles.DeleteVehicle;

public record DeleteVehicleCommand(
    string Plate
) : ICommand<Result>;