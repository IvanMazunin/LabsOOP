using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            double leftBorder = 1, rightBorder = 2;
            for (var x = leftBorder; x <= rightBorder; x += (rightBorder - leftBorder) / 10d)
            {
                double step = 1, sumSteps = 1, sumEps = 1;
                for (var index = 1; index <= 100; ++index)
                {
                    step *= Math.Pow(x, 2) / ((2 * index - 1) * 2 * index);
                    sumSteps += Math.Pow(-1, index) * (2 * index * index + 1) * step;
                }

                double eps = 0.0001;
                double stepEps = 1;
                int indexEps = 1;
                while (Math.Abs(stepEps) >= eps)
                {
                    stepEps *= Math.Pow(x, 2) / ((2 * indexEps - 1) * 2 * indexEps);
                    sumEps += Math.Pow(-1, indexEps) * (indexEps * indexEps * 2 + 1) * stepEps;
                    indexEps++;
                }
                double y = (x - 1  / 2d) * Math.Cos(x) - Math.Sin(x) * x * x / 2d;
                Console.WriteLine($"X = {x:f2} SN = {sumSteps:f6} SE = {sumEps:f6} Y = {y:f6}");

            }
        }
    }
}