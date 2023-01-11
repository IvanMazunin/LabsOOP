using System;

namespace Lab10
{
    class Program
    {
        static void Output(Person[] persons)
        {
            for (int i = 0; i < persons.Length; i++)
            {
                Console.Write($"Объект: {persons[i].GetType()}\n");
                persons[i].VirtualShow();
                Console.Write("\n");
            }
        }
        public static int GetInt(string message)
        {
            int keyber;
            bool isCorrect;
            do
            {
                Console.Write(message);
                isCorrect = int.TryParse(Console.ReadLine(), out keyber);
                if (!isCorrect)
                    Console.WriteLine("Введено недопустимое значение!");
            } while (!isCorrect);
            return keyber;
        }
        static void Main(string[] args)
        {
            int keys = GetInt("Введите размер массива объектов иерархии классов Person: ");
            while (keys <= 0)
                keys = GetInt("Введено недопустимое значение! Повторите ввод: ");
            Menu menu = new Menu(keys);
            menu.MainMenu();
        }
    }
}