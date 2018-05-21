using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeControl
{
    public class CourseItem
    {
        private int q1, q2, q3, q4;

        public CourseItem(string name, int q1a, int q2a, int q3a, int q4a)
        {
            Fach = name;
            q1 = q1a;
            q2 = q2a;
            q3 = q3a;
            q4 = q4a;
        }

        public string Fach { get; set; }
        public int Q1
        {
            get
            {
                return q1;
            }
            set
            {
                if (value < 0)
                    q1 = 0;
                else if (value > 15)
                    q1 = 15;
                else
                    q1 = value;
            }
        }
        public int Q2
        {
            get
            {
                return q2;
            }
            set
            {
                if (value < 0)
                    q2 = 0;
                else if (value > 15)
                    q2 = 15;
                else
                    q2 = value;
            }
        }
        public int Q3
        {
            get
            {
                return q3;
            }
            set
            {
                if (value < 0)
                    q3 = 0;
                else if (value > 15)
                    q3 = 15;
                else
                    q3 = value;
            }
        }
        public int Q4
        {
            get
            {
                return q4;
            }
            set
            {
                if (value < 0)
                    q4 = 0;
                else if (value > 15)
                    q4 = 15;
                else
                    q4 = value;
            }
        }
    }
}
