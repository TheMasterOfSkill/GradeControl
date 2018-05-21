using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeControl
{
    public class Exam
    {
        public Exam(int id, string name, int grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }

        public Exam(string name, int grade)
        {
            Name = name;
            Grade = grade;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Grade { get; set; }

        public int Predict(Course course)
        {
            Grade = course.Predict(false);
            return Grade;
        }

        public static List<ExamItem> GetExamItems(Exam[] exams)
        {
            List<ExamItem> examItems = new List<ExamItem>();

            foreach (var exam in exams)
                examItems.Add(new ExamItem(exam.Name, exam.Grade));

            return examItems;
        }
    }
}
