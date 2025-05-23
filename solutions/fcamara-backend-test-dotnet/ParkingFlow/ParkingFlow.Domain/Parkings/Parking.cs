﻿using ParkingFlow.Domain.Core.Abstracts;
using ParkingFlow.Domain.Core.Guards;

namespace ParkingFlow.Domain.Parkings;

public class Parking : Entity
{
    private Parking() { }

    public string Name { get; private set; }
    public CNPJ CNPJ { get; private set; }
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string District { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Postcode { get; private set; }
    public string Phone { get; private set; }
    public int CapacityCar { get; private set; }
    public int CapacityMotorcycle { get; private set; }

    public Parking(string name, CNPJ cnpj, string street, string number, string district, string city, string state, string postcode, string phone, int capacityCar, int capacityMotorcycle) : base()
    {
        ValidateInputs(name, street, number, district, city, state, postcode, phone, capacityCar, capacityMotorcycle);

        Name = name;
        CNPJ = cnpj;
        Street = street;
        Number = number;
        District = district;
        City = city;
        State = state;
        Postcode = postcode;
        Phone = phone;
        CapacityCar = capacityCar;
        CapacityMotorcycle = capacityMotorcycle;
    }

    public void Update(string name, CNPJ cnpj, string street, string number, string district, string city, string state, string postcode, string phone, int capacityCar, int capacityMotorcycle)
    {
        ValidateInputs(name, street, number, district, city, state, postcode, phone, capacityCar, capacityMotorcycle);

        Name = name;
        CNPJ = cnpj;
        Street = street;
        Number = number;
        District = district;
        City = city;
        State = state;
        Postcode = postcode;
        Phone = phone;
        CapacityCar = capacityCar;
        CapacityMotorcycle = capacityMotorcycle;
    }

    private static void ValidateInputs(string name, string street, string number, string district, string city, string state, string postcode, string phone, int capacityCar, int capacityMotorcycle)
    {
        name.NotEmpty().MinLength(2,argumentName:"name");
        phone.NotEmpty().MinLength(8,argumentName:"phone");
        state.NotEmpty().MinLength(2,argumentName:"state");
        city.NotEmpty().MinLength(2,argumentName:"city");
        district.NotEmpty().MinLength(2,argumentName:"district");
        number.NotEmpty().MaxLength(10,argumentName:"number");
        street.NotEmpty().MinLength(2,argumentName:"street");
        capacityCar.NotZero().GreaterThanOrEqualsTo(1,argumentName:"capacityCar");
        capacityMotorcycle.NotZero().GreaterThanOrEqualsTo(1,argumentName:"capacityMotorcycle");
        postcode.NotEmpty().HasLength(9,argumentName:"postcode");
    }
}