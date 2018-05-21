using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeControl
{
    public class QuarterCourse
    {
        public QuarterCourse(string name, int semester, bool lk, int grade)
        {
            Name = name;
            Semester = semester;
            Lk = lk;
            Grade = grade;
        }

        public QuarterCourse(string name, int semester, bool lk, int grade, bool relevant)
        {
            Name = name;
            Semester = semester;
            Lk = lk;
            Grade = grade;
            Relevant = relevant;
        }

        public string Name { get; set; }

        public int Semester { get; set; }

        public bool Lk { get; set; }

        public int Grade { get; set; }

        public bool Relevant { get; set; } = false;
    }
}
