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
using System.Windows.Threading;

namespace GradeControl
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlManager sqlManager = new SqlManager();
        private Student[] students;
        private Course[] allCourses;
        private Exam[] allExams;
        private RelevantCourse[] relevantCourses;
        private List<StudentItem> studentItems = new List<StudentItem>();
        private List<CourseItem> gkItems = new List<CourseItem>();
        private List<CourseItem> lkItems = new List<CourseItem>();
        private List<ExamItem> exItems = new List<ExamItem>();

        public MainWindow()
        {
            sqlManager.CreateDatabase();
            sqlManager.OpenConnection();
            sqlManager.CreateTableStudents();
            sqlManager.CreateTableCourses();
            sqlManager.CreateTableExams();
            InitializeComponent();

            SetupGridBindings();
            InitializeStudentView();
        }

        private void InitializeStudentView()
        {
            students = sqlManager.GetStudents();
            Binding bindingS = new Binding() { Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Source = studentItems, Path = new PropertyPath(".") };
            BindingOperations.SetBinding(studentSelection, ListBox.ItemsSourceProperty, bindingS);

            if (students.Length > 0)
            {
                foreach (Student student in students)
                    studentItems.Add(new StudentItem(student.Name));

                studentSelection.SelectedItem = studentItems.First();
            }
            else
                Help(true);
        }

        private void About()
        {
            MessageBox.Show("GradeControl v1.0\n\nCopyright © Fabrice von der Lehr, 2018\n\nIcon made by Freepik from www.flaticon.com\n\nDem Programm zugrunde liegen die Bestimmungen der OAVO Hessen (Stand: 2016).", "Über GradeControl");
        }

        private void Help(bool firstStart)
        {
            MessageBox.Show("Dieses Programm dient der Verwaltung deiner Noten in der gymnasialen Oberstufe in Hessen. Es ermöglicht es dir, deinen Abiturdurchschnitt bereits vor dem Abschluss aller Klausuren einschätzen zu können, indem du für ausstehende Zensuren deine Erwartungen einträgst. Das ansonsten übliche Verfahren, rechnerische Durchschnitte kleiner 1.0 auf 1.0 aufzurunden, wird hier nicht angewandt.\n\nIm linken Viertel der Benutzeroberfläche werden die SchülerInnen aufgelistet, deren Resultate in der Datenbank verzeichnet sind. Durch die Auswahl eines Schülers/einer Schülerin in der Liste werden seine/ihre Daten im verbleibenden rechten Teil des Programms angezeigt und können ggf. bearbeitet werden. Im Bezug auf die belegten Kurse stellen die rötlich hinterlegten Halbjahre solche dar, die in die Wertung des Abiturs eingebracht werden. Die der Anzeige zugrundeliegende Kurs- sowie Prüfungsfachauswahl kann über den Menüpunkt \"Einstellungen\" editiert werden, infolgedessen jedoch sämtliche vorherigen Notendaten verloren gehen.", "Informationen zum Programm", MessageBoxButton.OK, MessageBoxImage.Information);

            if (firstStart)
            {
                StudentDialog studentDialog = new StudentDialog(this, true);
                studentDialog.Show();
            }
        }

        private void SetupGridBindings()
        {
            Binding bindingBC = new Binding() { Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Source = gkItems, Path = new PropertyPath(".") };
            Binding bindingSC = new Binding() { Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Source = lkItems, Path = new PropertyPath(".") };
            Binding bindingA = new Binding() { Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Source = exItems, Path = new PropertyPath(".") };
            BindingOperations.SetBinding(dataGridBC, DataGrid.ItemsSourceProperty, bindingBC);
            BindingOperations.SetBinding(dataGridSC, DataGrid.ItemsSourceProperty, bindingSC);
            BindingOperations.SetBinding(dataGridA, DataGrid.ItemsSourceProperty, bindingA);
        }

        private void SetupGridColumns()
        {
            if (dataGridBC.Columns.Count == 5)
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

        public void FillInData(Course[] courses, Exam[] exams, int studentId)
        {
            sqlManager.DeleteAllCourses(studentId);
            sqlManager.DeleteAllExams(studentId);

            foreach (Course course in courses)
            {
                sqlManager.AddCourse(studentId, course);
            }

            foreach (Exam exam in exams)
            {
                sqlManager.AddExam(studentId, exam);
            }

            Student student = students.Where(item => item.Id == studentId).First();
            allCourses = sqlManager.GetCourses(student);
            allExams = sqlManager.GetExams(student);

            gkItems.Clear();
            lkItems.Clear();
            exItems.Clear();

            gkItems.AddRange(Course.GetCourseItems(this, courses.Where(gk => !gk.LK && gk.AttendedInQ()).ToArray()));
            lkItems.AddRange(Course.GetCourseItems(this, courses.Where(lk => lk.LK).ToArray()));
            exItems.AddRange(Exam.GetExamItems(this, exams));

            Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() => dataGridBC.Items.Refresh()));
            Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() => dataGridSC.Items.Refresh()));
            Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() => dataGridA.Items.Refresh()));

            Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() => AdaptGridView()));
            Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() => SetupGridColumns()));
            Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() => UpdateRelevantCourses()));
            Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() => UpdateResults()));
        }

        public void StudentAdded(string name, bool firstStart)
        {
            bool nameExists = false;
            if (studentItems != null)
                nameExists = studentItems.Exists(item => item.Name == name);

            if (nameExists)
                MessageBox.Show("Name bereits vorhanden.");
            else
            {
                studentItems.Add(new StudentItem(name));

                sqlManager.AddStudent(name);

                studentSelection.Items.Refresh();

                students = sqlManager.GetStudents();
                Student addedStudent = students.Where(item => item.Name == name).First();

                if (firstStart)
                    OpenTakenCourses(addedStudent.Id);
            }
        }

        public void StudentRenamed(string formerName, string newName)
        {
            bool nameExists = studentItems.Exists(item => item.Name == newName);

            if (nameExists)
                MessageBox.Show("Name bereits vorhanden.");
            else
            {
                StudentItem studentItem = studentItems.Find(item => item.Name == formerName);
                studentItems[studentItems.IndexOf(studentItem)].Name = newName;

                studentSelection.Items.Refresh();

                sqlManager.UpdateStudent(formerName, newName);
            }
        }

        private void UpdateResults()
        {
            int bctot = 0, sctot = 0, atot = 0;

            for (int i = 0; i < gkItems.Count; i++)
            {
                RelevantCourse relevantCourse = relevantCourses.Where(item => item.Name == gkItems[i].Fach).First();

                if (relevantCourse.Q1)
                    bctot += gkItems[i].Q1;
                if (relevantCourse.Q2)
                    bctot += gkItems[i].Q2;
                if (relevantCourse.Q3)
                    bctot += gkItems[i].Q3;
                if (relevantCourse.Q4)
                    bctot += gkItems[i].Q4;
            }

            for (int i = 0; i < lkItems.Count; i++)
            {
                sctot += 2 * lkItems[i].Q1;
                sctot += 2 * lkItems[i].Q2;
                sctot += 2 * lkItems[i].Q3;
                sctot += 2 * lkItems[i].Q4;
            }

            for (int i = 0; i < exItems.Count; i++)
            {
                atot += 4 * exItems[i].Notenpkt;
            }

            int sum = bctot + sctot + atot;
            double avgGrade = (double)((int)(100 * ((17.0 / 3.0) - (((double)sum) / 180.0)))) / 100.0;

            labelBCTot.Content = String.Format("Σ   {0} / 360 Pkt.", bctot.ToString());
            labelSCTot.Content = String.Format("Σ   {0} / 240 Pkt.", sctot.ToString());
            labelATot.Content = String.Format("Σ   {0} / 300 Pkt.", atot.ToString());
            labelTot.Content = String.Format("Σ   {0} / 900 Pkt.", sum.ToString());
            labelGrade.Content = avgGrade.ToString();
            labelGrade.Background = GetGradeColor(avgGrade);
        }

        private Brush GetGradeColor(double grade)
        {
            if (grade < 1.0)
                return new SolidColorBrush(Colors.White);
            if (grade <= 2.5)
                return new SolidColorBrush(Color.FromArgb(255, (byte)((grade - 1) * 17), 255, 0));
            else if (grade <= 4.0)
                return new SolidColorBrush(Color.FromArgb(255, 255, (byte)(255 - ((grade - 2.5) * 17)), 0));
            else
                return new SolidColorBrush(Color.FromArgb(255, 200, 0, 0));
        }

        public void OpenTakenCourses(int studentId)
        {
            TakenCourses takenCourses = new TakenCourses(this, studentId);
            takenCourses.Show();
        }

        public void OpenTakenCourses(object sender, RoutedEventArgs e)
        {
            StudentItem studentItem = (StudentItem)studentSelection.SelectedItem;
            if (studentItem != null)
            {
                string selected = studentItem.Name;
                Student selectedStudent = students.Where(item => item.Name == selected).First();

                TakenCourses takenCourses = new TakenCourses(this, allCourses, allExams, selectedStudent.Id);
                takenCourses.Show();
            }
        }

        public void OpenChosenExams(object sender, RoutedEventArgs e)
        {
            StudentItem studentItem = (StudentItem)studentSelection.SelectedItem;
            if (studentItem != null)
            {
                string selected = studentItem.Name;
                Student selectedStudent = students.Where(item => item.Name == selected).First();

                ChosenExams chosenExams = new ChosenExams(this, allCourses, allExams, selectedStudent.Id);
                chosenExams.Show();
            }
        }

        private void delete_Student_Click(object sender, RoutedEventArgs e)
        {
            StudentItem studentItem = (StudentItem)studentSelection.SelectedItem;
            if (studentItem != null)
            {
                string selected = studentItem.Name;
                StudentItem selectedStudent = studentItems.Where(item => item.Name == selected).First();

                studentItems.Remove(selectedStudent);

                gkItems.Clear();
                lkItems.Clear();
                exItems.Clear();
                studentSelection.Items.Refresh();
                dataGridBC.Items.Refresh();
                dataGridSC.Items.Refresh();
                dataGridA.Items.Refresh();

                sqlManager.DeleteStudent(selected);

                students = sqlManager.GetStudents();
            }
        }

        private void add_Student_Click(object sender, RoutedEventArgs e)
        {
            StudentDialog studentDialog = new StudentDialog(this, false);
            studentDialog.Show();
        }

        private void studentSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StudentItem studentItem = (StudentItem)studentSelection.SelectedItem;
            if(studentItem != null)
            {
                string selected = studentItem.Name;
                Student selectedStudent = students.Where(item => item.Name == selected).First();

                Course[] courses = sqlManager.GetCourses(selectedStudent);
                Exam[] exams = sqlManager.GetExams(selectedStudent);

                if (courses.Length > 0 && exams.Length > 0)
                    FillInData(courses, exams, selectedStudent.Id);
                else
                    OpenTakenCourses(selectedStudent.Id);
            }
        }

        private void studentSelection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string selected = ((StudentItem)studentSelection.SelectedItem).Name;

            StudentDialog studentDialog = new StudentDialog(this, selected);
            studentDialog.Show();
        }

        private void UpdateRelevantCourses()
        {
            Relevantor relevantor = new Relevantor(gkItems, lkItems, exItems);
            relevantCourses = relevantor.DetermineRelevantCourses();

            for (int i = 0; i < gkItems.Count; i++)
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

        public void UpdateCourse(CourseItem selected)
        {
            Course selectedCourse = allCourses.Where(item => item.Name == selected.Fach).First();

            selectedCourse.Q1 = selected.Q1;
            selectedCourse.Q2 = selected.Q2;
            selectedCourse.Q3 = selected.Q3;
            selectedCourse.Q4 = selected.Q4;

            sqlManager.UpdateCourse(selectedCourse);

            UpdateRelevantCourses();
            UpdateResults();
        }
        
        public void UpdateExam(ExamItem selected)
        {
            Exam selectedExam = allExams.Where(item => item.Name == selected.Fach).First();
            selectedExam.Grade = selected.Notenpkt;

            sqlManager.UpdateExam(selectedExam);

            UpdateResults();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sqlManager.CloseConnection();
        }

        private void OpenHelp(object sender, RoutedEventArgs e)
        {
            Help(false);
        }

        private void OpenAbout(object sender, RoutedEventArgs e)
        {
            About();
        }
    }
}
