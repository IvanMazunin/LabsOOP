using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10
{
    public class Menu
    {
        private Person[] persons;
        int objCount;
        bool isWorking;

        public Menu()
        {
            persons = new Person[10];
            objCount = 0;
            isWorking = true;
        }
        public Menu(int len)
        {
            persons = new Person[len];
            objCount = 0;
            isWorking = true;
        }
        //Реализация запроса вывода имен сотрудников заданной профессии
        public static void QueryTitleSearch(ref Person[] persons, string jobTitle)
        {
            Console.WriteLine($"Сотрудники професии {jobTitle}: ");
            foreach (var obj in persons)
            {
                if (obj is Employee)
                {
                    Employee employee = obj as Employee;
                    if (employee.JobTitle == jobTitle)
                        Console.WriteLine($"{employee.FirstName} {employee.LastName}");
                }
            }
            Console.WriteLine();
        }
        //Реализация запроса вывода имен лиц мужского пола
        public static void QueryMenSearch(ref Person[] persons)
        {
            Console.WriteLine($"Мужчины: ");
            foreach (var obj in persons)
                if (obj.Gender== "Мужчина")
                    Console.WriteLine($"{obj.FirstName} {obj.LastName}");
            Console.WriteLine();
        }
        //Реализация запроса вывода имен студентов заданного курса
        public static void QueryYearStudentSearch(ref Person[] persons, int year)
        {
            Console.WriteLine($"Студенты {year} курса: ");
            foreach (var obj in persons)
            {
                if (obj is Student)
                {
                    Student student = obj as Student;
                    if (student.Year == year)
                        Console.WriteLine($"{student.FirstName} {student.LastName}");
                }
            }
            Console.WriteLine();
        }
        public static void AddNew(object newElement, ref int objCount, ref Person[] persons)
        {
            if (objCount < persons.Length && (newElement is Person))
            {
                persons[objCount] = (Person)newElement;
                ++objCount;
            }
            else if (objCount >= persons.Length)
                Console.WriteLine("Достигнут лимит объектов массива!");
            else if (!(newElement is Person))
                Console.WriteLine("Объект не является частью иерархии Person!");
        }
        public void Output(ref int objCount)
        {
            for (int i = 0; i < objCount; i++)
            {
                Console.Write($"Объект: {persons[i].GetType()}\n");
                persons[i].VirtualShow();
                Console.WriteLine();
            }
        }
        public static int GetInt(string message)
        {
            int key;
            bool isCorrect;
            do
            {
                Console.Write(message);
                isCorrect = int.TryParse(Console.ReadLine(), out key);
                if (!isCorrect)
                    Console.WriteLine("Введено недопустимое значение!");
            } while (!isCorrect);
            return key;
        }
        public void MainMenu()
        {
            while (isWorking)
            {
                Console.WriteLine("Команды для массива объектов иерархии классов Person:\n" +
                    "1 - Вывести текущий массив объектов\n" +
                    "2 - Добавить новый объект в массив типа Person со случайными значениями\n" +
                    "3 - Добавить новый объект в массив типа Employee со случайными значениями\n" +
                    "4 - Добавить новый объект в массив типа Professor со случайными значениями\n" +
                    "5 - Добавить новый объект в массив типа Student со случайными значениями\n" +
                    "6 - Вывод элемента с помощью виртуального метода\n" +
                    "7 - Вывод элемента с помощью не виртуального метода\n" +
                    "8 - Запросы к массиву объектов\n" +
                    "9 - Сортировка элементов массива по возрасту с помощью интерфейса IComparable\n" +
                    "10 - Сортировка элементов массива по имени с помощью интерфейса IComparer\n" +
                    "11 - Поиск элемента в массиве по названию с помощью метода Equals\n" +
                    "12 - Поверхностное клонирование объекта RecordBookLine (класс, не связанный с иерархией Person)\n" +
                    "13 - Глубокое клонирование объекта RecordBookLine\n" +
                    "14 - Выход\n");
                int key = GetInt("Выберите номер команды: ");
                while (key < 1 || key > 14)
                    key = GetInt("Неверный номер команды! Повторный ввод: ");
                switch (key)
                {
                    case 1:
                        if (objCount > 0)
                            Output(ref objCount);
                        else
                            Console.WriteLine("Невозможно вывести!");
                        break;
                    case 2:
                        Person person = new Person();
                        person.RandomInit();
                        AddNew(person, ref objCount, ref persons);
                        break;
                    case 3:
                        Employee employee = new Employee();
                        employee.RandomInit();
                        AddNew(employee, ref objCount, ref persons);
                        break;
                    case 4:
                        Professor professor = new Professor();
                        professor.RandomInit();
                        AddNew(professor, ref objCount, ref persons);
                        break;
                    case 5:
                        Student student = new Student();
                        student.RandomInit();
                        AddNew(student, ref objCount, ref persons);
                        break;
                    case 6:
                        int virtualNumber = GetInt("Введите номер объекта в массиве: ");
                        while (virtualNumber < 0 || virtualNumber > persons.Length)
                            virtualNumber = GetInt("Недопустимое значение! Повторите ввод: ");
                        persons[virtualNumber - 1].VirtualShow();
                        break;
                    case 7:
                        int number = GetInt("Введите номер объекта в массиве: ");
                        while (number < 0 || number > persons.Length)
                            virtualNumber = GetInt("Недопустимое значение! Повторите ввод: ");
                        persons[number - 1].Show();
                        break;
                    case 8:
                       bool isWorkingQuery = true;
                       int keyQuery = 0;
                       switch (keyQuery)
                       {
                            case 0:
                                Console.WriteLine("Запросы для массива объектов:\n" +
                                              "1 - Вывод имен лиц мужского пола\n" +
                                              "2 - Вывод имен сотрудников заданной профессии\n" +
                                              "3 - Вывод имен студентов заданного курса\n" +
                                              "4 - Вернуться назад\n");
                                keyQuery = GetInt("Введите номер команды: ");
                                while (keyQuery < 1 || keyQuery > 4)
                                    keyQuery = GetInt("Введено недопустимое значение! Повторите ввод: ");
                                break;
                            case 1:
                                QueryMenSearch(ref persons);
                                break;
                            case 2:
                                int jobKey = GetInt("Введите название специальности для поиска:\n" +
                                        "1 - Охранник\n" +
                                        "2 - Вахтёр\n" +
                                        "3 - Преподаватель\n" +
                                        "3 - Лаборант\n" +
                                        "4 - Уборщик\n");
                                while (key < 1 || key > 5)
                                    jobKey = GetInt("Неверное значение!Повторите ввод: ");
                                switch (keyQuery)
                                {
                                    case 1:
                                        QueryTitleSearch(ref persons, "Охранник");
                                        break;
                                    case 2:
                                        QueryTitleSearch(ref persons, "Вахтёр");
                                        break;
                                    case 3:
                                        QueryTitleSearch(ref persons, "Преподаватель");
                                        break;
                                    case 4:
                                        QueryTitleSearch(ref persons, "Лаборант");
                                        break;
                                    case 5:
                                        QueryTitleSearch(ref persons, "Уборщик");
                                        break;
                                }
                                break;
                            case 3:
                                int year = GetInt("Введите номер курса от 1 до 6: ");
                                while (key < 1 || key > 6)
                                    year = GetInt("Неверное значение!Повторите ввод: ");
                                QueryYearStudentSearch(ref persons, year);
                                break;
                            case 4:
                                isWorkingQuery = false;
                                break;
                       }
                       break;
                    case 9:
                        Console.WriteLine("Отсортированный массив по возрасту:\n");
                        Array.Sort(persons);
                        Output(ref objCount);
                        break;
                    case 10:
                        Console.Write("Отсортированный массив по имени:\n");
                        Array.Sort(persons, new SortByType());
                        Output(ref objCount);
                        break;
                    case 11:
                        Console.Write("Введите искомый FirstName: ");
                        string searchName = Console.ReadLine();
                        Array.Sort(persons);
                        foreach (var obj in persons)
                        {
                            if (Person.Equals(obj.FirstName, searchName))
                            {
                                Console.WriteLine($"Объект с указанным FirstName ({searchName}) найден:");
                                obj.VirtualShow();
                            }
                        }
                        break;
                    case 12:
                        Subject subj = new Subject("Теория алгоритмов", 12, 32);
                        RecordBookLine recordBookLine = new RecordBookLine(subj, 5);
                        RecordBookLine copyRecordBookLine = (RecordBookLine)recordBookLine.ShallowCopy();
                        Console.WriteLine($"Изначальный объект:\n{recordBookLine}");
                        Console.WriteLine($"Поверхностно скопированный объект:\n{copyRecordBookLine}");
                        Console.WriteLine($"Изначальный объект после изменения его поверхностной копии:\n{recordBookLine}");
                        Console.WriteLine($"Поверхностно скопированный объект после его изменения:\n{copyRecordBookLine}");
                        break;
                    case 13:
                        Subject deepCar = new Subject("Теория алгоритмизации", 16, 78);
                        RecordBookLine deepRecordBookLine = new RecordBookLine(deepCar, 4);
                        RecordBookLine deepCopyRecordBookLine = (RecordBookLine)deepRecordBookLine.Clone();
                        Console.WriteLine($"Изначальный объект:\n{deepRecordBookLine}");
                        Console.WriteLine($"Глубоко скопированный объект:\n{deepCopyRecordBookLine}");
                        Console.WriteLine($"Изначальный объект после изменения его глубокой копии:\n{deepRecordBookLine}");
                        Console.WriteLine($"Глубоко скопированный объект после его изменения:\n{deepCopyRecordBookLine}");
                        break;
                    case 14:
                        isWorking = false;
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}