using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExtensions
{
    public static class StudentsLinqExtensions
    {
        public static List<Student> BudgetRank(this List<Student> students, int num, int esbp)
        {
            return students.Where(s => s.Subjects.Sum(sub => sub.ESBP) >= esbp).OrderByDescending(s => s.GPA).Take(num).ToList();
        }

        public static List<Student> BudgetRank2(this List<Student> students, int num, int esbp)
        {
            return students.Where(s => s.Subjects.Sum(sub => sub.ESBP) >= esbp).OrderByDescending(s => s.GPA).Take(num).ToList();
        }
    }
}
