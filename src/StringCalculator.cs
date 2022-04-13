using System.Text;

namespace StringCalculatorKata;

public class StringCalculator : IStringCalculator
{
    private string[] GetDelimiters(string numbers, out int pos)
    {
        if (numbers.StartsWith("//"))
        {
            var delimiters = new List<string>();
            var anyBracketOpened = false;
            var currentDelimiter = new StringBuilder();
            for (var i = 2; i < numbers.Length; i++)
            {
                var cur = numbers[i];
                switch (cur)
                {
                    case '\n':
                    {
                        pos = i+1;
                        if (!anyBracketOpened)
                        {
                            return new[] { currentDelimiter.ToString() };
                        }
                        return delimiters.ToArray();
                    }
                    case '[':
                        anyBracketOpened = true;
                        break;
                    case ']':
                        delimiters.Add(currentDelimiter.ToString());
                        currentDelimiter.Clear();
                        break;
                    default:
                        currentDelimiter.Append(cur);
                        break;
                }
            }

            throw new Exception("Delimiter header should be ended with a newline symbol");
        }

        pos = 0;
        return new [] {",","\n"};
    }
    public int Add(string numbers)
    {
        if (numbers == string.Empty)
        {
            return 0;
        }
        
        var delimiters = GetDelimiters(numbers, out int pos);

        var values = numbers[pos..]
            .Split(delimiters.ToArray(), StringSplitOptions.TrimEntries)
            .Select(str => Convert.ToInt32(str))
            .Where(value => value < 1001)
            .ToArray();

        var negativeValues = values.Where(value => value < 0).ToArray();

        if (negativeValues.Length > 0)
        {
            throw new NegativesNotAllowedException(negativeValues);
        }

        return values
            .Sum();
    }
}