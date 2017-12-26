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
    /// Interaktionslogik für TakenCourses.xaml
    /// </summary>
    public partial class TakenCourses : Window
    {
        public TakenCourses()
        {
            InitializeComponent();
        }

        private bool IsZ1() //z1: Fremdsprache von E1-Q4
        {
            if (e_e1.IsChecked.Value && e_e2.IsChecked.Value && e_q1.IsChecked.Value && e_q2.IsChecked.Value && e_q3.IsChecked.Value && e_q4.IsChecked.Value)
                return true;
            else if (l_e1.IsChecked.Value && l_e2.IsChecked.Value && l_q1.IsChecked.Value && l_q2.IsChecked.Value && l_q3.IsChecked.Value && l_q4.IsChecked.Value)
                return true;
            else if (f_e1.IsChecked.Value && f_e2.IsChecked.Value && f_q1.IsChecked.Value && f_q2.IsChecked.Value && f_q3.IsChecked.Value && f_q4.IsChecked.Value)
                return true;
            else
                return false;
        }

        private bool IsZ2() //z2: NW von E1-Q4
        {
            if (p_e1.IsChecked.Value && p_e2.IsChecked.Value && p_q1.IsChecked.Value && p_q2.IsChecked.Value && p_q3.IsChecked.Value && p_q4.IsChecked.Value)
                return true;
            else if (b_e1.IsChecked.Value && b_e2.IsChecked.Value && b_q1.IsChecked.Value && b_q2.IsChecked.Value && b_q3.IsChecked.Value && b_q4.IsChecked.Value)
                return true;
            else if (c_e1.IsChecked.Value && c_e2.IsChecked.Value && c_q1.IsChecked.Value && c_q2.IsChecked.Value && c_q3.IsChecked.Value && c_q4.IsChecked.Value)
                return true;
            else
                return false;
        }

        private bool IsZ3() //z3: Rel/Eth von Q1-Q4
        {
            if (evrel_q1.IsChecked.Value && evrel_q2.IsChecked.Value && evrel_q3.IsChecked.Value && evrel_q4.IsChecked.Value)
                return true;
            else if (kathrel_q1.IsChecked.Value && kathrel_q2.IsChecked.Value && kathrel_q3.IsChecked.Value && kathrel_q4.IsChecked.Value)
                return true;
            else if (eth_q1.IsChecked.Value && eth_q2.IsChecked.Value && eth_q3.IsChecked.Value && eth_q4.IsChecked.Value)
                return true;
            else
                return false;
        }

        private bool IsZ4() //z4: Ku/Mu/DS von Q1-Q2
        {
            if (ku_q1.IsChecked.Value && ku_q2.IsChecked.Value)
                return true;
            else if (mu_q1.IsChecked.Value && mu_q2.IsChecked.Value)
                return true;
            else if (ds_q1.IsChecked.Value && ds_q2.IsChecked.Value)
                return true;
            else
                return false;
        }

        private bool IsZ5() //z5: weitere NW/Fremdsprache/Inf von Q1-Q2
        {
            bool z5 = false;

            if (e_e1.IsChecked.Value && e_e2.IsChecked.Value && e_q1.IsChecked.Value && e_q2.IsChecked.Value && e_q3.IsChecked.Value && e_q4.IsChecked.Value)
            {
                if (l_q1.IsChecked.Value && l_q2.IsChecked.Value)
                    z5 = true;
                else if (f_q1.IsChecked.Value && f_q2.IsChecked.Value)
                    z5 = true;
            }
            else if (l_e1.IsChecked.Value && l_e2.IsChecked.Value && l_q1.IsChecked.Value && l_q2.IsChecked.Value && l_q3.IsChecked.Value && l_q4.IsChecked.Value)
            {
                if (e_q1.IsChecked.Value && e_q2.IsChecked.Value)
                    z5 = true;
                else if (f_q1.IsChecked.Value && f_q2.IsChecked.Value)
                    z5 = true;
            }
            else if (f_e1.IsChecked.Value && f_e2.IsChecked.Value && f_q1.IsChecked.Value && f_q2.IsChecked.Value && f_q3.IsChecked.Value && f_q4.IsChecked.Value)
            {
                if (l_q1.IsChecked.Value && l_q2.IsChecked.Value)
                    z5 = true;
                else if (f_q1.IsChecked.Value && f_q2.IsChecked.Value)
                    z5 = true;
            }
            else if (p_e1.IsChecked.Value && p_e2.IsChecked.Value && p_q1.IsChecked.Value && p_q2.IsChecked.Value && p_q3.IsChecked.Value && p_q4.IsChecked.Value)
            {
                if (b_q1.IsChecked.Value && b_q2.IsChecked.Value)
                    z5 = true;
                else if (c_q1.IsChecked.Value && c_q2.IsChecked.Value)
                    z5 = true;
            }
            else if (b_e1.IsChecked.Value && b_e2.IsChecked.Value && b_q1.IsChecked.Value && b_q2.IsChecked.Value && b_q3.IsChecked.Value && b_q4.IsChecked.Value)
            {
                if (p_q1.IsChecked.Value && p_q2.IsChecked.Value)
                    z5 = true;
                else if (c_q1.IsChecked.Value && c_q2.IsChecked.Value)
                    z5 = true;
            }
            else if (c_e1.IsChecked.Value && c_e2.IsChecked.Value && c_q1.IsChecked.Value && c_q2.IsChecked.Value && c_q3.IsChecked.Value && c_q4.IsChecked.Value)
            {
                if (p_q1.IsChecked.Value && p_q2.IsChecked.Value)
                    z5 = true;
                else if (b_q1.IsChecked.Value && b_q2.IsChecked.Value)
                    z5 = true;
            }
            else if (inf_q1.IsChecked.Value && inf_q2.IsChecked.Value)
                z5 = true;

            return z5;
        }

        private bool IsZ6() //z6: Rel/Eth von E1-E2 (optional alternierend)
        {
            if ((evrel_e1.IsChecked.Value ^ kathrel_e1.IsChecked.Value ^ eth_e1.IsChecked.Value) && (evrel_e2.IsChecked.Value ^ kathrel_e2.IsChecked.Value ^ eth_e2.IsChecked.Value))
                return true;
            else
                return false;
        }

        private bool IsZ7() //z7: Ku/Mu/DS von E1-E2 (optional alternierend)
        {
            if ((ku_e1.IsChecked.Value ^ mu_e1.IsChecked.Value ^ ds_e1.IsChecked.Value) && (ku_e2.IsChecked.Value ^ mu_e2.IsChecked.Value ^ ds_e2.IsChecked.Value))
                return true;
            else
                return false;
        }

        private bool IsZ8() //z8: Lat/Frz von E1-E2
        {
            if (l_e1.IsChecked.Value && l_e2.IsChecked.Value)
                return true;
            else if (f_e1.IsChecked.Value && f_e2.IsChecked.Value)
                return true;
            else
                return false;
        }

        private bool IsZ9() //z9: 2 LKs
        {
            int k = 0;
            bool[] lks = new bool[] { d_lk.IsChecked.Value, e_lk.IsChecked.Value, f_lk.IsChecked.Value, l_lk.IsChecked.Value, mu_lk.IsChecked.Value, ku_lk.IsChecked.Value, ds_lk.IsChecked.Value, g_lk.IsChecked.Value, pw_lk.IsChecked.Value, evrel_lk.IsChecked.Value, kathrel_lk.IsChecked.Value, eth_lk.IsChecked.Value, m_lk.IsChecked.Value, b_lk.IsChecked.Value, c_lk.IsChecked.Value, p_lk.IsChecked.Value, inf_lk.IsChecked.Value, pe_lk.IsChecked.Value };
            for (int i = 0; i < lks.Length; i++)
                if (lks[i])
                    k++;

            if (k == 2)
                return true;
            else
                return false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!IsZ1())
            {
                MessageBox.Show("Es wurde keine durchgängig belegte Fremdsprache eingetragen.");
                return;
            }
            if (!IsZ2())
            {
                MessageBox.Show("Es wurde keine durchgängig belegte Naturwissenschaft eingetragen.");
                return;
            }
            if (!IsZ3())
            {
                MessageBox.Show("Religion/Ethik wurde nicht durchgängig in der Qualifikationsphase belegt.");
                return;
            }
            if (!IsZ4())
            {
                MessageBox.Show("Kunst/Musik/DS wurde nicht durchgängig in den ersten beiden Halbjahren der Qualifikationsphase belegt.");
                return;
            }
            if (!IsZ5())
            {
                MessageBox.Show("In den ersten beiden Halbjahren der Qualifikationsphase wurde keine weitere Fremdsprache/Naturwissenschaft/Informatik durchgängig belegt.");
                return;
            }
            if (!IsZ6())
            {
                MessageBox.Show("Religion/Ethik wurde nicht in der Einführungsphase belegt.");
                return;
            }
            if (!IsZ7())
            {
                MessageBox.Show("Kunst/Musik/DS wurde nicht in der Einführungsphase belegt.");
                return;
            }
            if (!IsZ8())
            {
                MessageBox.Show("Latein/Französisch wurde nicht durchgängig in der Einführungsphase belegt.");
                return;
            }
            if (!IsZ9())
            {
                MessageBox.Show("Es wurden mehr/weniger als zwei LKs belegt.");
                return;
            }

            this.Close();
        }

        private void d_lk_Checked(object sender, RoutedEventArgs e)
        {
            d_e1.IsChecked = true;
            d_e2.IsChecked = true;
            d_q1.IsChecked = true;
            d_q2.IsChecked = true;
            d_q3.IsChecked = true;
            d_q4.IsChecked = true;
        }

        private void e_lk_Checked(object sender, RoutedEventArgs e)
        {
            e_e1.IsChecked = true;
            e_e2.IsChecked = true;
            e_q1.IsChecked = true;
            e_q2.IsChecked = true;
            e_q3.IsChecked = true;
            e_q4.IsChecked = true;
        }

        private void f_lk_Checked(object sender, RoutedEventArgs e)
        {
            f_e1.IsChecked = true;
            f_e2.IsChecked = true;
            f_q1.IsChecked = true;
            f_q2.IsChecked = true;
            f_q3.IsChecked = true;
            f_q4.IsChecked = true;
        }

        private void l_lk_Checked(object sender, RoutedEventArgs e)
        {
            l_e1.IsChecked = true;
            l_e2.IsChecked = true;
            l_q1.IsChecked = true;
            l_q2.IsChecked = true;
            l_q3.IsChecked = true;
            l_q4.IsChecked = true;
        }

        private void mu_lk_Checked(object sender, RoutedEventArgs e)
        {
            mu_e1.IsChecked = true;
            mu_e2.IsChecked = true;
            mu_q1.IsChecked = true;
            mu_q2.IsChecked = true;
            mu_q3.IsChecked = true;
            mu_q4.IsChecked = true;
        }

        private void ku_lk_Checked(object sender, RoutedEventArgs e)
        {
            ku_e1.IsChecked = true;
            ku_e2.IsChecked = true;
            ku_q1.IsChecked = true;
            ku_q2.IsChecked = true;
            ku_q3.IsChecked = true;
            ku_q4.IsChecked = true;
        }

        private void ds_lk_Checked(object sender, RoutedEventArgs e)
        {
            ds_e1.IsChecked = true;
            ds_e2.IsChecked = true;
            ds_q1.IsChecked = true;
            ds_q2.IsChecked = true;
            ds_q3.IsChecked = true;
            ds_q4.IsChecked = true;
        }

        private void g_lk_Checked(object sender, RoutedEventArgs e)
        {
            g_e1.IsChecked = true;
            g_e2.IsChecked = true;
            g_q1.IsChecked = true;
            g_q2.IsChecked = true;
            g_q3.IsChecked = true;
            g_q4.IsChecked = true;
        }

        private void pw_lk_Checked(object sender, RoutedEventArgs e)
        {
            pw_e1.IsChecked = true;
            pw_e2.IsChecked = true;
            pw_q1.IsChecked = true;
            pw_q2.IsChecked = true;
            pw_q3.IsChecked = true;
            pw_q4.IsChecked = true;
        }

        private void evrel_lk_Checked(object sender, RoutedEventArgs e)
        {
            evrel_e1.IsChecked = true;
            evrel_e2.IsChecked = true;
            evrel_q1.IsChecked = true;
            evrel_q2.IsChecked = true;
            evrel_q3.IsChecked = true;
            evrel_q4.IsChecked = true;
        }

        private void kathrel_lk_Checked(object sender, RoutedEventArgs e)
        {
            kathrel_e1.IsChecked = true;
            kathrel_e2.IsChecked = true;
            kathrel_q1.IsChecked = true;
            kathrel_q2.IsChecked = true;
            kathrel_q3.IsChecked = true;
            kathrel_q4.IsChecked = true;
        }

        private void eth_lk_Checked(object sender, RoutedEventArgs e)
        {
            eth_e1.IsChecked = true;
            eth_e2.IsChecked = true;
            eth_q1.IsChecked = true;
            eth_q2.IsChecked = true;
            eth_q3.IsChecked = true;
            eth_q4.IsChecked = true;
        }

        private void m_lk_Checked(object sender, RoutedEventArgs e)
        {
            m_e1.IsChecked = true;
            m_e2.IsChecked = true;
            m_q1.IsChecked = true;
            m_q2.IsChecked = true;
            m_q3.IsChecked = true;
            m_q4.IsChecked = true;
        }

        private void b_lk_Checked(object sender, RoutedEventArgs e)
        {
            b_e1.IsChecked = true;
            b_e2.IsChecked = true;
            b_q1.IsChecked = true;
            b_q2.IsChecked = true;
            b_q3.IsChecked = true;
            b_q4.IsChecked = true;
        }

        private void c_lk_Checked(object sender, RoutedEventArgs e)
        {
            c_e1.IsChecked = true;
            c_e2.IsChecked = true;
            c_q1.IsChecked = true;
            c_q2.IsChecked = true;
            c_q3.IsChecked = true;
            c_q4.IsChecked = true;
        }

        private void p_lk_Checked(object sender, RoutedEventArgs e)
        {
            p_e1.IsChecked = true;
            p_e2.IsChecked = true;
            p_q1.IsChecked = true;
            p_q2.IsChecked = true;
            p_q3.IsChecked = true;
            p_q4.IsChecked = true;
        }

        private void inf_lk_Checked(object sender, RoutedEventArgs e)
        {
            inf_e1.IsChecked = true;
            inf_e2.IsChecked = true;
            inf_q1.IsChecked = true;
            inf_q2.IsChecked = true;
            inf_q3.IsChecked = true;
            inf_q4.IsChecked = true;
        }

        private void pe_lk_Checked(object sender, RoutedEventArgs e)
        {
            pe_e1.IsChecked = true;
            pe_e2.IsChecked = true;
            pe_q1.IsChecked = true;
            pe_q2.IsChecked = true;
            pe_q3.IsChecked = true;
            pe_q4.IsChecked = true;
        }
    }
}
