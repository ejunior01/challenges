﻿using FluentAssertions;
using ParkingFlow.WebApi.Domain.Entities;
using ParkingFlow.WebApi.Domain.Enums;

namespace ParkingFlow.Tests.UnitTests.Domain;

public class VehicleTest
{
    [Fact]
    public void Should_CreateVehicle_When_ValidInput()
    {
       var vehicle = new Vehicle("Fiat","Uno","Preta","AAA-1515",TypeVehicle.Car);
       vehicle.Should().NotBeNull();
    }
    
    [Theory]
    [InlineData("f","Uno","Preta","AAA-1515")]
    [InlineData("Fiat","U","Preta","AAA-1515")]
    [InlineData("Fiat","Uno","P","AAA-1515")]
    [InlineData("Fiat","Uno","Preta","A")]
    public void Should_ThrowException_When_CreatingVehicleWithValuesAreLessThanAcceptable(string brand,string model,string color,string plate)
    {
        var act = () =>
        {
            var _ = new Vehicle(brand, model, color, plate, TypeVehicle.Car);
        };
        
        act.Should().Throw<ArgumentOutOfRangeException>();

    }
    
    [Theory]
    [InlineData(null,"Uno","Preta","AAA-1515")]
    [InlineData("Fiat",null,"Preta","AAA-1515")]
    [InlineData("Fiat","Uno",null,"AAA-1515")]
    [InlineData("Fiat","Uno","Preta",null)]
    [InlineData(" ","Uno","Preta","AAA-1515")]
    [InlineData("Fiat"," ","Preta","AAA-1515")]
    [InlineData("Fiat","Uno"," ","AAA-1515")]
    [InlineData("Fiat","Uno","Preta"," ")]
    [InlineData("","Uno","Preta","AAA-1515")]
    [InlineData("Fiat","","Preta","AAA-1515")]
    [InlineData("Fiat","Uno","","AAA-1515")]
    [InlineData("Fiat","Uno","Preta","")]
    public void Should_ThrowException_When_CreatingVehicleWithValuesAreIsNullOrWhiteSpace(string? brand,string? model,string? color,string? plate)
    {
        var act = () =>
        {
            var _ = new Vehicle(brand, model, color, plate, TypeVehicle.Car);
        };
        
        act.Should().Throw<ArgumentException>();

    }
   
}