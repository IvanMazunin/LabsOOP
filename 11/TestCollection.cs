﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using static Lab11.Program;

namespace Lab11
{
    class TestCollections
    {
        public const int MIN = 5;  //включительно
        public const int MAX = 11;  //не включительно
        public LinkedList<Person> personsLinkedList { get; set; }
        public LinkedList<string> stringLinkedList { get; set; }
        public SortedDictionary<Person, Employee> personsDict { get; set; }
        public SortedDictionary<string, Employee> stringDict { get; set; }
        public TestCollections(int len)
        {
            personsLinkedList = new LinkedList<Person>();
            stringLinkedList = new LinkedList<string>();
            personsDict = new SortedDictionary<Person, Employee>();
            stringDict = new SortedDictionary<string, Employee>();
            for (int i = 0; i < len; ++i)
            {
                try
                {
                    Employee employee = new Employee();
                    personsDict.Add(employee.BasePerson, employee);
                }
                catch
                {
                    --i;
                    continue;
                }
            }
            foreach (var person in personsDict)
            {
                personsLinkedList.AddLast(person.Key);
                stringLinkedList.AddLast(person.Key.ToString());
                stringDict.Add(person.Key.ToString(), person.Value);
            }
        }
        public void Show()
        {
            Console.WriteLine("LinkedList<Person>:\n");
            ShowLinkedList(personsLinkedList);

            Console.WriteLine("SortedDictionary<Person, Employee>:\n");
            ShowDictionary(personsDict);
        }
        public void RunTests()
        {
            if (personsDict.Count != 0)
            {
                Employee[] employees = new Employee[personsDict.Count];
                personsDict.Values.CopyTo(employees, 0);

                Employee emp = employees[0];
                Console.WriteLine($"Первый элемент коллекций: {emp}\n");
                GetMeasurements(emp);

                emp = employees[employees.Length / 2];
                Console.WriteLine($"Элемент из середины коллекций: {emp}\n");
                GetMeasurements(emp);

                emp = employees[employees.Length - 1];
                Console.WriteLine($"Элемент из конца коллекций: {emp}\n");
                GetMeasurements(emp);

                emp = new Employee();
                Console.WriteLine($"Несуществующий элемент: \n");
                GetMeasurements(emp);
            }
            else
            {
                Console.WriteLine("Нельзя запустить тестирование для коллекций без элементов!\n");
            }
        }
        private void GetMeasurements(Employee emp)
        {
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts;
            bool isFind;

            Person pers = emp.BasePerson;
            string persStr = pers.ToString();

            Console.Write("Объект найден в коллекции LinkedList<Person>: ");
            stopWatch.Start();
            isFind = personsLinkedList.Contains(pers);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(isFind.ToString() + ", время поиска: [" + ts.Ticks + "] такта");
            stopWatch.Reset();

            Console.Write("Объект найден в коллекции LinkedList<string>: ");
            stopWatch.Start();
            isFind = stringLinkedList.Contains(persStr);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(isFind.ToString() + ", время поиска: [" + ts.Ticks + "] такта");
            stopWatch.Reset();

            Console.Write("Объект найден по ключу в коллекции SortedDictionary<Person, Employee>: ");
            stopWatch.Start();
            isFind = personsDict.ContainsKey(pers);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(isFind.ToString() + ", время поиска:  [" + ts.Ticks + "] такта");
            stopWatch.Reset();

            Console.Write("Объект найден по ключу в коллекции SortedDictionary<string, Employee>: ");
            stopWatch.Start();
            isFind = stringDict.ContainsKey(persStr);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(isFind.ToString() + ", время поиска: [" + ts.Ticks + "] такта");
            stopWatch.Reset();

            Console.Write("Объект найден по значению в коллекции SortedDictionary<Person, Employee>: ");
            stopWatch.Start();
            isFind = stringDict.ContainsValue(emp);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(isFind.ToString() + ", время поиска: [" + ts.Ticks + "] такта");
            stopWatch.Reset();
        }
        public void AddRandom()
        {
            Employee employee = new Employee();
            try
            {
                personsDict.Add(employee.BasePerson, employee);
                stringLinkedList.Clear();
                personsLinkedList.Clear();
                stringDict.Clear();
                foreach (var person in personsDict)
                {
                    personsLinkedList.AddLast(person.Key);
                    stringLinkedList.AddLast(person.Key.ToString());
                    stringDict.Add(person.Key.ToString(), person.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка генерации: " + ex.Message + "\n");
            }
        }
        public void Delete()
        {
            Person key = Person.InputPerson();
            if (personsDict.Remove(key))
            {
                Console.WriteLine($"Объект: {key}, успешно удалён!\n");
            }
            else
            {
                Console.WriteLine("Такого ключа нет в словаре!\n");
            }
            stringLinkedList.Clear();
            personsLinkedList.Clear();
            stringDict.Clear();
            foreach (var person in personsDict)
            {
                personsLinkedList.AddLast(person.Key);
                stringLinkedList.AddLast(person.Key.ToString());
                stringDict.Add(person.Key.ToString(), person.Value);
            }
        }
    }
}