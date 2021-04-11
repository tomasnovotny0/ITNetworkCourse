using System;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            int integer = 12;
            Console.WriteLine(integer);

            float aFloat = 12.2F;
            Console.WriteLine(aFloat);

            bool aBool = true;
            Console.WriteLine(aBool);

            aBool = aFloat > integer;
            Console.WriteLine(aBool);
            
            Console.ReadKey();
        }
    }
}