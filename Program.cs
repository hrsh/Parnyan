using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
        start:
            bool test;
            int choosen;
            string sign = string.Empty;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("Sum (1), Muliplication (2), Division (3), Subtraction (4)");
                test = int.TryParse(Console.ReadLine(), out choosen);
            } while (!test || choosen < 1 || choosen > 4);

            double first, second;
            bool testFirst, testSecond;
            do
            {
                Console.WriteLine("Enter first number:");
                testFirst = double.TryParse(Console.ReadLine(), out first);
            } while (!testFirst);

            bool divisionByZeroTest;
            do
            {
                Console.WriteLine("Enter second number:");
                testSecond = double.TryParse(Console.ReadLine(), out second);
                divisionByZeroTest = choosen == 3 && second == 0 ? false : true;
                if (!divisionByZeroTest)
                    Console.Beep();
            } while (!testSecond || !divisionByZeroTest);

            double result = 0.0;
            switch (choosen)
            {
                case 1:
                    result = first + second;
                    sign = "+";
                    break;

                case 2:
                    result = first * second;
                    sign = "x";
                    break;

                case 3:
                    // prevent division by zero
                    if (second == 0)
                    {
                        second = first;
                    }
                    result = first / second;
                    sign = "/";
                    break;

                case 4:
                    result = first - second;
                    sign = "-";
                    break;
            }

            Console.WriteLine($"{first} {sign} {second} = {result}");
            Console.WriteLine("For exit, enter q, else press enter to begin :)");
            var r = Console.ReadLine();
            if (r != "q")
                goto start;
            else
                Environment.Exit(0);
        }
    }
}
