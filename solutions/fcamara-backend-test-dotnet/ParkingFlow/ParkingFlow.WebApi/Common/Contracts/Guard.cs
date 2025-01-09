namespace ParkingFlow.WebApi.Common.Contracts;

public static class Guard
{
    public static void IsNotNullOrWhiteSpace(string? text, string name)
    {
        ArgumentNullException.ThrowIfNull(text, nameof(text));
    }

    public static void IsGreaterThanOrEqualTo(int value, int minimum, string name)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, minimum);
    }
}