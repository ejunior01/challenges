using FluentResults;
using System.Text.RegularExpressions;

namespace ParkingFlow.Domain.Parkings;

public partial class CNPJ
{
    private CNPJ(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<CNPJ> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Fail(new Error("CNPJ cannot be null."));


        if (!CNPJRegex().IsMatch(value.Trim()))
            return Result.Fail(new Error("CNPJ does not match a valid format."));

        value = CNPJNormalizationRegex().Replace(value.Trim(), "");

        return Result.Ok(new CNPJ(value));
    }

    public static implicit operator string(CNPJ cnpj) => cnpj.Value;


    [GeneratedRegex(@"^(\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}|\d{14})$")]
    private static partial Regex CNPJRegex();

    [GeneratedRegex(@"\D")]
    private static partial Regex CNPJNormalizationRegex();

}