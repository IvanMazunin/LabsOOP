using System;
using System.Collections.Generic;

namespace Lab11
{
    class Program
    {
        public const int MIN = 5;  
        public const int MAX = 11;
        static void Main(string[] args)
        {
            Menu.Start();
            return;
        }
        public static SortedDictionary<Person, Employee> CreateDictionary()
        {
            Random rnd = new Random();
            int len = rnd.Next(MIN, MAX);
            SortedDictionary<Person, Employee> persons = new SortedDictionary<Person, Employee>();
            for (int i = 0; i < len; ++i)
            {
                try
                {
                    switch (rnd.Next(0, 2))
                    {
                        case 0:
                            Employee employee = new Employee();
                            persons.Add(employee.BasePerson, employee);
                            break;
                        case 1:
                            Professor engineer = new Professor();
                            persons.Add(engineer.BasePerson, engineer);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка генерации: " + ex.Message + "\n");
                    continue;
                }
            }
            return persons;
        }
        public static void ShowDictionary(SortedDictionary<Person, Employee> persons)
        {
            if (persons.Count != 0)
            {
                int counter = 0;
                foreach (var person in persons)
                {
                    Console.WriteLine($"{counter++}. Ключ: ");
                    Console.Write(person.Key);
                    Console.WriteLine("\nЗначение: ");
                    Console.WriteLine(person.Value.ToString() + '\n');
                }
            }
            else
            {
                Console.WriteLine("Словарь пуст!\n");
            }
        }
        public static void ShowTypeInDictionary(SortedDictionary<Person, Employee> persons, Type t)
        {
            int counter = 0;
            int index = 0;
            if (t == typeof(Employee))
            {
                Console.WriteLine("Элементы типа Employee:\n");
                foreach (var emp in persons)
                {
                    if (emp.Value != null && (emp.Value is Employee) && !(emp.Value is Professor) && !(emp.Value is Student))
                    {
                        Console.WriteLine(index.ToString() + ". " + emp.Value.ToString());
                        counter++;
                    }
                    index++;
                }
                Console.WriteLine("Кол-во элементов типа Employee: " + counter);
            }
            else if (t == typeof(Professor))
            {
                Console.WriteLine("Элементы типа Professor:\n");
                foreach (var eng in persons)
                {
                    if (eng.Value != null && (eng.Value is Professor))
                    {
                        Console.WriteLine(index.ToString() + ". " + eng.Value.ToString());
                        counter++;
                    }
                    index++;
                }
                Console.WriteLine("Кол-во элементов типа Professor: " + counter);
            }
            if (counter == 0)
                Console.WriteLine("Такого типа нет в коллекции!\n");
            return;
        }
        public static void InsertRandomIntoDictionary(ref SortedDictionary<Person, Employee> persons)
        {
            Random rnd = new Random();
            try
            {
                switch (rnd.Next(0, 2))
                {
                    case 0:
                        Employee employee = new Employee();
                        persons.Add(employee.BasePerson, employee);
                        Console.WriteLine($"Добавлен объект: {persons[employee.BasePerson]}\n");
                        break;
                    case 1:
                        Professor engineer = new Professor();
                        persons.Add(engineer.BasePerson, engineer);
                        Console.WriteLine($"Добавлен объект: {persons[engineer.BasePerson]}\n");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка генерации: " + ex.Message + "\n");
            }
        }
        public static void DeletePersonFromDictionary(ref SortedDictionary<Person, Employee> persons)
        {
            Person key = Person.InputPerson();
            if (persons.Remove(key))
            {
                Console.WriteLine($"Объект: {key}, успешно удалён!\n");
            }
            else
            {
                Console.WriteLine("Такого ключа нет в словаре!\n");
            }
        }
        public static SortedDictionary<Person, Employee> CopyDictionary(SortedDictionary<Person, Employee> persons)
        {
            var result = new SortedDictionary<Person, Employee>();
            foreach (var pair in persons)
            {
                result.Add((Person)pair.Key.Clone(), (Employee)pair.Value.Clone());
            }
            return result;
        }
        public static LinkedList<Person> CreateLinkedList()
        {
            Random rnd = new Random();
            int len = rnd.Next(MIN, MAX);
            LinkedList<Person> persons = new LinkedList<Person>();
            for (int i = 0; i < len; ++i)
            {
                switch (rnd.Next(0, 3))
                {
                    case 0:
                        persons.AddLast(new Person());
                        break;
                    case 1:
                        persons.AddLast(new Employee());
                        break;
                    case 2:
                        persons.AddLast(new Professor());
                        break;
                }
            }
            return persons;
        }
        public static void SortLinkedList(ref LinkedList<Person> persons)
        {
            Person[] p = persons.ToArray();
            Array.Sort(p);
            LinkedList<Person> result = new LinkedList<Person>();
            for (int i = 0; i < p.Length; ++i)
            {
                result.AddLast(p[i]);
            }
            persons = result;
        }
        public static void ShowLinkedList(LinkedList<Person> persons)
        {
            if (persons.Count != 0)
            {
                string result = "";
                int counter = 0;
                foreach (Person p in persons)
                {
                    if (p != null)
                        result += $"\t{counter}. " + p.ToString() + '\n';
                    else
                        result += "\tNULL\n";
                    counter++;
                }
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Список пуст!\n");
            }
        }
        public static void ShowTypeInLinkedList(LinkedList<Person> persons, Type t)
        {
            int counter = 0;
            int index = 0;
            if (t == typeof(Person))
            {
                Console.WriteLine("Элементы типа Person: ");
                foreach (Person p in persons)
                {
                    if (p != null && !(p is Employee))
                    {
                        Console.WriteLine(index.ToString() + ". " + p.ToString());
                        counter++;
                    }
                    index++;
                }
                Console.WriteLine("Кол-во элементов типа Person: " + counter);
            }
            else if (t == typeof(Employee))
            {
                Console.WriteLine("Элементы типа Employee: ");
                foreach (Person p in persons)
                {
                    if (p != null && p is Employee && !(p is Professor) && !(p is Student))
                    {
                        Console.WriteLine(index.ToString() + ". " + p.ToString());
                        counter++;
                    }
                    index++;
                }
                Console.WriteLine("Кол-во элементов типа Employee: " + counter);
            }
            else if (t == typeof(Professor))
            {
                Console.WriteLine("Элементы типа Professor: ");
                foreach (Person p in persons)
                {
                    if (p != null && p is Professor)
                    {
                        Console.WriteLine(index.ToString() + ". " + p.ToString());
                        counter++;
                    }
                    index++;
                }
                Console.WriteLine("Кол-во элементов типа Professor: " + counter);
            }
            if (counter == 0)
                Console.WriteLine("Такого типа нет в коллекции!\n");
            return;
        }
        public static LinkedList<Person> CopyLinkedList(LinkedList<Person> persons)
        {

            LinkedList<Person> result = new LinkedList<Person>();
            foreach (Person p in persons)
                result.AddLast((Person)p.Clone());
            return result;
        }
        public static int FindPerson(LinkedList<Person> persons, Person person)
        {
            int index = -1;
            int counter = 0;
            foreach (Person p in persons)
            {

                if (p.Equals(person))
                {
                    index = counter;
                    break;
                }
                counter += 1;
            }
            return index;
        }
        public static int GetInt(string inputMessage, string errorMessage, Predicate<int> condition)
        {
            int result;
            bool isCorrect;
            do
            {
                Console.Write(inputMessage);
                isCorrect = int.TryParse(Console.ReadLine(), out result) && condition(result);
                if (!isCorrect)
                    Console.WriteLine(errorMessage);
            } while (!isCorrect);
            return result;
        }      
    }
}