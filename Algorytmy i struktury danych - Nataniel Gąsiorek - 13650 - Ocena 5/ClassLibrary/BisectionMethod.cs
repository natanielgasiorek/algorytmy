using System;

namespace ClassLibrary
{
    public class BisectionMethod
    {
        private double intervalBegin { get; } = -100;     // Początek przedziału poszukiwań pierwiastka
        private double intervalEnd { get; } = 100;     // Koniec przedziału poszukiwań pierwiastka
        private double precision { get; } = 0.001;
        private double a;
        private double b;
        private double c;
        private double d;
        private double e;
        private double f;

        public BisectionMethod(double a, double b, double c, double d, double e, double f)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;

            if (a == 0)
                throw new ArgumentOutOfRangeException("Parameter a cannot be equal to 0!");

            double middle;

            Console.Write("Enter begining of interval: ");
            intervalBegin = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter end of interval: ");
            intervalEnd = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter precision of method: ");
            precision = Convert.ToDouble(Console.ReadLine());

            if (Function(intervalBegin) * Function(intervalEnd) > 0.0D)
            {
                Console.Write("Function has same signs at ends of interval");
                return;
            }

            Console.WriteLine("Interval begin: " + intervalBegin);
            Console.WriteLine("Interval end: " + intervalEnd);

            while (Math.Abs(intervalBegin - intervalEnd) > precision)
            {
                middle = (intervalBegin + intervalEnd) / 2.0D;
                Console.WriteLine("Root: " + middle);
                if (Function(intervalBegin) * Function(middle) < 0.0D)
                {
                    intervalEnd = middle;
                }
                else
                {
                    intervalBegin = middle;
                }
            }
        }

        private double Function(double x)
        { //ax^5 + bx^4 + cx^3 + dx^2 + ex + f = 0, przy a ≠ 0
            return (a * Math.Pow(x, 5)) + (b * Math.Pow(x, 4)) + (c * Math.Pow(x, 3)) + (d * Math.Pow(x, 2)) + (e * x) + f;
        }
    }
}