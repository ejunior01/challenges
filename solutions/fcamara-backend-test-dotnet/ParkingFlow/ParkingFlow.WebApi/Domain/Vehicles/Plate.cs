using System.Text.RegularExpressions;

namespace ParkingFlow.WebApi.Domain.Vehicles;

public partial class Plate
{
    private Plate(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Plate Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidOperationException();

        if (!PlateRegex().IsMatch(value))
            throw new InvalidOperationException();

        return new Plate(value.ToUpper());
    }

    [GeneratedRegex(@"(^[a-zA-z]{3}-\d{4}$)|(^[a-zA-z]{3}\d{1}[a-zA-z]{1}\d{2}$)")]
    private static partial Regex PlateRegex();
}