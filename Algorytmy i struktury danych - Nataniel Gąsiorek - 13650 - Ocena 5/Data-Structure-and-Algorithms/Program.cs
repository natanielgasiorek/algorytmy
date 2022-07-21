using ClassLibrary;
using System;

namespace Data_Structure_and_Algorithms
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ShowMenu();
        }

        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Wybierz podprogram:");
            Console.WriteLine("1) Kalkulator równania sześcienne (trzeciego stopnia)");
            Console.WriteLine("2) Kalkulator równania czwartego stopnia");
            Console.WriteLine("3) Kalkulator rownego podziału (algorytm bisekcji)");
            Console.WriteLine("4) Problem plecakowy:");
            Console.WriteLine("5) Problem komiwojażera:");
            Console.Write("\r\nWybierz opcje wybierając [1-5]:");

            switch (Console.ReadLine())
            {
                case "1":
                    StartCubicEquation();
                    break;

                case "2":
                    Start4thDegreeEquation();
                    break;

                case "3":
                    StartBisectionMethod();
                    break;

                case "4":
                    StartKnapsackProblem();
                    break;

                case "5":
                    StartTravellingSalesmanProblem();
                    break;

                default:
                    ShowMenu();
                    break;
            }
        }

        public static void ShowMenuBreake()
        {
            Console.WriteLine("\r\nWciśnij klawisz enter aby powrócić do menu...");
            Console.Read();
            ShowMenu();
        }

        public static void StartCubicEquation()
        {
            try
            {
                char[] arguments = { 'a', 'b', 'c', 'd' };
                double[] values = new double[arguments.Length];

                Console.WriteLine($"\r\nKalkulator równania sześcienne (trzeciego stopnia) – równanie algebraiczne postaci ax^3+bx^2+cx+d=0, przy a ≠ 0");

                for (int i = 0; i < arguments.Length; i++)
                {
                    Console.Write($"Podaj {arguments[i]}: ");
                    string line = Console.ReadLine();
                    values[i] = double.Parse(line);
                }

                var equation = new CubicEquation(values[0], values[1], values[2], values[3]);

                Console.WriteLine(equation);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            ShowMenuBreake();
        }

        public static void Start4thDegreeEquation()
        {
            try
            {
                char[] arguments = { 'a', 'b', 'c', 'd', 'e' };
                double[] values = new double[arguments.Length];

                Console.WriteLine($"\r\nKalkulator równania czwartego stopnia – równanie algebraiczne postaci ax^4 + bx^3 + cx^2 + d^x + e = 0, przy a ≠ 0.");

                for (int i = 0; i < arguments.Length; i++)
                {
                    Console.Write($"Podaj {arguments[i]}: ");
                    string line = Console.ReadLine();
                    values[i] = double.Parse(line);
                }

                new _4thDegreeEquation(values[0], values[1], values[2], values[3], values[4]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            ShowMenuBreake();
        }

        public static void StartBisectionMethod()
        {
            try
            {
                char[] arguments = { 'a', 'b', 'c', 'd', 'e', 'f' };
                double[] values = new double[arguments.Length];

                Console.WriteLine($"\r\nKalkulator rownego podziału (algorytm bisekcji)– równanie algebraiczne postaci ax^5 + bx^4 + cx^3 + dx^2 + ex + f = 0, przy a ≠ 0.");

                for (int i = 0; i < arguments.Length; i++)
                {
                    Console.Write($"Podaj {arguments[i]}: ");
                    string line = Console.ReadLine();
                    values[i] = double.Parse(line);
                }

                new BisectionMethod(values[0], values[1], values[2], values[3], values[4], values[5]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            ShowMenuBreake();
        }

        public static void StartKnapsackProblem()
        {
            Console.WriteLine($"\r\nProblem plecakowy");
            new KnapsackProblem();

            ShowMenuBreake();
        }

        public static void StartTravellingSalesmanProblem()
        {
            Console.WriteLine($"\r\nProblem komiwojażera");
            new TravellingSalesmanProblem();

            ShowMenuBreake();
        }
    }
}