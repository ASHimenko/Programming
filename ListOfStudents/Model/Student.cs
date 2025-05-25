using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfStudents.Model
{
    [Serializable]
    public class Student
    {
        public string FullName { get; set; }
        public int RecordBookId { get; }
        public string Group { get; set; }
        public Faculty Faculty { get; set; }
        public EducationForm EducationForm { get; set; }

        public Student(string fullName, int recordBookId, string group,
                     Faculty faculty, EducationForm educationForm)
        {
            FullName = fullName;
            RecordBookId = recordBookId;
            Group = group;
            Faculty = faculty;
            EducationForm = educationForm;
        }

        public override string ToString() => $"{FullName} - {Group} / {Faculty}";
    }
}
