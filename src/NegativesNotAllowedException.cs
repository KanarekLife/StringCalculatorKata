namespace StringCalculatorKata;

public class NegativesNotAllowedException : Exception
{
    public NegativesNotAllowedException(params int[] givenNegatives) : base("Negatives not allowed!")
    {
        NegativeNumbersPassed = givenNegatives;
    }

    public int[] NegativeNumbersPassed { get; }
}