using System.Text.RegularExpressions;

namespace ParkingFlow.WebApi.Domain.Parkings;

public partial class CNPJ
{
    private CNPJ(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static CNPJ Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidOperationException();

        if (!CNPJRegex().IsMatch(value.Trim()))
            throw new InvalidOperationException();

        return new CNPJ(value.Trim());
    }

    [GeneratedRegex(@"^(\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}|\d{14})$")]
    private static partial Regex CNPJRegex();
}