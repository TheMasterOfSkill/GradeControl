using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GradeControl
{
    public class SqlManager
    {
        private StringBuilder sqlQueue = new StringBuilder();
        private SQLiteConnection dbConnection;
        private Timer timer;
        private const string DB_FILENAME = "GradeControl.sqlite";
        private const int TIMER_INTERVAL = 60000;

        public void startTimedDBUpdate()
        {
            timer = new Timer(new TimerCallback(ExecuteQueue), null, TIMER_INTERVAL, Timeout.Infinite);
        }

        public void stopTimedDBUpdate()
        {
            timer.Dispose();
        }

        public void CreateDatabase()
        {
            if(!File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), DB_FILENAME)))
                SQLiteConnection.CreateFile(DB_FILENAME);
        }

        public void OpenConnection()
        {
            dbConnection = new SQLiteConnection(String.Format("Data Source = {0}; Version = 3;", DB_FILENAME));
            dbConnection.Open();
        }

        public void CloseConnection()
        {
            if(dbConnection != null)
                dbConnection.Close();
        }

        public void AddToQueue(string sql)
        {
            sqlQueue.AppendLine(sql);
        }

        public void ExecuteQueue()
        {
            if(sqlQueue.Length > 0)
            {
                SQLiteCommand command = new SQLiteCommand(sqlQueue.ToString(), dbConnection);
                command.ExecuteNonQuery();
            }
        }

        public void ExecuteQueue(object state)
        {
            if (sqlQueue.Length > 0)
            {
                SQLiteCommand command = new SQLiteCommand(sqlQueue.ToString(), dbConnection);
                command.ExecuteNonQuery();
                timer.Change(TIMER_INTERVAL, Timeout.Infinite);
            }
        }

        public void CreateTableStudents()
        {
            AddToQueue("CREATE TABLE STUDENTS (Id INTEGER NOT NULL AUTO_INCREMENT, Name TEXT, PRIMARY KEY (Id));");
            ExecuteQueue();
        }

        public void AddStudent(string name)
        {
            AddToQueue(String.Format("INSERT INTO STUDENTS (Name) VALUES ('{0}');", name));
        }

        public void UpdateStudent(string oldName, string newName)
        {
            AddToQueue(String.Format("UPDATE STUDENTS SET Name='{0}' WHERE Name='{1}';", newName, oldName));
        }

        public void DeleteStudent(string name)
        {
            AddToQueue(String.Format("DELETE FROM STUDENTS WHERE Name='{0}';", name));
        }

        public Student[] GetStudents()
        {
            string sql = "SELECT * FROM STUDENTS";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Student> students = new List<Student>();

            while (reader.Read())
                students.Add(new Student((int)reader["Id"], (string)reader["Name"]));

            return students.ToArray();
        }

        public void CreateTableCourses()
        {
            AddToQueue("CREATE TABLE COURSES (Id INTEGER NOT NULL AUTO_INCREMENT, Name TEXT, Fb INTEGER, Lk INTEGER, Pe3Std INTEGER, E1 INTEGER, E2 INTEGER, Q1 INTEGER, Q2 INTEGER, Q3 INTEGER, Q4 INTEGER, StudentId INTEGER, PRIMARY KEY (Id), FOREIGN KEY (StudentId) REFERENCES Students (Id) ON DELETE CASCADE);");
            ExecuteQueue();
        }

        public void AddCourse(int studentId, Course course)
        {
            AddToQueue(String.Format("INSERT INTO COURSES (Name, Fb, Lk, Pe3Std, E1, E2, Q1, Q2, Q3, Q4, StudentId) VALUES ('{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10});", course.Name, course.Fb.ToString(), Convert.ToInt32(course.LK).ToString(), Convert.ToInt32(course.Pe3Std).ToString(), course.E1.ToString(), course.E2.ToString(), course.Q1.ToString(), course.Q2.ToString(), course.Q3.ToString(), course.Q4.ToString(), studentId.ToString()));
        }

        public void UpdateCourse(Course course)
        {
            AddToQueue(String.Format("UPDATE COURSES SET Name='{0}', Fb={1}, Lk={2}, Pe3Std={3}, E1={4}, E2={5}, Q1={6}, Q2={7}, Q3={8}, Q4={9} WHERE Id='{10}';", course.Name, course.Fb.ToString(), Convert.ToInt32(course.LK).ToString(), Convert.ToInt32(course.Pe3Std).ToString(), course.E1.ToString(), course.E2.ToString(), course.Q1.ToString(), course.Q2.ToString(), course.Q3.ToString(), course.Q4.ToString(), course.Id.ToString()));
        }

        public void DeleteCourse(Course course)
        {
            AddToQueue(String.Format("DELETE FROM COURSES WHERE Id='{0}';", course.Id));
        }

        public Course[] GetCourses(Student student)
        {
            string sql = String.Format("SELECT * FROM COURSES WHERE StudentId={0}", student.Id.ToString());
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Course> courses = new List<Course>();

            while (reader.Read())
                courses.Add(new Course((int)reader["Id"], (string)reader["Name"], (int)reader["Fb"], Convert.ToBoolean((int)reader["Lk"]), (int)reader["E1"], (int)reader["E2"], (int)reader["Q1"], (int)reader["Q2"], (int)reader["Q3"], (int)reader["Q4"], Convert.ToBoolean((int)reader["Pe3Std"])));

            return courses.ToArray();
        }

        public void CreateTableExams()
        {
            AddToQueue("CREATE TABLE EXAMS (Id INTEGER NOT NULL AUTO_INCREMENT, Name TEXT, Grade INTEGER, StudentId INTEGER, PRIMARY KEY (Id), FOREIGN KEY (StudentId) REFERENCES Students (Id) ON DELETE CASCADE);");
            ExecuteQueue();
        }

        public void AddExam(int studentId, Exam exam)
        {
            AddToQueue(String.Format("INSERT INTO EXAMS (Name, Grade, StudentId) VALUES ('{0}', {1}, {2});", exam.Name, exam.Grade.ToString(), studentId.ToString()));
        }

        public void UpdateExam(Exam exam)
        {
            AddToQueue(String.Format("UPDATE EXAMS SET Name='{0}', Grade={1}, WHERE Id='{2}';", exam.Name, exam.Grade.ToString(), exam.Id.ToString()));
        }

        public void DeleteExam(Exam exam)
        {
            AddToQueue(String.Format("DELETE FROM EXAMS WHERE Id='{0}';", exam.Id));
        }

        public Exam[] GetExams(Student student)
        {
            string sql = String.Format("SELECT * FROM EXAMS WHERE StudentId={0}", student.Id.ToString());
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Exam> exams = new List<Exam>();

            while (reader.Read())
                exams.Add(new Exam((int)reader["Id"], (string)reader["Name"], (int)reader["Grade"]));

            return exams.ToArray();
        }
    }
}
