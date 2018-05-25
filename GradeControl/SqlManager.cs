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
        private SQLiteConnection dbConnection;
        private const string DB_FILENAME = "GradeControl.sqlite";

        public void CreateDatabase()
        {
            if(!File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), DB_FILENAME)))
                SQLiteConnection.CreateFile(DB_FILENAME);
        }

        public void OpenConnection()
        {
            dbConnection = new SQLiteConnection(String.Format("Data Source = {0}; Version = 3;", DB_FILENAME));
            dbConnection.Open();

            SQLiteCommand command = new SQLiteCommand("PRAGMA foreign_keys = ON;", dbConnection);
            command.ExecuteNonQuery();
        }

        public void CloseConnection()
        {
            if(dbConnection != null)
                dbConnection.Close();
        }

        public void ExecuteCommand(string sql)
        {
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public void CreateTableStudents()
        {
            ExecuteCommand("CREATE TABLE IF NOT EXISTS STUDENTS (Id INTEGER NOT NULL, Name TEXT, PRIMARY KEY (Id));");
        }

        public void AddStudent(string name)
        {
            ExecuteCommand(String.Format("INSERT INTO STUDENTS (Name) VALUES ('{0}');", name));
        }

        public void UpdateStudent(string oldName, string newName)
        {
            ExecuteCommand(String.Format("UPDATE STUDENTS SET Name='{0}' WHERE Name='{1}';", newName, oldName));
        }

        public void DeleteStudent(string name)
        {
            ExecuteCommand(String.Format("DELETE FROM STUDENTS WHERE Name='{0}';", name));
        }

        public Student[] GetStudents()
        {
            string sql = "SELECT * FROM STUDENTS";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Student> students = new List<Student>();

            while (reader.Read())
                students.Add(new Student(Convert.ToInt32(reader["Id"]), reader["Name"].ToString()));

            return students.ToArray();
        }

        public void CreateTableCourses()
        {
            ExecuteCommand("CREATE TABLE IF NOT EXISTS COURSES (Id INTEGER NOT NULL, Name TEXT, Fb INTEGER, Lk INTEGER, Pe3Std INTEGER, E1 INTEGER, E2 INTEGER, Q1 INTEGER, Q2 INTEGER, Q3 INTEGER, Q4 INTEGER, StudentId INTEGER, PRIMARY KEY (Id), FOREIGN KEY (StudentId) REFERENCES STUDENTS (Id) ON DELETE CASCADE);");
        }

        public void AddCourse(int studentId, Course course)
        {
            ExecuteCommand(String.Format("INSERT INTO COURSES (Name, Fb, Lk, Pe3Std, E1, E2, Q1, Q2, Q3, Q4, StudentId) VALUES ('{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10});", course.Name, course.Fb.ToString(), Convert.ToInt32(course.LK).ToString(), Convert.ToInt32(course.Pe3Std).ToString(), course.E1.ToString(), course.E2.ToString(), course.Q1.ToString(), course.Q2.ToString(), course.Q3.ToString(), course.Q4.ToString(), studentId.ToString()));
        }

        public void UpdateCourse(Course course)
        {
            ExecuteCommand(String.Format("UPDATE COURSES SET Name='{0}', Fb={1}, Lk={2}, Pe3Std={3}, E1={4}, E2={5}, Q1={6}, Q2={7}, Q3={8}, Q4={9} WHERE Id={10};", course.Name, course.Fb.ToString(), Convert.ToInt32(course.LK).ToString(), Convert.ToInt32(course.Pe3Std).ToString(), course.E1.ToString(), course.E2.ToString(), course.Q1.ToString(), course.Q2.ToString(), course.Q3.ToString(), course.Q4.ToString(), course.Id.ToString()));
        }

        public void DeleteCourse(Course course)
        {
            ExecuteCommand(String.Format("DELETE FROM COURSES WHERE Id='{0}';", course.Id));
        }

        public void DeleteAllCourses(int studentId)
        {
            ExecuteCommand(String.Format("DELETE FROM COURSES WHERE StudentId='{0}';", studentId));
        }

        public Course[] GetCourses(Student student)
        {
            string sql = String.Format("SELECT * FROM COURSES WHERE StudentId={0}", student.Id.ToString());
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Course> courses = new List<Course>();

            while (reader.Read())
                courses.Add(new Course(Convert.ToInt32(reader["Id"]), reader["Name"].ToString(), Convert.ToInt32(reader["Fb"]), Convert.ToBoolean(Convert.ToInt32(reader["Lk"])), Convert.ToInt32(reader["E1"]), Convert.ToInt32(reader["E2"]), Convert.ToInt32(reader["Q1"]), Convert.ToInt32(reader["Q2"]), Convert.ToInt32(reader["Q3"]), Convert.ToInt32(reader["Q4"]), Convert.ToBoolean(Convert.ToInt32(reader["Pe3Std"]))));

            return courses.ToArray();
        }

        public void CreateTableExams()
        {
            ExecuteCommand("CREATE TABLE IF NOT EXISTS EXAMS (Id INTEGER NOT NULL, Name TEXT, Grade INTEGER, StudentId INTEGER, PRIMARY KEY (Id), FOREIGN KEY (StudentId) REFERENCES STUDENTS (Id) ON DELETE CASCADE);");
        }

        public void AddExam(int studentId, Exam exam)
        {
            ExecuteCommand(String.Format("INSERT INTO EXAMS (Name, Grade, StudentId) VALUES ('{0}', {1}, {2});", exam.Name, exam.Grade.ToString(), studentId.ToString()));
        }

        public void UpdateExam(Exam exam)
        {
            ExecuteCommand(String.Format("UPDATE EXAMS SET Name='{0}', Grade={1} WHERE Id={2};", exam.Name, exam.Grade.ToString(), exam.Id.ToString()));
        }

        public void DeleteExam(Exam exam)
        {
            ExecuteCommand(String.Format("DELETE FROM EXAMS WHERE Id='{0}';", exam.Id));
        }

        public void DeleteAllExams(int studentId)
        {
            ExecuteCommand(String.Format("DELETE FROM EXAMS WHERE StudentId='{0}';", studentId));
        }

        public Exam[] GetExams(Student student)
        {
            string sql = String.Format("SELECT * FROM EXAMS WHERE StudentId={0}", student.Id.ToString());
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Exam> exams = new List<Exam>();

            while (reader.Read())
                exams.Add(new Exam(Convert.ToInt32(reader["Id"]), reader["Name"].ToString(), Convert.ToInt32(reader["Grade"])));

            return exams.ToArray();
        }
    }
}
