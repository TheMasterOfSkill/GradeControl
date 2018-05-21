using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeControl
{
    public class RelevantCourse
    {
        public RelevantCourse(string name, bool q1, bool q2, bool q3, bool q4)
        {
            Name = name;
            Q1 = q1;
            Q2 = q2;
            Q3 = q3;
            Q4 = q4;
        }

        public string Name { get; set; }

        public bool Q1 { get; set; }

        public bool Q2 { get; set; }

        public bool Q3 { get; set; }

        public bool Q4 { get; set; }
    }
}
