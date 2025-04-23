using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Domain.Parkings;

public class Parking: Entity
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

    public Parking(string name, CNPJ cnpj, string street, string number, string district, string city, string state, string postcode, string phone, int capacityCar, int capacityMotorcycle): base()
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
        ValidateInputs(name,  street,  number,  district,  city,  state, postcode, phone, capacityCar, capacityMotorcycle);

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
        Guard.IsNotNullOrWhiteSpace(name, nameof(name));
        Guard.IsNotNullOrWhiteSpace(phone, nameof(phone));
        Guard.IsGreaterThanOrEqualTo(capacityCar, 1, nameof(capacityCar));
        Guard.IsGreaterThanOrEqualTo(capacityMotorcycle, 1, nameof(capacityMotorcycle));
        Guard.IsNotNullOrWhiteSpace(street, nameof(street));
        Guard.IsNotNullOrWhiteSpace(number, nameof(number));
        Guard.IsNotNullOrWhiteSpace(district, nameof(district));
        Guard.IsNotNullOrWhiteSpace(city, nameof(city));
        Guard.IsNotNullOrWhiteSpace(state, nameof(state));
    }
}