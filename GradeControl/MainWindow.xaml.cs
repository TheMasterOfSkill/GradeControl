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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GradeControl
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlManager sqlManager = new SqlManager();

        public MainWindow()
        {
            InitializeComponent();
            sqlManager.CreateDatabase();
        }

        public void OpenStudentSelection(object sender, RoutedEventArgs e)
        {
            TakenCourses takenCourses = new TakenCourses(this);
            takenCourses.Show();
        }

        public void FillInData(Course[] courses, Exam[] exams)
        {

        }

        public void OpenTakenCourses(object sender, RoutedEventArgs e)
        {
            TakenCourses takenCourses = new TakenCourses(this);
            takenCourses.Show();
        }

        public void OpenChosenExams(object sender, RoutedEventArgs e)
        {
            ChosenExams chosenExams = new ChosenExams();
            chosenExams.Show();
        }

        private void delete_Student_Click(object sender, RoutedEventArgs e)
        {

        }

        private void add_Student_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
