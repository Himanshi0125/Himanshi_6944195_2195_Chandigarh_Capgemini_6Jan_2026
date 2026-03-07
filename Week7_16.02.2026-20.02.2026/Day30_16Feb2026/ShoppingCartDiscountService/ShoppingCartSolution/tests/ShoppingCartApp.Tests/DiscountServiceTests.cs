using Xunit;
using ShoppingCartApp;

namespace ShoppingCartApp.Tests;

public class DiscountServiceTests
{
    private readonly DiscountService service = new DiscountService();

    [Theory]
    [InlineData(120, 108)] // 10% discount
    [InlineData(60, 57)]   // 5% discount
    [InlineData(30, 30)]   // no discount
    public void ApplyDiscount_ReturnsExpectedTotal(decimal total, decimal expected)
    {
        // Act
        var result = service.ApplyDiscount(total);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ApplyDiscount_ZeroTotal_ReturnsZero()
    {
        decimal total = 0;

        var result = service.ApplyDiscount(total);

        Assert.Equal(0, result);
    }
}
