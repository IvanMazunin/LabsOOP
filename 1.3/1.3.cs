using System;

namespace Lab1_3
{
    class Program
    {
        static void Main()
        {
            float a1 = 1000f;
            float b1 = 0.0001f;
            double a2 = 1000d;
            double b2 = 0.0001d;

            //Промежуточные значения и итоговый результат для float
            float c1 = (a1 - b1) * (a1 - b1) * (a1 - b1) * (a1 - b1);
            float d1= (a1 * a1 * a1 * a1 + 6f * a1 * a1 * b1 * b1 - 4f * a1 * b1 * b1 * b1);
            float e1 = (b1 * b1 * b1 * b1);
            float f1 = (4f * a1 * a1 * a1 * b1);
            float result1 = (c1 - d1) / (e1 - f1);

            //Промежуточные значения и итоговый результат для double
            double c2 = (a2 - b2) * (a2 - b2) * (a2 - b2) * (a2 - b2);
            double d2 = (a2 * a2 * a2 * a2 + 6d * a2 * a2 * b2 * b2 - 4f * a2 * b2 * b2 * b2);
            double e2 = (b2 * b2 * b2 * b2);
            double f2 = (4d * a2 * a2 * a2 * b2);
            double result2 = (c2 - d2) / (e2 - f2);

            //Вывод промежуточных вычислений и ответа
            Console.WriteLine("Промежуточные  рузультаты: ");
            Console.WriteLine("(a-b)^4:");
            Console.WriteLine($"f: {c1}");
            Console.WriteLine($"d: {c2}");
            Console.WriteLine();

            Console.WriteLine("a^4 -+6(ab)^2 - 4ab^3:");
            Console.WriteLine($"f: {d1}");
            Console.WriteLine($"d: {d2}");
            Console.WriteLine();

            Console.WriteLine("b^4:");
            Console.WriteLine($"f: {e1}");
            Console.WriteLine($"d: {e2}");
            Console.WriteLine();

            Console.WriteLine("4ba^3: ");
            Console.WriteLine($"f: {f1}");
            Console.WriteLine($"d: {f2}");
            Console.WriteLine();

            Console.WriteLine($"Ответ для float: {result1}");
            Console.WriteLine($"Ответ для double: {result2}");
        }
       
    }
}
