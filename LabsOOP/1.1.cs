using System;

namespace Lab1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            double x;
            bool isCorrect = true;
            do
                Console.WriteLine("Введите целое n:");
            while (!int.TryParse(Console.ReadLine(), out n));
            do
                Console.WriteLine("Введите целое m:");
            while (!int.TryParse(Console.ReadLine(), out m));
            do
            {
                isCorrect = true;
                Console.WriteLine("Введите вещественное x:");
                //Если введено вещественное значение, то проверяется принадлежность числа ОДЗ
                if (double.TryParse(Console.ReadLine(), out x))
                {
                    if (-0.5 - Math.Sqrt(5) > x || -0.5 + Math.Sqrt(5) < x)
                    {
                        Console.WriteLine("x не удовлетворяет области допустимых значений!");
                        isCorrect = false;
                    }
                }
            }
            while (!isCorrect);
            Console.WriteLine($"1) n = {n}, m = {m}, n+++m- = {n++ + m--}");
            Console.WriteLine($"2) n = {n}, m = {m}, n*m<m++ = {n * m < m++}");
            Console.WriteLine($"3) n = {n}, m = {m}, n-->++m = {n-- > ++m}");
            Console.WriteLine($"4) x = {x}, acrsin(x + x^2) = {Math.Asin(x+x*x)}");
        }
    }
}
