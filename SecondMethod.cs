using System;

class SecondMethod
{
    public static void SecondMethodOutput(int numSamples, double alpha, double beta)
    {
        var rand = new Random();

        double[] betaSamples = new double[numSamples];

        for (int i = 0; i < numSamples; i++)
        {
            betaSamples[i] = BetaAcceptReject(alpha, beta, rand);
        }

        double mean = CalculateMean(betaSamples);
        double variance = CalculateVariance(betaSamples, mean);

        Console.WriteLine($"Media estimată: {mean}");
        Console.WriteLine($"Dispersia estimată: {variance}");
    }

    static double BetaAcceptReject(double alpha, double beta, Random rand)
    {
        while (true)
        {
            double U1 = rand.NextDouble();
            double U2 = rand.NextDouble();
            double X = Math.Pow(U1, 1.0 / alpha);
            double Y = Math.Pow(U2, 1.0 / beta);

            if (X + Y <= 1)
            {
                return X / (X + Y);
            }
        }
    }

    static double CalculateMean(double[] samples)
    {
        double sum = 0.0;
        foreach (var sample in samples)
        {
            sum += sample;
        }
        return sum / samples.Length;
    }

    static double CalculateVariance(double[] samples, double mean)
    {
        double sum = 0.0;
        foreach (var sample in samples)
        {
            sum += Math.Pow(sample - mean, 2);
        }
        return sum / samples.Length;
    }
}