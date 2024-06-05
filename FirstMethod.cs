class FirstMethod
{
    public static void FirstMethodOutput(int numSamples, double alpha, double beta)
    {
        var rand = new Random();

        double[] betaSamples = new double[numSamples];

        for (int i = 0; i < numSamples; i++)
        {
            betaSamples[i] = BetaSampleGamma(alpha, beta, rand);
        }

        double mean = CalculateMean(betaSamples);
        double variance = CalculateVariance(betaSamples, mean);

        Console.WriteLine($"Media estimată: {mean}");
        Console.WriteLine($"Dispersia estimată: {variance}");
    }

    static double BetaSampleGamma(double alpha, double beta, Random rand)
    {
        double X = GammaSample(alpha, rand);
        double Y = GammaSample(beta, rand);
        return X / (X + Y);
    }

    static double GammaSample(double shape, Random rand)
    {
        if (shape < 1.0)
        {
            double U = rand.NextDouble();
            return GammaSample(1.0 + shape, rand) * Math.Pow(U, 1.0 / shape);
        }

        var d = shape - 1.0 / 3.0;
        var c = 1.0 / Math.Sqrt(9.0 * d);
        double x, v;

        while (true)
        {
            do
            {
                x = NormalSample(rand);
                v = 1.0 + c * x;
            } while (v <= 0.0);

            v = v * v * v;
            double U = rand.NextDouble();

            if (U < 1.0 - 0.0331 * (x * x) * (x * x)) return d * v;
            if (Math.Log(U) < 0.5 * x * x + d * (1.0 - v + Math.Log(v))) return d * v;
        }
    }

    static double NormalSample(Random rand)
    {
        double u1 = 1.0 - rand.NextDouble();
        double u2 = 1.0 - rand.NextDouble();
        return Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
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
