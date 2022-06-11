using System;

namespace Calc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserChoicesGeneration();
        }

        static void UserChoicesGeneration()
        {
            Console.Title = "Сalculator";
            Console.WriteLine($"PRESS 1 - Hand Insert\nPRESS 2 - Random Numbers\n" +
                $"PRESS 3 - Menu\nPRESS 4 - Exit programm");

            var choices = Console.ReadLine();

            while (choices != "1" || choices != "2" || choices != "3" || choices != "4")
            {
                switch (choices)
                {
                    case "1":
                        HandInsert();
                        break;
                    case "2":
                        RandomInsert();
                        break;
                    case "3":
                        UserChoicesGeneration();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                }

                Console.WriteLine($"\nPRESS 1 - Hand Insert\nPRESS 2 - Random Numbers\n" +
                    $"PRESS 3 - Menu\nPRESS 4 - Exit programm");

                choices = Console.ReadLine();
                Console.Clear();
            }
        }

        static void RandomInsert()
        {
            Random random = new Random();
            EmergencyCheck(UserInputSign(), random.Next(1, 100), random.Next(-100, 100));
        }

        static void HandInsert()
        {
            EmergencyCheck(UserInputSign());
        }

        static double UserInputNumber()
        {
            double staded;
            Console.Write("Input number: ");
            var checkStaded = Console.ReadLine();
            bool isSuccessful = double.TryParse(checkStaded, out staded);
            while (!isSuccessful)
            {
                Console.WriteLine("Error");
                Console.Write("Input number: ");
                checkStaded = Console.ReadLine();
                isSuccessful = double.TryParse(checkStaded, out staded);
            }

            return staded;
        }

        static string UserInputSign()
        {
            string[] arraySign = { "+", "-", "*", "/", "^", "!" };

            bool isSuccessful = false;
            while (!isSuccessful)
            {
                Console.Write($"Insert: + - * / ^ !\n");

                var checkSign = Console.ReadLine();

                for (int i = 0; i < arraySign.Length; i++)
                {
                    if (arraySign[i] == checkSign)
                    {
                        return checkSign;
                    }
                }
            }

            return $"UserInput return Null";
        }

        static void EmergencyCheck(string sign)
        {
            double firstNumber;
            double secondNumber;

            if (sign == "!")
            {
                firstNumber = UserInputNumber();

                while (firstNumber > 170 || firstNumber < 0)
                {
                    Console.WriteLine("NOT CORRECTED\nCheck events\nCorrect input:\n " +
                        "\tMax Value <= 170\n  \tNumber > 0\n \tIf Number not int=>rounding will be done");
                    firstNumber = UserInputNumber();
                }

                Console.WriteLine($"{(ulong)firstNumber}{sign}={Action(firstNumber, sign)}");
            }

            else
            {
                firstNumber = UserInputNumber();
                secondNumber = UserInputNumber();

                if (sign == "/" && secondNumber == 0)
                {
                    Console.WriteLine("Division 0");
                }

                else
                {
                    Console.WriteLine($"{firstNumber}{sign}{secondNumber}={Action(firstNumber, secondNumber, sign)}");
                }
            }
        }

        static void EmergencyCheck(string sign, double firstNumber, double secondNumber)
        {
            if (sign == "!")
            {
                Console.WriteLine($"FirstNumber={(ulong)firstNumber}");

                while (firstNumber > 170 || firstNumber < 0)
                {
                    Console.WriteLine("NOT CORRECTED\nCheck events\nCorrect input:\n " +
                        "\tMax Value <= 170\n  \tNumber > 0\n \tIf Number not int=>rounding will be done");

                    UserChoicesGeneration();
                    Console.Clear();
                }

                Console.WriteLine($"{(ulong)firstNumber}{sign}={Action(firstNumber, sign)}");
            }

            else
            {
                Console.WriteLine($"FirstNumber= {firstNumber}");
                Console.WriteLine($"SecondNumber= {secondNumber}");

                if (sign == "/" && secondNumber == 0)
                {
                    Console.WriteLine("Division 0");
                }

                else
                {
                    Console.WriteLine($"{firstNumber}{sign}{secondNumber}={Action(firstNumber, secondNumber, sign)}");
                }
            }
        }

        static double Action(double firstNumber, double secondNumber, string sign)
        {
            switch (sign)
            {
                case "+":
                    return Sum(firstNumber, secondNumber);
                case "-":
                    return Subtraction(firstNumber, secondNumber);
                case "*":
                    return Multiplication(firstNumber, secondNumber);
                case "/":
                    return Division(firstNumber, secondNumber);
                case "^":
                    return Degree(firstNumber, secondNumber);
                default:
                    return 0;
            }
        }

        static double Action(double firstNumber, string sign)
        {
            switch (sign)
            {
                case "!":
                    return Factorial(firstNumber);
                default:
                    return 0;
            }
        }

        static double Sum(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        static double Multiplication(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        static double Division(double firstNumber, double secondNumber)
        {
            return firstNumber / secondNumber;
        }

        static double Subtraction(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }

        static double Degree(double firstNumber, double secondNumber)
        {
            var sum = Math.Pow(firstNumber, secondNumber);

            if (sum > double.MaxValue)
            {
                Console.WriteLine($"Sorry OVER Maximum Value");
                return double.NaN;
            }

            return sum;
        }

        static double Factorial(double firstNumber)
        {
            if (firstNumber >= 0 && firstNumber <= 1)
            {
                return 1;
            }

            return firstNumber * Factorial(firstNumber - 1);
        }
    }
}