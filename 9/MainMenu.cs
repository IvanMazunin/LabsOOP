using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Lab9
{
    public class MainMenu : Program
    {
        private bool isWorking = true;
        private MoneyArray banks;
        private List<Money> moneyList = new List<Money>();

        public static int GetInt(string message)
        {
            int num;
            bool isCorrect;
            do
            {
                Console.Write(message);
                isCorrect = int.TryParse(Console.ReadLine(), out num) && num > 0;
                if (!isCorrect)
                    Console.WriteLine("Введено недопустимое значение!");
            } while (!isCorrect);
            return num;
        }
        public void Menu()
        {
            int key = 0;
            while (isWorking)
            {
                switch(key)
                { 
                    case 0:
                        Console.WriteLine("Список доступных команд:\n" +
                            "1 - Работа с классом Money\n" +
                            "2 - Работа с классом-коллекцией MoneyArray (массив объектов Money)\n" +
                            "3 - Закрыть программу\n");
                        key = GetInt("Выберите номер команды: ");
                        while (key < 1 || key > 3)
                            key = GetInt("Неверный ввод! Выберите повторно номер команды: ");
                        break;
                    case 1:
                        Console.WriteLine("Команды для объектов класса Money:\n" +
                            "1 - Создать объект класса Money ручным вводом\n" +
                            "2 - Создать объект класса Money со случайными значениями\n" +
                            "3 - Удалить объект класса Money\n" +
                            "4 - Вывести текущие объекты класса Money и всего созданное количество объектов\n" +
                            "5 - Добавить копеек к объекту класса Money\n" +
                            "6 - Унарные операции с объектами класса Money\n" +
                            "7 - Бинарные операции с объектами класса Money\n" +
                            "8 - Операции явного и неявного приведения объектов класса Money\n" +
                            "9 - Назад\n");
                        int subKey = GetInt("Выберите номер команды: ");
                        while (subKey < 1 || subKey > 9)
                            subKey = GetInt("Неверный ввод! Выберите повторно номер команды: ");
                        switch (subKey)
                        {
                            case 1:
                               int rub = GetInt("Введите количество рублей: "), kop = GetInt("Введите количество копеек: ");
                                moneyList.Add(new Money(rub, kop));
                                if (kop > 99)
                                    moneyList.RemoveAt(moneyList.Count - 1);
                                break;
                            case 2:
                                Random rand = new Random();
                                int randRub = rand.Next(), randKop = rand.Next(0,100);
                                moneyList.Add(new Money(randRub, randKop));
                                Console.WriteLine("Объект класса Money успешно создан");
                                break;
                            case 3:
                                int deleteNum = GetInt("Укажите номер удаляемого объекта: ");
                                if (moneyList.Contains(moneyList[deleteNum - 1]))
                                    moneyList.RemoveAt(deleteNum - 1);
                                break;
                            case 4:
                                Console.WriteLine("Текущие объекты класса Money:");
                                for (int i = 0; i < moneyList.Count; i++)
                                {
                                    Console.Write(moneyList[i].ToString());
                                    Console.Write(' ');
                                }
                                Console.WriteLine($"\nВсего созданных объектов класса Money: {Money.count}");
                                break;
                            case 5:
                                int pos = GetInt("Укажите номер номер объекта, к которому необходимо добавить копейки: ");
                                int addKops = GetInt("Укажите сколько копеек необходимо добавить: ");
                                if (moneyList.Contains(moneyList[pos - 1]))
                                    moneyList[pos - 1].AddKopeks(addKops);
                                else
                                    Console.Write($"Объект с указанным номером ({pos}) не найден!");
                                break;
                            case 6:
                                Console.WriteLine("Доступные унарные операции для объектов класса Money:\n" +
                                    "1 - Добавление копейки (операция инкрементирования ++)\n" +
                                    "2 - Вычитание копейки (операция декрементирования --)\n");
                                int subNumUnary = GetInt("Введите номер команды: ");
                                while (subNumUnary < 1 || subNumUnary > 2)
                                    subNumUnary = GetInt("Неверный ввод! Выберите повторно номер команды: ");
                                switch (subNumUnary)
                                {
                                    case 1:
                                        int numInc = GetInt("Укажите номер объекта: ");
                                        if (moneyList.Contains(moneyList[numInc - 1]))
                                        {
                                            ++moneyList[numInc - 1];
                                            Console.WriteLine("Инкрементирование прошло успешно");
                                        }
                                        else
                                            Console.WriteLine("Указанный объект не найден!");
                                        break;
                                    case 2:
                                        int numDec = GetInt("Укажите номер объекта: ");
                                        if (moneyList.Contains(moneyList[numDec - 1]))
                                        {
                                            --moneyList[numDec - 1];
                                        }
                                        else
                                            Console.WriteLine("Указанный объект не найден!");
                                        break;
                                }
                                break;
                            case 7:
                                Console.WriteLine("Доступные бинарные операции для объектов класса Money:\n" +
                                    "1 - Вычитание числа копеек из объекта Money (Money m - число)\n" +
                                    "2 - Вычитание объекта Money из числа копеек (число - Money m)\n" +
                                    "3 - Прибавление числа копеек к объекта Money (Money m + число)\n" +
                                    "4 - Прибавление объекта Money к числу копеек (число + Money m)\n");
                                int subNumBinary = GetInt("Введите номер команды: ");
                                while (subNumBinary > 4 || subNumBinary < 1)
                                    subNumUnary = GetInt("Неверный ввод! Выберите повторно номер команды: ");
                                switch (subNumBinary)
                                {
                                    case 1:
                                        int indexSubstract = GetInt("Укажите номер объекта: ");
                                        int numSubstract = GetInt("Укажите вычитаемое число копеек: ");
                                        if (moneyList.Contains(moneyList[indexSubstract - 1]))
                                        {
                                            moneyList[indexSubstract - 1] = moneyList[indexSubstract - 1] - numSubstract;
                                            Console.WriteLine("Вычитание прошло успешно");
                                        }
                                        else
                                            Console.WriteLine("Указанный объект не найден!");
                                        break;
                                    case 2:
                                        int indexSubstractReverse = GetInt("Укажите номер объекта: ");
                                        int numSubstractReverse = GetInt("Укажите число копеек: ");
                                        if (moneyList.Contains(moneyList[indexSubstractReverse - 1]))
                                        {
                                            moneyList[indexSubstractReverse - 1] = numSubstractReverse - moneyList[indexSubstractReverse - 1];
                                            Console.WriteLine("Вычитание прошло успешно");
                                        }
                                        else
                                             Console.WriteLine("Указанный объект не найден!");
                                        break;
                                    case 3:
                                        int indexPlus = GetInt("Укажите номер объекта: ");
                                        int numPlus = GetInt("Укажите прибавляемое число: ");
                                        if (moneyList.Contains(moneyList[indexPlus - 1]))
                                        {
                                            moneyList[indexPlus - 1] = moneyList[indexPlus - 1] + numPlus;
                                            Console.WriteLine("Сложение прошло успешно");
                                        }
                                        else
                                            Console.WriteLine("Указанный объект не найден!");
                                        break;
                                    case 4:
                                        int indexPlusReverse = GetInt("Укажите номер объекта: ");
                                        int numPlusReverse = GetInt("Укажите прибавляемое число: ");
                                        if (moneyList.Contains(moneyList[indexPlusReverse - 1]))
                                        {
                                            moneyList[indexPlusReverse - 1] = numPlusReverse + moneyList[indexPlusReverse - 1];
                                            Console.WriteLine("сложение прошло успешно");
                                        }
                                        else
                                            Console.WriteLine("Указанный объект не найден!");
                                        break;
                                }
                                break;
                            case 8:
                                Console.WriteLine("Доступные операции приведения для объектов класса Money:\n" +
                                    "1 - Явное целочисленное приведение объекта Money, результатом которого является количество рублей\n" +
                                    "2 - Невное вещественное приведение объекта Money, результатом которого являются копейки\n");
                                int subNumCast = GetInt("Введите номер команды: ");
                                while (subNumCast < 1 || subNumCast > 2)
                                    subNumUnary = GetInt("Неверный ввод! Выберите повторно номер команды: ");
                                switch (subNumCast)
                                {
                                    case 1:
                                        int indexCastInt = GetInt("Укажите номер объекта: ");
                                        if (moneyList.Contains(moneyList[indexCastInt - 1]))
                                        {
                                            int rubCast = (int)moneyList[indexCastInt - 1];
                                            Console.WriteLine($"Целая часть(рубли) объекта {moneyList[indexCastInt - 1]} с помощью приведения = {rubCast}");
                                        }
                                        else
                                             Console.WriteLine("Указанный объект не найден!");
                                        break;
                                    case 2:
                                        int indexCastDouble = GetInt("Укажите номер объекта: ");
                                        if (moneyList.Contains(moneyList[indexCastDouble - 1]))
                                        {
                                            double kopCast = moneyList[indexCastDouble - 1];
                                            Console.WriteLine($"Дробная часть(копейки) объекта {moneyList[indexCastDouble - 1]} с помощью приведения = {kopCast}");
                                        }
                                        else
                                             Console.WriteLine("Указанный объект не найден!");
                                        break;
                                }
                                break;
                            case 9:
                                key = 0;
                                Console.WriteLine();
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Команды для класса-коллекции MoneyArray:\n" +
                            "1 - Создать объект MoneyArray ручным заполнением\n" +
                            "2 - Создать объект MoneyArray заполнением случайными значениями\n" +
                            "3 - Вывести текущий объект MoneyArray\n" +
                            "4 - Найти в текущем MoneyArray минимальную сумму\n" +
                            "5 - Вернуться назад\n");
                        subKey = GetInt("Выберите номер команды: ");
                        while (subKey < 1 || subKey > 5)
                            subKey = GetInt("Неверный ввод! Выберите повторно номер команды: ");
                        switch (subKey)
                        {
                            case 1:
                                int numbersInput = GetInt("Введите количество элементов Money объекта MoneyArray: ");
                                while (numbersInput <= 0)
                                    numbersInput = GetInt("Введено недопустимое количество элементов! Повторите ввод: ");
                                banks = new MoneyArray(numbersInput);
                                Console.WriteLine("Объект MoneyArray успешно создан");
                                break;
                            case 2:
                                int numbersRandom = GetInt("Введите количество элементов Money объекта MoneyArray: ");
                                while (numbersRandom <= 0)
                                    numbersRandom = GetInt("Введено недопустимое количество элементов! Повторите ввод: ");
                                int minRandom = GetInt("Введите минимальную границу случайных значений рублей: ");
                                int maxRandom = GetInt("Введите максимальную границу случайных значений рублей: ");
                                while (minRandom > maxRandom || minRandom < 0)
                                    minRandom = GetInt("Повторите ввод нижней границы: ");
                                banks = new MoneyArray(numbersRandom, minRandom, maxRandom);
                                Console.WriteLine("Объект MoneyArray успешно создан");
                                break;
                            case 3:
                                Console.WriteLine("Текущий объект MoneyArray:");
                                Console.Write(banks);
                                Console.WriteLine("\n");
                                break;
                            case 4:
                                FindMinBank(banks);
                                break;
                            case 5:
                                key = 0;
                                Console.WriteLine();
                                break;
                        }
                        break;
                    case 3:
                        isWorking = false;
                        break;
                }
            }
        }
    }
}
