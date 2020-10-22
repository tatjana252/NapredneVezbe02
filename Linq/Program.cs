using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqExtensions;
using System.Linq.Expressions;

namespace Linq
{
    class Program
    {
        static List<Student> students = new List<Student>();

        static Program()
        {
            students.Add(new Student { StudentId = 1, Name = "Pera", Lastname = "Peric", DateOfBirth = new DateTime(1997, 6, 6), YearOfEnrollment = 2016, GPA = 9.45 });
            students.Add(new Student { StudentId = 2, Name = "Mika", Lastname = "Mikic", DateOfBirth = new DateTime(1996, 6, 6), YearOfEnrollment = 2016, GPA = 7.1 });
            students.Add(new Student { StudentId = 3, Name = "Zika", Lastname = "Zikic", DateOfBirth = new DateTime(1998, 6, 6), YearOfEnrollment = 2017, GPA = 8.2 });
            students.Add(new Student { StudentId = 4, Name = "Jovana", Lastname = "Jovana", DateOfBirth = new DateTime(1992, 6, 6), YearOfEnrollment = 2012, GPA = 6.9 });
            students.Add(new Student { StudentId = 5, Name = "Ana", Lastname = "Anic", DateOfBirth = new DateTime(1997, 6, 6), YearOfEnrollment = 2017, GPA = 8.8 });
        }


        static void Main(string[] args)
        {
            //Student s404 = students.SingleOrDefault(s => s.StudentId == 404);
            //Console.WriteLine(s404);

            //double avg = students.Average(s => s.GPA);
            //Console.WriteLine("Average: " + avg);

            //List<Student> students1 = students.Where(s => s.GPA > 8).ToList();
            //students.ForEach(s => Console.WriteLine(s));

            //double avg2016 = students.Where(s => s.YearOfEnrollment == 2016).Average(s => s.GPA);
            //Console.WriteLine(avg2016);

            //Console.WriteLine(maxGpa);

            //Student s = students.First(s =>
            //{ 
            //    return s.GPA == students.Max(s => s.GPA);
            //});

            students.OrderByDescending(s => s.GPA).Take(3).ToList().ForEach(s => Console.WriteLine(s));
            //students.OrderByDescending(s => s.GPA).Skip(3).Take(3).ToList().ForEach(s => Console.WriteLine(s));

            //students.OrderByDescending(s => s.GPA).Select(s =>
            //{
            //    return new { Fullname = $"{s.Name} {s.Lastname}", s.GPA };
            //}).ToList().ForEach(s => { Console.WriteLine(s.Fullname + s.GPA); });

            //students.BudgetRank(3, 0).ForEach(s => Console.WriteLine(s));

            //if(students.Any(s => s.StudentId == 4))
            //{

            //}

            //students.All(s=> s.Name!=null);
            //students.OfType<Student>();

            Student s = PronadjiPoIndeksu(45, 2012);
            Student pera = PronadjiImePrezime("Pera", "Peric");

            //Student student = Pronadji(UslovPeraPeric);
            //Console.WriteLine(student);

            Student student1 = Pronadji(UslovImePrezime("Pera", "Peric"));
            Console.WriteLine(student1);

            Student student2 = PronadjiFunc(s =>
            {
                return s.Name == "Pera" && s.Lastname == "Peric";
            });

            Foreach((s) => Console.WriteLine(s));
        }

        public delegate bool Uslov(Student s);

        public static bool UslovPeraPeric(Student s)
        {
            return s.Name == "Pera" && s.Lastname == "Peric";
        }

        public static Uslov UslovImePrezime(string ime, string prezime)
        {
            return delegate (Student s)
            {
                return s.Name == ime && s.Lastname == prezime;
            };
        }




        public static Student PronadjiPoIndeksu(int broj, int godina)
        {
            foreach (Student s in students)
            {
                if (s.StudentId == broj && s.YearOfEnrollment == godina)
                {
                    return s;
                }
            }
            return null;
        }

        public static Student PronadjiImePrezime(string ime, string prezime)
        {
            foreach (Student s in students)
            {
                if (s.Name == ime && s.Lastname == prezime)
                {
                    return s;
                }
            }
            return null;
        }

        public static Student Pronadji(Uslov uslov)
        {
            foreach (Student s in students)
            {
                if (uslov(s))
                {
                    return s;
                }
            }
            return null;
        }

        public static Student PronadjiFunc(Func<Student, bool> uslov)
        {
            foreach (Student s in students)
            {
                if (uslov(s))
                {
                    return s;
                }
            }
            return null;
        }

        public static Student PronadjiExp(Expression<Func<Student, bool>> uslov)
        {
            foreach (Student s in students)
            {
                if ((uslov.Compile())(s))
                {
                    return s;
                }
            }
            return null;
        }

        public static Student PronadjiPredicate(Predicate<Student> uslov)
        {
            foreach (Student s in students)
            {
                if (uslov(s))
                {
                    return s;
                }
            }
            return null;
        }

        public static Student Foreach(Action<Student> action)
        {
            foreach (Student s in students)
            {
                action(s);
            }
            return null;
        }

    }
}
