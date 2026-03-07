using Xunit;
using StudentApp;

namespace StudentApp.Tests;

public class GradeCalculatorTests
{
    private readonly GradeCalculator calc = new GradeCalculator();

    [Theory]
    [InlineData(95, "A")]
    [InlineData(80, "B")]
    [InlineData(65, "C")]
    [InlineData(40, "F")]
    public void GetGrade_ReturnsExpectedGrade(int score, string expected)
    {
        // Act
        var grade = calc.GetGrade(score);

        // Assert
        Assert.Equal(expected, grade);
    }
}
