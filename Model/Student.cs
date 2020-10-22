using System;
using System.Collections.Generic;

namespace Model
{
    public class Student
    {
        public long StudentId { get; set; }
        public int YearOfEnrollment { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double GPA { get; set; }

        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public override string ToString()
        {
            return $"{StudentId}/{YearOfEnrollment} {Name} {Lastname} {GPA} {DateOfBirth.ToString("dd.MM.yyyy.")}";
        }
    }
}
