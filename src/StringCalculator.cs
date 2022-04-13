namespace StringCalculatorKata;

public class StringCalculator : IStringCalculator
{
    public int Add(string numbers)
    {
        if (numbers == string.Empty)
        {
            return 0;
        }

        return numbers
            .Split(',')
            .Select(str => Convert.ToInt32(str))
            .Sum();
    }
}