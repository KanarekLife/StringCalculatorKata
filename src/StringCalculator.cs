namespace StringCalculatorKata;

public class StringCalculator : IStringCalculator
{
    public int Add(string numbers)
    {
        if (numbers == string.Empty)
        {
            return 0;
        }

        var lines = numbers.Split('\n');
        var delimiters = new [] { ",", "\n" };
        
        if (lines[0].StartsWith("//"))
        {
            delimiters = new[] { lines[0][2..] };
            lines = lines[1..];
        }

        return lines
            .Aggregate((a,b) => $"{a}\n{b}")
            .Split(delimiters, StringSplitOptions.TrimEntries)
            .Select(str => Convert.ToInt32(str))
            .Sum();
    }
}