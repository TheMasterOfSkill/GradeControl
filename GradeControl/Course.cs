using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public Course(string name, int fb, bool lK, int e1, int e2, int q1, int q2, int q3, int q4, bool pe3Std)
        {
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

        public bool AttendedInQ()
        {
            if (Q1 >= 0 || Q2 >= 0 || Q3 >= 0 || Q4 >= 0)
                return true;
            else
                return false;
        }

        public int Predict(bool setting)
        {
            int num = 0, tot = 0;
            if (Q1 >= 0 && Q1 <= 15)
            {
                num++;
                tot += Q1;
            }
            if (Q2 >= 0 && Q1 <= 15)
            {
                num++;
                tot += Q2;
            }
            if (Q3 >= 0 && Q1 <= 15)
            {
                num++;
                tot += Q3;
            }
            if (Q4 >= 0 && Q1 <= 15)
            {
                num++;
                tot += Q4;
            }

            int prediction = (int)Math.Round((double)tot / (double)num) + 16;

            MessageBox.Show(tot.ToString() + "\n" + num.ToString());

            if(setting)
            {
                if (Q1 == -2)
                {
                    Q1 = prediction;
                }
                if (Q2 == -2)
                {
                    Q1 = prediction;
                }
                if (Q3 == -2)
                {
                    Q1 = prediction;
                }
                if (Q4 == -2)
                {
                    Q1 = prediction;
                }
            }

            return prediction;
        }

        public static List<CourseItem> GetCourseItems(MainWindow mw, Course[] courses)
        {
            List<CourseItem> courseItems = new List<CourseItem>();

            foreach (var course in courses)
                courseItems.Add(new CourseItem(mw, course.Name, course.Q1, course.Q2, course.Q3, course.Q4));

            return courseItems;
        }
    }
}
