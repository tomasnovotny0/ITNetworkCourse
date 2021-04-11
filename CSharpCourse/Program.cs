using System;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            // Variables
            int integer = 12;
            Console.WriteLine(integer);

            float aFloat = 12.2F;
            Console.WriteLine(aFloat);

            bool aBool = true;
            Console.WriteLine(aBool);

            aBool = aFloat > integer;
            Console.WriteLine(aBool);

            // Reading user input
            Console.WriteLine("Write something and I will repeat it twice:");
            string input;
            input = Console.ReadLine();
            string output = $"{input}, {input}!";
            Console.WriteLine(output);

            // Parsing
            Console.WriteLine("Enter number to be multiplied:");
            string numberInput = Console.ReadLine();
            int number = 0;
            try {
                number = int.Parse(numberInput);
            }
            catch (FormatException formatException) {
                Console.WriteLine($"{numberInput} is not a valid number!");
            }

            int multiplied = number * 2;
            Console.WriteLine(multiplied);
            Console.ReadKey();
            
            // Simple calculator
            Console.WriteLine("Welcome to simple calculator");
            Console.WriteLine("Enter first number");
            float a = float.Parse(Console.ReadLine()); // unsafe
            Console.WriteLine("Enter second number:");
            float b = float.Parse(Console.ReadLine()); // also unsafe
            float sum = a + b;
            float difference = a - b;
            float multiple = a * b;
            float divided = a / b;
            Console.WriteLine($"{a} + {b} = {sum}");
            Console.WriteLine($"{a} - {b} = {difference}");
            Console.WriteLine($"{a} * {b} = {multiple}");
            Console.WriteLine($"{a} / {b} = {divided}");
            Console.ReadKey();
        }
    }
}