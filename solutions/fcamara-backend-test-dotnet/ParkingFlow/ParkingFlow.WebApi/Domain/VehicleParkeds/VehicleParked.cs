using ParkingFlow.WebApi.Common.Contracts;
using ParkingFlow.WebApi.Domain.Parkings;
using ParkingFlow.WebApi.Domain.Vehicles;

namespace ParkingFlow.WebApi.Domain.VehicleParkeds;

public class VehicleParked
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Parking Parking { get; init; }
    public Vehicle Vehicle { get; init; }
    public double Amount { get; private set; }
    public bool IsPaid { get; private set; } = false;
    public bool IsExit { get; private set; } = false;
    public DateTimeOffset EntryOnUtc { get; init; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? ExitdOnUtc { get; private set; } = null;
    public DateTimeOffset? UpdatedOnUt { get; private set; } = null;

    public VehicleParked(Parking parking, Vehicle vehicle)
    {
        Parking = parking;
        Vehicle = vehicle;
    }

    // Extrair posteriomente o calculo de pagamento para um serviço
    public void Payment(double amount) {
        Guard.IsGreaterThanOrEqualTo(amount, 0.01, "O valor de pagamento deve ser maior do que zero.");

        var totalHours = (EntryOnUtc - DateTimeOffset.Now).TotalHours;
        var totalAmout = totalHours * 5.0;
        
        if(totalAmout == amount) {
            IsPaid = true;
        } else {
            throw new InvalidOperationException("O valor de pagamento é diferente do valor devido.");
        }

    }

}
