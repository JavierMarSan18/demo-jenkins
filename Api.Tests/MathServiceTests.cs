using Api.Services;

namespace Api.Tests;

public class MathServiceTests
{
    private readonly MathService _mathService;

    public MathServiceTests()
    {
        _mathService = new MathService();
    }

    [Fact]
    public void Add_ShouldReturnSum_WhenGivenTwoNumbers()
    {
        // Arrange
        int a = 5, b = 7;

        // Act
        var result = _mathService.Add(a, b);

        // Assert
        Assert.Equal(12, result);
    }

    [Fact]
    public void Subtract_ShouldReturnDifference_WhenGivenTwoNumbers()
    {
        // Arrange
        int a = 10, b = 4;

        // Act
        var result = _mathService.Subtract(a, b);

        // Assert
        Assert.Equal(6, result);
    }

    [Theory]
    [InlineData(2, true)]
    [InlineData(3, false)]
    [InlineData(10, true)]
    public void IsEven_ShouldIdentifyEvenNumbers(int input, bool expected)
    {
        // Act
        var result = _mathService.IsEven(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Multiply_ShouldReturnProduct_WhenGivenTwoNumbers()
    {
        // Arrange
        int a = 3, b = 4;
        // Act
        var result = _mathService.Multiply(a, b);
        // Assert
        Assert.Equal(12, result);
    }
    [Fact]
    public void Divide_ShouldReturnQuotient_WhenGivenTwoNumbers()
    {
        // Arrange
        int a = 8, b = 2;
        // Act
        var result = _mathService.Divide(a, b);
        // Assert
        Assert.Equal(4, result);
    }
}
