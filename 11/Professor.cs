using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    public class Professor : Employee
    {
        private List<string> subjects = new List<string>(2);
        protected readonly string[] someSubjects = new string[] { "Теория Алгоритмов", "Искусственный интелект", "Объектно ориентированное программирование", "Базы данных", "Разработка web-приложения",
                                                                  "Основы алгоритмизации и программирования", "Бизнес информатика", "Учебно-исследовательская работа"  };
        public Professor()
        {
            this.RandomInit();
        }
        public Professor(string firstName, string lastName, string gender, int age, string jobTitle, List<string> subjects) : base(firstName, lastName, gender, age, jobTitle)
        {
            this.JobTitle = "Профессор";
            this.subjects = new List<string>(subjects);
        }
        public Professor(Professor copyProfessor)
        {
            this.FirstName = copyProfessor.FirstName;
            this.LastName = copyProfessor.LastName;
            this.Gender = copyProfessor.Gender;
            this.Age = copyProfessor.Age;
            this.JobTitle = copyProfessor.JobTitle;
            this.subjects = copyProfessor.subjects;
        }
        public Person BasePerson
        {
            get
            {
                return new Person(this.FirstName, this.LastName, this.Gender, this.Age);
            }
        }
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < subjects.Count)
                    return subjects[index];
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < subjects.Count)
                    subjects[index] = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public List<string> Subjects
        {
            get
            {
                return subjects;
            }
            set
            {
                subjects = value;
            }
        }
        public override string ToString()
        {
            string s = "";
            s = $"Сотрудник: {this.FirstName} {this.LastName}\n Пол: {this.Gender}\n Возраст: {this.Age}\n Должность: {this.JobTitle}\n";

            s += "Предметы: ";
            foreach (var subject in subjects)
            {
                s += $"{subject}, ";
            }
            return s;
        }
        public void AddSubject(string newSubject)
        {
            subjects.Add(newSubject);
        }

        public override void RandomInit()
        {
            Random rand = new Random();
            this.FirstName = firstNames[rand.Next(0, 10)];
            this.LastName = lastNames[rand.Next(0, 10)];
            this.Gender = genders[rand.Next(0, 2)];
            this.Age = rand.Next(18, 71);
            this.JobTitle = "Преподаватель";
            for (int i = 0; i < 2; i++)
            {
                this.subjects.Add(someSubjects[rand.Next(0, 5)]);
                System.Threading.Thread.Sleep(15);
            }
        }
    }
}