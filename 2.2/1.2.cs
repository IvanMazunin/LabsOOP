using System;

namespace Lab1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                double x, y;
                //Ввод координат x и y
                do
                    Console.Write("Введите x координату: ");
                while (!Double.TryParse(Console.ReadLine(), out x));
                do
                    Console.Write("Введите y координату: ");
                while (!Double.TryParse(Console.ReadLine(), out y));

                //Проверка на принадлежность одной из областей
                bool plane1 = x >= -7 && x <= 0 && y >= -5 && y <= -3;
                bool plane2 = x >= 0 && x <= 4 && y >= 2 && y <= 5;
                Console.WriteLine(plane1 || plane2);
                Console.WriteLine();
            }
        }
    }
}
