using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Domain.Parkings;

public class Address
{
    public Address(string street, string number, string district, string city, string state, string postcode)
    {
        Street = street;
        Number = number;
        District = district;
        City = city;
        State = state;
        Postcode = postcode;
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string District { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Postcode { get; private set; }

    public static Address Create(string street, string number, string district, string city, string state, string postcode)
    {
        Guard.IsNotNullOrWhiteSpace(street, nameof(street));
        Guard.IsNotNullOrWhiteSpace(number, nameof(number));
        Guard.IsNotNullOrWhiteSpace(district, nameof(district));
        Guard.IsNotNullOrWhiteSpace(city, nameof(city));
        Guard.IsNotNullOrWhiteSpace(state, nameof(state));
        return new Address(street, number, district, city, state, postcode);
    }

}