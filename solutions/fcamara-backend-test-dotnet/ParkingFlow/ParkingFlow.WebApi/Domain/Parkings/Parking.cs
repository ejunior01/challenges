using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Domain.Parkings;

public class Parking
{
    public Parking(string name, CNPJ cnpj, Address address, string phone, int capacityCar, int capacityMotorcycle)
    {
        
        Guard.IsNotNullOrWhiteSpace(name, nameof(name));
        Guard.IsNotNullOrWhiteSpace(phone, nameof(phone));
        Guard.IsGreaterThanOrEqualTo(capacityCar,1 , nameof(capacityCar));
        Guard.IsGreaterThanOrEqualTo(capacityMotorcycle,1, nameof(capacityMotorcycle));
        
        Name = name;
        CNPJ = cnpj;
        Address = address;
        Phone = phone;
        CapacityCar = capacityCar;
        CapacityMotorcycle = capacityMotorcycle;
    }


    public string Name { get; private set; } 
    public CNPJ CNPJ { get; private set; }
    public Address Address { get; private set; }  
    public string Phone { get; private set; } 
    public int CapacityCar { get; private set; }
    public int CapacityMotorcycle { get; private set; }
    
}