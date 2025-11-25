using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public double Grade { get; set; }

        public Student() { }

        public Student(string id, string name, string className, double grade)
            {
            Id = id;
            Name = name;
            Class = className;
            Grade = grade;
        }
        public override string ToString()
            {
            return $"{Id} - {Name} - {Class} - {Grade}";
        }
        public bool IsValid()
            {
            return !string.IsNullOrWhiteSpace(Id)
                && !string.IsNullOrWhiteSpace(Name)
                && !string.IsNullOrWhiteSpace(Class)
                && Grade >= 0 && Grade <= 10;
        }

    }
}
