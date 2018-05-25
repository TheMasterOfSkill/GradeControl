using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeControl
{
    public class ExamItem
    {
        private MainWindow mainWindow;
        private int grade;

        public ExamItem(MainWindow mw, string name, int gr)
        {
            mainWindow = mw;
            Fach = name;
            grade = gr;
        }

        public string Fach { get; set; }
        public int Notenpkt
        {
            get
            {
                return grade;
            }
            set
            {
                if (value < 0)
                    grade = 0;
                else if (value > 15)
                    grade = 15;
                else
                    grade = value;

                mainWindow.UpdateExam(this);
            }
        }
    }
}
