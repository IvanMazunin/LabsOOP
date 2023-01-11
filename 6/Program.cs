using System;
using System.Linq;
using System.Text;

namespace Lab6_2_
{
    class Program
    {
        static int GetInt(string message)
        {
            int number;
            bool isCorrect;
            do
            {
                Console.Write(message);
                isCorrect = int.TryParse(Console.ReadLine(), out number);
                if (!isCorrect)
                    Console.WriteLine("Введено недопустимое значение!");
            } while (!isCorrect);
            return number;
        }
        static int[,] CreateTwoDimensionalMas(int rows, int columns)
        {
            if (rows > 0 && columns > 0)
            {
                int[,] mas = new int[rows, columns];
                Console.WriteLine("Массив создан\n");
                return mas;
            }
            else
            {
                int[,] mas = new int[0, 0];
                Console.WriteLine("Ошибка ввода! Создан массив по умолчанию");
                return mas;
            }
        }

        static int[,] InputTwoDimensionalMas(ref int[,] mas)
        {
            if (mas.Length != 0)
            {
                int rows = mas.GetUpperBound(0) + 1;
                int columns = mas.Length / rows;
                int number;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write("Введите элемент: ");
                        while (!(int.TryParse(Console.ReadLine(), out number)))
                            Console.Write("Недопустимое значение! Повторите ввод: ");
                        mas[i, j] = number;
                    }
                }
            }
            else
                Console.WriteLine("Ошибка! Попытка заполнения массива нулевой длины!");
            return mas;
        }

        static int[,] FillRandomTwoDimensionalMas(ref int[,] mas)
        {
            if (mas.Length != 0)
            {
                Random rand = new Random();
                int rows = mas.GetUpperBound(0) + 1;
                int columns = mas.Length / rows;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                        mas[i, j] = rand.Next(1, 51);
                }
            }
            else
                Console.WriteLine("Ошибка! Попытка заполнения массива нулевой длины!");
            return mas;
        }
        static void OutputTwoDimensionalMas(ref int[,] mas)
        {
            if (mas.Length != 0)
            {
                int rows = mas.GetUpperBound(0) + 1;
                int columns = mas.Length / rows;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                        Console.Write($"{mas[i, j]}\t");
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("Массив пуст!\n");

        }
        static int[,] SolveTwoDimesionalMas(ref int[,] mas)
        {
            if (mas.Length > 0)
            {
                int rows = mas.GetUpperBound(0) + 1;
                int columns = mas.Length / rows;
                int[] tempMas = new int [columns];
                int[,] newMas = new int[rows - 1, columns];
                int i = 0;
                bool isZero = false;
                while(!isZero && i < rows)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        tempMas[j] = mas[i, j];
                    }
                    if (Array.IndexOf(tempMas, 0) != Array.LastIndexOf(tempMas, 0))
                        if (rows != 1)
                        {
                            for (int a = 0, c = 0; a < rows; a++)
                            { 
                                if (a != i)
                                {
                                    for (int b = 0; b < columns; b++)
                                        newMas[c, b] = mas[a, b];
                                    c++;
                                }
                            }
                            isZero = true;
                        }
                        else return newMas;
                    i++;
                }
                return newMas;
            }
            else
                Console.WriteLine("Попытка отсортировать массив нулевой длины!\n");
            return mas;
        }
        static StringBuilder GetStrInput(string message)
        {
            string readStr;
            Console.WriteLine(message);
            readStr = Console.ReadLine();
            StringBuilder newStr = new StringBuilder(readStr);
            if (newStr.Length != 0)
                return newStr;
            else
            {
                while (newStr.Length == 0)
                {
                    Console.Write("Недопустимый ввод! Повторите ввод: ");
                    readStr = Console.ReadLine();
                    newStr = new StringBuilder(readStr);
                }
                return newStr;
            }
        }
        static StringBuilder GetStrRandom()
        {
            string[] words = { "Annoyingly", "Baggageman", "Complacent", "Dichromate", "Economical", "Fontanelle", "Grapefruit", "Heptagonal", "Idiopathic", "Jardiniere" };
            StringBuilder newStr = new StringBuilder();
            Random rand = new Random();
            int wordsNumber = rand.Next(1, 21);
            for (int i = 0; i < wordsNumber; i++)
            {
                newStr.Append(words[rand.Next(10)]);
                newStr.Append(" ");
            }
            return newStr;
        }
        static StringBuilder moveWords(StringBuilder str)
        {
            StringBuilder newStr = new StringBuilder();
            if (str.Length > 0)
            {
                string[] splittedStr = str.ToString().Split(" ");
                for (int i = 0; i < splittedStr.Length; i++)
                {
                    StringBuilder tempStr = new StringBuilder();
                    for (int j = i + 1; j < splittedStr[i].Length + i + 1; j++)
                        tempStr.Append(splittedStr[i][j % splittedStr[i].Length]);
                    newStr.Append(tempStr.ToString());
                    newStr.Append(" ");
                }
                return newStr;
            }
            else
            {
                Console.Write("Ошибка! Попытка изменения пустой строки!");
                return str;
            }
        }

        static void MainMenu(bool isWorking, int[,] masTwo, StringBuilder str)
        {
            int key = 0;
            while (isWorking)
            {
                switch (key)
                {
                    case 0:
                        Console.WriteLine("Список доступных команд:\n" +
                            "1 - Работа со строками\n" +
                            "2 - Работа с двумерными массивами\n" +
                            "3 - Закрыть программу\n");
                        key = GetInt("Выберите номер команды: ");
                        while (key < 1 || key > 3)
                            key = GetInt("Неверный ввод! Выберите повторно номер команды: ");
                        break;
                    case 1:
                        Console.WriteLine("Команды для строк:\n" +
                            "1 - Создать строку\n" +
                            "2 - Вывести текущую строку\n" +
                            "3 - Сдвинуть циклически влево каждое слово на количество символов равное номеру этого слова в строке\n" +
                            "4 - Назад\n");
                        int subKey = GetInt("Выберите номер команды: ");
                        while (subKey < 1 || subKey > 4)
                            subKey = GetInt("Неверный ввод! Выберите повторно номер команды: ");
                        switch (subKey)
                        {
                            case 1:
                                Console.Write("Типы заполнения строки:\n" +
                                              "1 - Заполнить строку случайными словами\n" +
                                              "2 - Заполнить строку ручным вводом\n\n");
                                subKey = GetInt("Выберите номер команды: ");
                                while (subKey < 1 || subKey > 2)
                                subKey = GetInt("Неверный ввод! Выберите повторно номер команды: ");
                                switch (subKey)
                                {
                                    case 1:
                                        str = GetStrRandom();
                                        break;
                                    case 2:
                                        str = GetStrInput("Введите строку: ");
                                        break;
                                }
                                break;
                            case 2:
                                if (str.Length > 0)
                                    Console.WriteLine($"Ваша строка:\n{str}");
                                else
                                    Console.WriteLine("Ошибка! Пустая строка!");
                                break;
                            case 3:
                                str = moveWords(str);
                                break;
                            case 4:
                                key = 0;
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Команды для двумерных массивов:\n" +
                            "1 - Создать массив\n" +
                            "2 - Вывести имеющийся массив\n" +
                            "3 - Удаление строки, содержащей более одного 0\n" +
                            "4 - Вернуться назад\n");
                        subKey = GetInt("Выберите номер команды: ");
                        while (subKey < 1 || subKey > 4)
                            subKey = GetInt("Неверный ввод! Выберите повторно номер команды: ");
                        switch (subKey)
                        {
                            case 1:
                                int rows = GetInt("Введите количество строк массива: ");
                                int columns = GetInt("Введите количество столбцов массива: ");
                                masTwo = CreateTwoDimensionalMas(rows, columns);
                                if (rows > 0 && columns > 0)
                                {
                                    Console.Write("Типы заполнения массива:\n" +
                                            "1 - Заполнить массив случайными числами\n" +
                                            "2 - Заполнить массив ручным вводом\n\n");
                                    subKey = GetInt("Выберите номер команды: ");
                                    while (subKey < 1 || subKey > 2)
                                        subKey = GetInt("Неверный ввод! Выберите повторно номер команды: ");
                                    switch (subKey)
                                    {
                                        case 1:
                                            FillRandomTwoDimensionalMas(ref masTwo);
                                            break;
                                        case 2:
                                            InputTwoDimensionalMas(ref masTwo);
                                            break;
                                    }
                                }
                                break;
                            case 2:
                                OutputTwoDimensionalMas(ref masTwo);
                                break;
                            case 3:
                                masTwo = SolveTwoDimesionalMas(ref masTwo);
                                break;
                            case 4:
                                key = 0;
                                break;
                        }
                        break;
                    case 3:
                        isWorking = false;
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder();
            int[,] masTwo = new int[0, 0];
            bool isWorking = true;
            MainMenu(isWorking, masTwo, str);
        }
    }
}
