using System;
using System.Collections.Generic;
using System.Data;
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
        private SqlManager sqlManager = new SqlManager();
        private Course[] allCourses;
        private Exam[] allExams;
        private List<CourseItem> gkItems;
        private List<CourseItem> lkItems;
        private List<ExamItem> exItems;

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

        private void SetupGridColumns()
        {
            if(dataGridBC.Columns.Count == 5)
            {
                dataGridBC.Columns[0].MinWidth = 100;
                dataGridBC.Columns[0].CanUserSort = false;
                dataGridBC.Columns[0].CanUserResize = false;
                dataGridBC.Columns[0].CanUserReorder = false;
                dataGridBC.Columns[0].IsReadOnly = true;

                dataGridBC.Columns[1].MinWidth = 35;
                dataGridBC.Columns[1].CanUserSort = false;
                dataGridBC.Columns[1].CanUserResize = false;
                dataGridBC.Columns[1].CanUserReorder = false;

                dataGridBC.Columns[2].MinWidth = 35;
                dataGridBC.Columns[2].CanUserSort = false;
                dataGridBC.Columns[2].CanUserResize = false;
                dataGridBC.Columns[2].CanUserReorder = false;

                dataGridBC.Columns[3].MinWidth = 35;
                dataGridBC.Columns[3].CanUserSort = false;
                dataGridBC.Columns[3].CanUserResize = false;
                dataGridBC.Columns[3].CanUserReorder = false;

                dataGridBC.Columns[4].MinWidth = 35;
                dataGridBC.Columns[4].CanUserSort = false;
                dataGridBC.Columns[4].CanUserResize = false;
                dataGridBC.Columns[4].CanUserReorder = false;
            }

            if (dataGridSC.Columns.Count == 5)
            {
                dataGridSC.Columns[0].MinWidth = 100;
                dataGridSC.Columns[0].CanUserSort = false;
                dataGridSC.Columns[0].CanUserResize = false;
                dataGridSC.Columns[0].CanUserReorder = false;
                dataGridSC.Columns[0].IsReadOnly = true;

                dataGridSC.Columns[1].MinWidth = 35;
                dataGridSC.Columns[1].CanUserSort = false;
                dataGridSC.Columns[1].CanUserResize = false;
                dataGridSC.Columns[1].CanUserReorder = false;

                dataGridSC.Columns[2].MinWidth = 35;
                dataGridSC.Columns[2].CanUserSort = false;
                dataGridSC.Columns[2].CanUserResize = false;
                dataGridSC.Columns[2].CanUserReorder = false;

                dataGridSC.Columns[3].MinWidth = 35;
                dataGridSC.Columns[3].CanUserSort = false;
                dataGridSC.Columns[3].CanUserResize = false;
                dataGridSC.Columns[3].CanUserReorder = false;

                dataGridSC.Columns[4].MinWidth = 35;
                dataGridSC.Columns[4].CanUserSort = false;
                dataGridSC.Columns[4].CanUserResize = false;
                dataGridSC.Columns[4].CanUserReorder = false;
            }


            if (dataGridA.Columns.Count == 2)
            {
                dataGridA.Columns[0].MinWidth = 130;
                dataGridA.Columns[0].CanUserSort = false;
                dataGridA.Columns[0].CanUserResize = false;
                dataGridA.Columns[0].CanUserReorder = false;
                dataGridA.Columns[0].IsReadOnly = true;

                dataGridA.Columns[1].MinWidth = 35;
                dataGridA.Columns[1].CanUserSort = false;
                dataGridA.Columns[1].CanUserResize = false;
                dataGridA.Columns[1].CanUserReorder = false;
            }
        }

        private void AdaptGridView()
        {
            for(int i = 0; i < dataGridBC.Items.Count; i++)
            {
                CourseItem gkItem = (CourseItem)dataGridBC.Items.GetItemAt(i);

                if (gkItem.Q1 == -1)
                    DataGridStyler.SetCellEmptyAndDisabled(dataGridBC, i, 1);

                if (gkItem.Q2 == -1)
                    DataGridStyler.SetCellEmptyAndDisabled(dataGridBC, i, 2);

                if (gkItem.Q3 == -1)
                    DataGridStyler.SetCellEmptyAndDisabled(dataGridBC, i, 3);

                if (gkItem.Q4 == -1)
                    DataGridStyler.SetCellEmptyAndDisabled(dataGridBC, i, 4);
            }

            for (int i = 0; i < dataGridSC.Items.Count; i++)
            {
                CourseItem lkItem = (CourseItem)dataGridSC.Items.GetItemAt(i);

                if (lkItem.Q1 == -1)
                    DataGridStyler.SetCellEmptyAndDisabled(dataGridSC, i, 1);

                if (lkItem.Q2 == -1)
                    DataGridStyler.SetCellEmptyAndDisabled(dataGridSC, i, 2);

                if (lkItem.Q3 == -1)
                    DataGridStyler.SetCellEmptyAndDisabled(dataGridSC, i, 3);

                if (lkItem.Q4 == -1)
                    DataGridStyler.SetCellEmptyAndDisabled(dataGridSC, i, 4);
            }
        }

        public void FillInData(Course[] courses, Exam[] exams)
        {
            allCourses = courses;
            allExams = exams;

            gkItems = Course.GetCourseItems(courses.Where(gk => !gk.LK && gk.AttendedInQ()).ToArray());
            lkItems = Course.GetCourseItems(courses.Where(lk => lk.LK).ToArray());
            exItems = Exam.GetExamItems(exams);

            Binding bindingBC = new Binding() { Mode = BindingMode.TwoWay, Source = gkItems, Path = new PropertyPath(".") };
            Binding bindingSC = new Binding() { Mode = BindingMode.TwoWay, Source = lkItems, Path = new PropertyPath(".") };
            Binding bindingA = new Binding() { Mode = BindingMode.TwoWay, Source = exItems, Path = new PropertyPath(".") };
            BindingOperations.SetBinding(dataGridBC, DataGrid.ItemsSourceProperty, bindingBC);
            BindingOperations.SetBinding(dataGridSC, DataGrid.ItemsSourceProperty, bindingSC);
            BindingOperations.SetBinding(dataGridA, DataGrid.ItemsSourceProperty, bindingA);

            SetupGridColumns();
            AdaptGridView();
        }

        private void UpdateData()
        {
            gkItems = Course.GetCourseItems(allCourses.Where(gk => !gk.LK && gk.AttendedInQ()).ToArray());
            lkItems = Course.GetCourseItems(allCourses.Where(lk => lk.LK).ToArray());
            exItems = Exam.GetExamItems(allExams);
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
            Relevantor relevantor = new Relevantor(gkItems, lkItems, exItems);
            RelevantCourse[] relevantCourses = relevantor.DetermineRelevantCourses();

            for(int i = 0; i < gkItems.Count; i++)
            {
                RelevantCourse relevantCourse = relevantCourses.Where(item => item.Name == gkItems[i].Fach).First();
                DataGridStyler.SetCellRelevant(dataGridBC, i, 1, relevantCourse.Q1);
                DataGridStyler.SetCellRelevant(dataGridBC, i, 2, relevantCourse.Q2);
                DataGridStyler.SetCellRelevant(dataGridBC, i, 3, relevantCourse.Q3);
                DataGridStyler.SetCellRelevant(dataGridBC, i, 4, relevantCourse.Q4);
            }

            for (int i = 0; i < lkItems.Count; i++)
            {
                RelevantCourse relevantCourse = relevantCourses.Where(item => item.Name == lkItems[i].Fach).First();
                DataGridStyler.SetCellRelevant(dataGridSC, i, 1, relevantCourse.Q1);
                DataGridStyler.SetCellRelevant(dataGridSC, i, 2, relevantCourse.Q2);
                DataGridStyler.SetCellRelevant(dataGridSC, i, 3, relevantCourse.Q3);
                DataGridStyler.SetCellRelevant(dataGridSC, i, 4, relevantCourse.Q4);
            }
        }

        private void add_Student_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
