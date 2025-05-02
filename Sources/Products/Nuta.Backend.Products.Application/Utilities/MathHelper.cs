namespace Nuta.Backend.Products.Application.Utilities;

public static class MathHelper
{
    public static double LinearScore(double value, double min, double max, int maxScore)
    {
        if (value >= min && value <= max)
            return maxScore;

        var width = max - min;
        var distance = Math.Min(Math.Abs(value - min), Math.Abs(value - max));
        var score = (1 - distance / width) * maxScore;

        return Math.Max(0, score);
    }
}