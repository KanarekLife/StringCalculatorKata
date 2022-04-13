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

    [Fact]
    public void Should_ReturnSumOfMoreNumbersSeparatedByComma()
    {
        const string input = "1,2,3,4,5,6";
        const int expected = 21;

        var actual = _calculator.Add(input);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Should_ReturnSumOfNumbersSeparatedByNewLineOrComma()
    {
        const string input = "1\n2,3";
        const int expected = 6;

        var actual = _calculator.Add(input);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Should_AllowToChangeDelimiter()
    {
        const string input = "//;\n1;2";
        const int expected = 3;

        var actual = _calculator.Add(input);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Should_ThrowError_WhenSingleNegativeNumberIsPassed()
    {
        const string input = "-5, 10";

        Assert.Throws<NegativesNotAllowedException>(() => _calculator.Add(input));
        
        try
        {
            _calculator.Add(input);
        }
        catch (NegativesNotAllowedException exception)
        {
            Assert.Equal(new [] {-5}, exception.NegativeNumbersPassed);
        }
    }

    [Fact]
    public void Should_ThrowError_WhenMultipleNegativeNumbersArePassed()
    {
        const string input = "-5,-10,-20";

        Assert.Throws<NegativesNotAllowedException>(() => _calculator.Add(input));

        try
        {
            _calculator.Add(input);
        }
        catch (NegativesNotAllowedException exception)
        {
            Assert.Equal(new [] {-5, -10, -20}, exception.NegativeNumbersPassed);
        }
    }

    [Fact]
    public void Should_IgnoreNumbersBiggerThan1000()
    {
        const string input = "2,1001";
        const int expected = 2;

        var actual = _calculator.Add(input);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Should_AcceptDelimitersWithAnyLength()
    {
        const string input = "//[***]\n1***2***3";
        const int expected = 6;

        var actual = _calculator.Add(input);
        
        Assert.Equal(expected, actual);
    }
}