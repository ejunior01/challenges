using System.Numerics;
using System.Runtime.CompilerServices;

namespace ParkingFlow.Domain.Core.Guards;

public static class Ensure
{

    public static T NotNull<T>(this T value, string? message = null, [CallerArgumentExpression(nameof(value))] string argumentName = "")
        where T : class
    {
        message ??= $"The value of '{argumentName}' cannot be null.";

        if (value is null)
            throw new ArgumentNullException(argumentName, message);
        return value;
    }


    public static string NotEmpty(this string value, string? message = null, [CallerArgumentExpression(nameof(value))] string argumentName = "")
    {
        message ??= $"The value of '{argumentName}' cannot be empty.";

        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(message, argumentName);
        return value;
    }

    public static IEnumerable<T> NotEmpty<T>(this IEnumerable<T> value, string message, string argumentName)
    {
        if (value is null)
            throw new ArgumentNullException(argumentName, message);
        var notEmpty = value.ToList();

        if (notEmpty.Count == 0)
            throw new ArgumentException(message, argumentName);

        return notEmpty;
    }

    public static Guid NotDefault(this Guid value, string? message = null, [CallerArgumentExpression(nameof(value))] string argumentName = "")
    {
        message ??= $"The value of '{argumentName}' cannot be empty.";

        if (value == Guid.Empty)
            throw new ArgumentException(message, argumentName);
        return value;
    }

    public static DateTime NotDefault(this DateTime value, string argumentName, string? message = null)
    {
        if (value != default) return value;
        message ??= $"The value of '{argumentName}' cannot be the default DateTime.";
        throw new ArgumentException(message, argumentName);
    }

    public static DateOnly NotDefault(this DateOnly value, string argumentName, string? message = null)
    {
        if (value != default) return value;
        message ??= $"The value of '{argumentName}' cannot be the default DateOnly.";
        throw new ArgumentException(message, argumentName);
    }

    public static DateTime NotEqual(
        this DateTime value,
        DateTime other, string argumentName,
        string? message = null)
    {
        if (value != other) return value;
        message ??= $"The value of '{argumentName}' cannot be equal to '{other}'.";
        throw new ArgumentException(message, argumentName);

    }


    public static T AreEqual<T>(this T value, T other, string message, string argumentName)
        where T : IComparable<T>
    {
        if (value.CompareTo(other) == 0)
            throw new ArgumentOutOfRangeException(argumentName, message);
        return value;
    }


    public static T NotZero<T>(this T value, string? message = null, [CallerArgumentExpression(nameof(value))] string argumentName = "")
        where T : INumber<T>
    {
        message ??= $"The value of '{value}' cannot be zero.";

        if (T.IsZero(value))
            throw new ArgumentException(message, argumentName);
        return value;
    }


    public static T GreaterThan<T>(this T value, T minValue, string? message = null, [CallerArgumentExpression(nameof(value))] string argumentName = "")
        where T : IComparable<T>
    {
        message ??= $"The value ('{value}')  must be greater than {minValue}";

        if (value.CompareTo(minValue) <= 0)
            throw new ArgumentOutOfRangeException(argumentName, message);
        return value;
    }

    public static T GreaterThanOrEqualsTo<T>(this T value, T minValue, string? message = null, [CallerArgumentExpression(nameof(value))] string argumentName = "")
       where T : IComparable<T>
    {
        message ??= $"The value ('{value}')  must be greater than or equals to {minValue}";

        if (value.CompareTo(minValue) < 0)
            throw new ArgumentOutOfRangeException(argumentName, message);
        return value;
    }

    public static T LessThan<T>(this T value, T maxValue, string? message = null, [CallerArgumentExpression(nameof(value))] string argumentName = "")
        where T : IComparable<T>
    {
        message ??= $"The value ('{value}')  must be less than {maxValue}";

        if (value.CompareTo(maxValue) >= 0)
            throw new ArgumentOutOfRangeException(argumentName, message);
        return value;
    }

    public static T LessThanOrEqualsTo<T>(this T value, T maxValue, string? message = null, [CallerArgumentExpression(nameof(value))] string argumentName = "")
      where T : IComparable<T>
    {
        message ??= $"The value ('{value}')  must be less than or equals to {maxValue}";

        if (value.CompareTo(maxValue) > 0)
            throw new ArgumentOutOfRangeException(argumentName, message);
        return value;
    }

    public static string MinLength(this string value, int minLength, string? message = null, [CallerArgumentExpression(nameof(value))] string argumentName = "")
    {
        message ??= $"The value ('{value}') must have a minimum length of {minLength}";

        if (value.Length < minLength)
            throw new ArgumentOutOfRangeException(argumentName, message);
        return value;
    }

    public static string MaxLength(this string value, int maxLength, string? message = null, [CallerArgumentExpression(nameof(value))] string argumentName = "")
    {
        message ??= $"The value ('{value}') must have a maximum  length of {maxLength}";

        if (value.Length > maxLength)
            throw new ArgumentOutOfRangeException(argumentName, message);
        return value;
    }


    public static string HasLength(this string value, int length, string? message = null, [CallerArgumentExpression(nameof(value))] string argumentName = "")
    {
        message ??= $"The value ('{value}') must be exactly length of {length}";

        if (value.Length != length)
            throw new ArgumentOutOfRangeException(argumentName, message);
        return value;
    }
}