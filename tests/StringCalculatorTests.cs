using Xunit;

namespace StringCalculatorKata.Tests;

public class StringCalculatorTests
{
    private readonly IStringCalculator _calculator;

    public StringCalculatorTests()
    {
        _calculator = new StringCalculator();
    }

    [Fact]
    public void Should_Return0ForEmptyString()
    {
        const string input = "";
        const int expected = 0;

        var actual = _calculator.Add(input);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Should_ReturnIfGivenSingleNumber()
    {
        const string input = "1";
        const int expected = 1;

        var actual = _calculator.Add(input);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Should_ReturnSumOfTwoNumbersSeparatedByComma()
    {
        const string input = "1,2";
        const int expected = 3;

        var actual = _calculator.Add(input);
        
        Assert.Equal(expected, actual);
    }
}