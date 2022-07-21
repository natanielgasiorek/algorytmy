using System;

namespace ClassLibrary
{
    public class CubicEquation
    {
        private double a, b, c, d;
        public string x1, x2, x3;

        public CubicEquation(double a, double b, double c, double d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;

            if (a == 0)
                throw new ArgumentOutOfRangeException("Parameter a cannot be equal to 0!");

            Calculate();
        }
        private double checkSquareRoot(double x, double y)
        {
            var result = Math.Pow(x, y);

            if (x > 0)
                return result;
            else
                return -1 * Math.Pow(-x, y);
        }

        private void Calculate()
        {
            double w = -b / (3.0 * a);

            double p = (3.0 * a * Math.Pow(w, 2.0) + 2.0 * b * w + c) / a;

            double q = (a * Math.Pow(w, 3.0) + b * Math.Pow(w, 2.0) + c * w + d) / a;

            double D = (Math.Pow(q, 2.0) / 4.0) + (Math.Pow(p, 3.0) / 27.0);

            if (D > 0)
            {
                double u = checkSquareRoot(-(q / 2.0) + Math.Sqrt(D), 1.0 / 3.0);
                double v = checkSquareRoot(-(q / 2.0) - Math.Sqrt(D), 1.0 / 3.0);

                x1 = (u + v + w).ToString();
                x2 = (-0.5 * (u + v) + w).ToString() + " + " + ((Math.Sqrt(3) / 2.0) * (u - v)).ToString() + "i";
                x3 = (-0.5 * (u + v) + w).ToString() + " - " + ((Math.Sqrt(3) / 2.0) * (u - v)).ToString() + "i";

                return;
            }

            if (D < 0)
            {
                double fi = Math.Acos((double)(3 * q) / (double)(2 * p * Math.Sqrt(-p / 3.0)));

                x1 = (w + 2 * Math.Sqrt(-p / 3.0) * Math.Cos(fi / 3.0)).ToString();
                x2 = (w + 2 * Math.Sqrt(-p / 3.0) * Math.Cos(fi / 3.0 + (2.0 * Math.PI) / 3.0)).ToString();
                x3 = (w + 2 * Math.Sqrt(-p / 3.0) * Math.Cos(fi / 3.0 + (4.0 * Math.PI) / 3.0)).ToString();

                return;
            }

            if (D == 0)
            {
                x1 = (w - 2 * checkSquareRoot(q / 2.0, 1.0 / 3.0)).ToString();
                x2 = x3 = (w + checkSquareRoot(q / 2.0, 1.0 / 3.0)).ToString();

                return;
            }
        }

        public override string ToString() => $"x1={x1}, x2={x2}, x3={x3}";
    }
}
