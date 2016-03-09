using System;

namespace ExtrenumFinding
{
    class Program
    {
        static void Main()
        {
            GoldenSectionSearch(0.009,0.62,1000,10,-10);
        }

        static void GoldenSectionSearch(double epsilon, double r, int maxIteration, double upperBound, double lowerBound)
        {
            int i = 0;

            while ((upperBound -lowerBound)>epsilon && i<maxIteration)
            {
                i++;

                Console.WriteLine("Iteration: "+i);
                Console.WriteLine("Lower Bound = "+lowerBound);
                Console.WriteLine("Upper Bound = "+upperBound);
                Console.WriteLine("H = "+(upperBound-lowerBound));
                double x1 = upperBound - r*(upperBound - lowerBound);
                double x2 = lowerBound + r*(upperBound - lowerBound);
                Console.WriteLine("x1 = "+x1);
                Console.WriteLine("x2 = " + x2);
                double w1 = Func(x1);
                double w2 = Func(x2);

                Console.WriteLine("W(x1) = " + w1);
                Console.WriteLine("W(x2) = " + w2);

                if (w1 >= w2)
                    upperBound = x2;
                else
                    lowerBound = x1;

                if (Func(lowerBound) > Func(upperBound))
                    Console.WriteLine(lowerBound);
                else
                    Console.WriteLine(upperBound);
            }
            Console.ReadLine();
        }


       static double Function1(double x)
       {
           return -x*x*x + 3*x*x - 3*x + 100;
       }

        static double Function2(double x)
        {
            return 15*Math.Exp(0.15*x);
        }

        static double Func(double x)
        {
            return Math.Min(Function1(x), Function2(x));
        }

    }
}
