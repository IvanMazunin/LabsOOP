using System;
using System.Collections.Generic;
using static Lab11.Program;

namespace Lab11
{
    static class Menu
    {
        public static void Start()
        {
            bool isWorking = false;
            LinkedList<Person> personsLinkedList = CreateLinkedList();
            SortedDictionary<Person, Employee> personsDict = CreateDictionary();
            TestCollections testCollections = new TestCollections(TestCollections.MIN);

            while (!isWorking)
            {
                Console.WriteLine("Номера команд:\n1. 1 часть\n2. 2 часть\n3. 3 часть\n0. Назад\n");
                int key = Program.GetInt("Введите номер команды: ", "Несуществующая команда, повторите ввод =>\n", (int num) => num >= 0 && num <= 3);
                Console.Clear();
                switch (key)
                {
                    case 1:
                        Task1(ref personsLinkedList);
                        break;
                    case 2:
                        Task2(ref personsDict);
                        break;
                    case 3:
                        task3(ref testCollections);
                        break;
                    case 0:
                        isWorking = true;
                        break;
                }
            }
        }
        public static void Task1(ref LinkedList<Person> personsLinkedList)
        {
            bool isWorking = false;
            while (!isWorking)
            {
                Console.WriteLine("Номера команд:\n" +
                   "1. Генерация и вывод нового списка\n" +
                   "2. Добавить объект в список (объект добавиться в конец)\n" +
                   "3. Удалить объект из списка\n" +
                   "4. Вывести все элементы типа Person и их количество\n" +
                   "5. Вывести все элементы типа Employee и их количество\n" +
                   "6. Вывести все элементы типа Professor и их количество\n" +
                   "7. Вывести все элементы типа Student и их количество\n" +
                   "8. Выполнить клонирование коллекции\n" +
                   "9. Выполнить сортировку коллекции\n" +
                   "10. Выполнить поиск элемента в коллекции\n" +
                   "0. Назад\n");
                Console.WriteLine("Исходный список:\n");
                ShowLinkedList(personsLinkedList);
                int key = Program.GetInt("Введите номер команды: ", "Несуществующая команда, повторите ввод =>\n", (int num) => num >= 0 && num <= 10);
                switch (key)
                {
                    case 1:
                        personsLinkedList = CreateLinkedList();
                        ShowLinkedList(personsLinkedList);
                        break;
                    case 2:
                        personsLinkedList.AddLast(Person.InputPerson());
                        break;
                    case 3:
                        if (personsLinkedList.Count != 0)
                        {
                            personsLinkedList.RemoveLast();
                            Console.WriteLine($"Из конца списка удалён объект!\n");
                        }
                        else
                            Console.WriteLine("Удаление из пустого списка невозможно!\n");
                        break;
                    case 4:
                        ShowTypeInLinkedList(personsLinkedList, typeof(Person));
                        break;
                    case 5:
                        ShowTypeInLinkedList(personsLinkedList, typeof(Employee));
                        break;
                    case 6:
                        ShowTypeInLinkedList(personsLinkedList, typeof(Professor));
                        break;
                    case 7:
                        ShowTypeInLinkedList(personsLinkedList, typeof(Student));
                        break;
                    case 8:
                        LinkedList<Person> personsLinkedListCopy = CopyLinkedList(personsLinkedList);
                        int len = personsLinkedList.Count;
                        for (int i = 0; i < len; ++i)
                            Console.WriteLine($"Из конца исходного списка удалён объект!\n");
                        Console.WriteLine("Исходный список:\n");
                        ShowLinkedList(personsLinkedList);
                        Console.WriteLine("Копия списка:\n");
                        ShowLinkedList(personsLinkedListCopy);
                        personsLinkedList = CopyLinkedList(personsLinkedListCopy);
                        break;
                    case 9:
                        SortLinkedList(ref personsLinkedList);
                        Console.WriteLine("Список успешно отсортирован!\n");
                        break;
                    case 10:
                        Console.WriteLine($"Индекс элемента в списке: {FindPerson(personsLinkedList, Person.InputPerson())}");
                        break;
                    case 0:
                        isWorking = true;
                        break;
                }
            }

        }
        public static void Task2(ref SortedDictionary<Person, Employee> personsDict)
        {
            bool isWorking = false;
            while (!isWorking)
            {
                Console.WriteLine("Номера команд:\n" +
                   "1. Генерация и вывод нового словаря\n" +
                   "2. Добавить объект в словарь\n" +
                   "3. Удалить объект из словаря\n" +
                   "4. Вывести все элементы типа Employee и их количество\n" +
                   "5. Вывести все элементы типа Professor и их количество\n" +
                   "6. Вывести все элементы типа Student и их количество\n" +
                   "7. Выполнить клонирование коллекции\n" +
                   "8. Выполнить поиск элемента в коллекции\n" +
                   "0. Назад\n");
                Console.WriteLine("Исходный словарь:\n");
                ShowDictionary(personsDict);
                int key = Program.GetInt("Введите номер команды: ", "Несуществующая команда, повторите ввод =>\n", (int num) => num >= 0 && num <= 8);
                switch (key)
                {
                    case 1:
                        personsDict = CreateDictionary();
                        break;
                    case 2:
                        InsertRandomIntoDictionary(ref personsDict);
                        break;
                    case 3:
                        DeletePersonFromDictionary(ref personsDict);
                        break;
                    case 4:
                        ShowTypeInDictionary(personsDict, typeof(Employee));
                        break;
                    case 5:
                        ShowTypeInDictionary(personsDict, typeof(Professor));
                        break;
                    case 6:
                        ShowTypeInDictionary(personsDict, typeof(Student));
                        break;
                    case 7:
                        var personsDictCopy = CopyDictionary(personsDict);
                        personsDict.Clear();
                        Console.WriteLine("Исходный словарь:\n");
                        ShowDictionary(personsDict);
                        Console.WriteLine("Копия словаря:\n");
                        ShowDictionary(personsDictCopy);
                        personsDict = CopyDictionary(personsDictCopy);
                        break;
                    case 8:
                        try
                        {
                            Console.WriteLine($"Объект {personsDict[Person.InputPerson()]} содержтися в словаре!\n");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}\n");
                        }
                        break;
                    case 0:
                        isWorking = true;
                        break;
                }
            }
        }
        public static void task3(ref TestCollections testCollections)
        {
            bool isWorking = false;
            while (!isWorking)
            {
                Console.WriteLine("Номера команд:\n" +
                   "1. Генерация и вывод нового объекта TestCollections\n" +
                   "2. Добавить элемент в TestCollections\n" +
                   "3. Удалить объект из TestCollections\n" +
                   "4. Запустить тесты\n" +
                   "0. Назад\n");
                Console.WriteLine("Исходный объект TestCollections:\n");
                testCollections.Show();
                int key = Program.GetInt("Введите номер команды: ", "Несуществующая команда, повторите ввод =>\n", (int num) => num >= 0 && num <= 4);
                switch (key)
                {
                    case 1:
                        testCollections = new TestCollections(Program.GetInt("Введите длину коллекций для тестирования: ",
                $"Длина должна быть целым цислом в диапозоне [{TestCollections.MIN}, {TestCollections.MAX - 1}, повторите ввод =>\n",
                (int num) => num >= TestCollections.MIN && num <= TestCollections.MAX - 1));
                        break;
                    case 2:
                        testCollections.AddRandom();
                        break;
                    case 3:
                        testCollections.Delete();
                        break;
                    case 4:
                        testCollections.RunTests();
                        break;
                    case 0:
                        isWorking = true;
                        break;
                }
            }
        }
    }
}