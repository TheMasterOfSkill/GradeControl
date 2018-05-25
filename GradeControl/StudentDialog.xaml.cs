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
    /// Interaktionslogik für StudentDialog.xaml
    /// </summary>
    public partial class StudentDialog : Window
    {
        MainWindow mainWindow;
        string formerName = String.Empty;
        bool firstStart = false;

        public StudentDialog(MainWindow mw, bool fs)
        {
            mainWindow = mw;
            firstStart = fs;
            InitializeComponent();
        }

        public StudentDialog(MainWindow mw, string oldName)
        {
            mainWindow = mw;
            formerName = oldName;
            InitializeComponent();
            textBox.Text = oldName;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != String.Empty)
            {
                this.Hide();

                if (formerName == String.Empty)
                    mainWindow.StudentAdded(textBox.Text, firstStart);
                else
                    mainWindow.StudentRenamed(formerName, textBox.Text);

                this.Close();
            }
            else
                MessageBox.Show("Name leer.");
        }
    }
}
