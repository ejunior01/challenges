using ParkingFlow.Domain.Core.Guards;

namespace ParkingFlow.Tests.UnitTests.Domain.Core.Guards;

public class EnsureTests
{
    [Fact]
    public void NotNull_ShouldThrow_WhenNull()
    {
        string value = null;
        var ex = Assert.Throws<ArgumentNullException>(() => value.NotNull());
        Assert.Contains("cannot be null", ex.Message);
    }

    [Fact]
    public void NotEmpty_String_ShouldThrow_WhenEmpty()
    {
        var ex = Assert.Throws<ArgumentException>(() => "".NotEmpty());
        Assert.Contains("cannot be empty", ex.Message);
    }

    [Fact]
    public void NotEmpty_Enumerable_ShouldThrow_WhenNull()
    {
        List<int> list = null;
        var ex = Assert.Throws<ArgumentNullException>(() => list.NotEmpty("List cannot be null", "list"));
        Assert.Contains("List cannot be null", ex.Message);
    }

    [Fact]
    public void NotEmpty_Enumerable_ShouldThrow_WhenEmpty()
    {
        var list = new List<int>();
        var ex = Assert.Throws<ArgumentException>(() => list.NotEmpty("List cannot be empty", "list"));
        Assert.Contains("List cannot be empty", ex.Message);
    }

    [Fact]
    public void NotDefault_Guid_ShouldThrow_WhenEmpty()
    {
        var ex = Assert.Throws<ArgumentException>(() => Guid.Empty.NotDefault());
        Assert.Contains("cannot be empty", ex.Message);
    }

    [Fact]
    public void NotDefault_DateTime_ShouldThrow_WhenDefault()
    {
        var ex = Assert.Throws<ArgumentException>(() => default(DateTime).NotDefault("date"));
        Assert.Contains("cannot be the default DateTime", ex.Message);
    }

    [Fact]
    public void NotDefault_DateOnly_ShouldThrow_WhenDefault()
    {
        var ex = Assert.Throws<ArgumentException>(() => default(DateOnly).NotDefault("date"));
        Assert.Contains("cannot be the default DateOnly", ex.Message);
    }

    [Fact]
    public void NotEqual_ShouldThrow_WhenEqual()
    {
        var date = DateTime.Now;
        var ex = Assert.Throws<ArgumentException>(() => date.NotEqual(date, "date"));
        Assert.Contains("cannot be equal", ex.Message);
    }

    [Fact]
    public void AreEqual_ShouldThrow_WhenEqual()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => 10.AreEqual(10, "Values must not be equal", "value"));
        Assert.Contains("Values must not be equal", ex.Message);
    }

    [Fact]
    public void NotZero_ShouldThrow_WhenZero()
    {
        var ex = Assert.Throws<ArgumentException>(() => 0.NotZero());
        Assert.Contains("cannot be zero", ex.Message);
    }

    [Fact]
    public void GreaterThan_ShouldThrow_WhenLessOrEqual()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => 5.GreaterThan(5));
        Assert.Contains("must be greater than", ex.Message);
    }

    [Fact]
    public void GreaterThanOrEqualsTo_ShouldThrow_WhenLess()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => 4.GreaterThanOrEqualsTo(5));
        Assert.Contains("must be greater than or equals to", ex.Message);
    }

    [Fact]
    public void LessThan_ShouldThrow_WhenGreaterOrEqual()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => 6.LessThan(5));
        Assert.Contains("must be less than", ex.Message);
    }

    [Fact]
    public void LessThanOrEqualsTo_ShouldThrow_WhenGreater()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => 6.LessThanOrEqualsTo(5));
        Assert.Contains("must be less than or equals to", ex.Message);
    }

    [Fact]
    public void MinLength_ShouldThrow_WhenShorter()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => "abc".MinLength(5, "Too short", "text"));
        Assert.Contains("Too short", ex.Message);
    }

    [Fact]
    public void MaxLength_ShouldThrow_WhenLonger()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => "abcdef".MaxLength(5, "Too long", "text"));
        Assert.Contains("Too long", ex.Message);
    }

    [Fact]
    public void HasLength_ShouldThrow_WhenLengthMismatch()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => "abc".HasLength(4, "Wrong length", "text"));
        Assert.Contains("Wrong length", ex.Message);
    }


    [Fact]
    public void NotNull_ShouldReturn_WhenNotNull()
    {
        var result = "hello".NotNull();
        Assert.Equal("hello", result);
    }

    [Fact]
    public void NotEmpty_ShouldReturn_WhenNotEmpty()
    {
        var result = "text".NotEmpty();
        Assert.Equal("text", result);
    }

    [Fact]
    public void NotZero_ShouldReturn_WhenNotZero()
    {
        var result = 5.NotZero();
        Assert.Equal(5, result);
    }
}
