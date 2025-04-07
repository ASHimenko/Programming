using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model
{
    public class Discipline
    {
        private string _name;
        private int _grade;
        private string _lecturer;


        public Discipline() { }


        public Discipline(string name, int grade, string lecturer)
        {
            Name = name;
            Grade = grade;
            Lecturer = lecturer;
        }


        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название дисциплины не может быть пустым.");
                _name = value;
            }
        }

        public int Grade
        {
            get { return _grade; }
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentException("Оценка должна быть от 0 до 10.");
                _grade = value;
            }
        }

        public string Lecturer
        {
            get { return _lecturer; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Преподаватель не может быть пустым.");
                _lecturer = value;
            }
        }
    }
}
