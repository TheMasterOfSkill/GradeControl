using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeControl
{
    public class Exam
    {
        public Exam(int id, string name, int grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Grade { get; set; }
    }
}
