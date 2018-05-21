using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeControl
{
    public class ExamItem
    {
        private int grade;

        public ExamItem(string name, int grade)
        {
            Fach = name;
            Notenpkt = grade;
        }

        public string Fach { get; set; }
        public int Notenpkt
        {
            get
            {
                return grade;
            }
            set
            {
                if (value < 0)
                    grade = 0;
                else if (value > 15)
                    grade = 15;
                else
                    grade = value;
            }
        }
    }
}
