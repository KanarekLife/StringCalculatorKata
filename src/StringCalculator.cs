using System.Text;

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
        var delimiters = new List<string> { ",", "\n" };
        
        if (lines[0].StartsWith("//"))
        {
            var header = lines[0];
            delimiters = new List<string>();
            var openBracket = true;
            var anyBracketOpened = false;
            var delimiterBuilder = new StringBuilder();
            for (var i = 2; i < header.Length; i++)
            {
                switch (header[i])
                {
                    case '[':
                        openBracket = true;
                        anyBracketOpened = true;
                        break;
                    case ']':
                        openBracket = false;
                        delimiters.Add(delimiterBuilder.ToString());
                        delimiterBuilder.Clear();
                        break;
                    default:
                    {
                        if (openBracket)
                        {
                            delimiterBuilder.Append(header[i]);
                        }

                        break;
                    }
                }
            }

            if (!anyBracketOpened)
            {
                delimiters.Add(delimiterBuilder.ToString());
            }
            lines = lines[1..];
        }

        var values = lines
            .Aggregate((a, b) => $"{a}\n{b}")
            .Split(delimiters.ToArray(), StringSplitOptions.TrimEntries)
            .Select(str => Convert.ToInt32(str))
            .ToArray();

        var negativeValues = values.Where(value => value < 0).ToArray();

        if (negativeValues.Length > 0)
        {
            throw new NegativesNotAllowedException(negativeValues);
        }

        return values
            .Where(value => value < 1001)
            .Sum();
    }
}