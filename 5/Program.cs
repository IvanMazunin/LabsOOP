using System;

namespace Lab5
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
                    Console.WriteLine("Недопустимое значение!");
            } while (!isCorrect);
            return number;
        }

        static int[] CreateOneDimensionalArr(int length = 0)
        {
            if (length > 0)
            {
                int[] mas = new int[length];
                Console.WriteLine("Массив создан\n");
                return mas;
            }
            else
            {
                int[] mas = new int[0];
                Console.WriteLine("Ошибка ввода! Создан массив по умолчанию");
                return mas;
            }
        }

        static int[] InputOneDimensionalArr(ref int[] mas)
        {
            if (mas.Length != 0)
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    int number;
                    Console.Write("Введите элемент: ");
                    while (!(int.TryParse(Console.ReadLine(), out number)))
                        Console.Write("Недопустимое значение! Повторите ввод: ");
                    mas[i] = number;
                }
            }
            else
                Console.WriteLine("Ошибка! Попытка заполнения массива нулевой длины!");
            return mas;
        }

        static int[] FillRandomOneDimensionalArr(ref int[] mas)
        {
            if (mas.Length != 0)
            {
                Random rand = new Random();
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = rand.Next(1, 51);
                }
            }
            else
                Console.WriteLine("Ошибка! Попытка заполнения массива нулевой длины!");
            return mas;
        }
        static void OutputOneDimensionalArr(ref int[] mas)
        {
            if (mas.Length != 0)
            {
                Console.Write("Ваш одномерный массив: ");
                foreach (int key in mas)
                {
                    Console.Write($"{key}");
                }
                Console.WriteLine("\n");
            }
            else
                Console.WriteLine("Массив пуст!");
        }

        static int[] SolveOneDimensionalArr(ref int[] mas)
        {
            if (mas.Length != 0)
            {
                int len = mas.Length;
                foreach (int key in mas)
                {
                    if (key % 2 == 0)
                        len++;
                }
                int[] newArr = CreateOneDimensionalArr(len);

                for (int i = 0, j = 0; i < mas.Length; i++, j++)
                {
                    newArr[j] = mas[i];
                    if (mas[i] % 2 == 0)
                        newArr[++j] = 0;
                }
                return newArr;
            }
            else
                Console.WriteLine("Массив пуст!\n");
            return mas;
        }

        static int[,] CreateTwoDimensionalArr(int rows, int columns)
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
        static int[,] InputTwoDimensionalArr(ref int[,] mas)
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

        static int[,] FillRandomTwoDimensionalArr(ref int[,] mas)
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
        static void OutputTwoDimensionalArr(ref int[,] mas)
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
        static bool[] GetZeroLinesIndexesTwoArr(ref int[,] mas)
        {
            if (mas.Length != 0)
            {
                int rows = mas.GetUpperBound(0) + 1;
                int columns = mas.Length / rows;
                bool[] indexArr = new bool[rows];
                int evenRowsCounter = 0;
                for (int i = 0; i < rows; i++)
                {
                    bool isZero = false;
                    for (int j = 0; j < columns; j++)
                    {
                        if (mas[i, j] == 0)
                            indexArr[i] = true;
                    }
                }
                return indexArr;
            }
            else
            {
                Console.WriteLine("Ошибка! Попытка обработки массива нулевой длины!");
                return new bool[0];
            }
        }
        static int[,] DeleteZeroLinesTwoArr(ref int[,] mas, ref bool[] indexArr)
        {
            if (indexArr.Length != 0)
            {
                int number = 0;
                for (int i = 0; i < indexArr.Length; i++)
                    if (indexArr[i] == true)
                        number++;
                int rows = mas.GetUpperBound(0) + 1;
                int columns = mas.Length / rows;
                int[,] newArr = CreateTwoDimensionalArr(rows - number, columns);
                for (int i = 0, k = 0; i < rows; i++)
                    if (indexArr[i] != true)
                    {
                        for (int j = 0; j < columns; j++)
                           newArr[k, j] = mas[i, j];
                        k++;
                    }
                return newArr;
            }
            else
            {
                Console.WriteLine("Ошибка! Попытка обработки массива нулевой длины!");
                return mas;
            }
        }

        static int[][] CreateRipArr(int rows = 0)
        {
            if (rows > 0)
            {
                int[][] mas = new int[rows][];
                for (int i = 0; i < rows; i++)
                {
                    int columns;
                    do
                        columns = GetInt($"Введите количество элементов {i + 1} строки: ");
                    while (columns < 1);
                    mas[i] = new int[columns];
                    for (int j = 0; j < columns; j++)
                        mas[i][j] = 0;
                }
                Console.WriteLine("Массив создан\n");
                return mas;
            }
            else
            {
                int[][] mas = new int[0][];
                Console.WriteLine("Ошибка ввода! Создан массив по умолчанию");
                return mas;
            }
        }
        static int[][] InputRipArr(ref int[][] mas)
        {
            if (mas.Length != 0)
            {
                int rows = mas.GetUpperBound(0) + 1;
                int number;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < mas[i].Length; j++)
                    {
                        Console.Write($"Введите элемент для {i + 1} строки: ");
                        while (!(int.TryParse(Console.ReadLine(), out number)))
                            Console.Write("Недопустимое значение! Повторите ввод: ");
                        mas[i][j] = number;
                    }
                }
                return mas;
            }
            else
                Console.WriteLine("Попытка заполнить массив нулевой длины!\n");
            return mas;
        }

        static int[][] FillRandomRipArr(ref int[][] mas)
        {
            if (mas.Length != 0)
            {
                int rows = mas.GetUpperBound(0) + 1;
                Random rand = new Random();
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < mas[i].Length; j++)
                        mas[i][j] = rand.Next(1, 51);
                }
                return mas;
            }
            else
                Console.WriteLine("Попытка заполнить массив нулевой длины!\n");
            return mas;
        }
        static void OutputRipArr(ref int[][] mas)
        {
            if (mas.Length != 0)
            {
                int rows = mas.GetUpperBound(0) + 1;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < mas[i].Length; j++)
                        Console.Write($"{mas[i][j]}\t");
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("Массив пуст!\n");
        }
        static int[][] AddLinesRipArr(ref int[][] mas)
        {
            if (mas.Length != 0)
            {
                int rows = mas.GetUpperBound(0) + 1;
                int newRows = GetInt("Введите количество добавляемых строк: ");
                int[][] addArr = CreateRipArr(newRows);
                addArr = FillRandomRipArr(ref addArr);
                int[][] newArr = new int[newRows + rows][];
                for (int i = 0; i < rows; i++)
                {
                    newArr[i] = new int[mas[i].Length];
                    for (int j = 0; j < mas[i].Length; j++)
                    {
                        newArr[i][j] = mas[i][j];
                    }
                }
                for (int i = rows, k = 0; i < rows + newRows; i++, k++)
                {
                    newArr[i] = new int[addArr[k].Length];
                    for (int j = 0; j < addArr[k].Length; j++)
                    {
                        newArr[i][j] = addArr[k][j];
                    }
                }

                return newArr;
            }
            else 
                Console.WriteLine("Попытка удаления из массива нулевой длины!\n");
            return mas;
        }
        static void Main(string[] args)
        {
            bool isWorking = true;
            int[] masOne = new int[0];
            int[,] masTwo = new int[0, 0];
            int[][] masRip = new int[0][];
            int key = 0;
            while (isWorking)
            {
                switch (key)
                {
                    case 0:
                        Console.WriteLine("Список доступных команд:\n" +
                            "1 - Работа с одномерными массивами\n" +
                            "2 - Работа с двумерными массивами\n" +
                            "3 - Работа с рваными массивами\n" +
                            "4 - Закрыть программу\n");
                        key = GetInt("Введите номер команды: ");
                        while (key < 1 || key > 4)
                            key = GetInt("Неверный ввод! Введите повторно номер команды: ");
                        break;
                    case 1:
                        Console.WriteLine("Одномерные массивы:\n" +
                            "1 - Создать массив\n" +
                            "2 - Вывести имеющийся массив\n" +
                            "3 - Вставить 0 после каждого четного элемента массива\n" +
                            "4 - Назад\n");
                        int subKey = GetInt("Введите номер команды: ");
                        while (subKey < 1 || subKey > 4)
                            subKey = GetInt("Неверный ввод! Введите повторно номер команды: ");
                        switch (subKey)
                        {
                            case 1:
                                int numsOne = GetInt("Введите количество элементов массива: ");
                                masOne = CreateOneDimensionalArr(numsOne);
                                Console.WriteLine("Типы заполнения массива:\n" +
                                    "1 - Заполнить массив случайными числами\n" +
                                    "2 - Заполнить массив ручным вводом\n");
                                subKey = GetInt("Введите номер команды: ");
                                while (subKey < 1 || subKey > 2)
                                    subKey = GetInt("Неверный ввод! Введите повторно номер команды: ");
                                switch (subKey)
                                {
                                    case 1:
                                        FillRandomOneDimensionalArr(ref masOne);
                                        break;
                                    case 2:
                                        InputOneDimensionalArr(ref masOne);
                                        break;
                                }
                                break;
                            case 2:
                                OutputOneDimensionalArr(ref masOne);
                                break;
                            case 3:
                                masOne = SolveOneDimensionalArr(ref masOne);
                                break;
                            case 4:
                                key = 0;
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Двумерные массивы:\n" +
                            "1 - Создать массив\n" +
                            "2 - Вывести имеющийся массив\n" +
                            "3 - Удалить строки с нулевыми элементами\n" +
                            "4 - Назад\n");
                        subKey = GetInt("Введите номер команды: ");
                        while (subKey < 1 || subKey > 3)
                            subKey = GetInt("Неверный ввод! Введите повторно номер команды: ");
                        switch (subKey)
                        {
                            case 1:
                                int rows = GetInt("Введите количество строк массива: ");
                                int columns = GetInt("Введите количество столбцов массива: ");
                                masTwo = CreateTwoDimensionalArr(rows, columns);
                                Console.WriteLine("Типы заполнения массива:\n" +
                                        "1 - Заполнить массив случайными числами\n" +
                                        "2 - Заполнить массив ручным вводом\n");
                                subKey = GetInt("Введите номер команды: ");
                                while (subKey < 1 || subKey > 2)
                                    subKey = GetInt("Неверный ввод! Введите повторно номер команды: ");
                                switch (subKey)
                                {
                                    case 1:
                                        FillRandomTwoDimensionalArr(ref masTwo);
                                        break;
                                    case 2:
                                        InputTwoDimensionalArr(ref masTwo);
                                        break;
                                }
                                break;
                            case 2:
                                OutputTwoDimensionalArr(ref masTwo);
                                break;
                            case 3:
                                bool[] indexArr = GetZeroLinesIndexesTwoArr(ref masTwo);
                                masTwo = DeleteZeroLinesTwoArr(ref masTwo, ref indexArr);
                                break;
                            case 4:
                                key = 0;
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Рваные массивы:\n" +
                            "1 - Создать массив\n" +
                            "2 - Вывести имеющийся массив\n" +
                            "3 - Добавить строки в конец массива\n" +
                            "4 - Назад\n");
                        subKey = GetInt("Введите номер команды: ");
                        while (subKey < 1 || subKey > 3)
                            subKey = GetInt("Неверный ввод! Введите повторно номер команды: ");
                        switch (subKey)
                        {
                            case 1:
                                int rows = GetInt("Введите количество строк массива: ");
                                masRip = CreateRipArr(rows);
                                Console.WriteLine("Типы заполнения массива:\n" +
                                        "1 - Заполнить массив случайными числами\n" +
                                        "2 - Заполнить массив ручным вводом\n" +
                                        "3 - Назад\n");
                                subKey = GetInt("Введите номер команды: ");
                                while (subKey < 1 || subKey > 2)
                                    subKey = GetInt("Неверный ввод! Введите повторно номер команды: ");
                                switch (subKey)
                                {
                                    case 1:
                                        FillRandomRipArr(ref masRip);
                                        break;
                                    case 2:
                                        InputRipArr(ref masRip);
                                        break;
                                }
                                break;
                            case 2:
                                OutputRipArr(ref masRip);
                                break;
                            case 3:
                                masRip = AddLinesRipArr(ref masRip);
                                break;
                            case 4:
                                key = 0;
                                break;
                        }
                        break;
                    case 4:
                        isWorking = false;
                        break;
                }
            }
        }
    }
}
