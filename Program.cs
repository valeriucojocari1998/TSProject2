using System;

class Program
{
    static void Main(string[] args)
    {
        int numSamples = 1000000;
        double alpha = 0.3;
        double beta = 5.0;

        Console.WriteLine("First Method");
        FirstMethod.FirstMethodOutput(numSamples, alpha, beta);

        Console.WriteLine("\nSecond Method");
        SecondMethod.SecondMethodOutput(numSamples, alpha, beta);
    }
}

