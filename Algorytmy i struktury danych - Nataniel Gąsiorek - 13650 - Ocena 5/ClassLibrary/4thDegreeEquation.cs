using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class _4thDegreeEquation
    {
        private double a, b, c, d, e;

        public _4thDegreeEquation(double a, double b, double c, double d, double e)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;

            if (a == 0)
                throw new ArgumentOutOfRangeException("Parameter a cannot be equal to 0!");

            Calculate();
        }

        static double checkSquareRoot(double x, double y)
        {
            var result = Math.Pow(x, y);

            if (x > 0)
                return result;
            else
                return -1 * Math.Pow(-x, y);
        }

        private void Calculate()
        {
            //Obliczamy F,G,H

            double f = (c / a) - ((3 * Math.Pow(b, 2.0)) / (8 * Math.Pow(a, 2.0)));
            double g = (d / a) + (Math.Pow(b, 3.0) / (8.0 * Math.Pow(a, 3.0))) - ((b * c) / (2.0 * Math.Pow(a, 2.0)));
            double h = (e / a) - ((3 * Math.Pow(b, 4.0)) / (256.0 * Math.Pow(a, 4.0))) + ((Math.Pow(b, 2.0) * c) / (16.0 * Math.Pow(a, 3.0))) - ((b * d) / (4.0 * Math.Pow(a, 2.0)));

            //Definiujemy wartości Argumenty-PRIM

            double aprim = 1.0;
            double bprim = f / 2.0;
            double cprim = (Math.Pow(f, 2.0) - (4.0 * h)) / 16.0;
            double dprim = -(Math.Pow(g, 2.0) / 64.0);

            Console.WriteLine(aprim + "y^3 + " + bprim + "y^2 + " + cprim + "y + " + dprim + " = 0");

            double w = -(bprim / (3.0 * aprim));
            double p = ((3.0 * aprim * Math.Pow(w, 2.0)) + (2.0 * bprim * w) + cprim) / aprim;
            double q = ((aprim * Math.Pow(w, 3.0)) + (bprim * Math.Pow(w, 2.0)) + (cprim * w) + dprim) / aprim;


            //Obliczamy deltę i porównujemy ją z zerem

            double delta = (Math.Pow(q, 2.0) / 4.0) + (Math.Pow(p, 3.0) / 27.0);
            Console.WriteLine("Delta = " + delta);

            if (delta > 0)
            {
                DeltaWieksza(w, p, q, delta, g, a, b);
            }
            else if (delta < 0)
            {
                DeltaMniejsza(w, p, q, delta, g, a, b);
            }
            else if (delta == 0)
            {
                DeltaRowna(w, p, q, delta, g, a, b);
            }
        }

        static void DeltaWieksza(double w, double p, double q, double delta, double g, double a, double b)
        {
            double u = Math.Cbrt((-q / 2.0) + Math.Sqrt(delta));
            double v = Math.Cbrt((-q / 2.0) - Math.Sqrt(delta));

            double x1 = u + v + w;
            double x2 = (-0.5 * (u + v)) + w;
            double x3 = x2;
            double urojona = (Math.Sqrt(3.0) / 2.0) * (u - v);

            Console.WriteLine("urojona: " + urojona);


            Console.WriteLine("Jeden pierwiastek rzeczyswisty i dwa zespolone.");
            Console.WriteLine("x1 = " + x1);
            Console.WriteLine(x2 + " + " + urojona + "i");
            Console.WriteLine(x3 + " - " + urojona + "i");
        }

        static void DeltaRowna(double w, double p, double q, double delta, double g, double a, double b)
        {
            double x1 = w - 2.0 * Math.Cbrt(q / 2.0);
            double x23 = w + Math.Cbrt(q / 2.0);

            Console.WriteLine($"{x1}, {x23}");

            Console.WriteLine("Wynikiem równania są dwa pierwiastki rzeczywiste: " + x1 + " oraz drugi-podwójny: " + x23);
        }

        static void DeltaMniejsza(double w, double p, double q, double delta, double g, double a, double b)
        {
            Console.WriteLine("Trzy pierwiastki rzeczyswiste.");

            double fi = Math.Acos((3.0 * q) / (2.0 * p * Math.Sqrt(-p / 3.0)));

            double x1 = (w + (2 * Math.Sqrt(-p / 3.0)) * Math.Cos(fi / 3.0));
            double x2 = (w + 2 * Math.Sqrt(-p / 3.0) * Math.Cos(fi / 3.0 + (2.0 * Math.PI) / 3.0));
            double x3 = (w + 2 * Math.Sqrt(-p / 3.0) * Math.Cos(fi / 3.0 + (4.0 * Math.PI) / 3.0));

            Console.WriteLine($"{x1}, {x2}, {x3}");

            //Ciąg dalszy

            if (x1 == 0)
            {
                double y1 = x2;
                double y2 = x3;

                double P, Q, R, S;
                P = checkSquareRoot(y1, 1.0 / 2.0);
                Q = checkSquareRoot(y2, 1.0 / 2.0);
                R = -(g / (8.0 * P * Q));
                S = b / (4.0 * a);
                Console.WriteLine("x1 = " + (P + Q) + " + " + (R - S) + "i");
                Console.WriteLine("x2 = " + (P - Q) + " + " + (-R - S) + "i");
                Console.WriteLine("x3 = " + (-P + Q) + " + " + (-R - S) + "i");
                Console.WriteLine("x4 = " + (-P - Q) + " + " + (R - S) + "i");


            }
            else if (x2 == 0)
            {
                double y1 = x1;
                double y2 = x3;
                double P, Q, R, S;
                P = checkSquareRoot(y1, 1.0 / 2.0);
                Q = checkSquareRoot(y2, 1.0 / 2.0);
                R = -(g / (8.0 * P * Q));
                S = b / (4.0 * a);
                Console.WriteLine("x1 = " + (P + Q) + " + " + (R - S) + "i");
                Console.WriteLine("x2 = " + (P - Q) + " + " + (-R - S) + "i");
                Console.WriteLine("x3 = " + (-P + Q) + " + " + (-R - S) + "i");
                Console.WriteLine("x4 = " + (-P - Q) + " + " + (R - S) + "i");

            }
            else
            {
                double y1 = x1;
                double y2 = x2;
                double P, Q, R, S;
                P = checkSquareRoot(y1, 1.0 / 2.0);
                Q = checkSquareRoot(y2, 1.0 / 2.0);
                R = -(g / (8.0 * P * Q));
                S = b / (4.0 * a);
                Console.WriteLine("x1 = " + (P + Q) + " + " + (R - S) + "i");
                Console.WriteLine("x2 = " + (P - Q) + " + " + (-R - S) + "i");
                Console.WriteLine("x3 = " + (-P + Q) + " + " + (-R - S) + "i");
                Console.WriteLine("x4 = " + (-P - Q) + " + " + (R - S) + "i");
            }
        }
    }
}
