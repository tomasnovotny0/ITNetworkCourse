using System;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            ExecuteExercise1();
            ExecuteExercise2();
            ExecuteExercise3();
        }

        /*
         * Difficulty - Easy
         * Input - name, property
         * Output - $name is $property
         */
        static void ExecuteExercise1() {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter property:");
            string property = Console.ReadLine();
            Console.WriteLine("{0} is {1}", name, property);
            Console.ReadKey();
        }

        /*
         * Difficulty - Medium
         * Input - number (integer)
         * Output - number^2
         */
        static void ExecuteExercise2() {
            Console.WriteLine("Enter number:");
            string entry = Console.ReadLine();
            int number = int.Parse(entry); // unsafe
            Console.WriteLine("Result: " + number * number);
            Console.ReadKey();
        }

        /*
         * Difficulty - Advanced
         * Input - Circle radius
         * Output - Perimeter, Area
         * PI value - 3.1415
         */
        static void ExecuteExercise3() {
            float PI = 3.1415F;
            Console.WriteLine("Enter circle radius:");
            string entry = Console.ReadLine();
            bool validNumber = false;
            float radius = 0;
            while (!validNumber) {
                try {
                    radius = float.Parse(entry);
                    validNumber = true;
                }
                catch (FormatException e) {
                    Console.WriteLine($"{entry} is not a valid number");
                    entry = Console.ReadLine();
                }
            }

            float perimeter = 2 * PI * radius;
            float radius2 = radius * radius;
            float area = 2 * PI * radius2;
            Console.WriteLine("Circle perimeter is {0}", perimeter);
            Console.WriteLine("Circle area is {0}", area);
            Console.ReadKey();
        }
    }
}