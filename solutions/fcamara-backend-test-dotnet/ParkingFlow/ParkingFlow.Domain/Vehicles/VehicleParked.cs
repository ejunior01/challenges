using ParkingFlow.Domain.Core.Guards;
using ParkingFlow.Domain.Parkings;

namespace ParkingFlow.Domain.Vehicles;

public class VehicleParked(Parking parking, Vehicle vehicle)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Parking Parking { get; init; } = parking;
    public Vehicle Vehicle { get; init; } = vehicle;
    public double Amount { get; private set; }
    public bool IsPaid { get; private set; } = false;
    public bool IsExit { get; private set; } = false;
    public DateTimeOffset EntryOnUtc { get; init; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? ExitdOnUtc { get; private set; } = null;
    public DateTimeOffset? UpdatedOnUt { get; private set; } = null;

    // Extrair posteriomente o calculo de pagamento para um serviço
    public void Payment(double amount)
    {
        amount.GreaterThanOrEqualsTo(0.01, "O valor de pagamento deve ser maior do que zero.");

        var totalHours = (EntryOnUtc - DateTimeOffset.Now).TotalHours;
        var totalAmout = totalHours * 5.0;

        if (totalAmout == amount)
        {
            IsPaid = true;
            Amount = amount;
            UpdatedOnUt = DateTimeOffset.UtcNow;
        }
        else
        {
            throw new InvalidOperationException("O valor de pagamento é diferente do valor devido.");
        }

    }

    public void Exit()
    {

        if (IsExit)
        {
            throw new InvalidOperationException("Veículo já saiu do estacionamento.");
        }

        if (!IsPaid)
        {
            throw new InvalidOperationException("Veículo não pagou o estacionamento.");
        }

        IsExit = true;
        ExitdOnUtc = DateTimeOffset.UtcNow;
    }
}
