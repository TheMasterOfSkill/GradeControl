using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeControl
{
    public class Course
    {
        public Course(int id, string name, int fb, bool lK, int e1, int e2, int q1, int q2, int q3, int q4, bool pe3Std)
        {
            Id = id;
            Name = name;
            Fb = fb;
            LK = lK;
            E1 = e1;
            E2 = e2;
            Q1 = q1;
            Q2 = q2;
            Q3 = q3;
            Q4 = q4;
            Pe3Std = pe3Std;
        }

        public Course() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Fb { get; set; }

        public bool LK { get; set; }

        public int E1 { get; set; }

        public int E2 { get; set; }

        public int Q1 { get; set; }

        public int Q2 { get; set; }

        public int Q3 { get; set; }

        public int Q4 { get; set; }

        public bool Pe3Std { get; set; }

    }
}
