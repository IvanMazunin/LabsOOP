using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10
{
    //Класс реализующий интерфейс IRandomInit
    public class Subject : IRandomInit
    {
        public string name;
        public int lectureHours;
        public int practiceHours;
        public Subject()
        {
            name = "ПУСТО";
            lectureHours = 0;
            practiceHours = 0;
        }
        public Subject(string name, int lectureHours, int practiceHours)
        {
            this.name = name;
            this.lectureHours = lectureHours;
            this.practiceHours = practiceHours;
        }
        public Subject(Subject copySubject)
        {
            this.name = copySubject.name;
            this.lectureHours = copySubject.lectureHours;
            this.practiceHours = copySubject.practiceHours;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int LectureHours
        {
            get
            {
                return lectureHours;
            }
            set
            {
                lectureHours = value;
            }
        }
        public int PracticeHours
        {
            get
            {
                return practiceHours;
            }
            set
            {
                practiceHours = value;
            }
        }
        //Реализация интерфейса IRandomInit
        public void RandomInit()
        {
            string[] names = new string[] { "Теория Алгоритмов", "Искусственный интелект", "Объектно ориентированное программирование", "Базы данных", "Разработка web-приложения",
                                               "Основы алгоритмизации и программирования", "Бизнес информатика", "Учебно-исследовательская работа"  };
            Random rand = new Random();
            name = names[rand.Next(0, 8)];
            lectureHours = rand.Next(8, 17);
            practiceHours = rand.Next(30, 61);
        }
    }
    public class RecordBookLine : Subject, ICloneable
    {
        public int finalMark;
        public Subject subject;
        public RecordBookLine()
        {
            finalMark = 0;
            subject = new Subject();
        }
        public RecordBookLine(Subject subject, int finalMark)
        {
            this.subject = subject;
            this.finalMark = finalMark;
        }

        public override string ToString()
        {
            return $"{subject}\n Итоговая оценка:{finalMark}\n";
        }
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
        public object Clone()
        {
            return new RecordBookLine(this.subject, this.finalMark);
        }
    }
}