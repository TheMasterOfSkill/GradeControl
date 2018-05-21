using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GradeControl
{
    /// <summary>
    /// Interaktionslogik für ChosenExams.xaml
    /// </summary>
    public partial class ChosenExams : Window
    {
        private MainWindow mainWindow;
        private bool lkChange = true;
        private List<Course> gk3s;
        private List<Course> gk4s;
        private Course[] allCourses;
        private Course[] lks;
        private Course[] testableGKs;
        private Course lk1Course;
        private Course lk2Course;
        private Course gk3Course;
        private Course gk4Course;
        private Course gk5Course;

        public ChosenExams()
        {
            InitializeComponent();
        }

        public ChosenExams(MainWindow mw, Course[] courses)
        {
            InitializeComponent();

            mainWindow = mw;
            allCourses = courses;
            lks = getLKs();
            lk1_cb.ItemsSource = getCourseNames(lks);
            lk2_cb.ItemsSource = getCourseNames(lks);
            Course[] gk3s = SetupGK3s();
            gk3_cb.ItemsSource = getCourseNames(gk3s);
        }

        private Course[] getLKs()
        {
            return allCourses.Where(c => c.LK).ToArray();
        }

        private Course[] getTestableGKs()
        {
            return allCourses.Where(c => c.Name != lk1Course.Name && c.Name != lk2Course.Name && c.E1 >= 0 && c.E2 >= 0 && c.Q1 >= 0 && c.Q2 >= 0 && c.Q3 >= 0 && c.Q4 >= 0).ToArray();
        }

        private bool minFBs(Course[] courses, int diversityCount)
        {
            if (courses.Any(c => c.Fb == 4))
                diversityCount++;

            int count = courses.Select(c => c.Fb).Distinct().Count();

            StringBuilder sb = new StringBuilder();
            foreach (var course in courses)
                sb.AppendLine(course.Name + " - " + course.Fb.ToString());

            //MessageBox.Show("DiversityCount: " + diversityCount.ToString() + "\n" + "Count: " + count.ToString() + "\n" + sb.ToString());

            return count >= diversityCount;
        }

        private bool obligatoryCourses(Course[] courses)
        {
            return courses.Any(c => c.Name == "Deutsch") && courses.Any(c => c.Name == "Mathematik") && courses.Any(c => c.Name == "Englisch" || c.Name == "Französisch" || c.Name == "Italienisch" || c.Name == "Spanisch" || c.Name == "Russisch" || c.Name == "Griechisch" || c.Name == "Latein" || c.Name == "Biologie" || c.Name == "Chemie" || c.Name == "Physik" || c.Name == "Informatik");
        }

        private List<string> getCourseNames(Course[] courses)
        {
            return courses.Select(c => c.Name).ToList();
        }

        private bool isGK5(Course gk, string gks4Name, Course[] coursesToBeChecked)
        {
            bool z1 = gk.Name != gks4Name;
            bool z2 = obligatoryCourses(coursesToBeChecked);
            bool z3 = minFBs(coursesToBeChecked, 3);

            if (z1 && z2 && z3)
                return true;
            else
                return false;
        }

        private Course[] SetupGK3s()
        {
            testableGKs = getTestableGKs();
            gk3s = testableGKs.Where(gk => minFBs(new Course[] { lk1Course, lk2Course, gk }, 2) && gk.Name != "Sport").ToList();

            Course[] gk4s;
            for (int i = 0; i < gk3s.Count; i++)
            {
                gk4s = SetupGK4s(gk3s[i]);
                if (gk4s.Length == 0)
                {
                    gk3s.RemoveAt(i);
                    i--;
                }

            }

            return gk3s.ToArray();
        }

        private Course[] SetupGK4s(Course gk3C)
        {
            gk4s = testableGKs.Where(gk => gk.Name != gk3C.Name).ToList();
            if (!lks.Any(lk => lk.Name == "Sport"))
            {
                Course peCourse = gk4s.Where(gk => gk.Name == "Sport").First();
                if (!peCourse.Pe3Std)
                    gk4s.Remove(peCourse);
            }

            Course[] gk5s;
            bool possibleCombination = false;
            for (int i = 0; i < gk4s.Count; i++)
            {
                gk5s = SetupGK5s(gk3C, gk4s[i]);
                if (gk5s.Length == 0)
                {
                    gk4s.RemoveAt(i);
                    i--;
                }
                else
                    possibleCombination = true;
            }

            if(possibleCombination)
                return gk4s.ToArray();
            else
                return new Course[0];
        }

        private Course[] SetupGK5s(Course gk3C, Course gk4C)
        {
            return gk4s.Where(gk => isGK5(gk, gk4.Name, new Course[] { lk1Course, lk2Course, gk3C, gk4C, gk })).ToArray();
        }

        private Exam[] GetExams()
        {
            Exam[] exams = new Exam[5];
            exams[0] = new Exam(lk1Course.Name, 0);
            exams[1] = new Exam(lk2Course.Name, 0);
            exams[2] = new Exam(gk3Course.Name, 0);
            exams[3] = new Exam(gk4Course.Name, 0);
            exams[4] = new Exam(gk5Course.Name, 0);

            return exams;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.FillInData(allCourses, GetExams());
            this.Close();
        }

        private void lk1_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lkChange)
            {
                lkChange = false;
                lk1Course = lks.Where(lk => lk.Name == (string)lk1_cb.SelectedValue).First();
                lk2Course = lks.Where(lk => lk.Name != (string)lk1_cb.SelectedValue).First();

                lk2_cb.SelectedValue = lk2Course.Name;
            }

            lkChange = true;
        }

        private void lk2_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lkChange)
            {
                lkChange = false;
                lk2Course = lks.Where(lk => lk.Name == (string)lk2_cb.SelectedValue).First();
                lk1Course = lks.Where(lk => lk.Name != (string)lk2_cb.SelectedValue).First();

                lk1_cb.SelectedValue = lk1Course.Name;
            }

            lkChange = true;
        }

        private void gk3_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gk3Course = testableGKs.Where(gk => gk.Name == (string)gk3_cb.SelectedValue).First();

            gk4_cb.ItemsSource = getCourseNames(SetupGK4s(gk3Course));
        }

        private void gk4_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gk4Course = testableGKs.Where(gk => gk.Name == (string)gk4_cb.SelectedValue).First();

            gk5_cb.ItemsSource = getCourseNames(SetupGK5s(gk3Course, gk4Course));
        }

        private void gk5_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gk5Course = testableGKs.Where(gk => gk.Name == (string)gk5_cb.SelectedValue).First();
        }
    }
}
