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
        private int studentId;
        private MainWindow mainWindow;
        private Exam[] exams;

        public TakenCourses(MainWindow mw, int sid)
        {
            InitializeComponent();
            mainWindow = mw;
            studentId = sid;
        }

        public TakenCourses(MainWindow mw, Course[] courses, Exam[] exs, int sid)
        {
            InitializeComponent();
            mainWindow = mw;
            exams = exs;
            studentId = sid;

            foreach(Course course in courses)
            {
                switch(course.Name)
                {
                    case "Deutsch":
                        d_e1.IsChecked = course.E1 >= 0;
                        d_e2.IsChecked = course.E2 >= 0;
                        d_q1.IsChecked = course.Q1 >= 0;
                        d_q2.IsChecked = course.Q2 >= 0;
                        d_q3.IsChecked = course.Q3 >= 0;
                        d_q4.IsChecked = course.Q4 >= 0;
                        d_lk.IsChecked = course.LK;
                        break;

                    case "Englisch":
                        e_e1.IsChecked = course.E1 >= 0;
                        e_e2.IsChecked = course.E2 >= 0;
                        e_q1.IsChecked = course.Q1 >= 0;
                        e_q2.IsChecked = course.Q2 >= 0;
                        e_q3.IsChecked = course.Q3 >= 0;
                        e_q4.IsChecked = course.Q4 >= 0;
                        e_lk.IsChecked = course.LK;
                        break;

                    case "Französisch":
                        f_e1.IsChecked = course.E1 >= 0;
                        f_e2.IsChecked = course.E2 >= 0;
                        f_q1.IsChecked = course.Q1 >= 0;
                        f_q2.IsChecked = course.Q2 >= 0;
                        f_q3.IsChecked = course.Q3 >= 0;
                        f_q4.IsChecked = course.Q4 >= 0;
                        f_lk.IsChecked = course.LK;
                        break;

                    case "Italienisch":
                        it_e1.IsChecked = course.E1 >= 0;
                        it_e2.IsChecked = course.E2 >= 0;
                        it_q1.IsChecked = course.Q1 >= 0;
                        it_q2.IsChecked = course.Q2 >= 0;
                        it_q3.IsChecked = course.Q3 >= 0;
                        it_q4.IsChecked = course.Q4 >= 0;
                        it_lk.IsChecked = course.LK;
                        break;

                    case "Spanisch":
                        sp_e1.IsChecked = course.E1 >= 0;
                        sp_e2.IsChecked = course.E2 >= 0;
                        sp_q1.IsChecked = course.Q1 >= 0;
                        sp_q2.IsChecked = course.Q2 >= 0;
                        sp_q3.IsChecked = course.Q3 >= 0;
                        sp_q4.IsChecked = course.Q4 >= 0;
                        sp_lk.IsChecked = course.LK;
                        break;

                    case "Russisch":
                        ru_e1.IsChecked = course.E1 >= 0;
                        ru_e2.IsChecked = course.E2 >= 0;
                        ru_q1.IsChecked = course.Q1 >= 0;
                        ru_q2.IsChecked = course.Q2 >= 0;
                        ru_q3.IsChecked = course.Q3 >= 0;
                        ru_q4.IsChecked = course.Q4 >= 0;
                        ru_lk.IsChecked = course.LK;
                        break;

                    case "Griechisch":
                        gr_e1.IsChecked = course.E1 >= 0;
                        gr_e2.IsChecked = course.E2 >= 0;
                        gr_q1.IsChecked = course.Q1 >= 0;
                        gr_q2.IsChecked = course.Q2 >= 0;
                        gr_q3.IsChecked = course.Q3 >= 0;
                        gr_q4.IsChecked = course.Q4 >= 0;
                        gr_lk.IsChecked = course.LK;
                        break;

                    case "Latein":
                        l_e1.IsChecked = course.E1 >= 0;
                        l_e2.IsChecked = course.E2 >= 0;
                        l_q1.IsChecked = course.Q1 >= 0;
                        l_q2.IsChecked = course.Q2 >= 0;
                        l_q3.IsChecked = course.Q3 >= 0;
                        l_q4.IsChecked = course.Q4 >= 0;
                        l_lk.IsChecked = course.LK;
                        break;

                    case "Musik":
                        mu_e1.IsChecked = course.E1 >= 0;
                        mu_e2.IsChecked = course.E2 >= 0;
                        mu_q1.IsChecked = course.Q1 >= 0;
                        mu_q2.IsChecked = course.Q2 >= 0;
                        mu_q3.IsChecked = course.Q3 >= 0;
                        mu_q4.IsChecked = course.Q4 >= 0;
                        mu_lk.IsChecked = course.LK;
                        break;

                    case "Kunst":
                        ku_e1.IsChecked = course.E1 >= 0;
                        ku_e2.IsChecked = course.E2 >= 0;
                        ku_q1.IsChecked = course.Q1 >= 0;
                        ku_q2.IsChecked = course.Q2 >= 0;
                        ku_q3.IsChecked = course.Q3 >= 0;
                        ku_q4.IsChecked = course.Q4 >= 0;
                        ku_lk.IsChecked = course.LK;
                        break;

                    case "Darstellendes Spiel":
                        ds_e1.IsChecked = course.E1 >= 0;
                        ds_e2.IsChecked = course.E2 >= 0;
                        ds_q1.IsChecked = course.Q1 >= 0;
                        ds_q2.IsChecked = course.Q2 >= 0;
                        ds_q3.IsChecked = course.Q3 >= 0;
                        ds_q4.IsChecked = course.Q4 >= 0;
                        break;

                    case "Geschichte":
                        g_e1.IsChecked = course.E1 >= 0;
                        g_e2.IsChecked = course.E2 >= 0;
                        g_q1.IsChecked = course.Q1 >= 0;
                        g_q2.IsChecked = course.Q2 >= 0;
                        g_q3.IsChecked = course.Q3 >= 0;
                        g_q4.IsChecked = course.Q4 >= 0;
                        g_lk.IsChecked = course.LK;
                        break;

                    case "Politik und Wirtschaft":
                        pw_e1.IsChecked = course.E1 >= 0;
                        pw_e2.IsChecked = course.E2 >= 0;
                        pw_q1.IsChecked = course.Q1 >= 0;
                        pw_q2.IsChecked = course.Q2 >= 0;
                        pw_q3.IsChecked = course.Q3 >= 0;
                        pw_q4.IsChecked = course.Q4 >= 0;
                        pw_lk.IsChecked = course.LK;
                        break;

                    case "Wirtschaftswissens.":
                        ec_e1.IsChecked = course.E1 >= 0;
                        ec_e2.IsChecked = course.E2 >= 0;
                        ec_q1.IsChecked = course.Q1 >= 0;
                        ec_q2.IsChecked = course.Q2 >= 0;
                        ec_q3.IsChecked = course.Q3 >= 0;
                        ec_q4.IsChecked = course.Q4 >= 0;
                        ec_lk.IsChecked = course.LK;
                        break;

                    case "Rechtskunde":
                        law_e1.IsChecked = course.E1 >= 0;
                        law_e2.IsChecked = course.E2 >= 0;
                        law_q1.IsChecked = course.Q1 >= 0;
                        law_q2.IsChecked = course.Q2 >= 0;
                        law_q3.IsChecked = course.Q3 >= 0;
                        law_q4.IsChecked = course.Q4 >= 0;
                        break;

                    case "Philosophie":
                        phil_e1.IsChecked = course.E1 >= 0;
                        phil_e2.IsChecked = course.E2 >= 0;
                        phil_q1.IsChecked = course.Q1 >= 0;
                        phil_q2.IsChecked = course.Q2 >= 0;
                        phil_q3.IsChecked = course.Q3 >= 0;
                        phil_q4.IsChecked = course.Q4 >= 0;
                        break;

                    case "Erdkunde":
                        ek_e1.IsChecked = course.E1 >= 0;
                        ek_e2.IsChecked = course.E2 >= 0;
                        ek_q1.IsChecked = course.Q1 >= 0;
                        ek_q2.IsChecked = course.Q2 >= 0;
                        ek_q3.IsChecked = course.Q3 >= 0;
                        ek_q4.IsChecked = course.Q4 >= 0;
                        ek_lk.IsChecked = course.LK;
                        break;

                    case "Ev. Religion":
                        evrel_e1.IsChecked = course.E1 >= 0;
                        evrel_e2.IsChecked = course.E2 >= 0;
                        evrel_q1.IsChecked = course.Q1 >= 0;
                        evrel_q2.IsChecked = course.Q2 >= 0;
                        evrel_q3.IsChecked = course.Q3 >= 0;
                        evrel_q4.IsChecked = course.Q4 >= 0;
                        evrel_lk.IsChecked = course.LK;
                        break;

                    case "Kath. Religion":
                        kathrel_e1.IsChecked = course.E1 >= 0;
                        kathrel_e2.IsChecked = course.E2 >= 0;
                        kathrel_q1.IsChecked = course.Q1 >= 0;
                        kathrel_q2.IsChecked = course.Q2 >= 0;
                        kathrel_q3.IsChecked = course.Q3 >= 0;
                        kathrel_q4.IsChecked = course.Q4 >= 0;
                        kathrel_lk.IsChecked = course.LK;
                        break;

                    case "Ethik":
                        eth_e1.IsChecked = course.E1 >= 0;
                        eth_e2.IsChecked = course.E2 >= 0;
                        eth_q1.IsChecked = course.Q1 >= 0;
                        eth_q2.IsChecked = course.Q2 >= 0;
                        eth_q3.IsChecked = course.Q3 >= 0;
                        eth_q4.IsChecked = course.Q4 >= 0;
                        break;

                    case "Mathematik":
                        m_e1.IsChecked = course.E1 >= 0;
                        m_e2.IsChecked = course.E2 >= 0;
                        m_q1.IsChecked = course.Q1 >= 0;
                        m_q2.IsChecked = course.Q2 >= 0;
                        m_q3.IsChecked = course.Q3 >= 0;
                        m_q4.IsChecked = course.Q4 >= 0;
                        m_lk.IsChecked = course.LK;
                        break;

                    case "Biologie":
                        b_e1.IsChecked = course.E1 >= 0;
                        b_e2.IsChecked = course.E2 >= 0;
                        b_q1.IsChecked = course.Q1 >= 0;
                        b_q2.IsChecked = course.Q2 >= 0;
                        b_q3.IsChecked = course.Q3 >= 0;
                        b_q4.IsChecked = course.Q4 >= 0;
                        b_lk.IsChecked = course.LK;
                        break;

                    case "Chemie":
                        c_e1.IsChecked = course.E1 >= 0;
                        c_e2.IsChecked = course.E2 >= 0;
                        c_q1.IsChecked = course.Q1 >= 0;
                        c_q2.IsChecked = course.Q2 >= 0;
                        c_q3.IsChecked = course.Q3 >= 0;
                        c_q4.IsChecked = course.Q4 >= 0;
                        c_lk.IsChecked = course.LK;
                        break;

                    case "Physik":
                        p_e1.IsChecked = course.E1 >= 0;
                        p_e2.IsChecked = course.E2 >= 0;
                        p_q1.IsChecked = course.Q1 >= 0;
                        p_q2.IsChecked = course.Q2 >= 0;
                        p_q3.IsChecked = course.Q3 >= 0;
                        p_q4.IsChecked = course.Q4 >= 0;
                        p_lk.IsChecked = course.LK;
                        break;

                    case "Informatik":
                        inf_e1.IsChecked = course.E1 >= 0;
                        inf_e2.IsChecked = course.E2 >= 0;
                        inf_q1.IsChecked = course.Q1 >= 0;
                        inf_q2.IsChecked = course.Q2 >= 0;
                        inf_q3.IsChecked = course.Q3 >= 0;
                        inf_q4.IsChecked = course.Q4 >= 0;
                        inf_lk.IsChecked = course.LK;
                        break;

                    case "Sport":
                        pe_e1.IsChecked = course.E1 >= 0;
                        pe_e2.IsChecked = course.E2 >= 0;
                        pe_q1.IsChecked = course.Q1 >= 0;
                        pe_q2.IsChecked = course.Q2 >= 0;
                        pe_q3.IsChecked = course.Q3 >= 0;
                        pe_q4.IsChecked = course.Q4 >= 0;
                        pe_lk.IsChecked = course.LK;
                        pe_3std.IsChecked = course.Pe3Std;
                        break;

                }
            }
        }

        private bool IsZ1() //z1: Fremdsprache von E1-Q4
        {
            if (e_e1.IsChecked.Value && e_e2.IsChecked.Value && e_q1.IsChecked.Value && e_q2.IsChecked.Value && e_q3.IsChecked.Value && e_q4.IsChecked.Value)
                return true;
            else if (f_e1.IsChecked.Value && f_e2.IsChecked.Value && f_q1.IsChecked.Value && f_q2.IsChecked.Value && f_q3.IsChecked.Value && f_q4.IsChecked.Value)
                return true;
            else if (it_e1.IsChecked.Value && it_e2.IsChecked.Value && it_q1.IsChecked.Value && it_q2.IsChecked.Value && it_q3.IsChecked.Value && it_q4.IsChecked.Value)
                return true;
            else if (sp_e1.IsChecked.Value && sp_e2.IsChecked.Value && sp_q1.IsChecked.Value && sp_q2.IsChecked.Value && sp_q3.IsChecked.Value && sp_q4.IsChecked.Value)
                return true;
            else if (ru_e1.IsChecked.Value && ru_e2.IsChecked.Value && ru_q1.IsChecked.Value && ru_q2.IsChecked.Value && ru_q3.IsChecked.Value && ru_q4.IsChecked.Value)
                return true;
            else if (gr_e1.IsChecked.Value && gr_e2.IsChecked.Value && gr_q1.IsChecked.Value && gr_q2.IsChecked.Value && gr_q3.IsChecked.Value && gr_q4.IsChecked.Value)
                return true;
            else if (l_e1.IsChecked.Value && l_e2.IsChecked.Value && l_q1.IsChecked.Value && l_q2.IsChecked.Value && l_q3.IsChecked.Value && l_q4.IsChecked.Value)
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
                if (f_q1.IsChecked.Value && f_q2.IsChecked.Value)
                    z5 = true;
                else if (it_q1.IsChecked.Value && it_q2.IsChecked.Value)
                    z5 = true;
                else if (sp_q1.IsChecked.Value && sp_q2.IsChecked.Value)
                    z5 = true;
                else if (ru_q1.IsChecked.Value && ru_q2.IsChecked.Value)
                    z5 = true;
                else if (gr_q1.IsChecked.Value && gr_q2.IsChecked.Value)
                    z5 = true;
                else if (l_q1.IsChecked.Value && l_q2.IsChecked.Value)
                    z5 = true;
            }
            if (f_e1.IsChecked.Value && f_e2.IsChecked.Value && f_q1.IsChecked.Value && f_q2.IsChecked.Value && f_q3.IsChecked.Value && f_q4.IsChecked.Value)
            {
                if (e_q1.IsChecked.Value && e_q2.IsChecked.Value)
                    z5 = true;
                else if (it_q1.IsChecked.Value && it_q2.IsChecked.Value)
                    z5 = true;
                else if (sp_q1.IsChecked.Value && sp_q2.IsChecked.Value)
                    z5 = true;
                else if (ru_q1.IsChecked.Value && ru_q2.IsChecked.Value)
                    z5 = true;
                else if (gr_q1.IsChecked.Value && gr_q2.IsChecked.Value)
                    z5 = true;
                else if(l_q1.IsChecked.Value && l_q2.IsChecked.Value)
                    z5 = true;
            }
            if (it_e1.IsChecked.Value && it_e2.IsChecked.Value && it_q1.IsChecked.Value && it_q2.IsChecked.Value && it_q3.IsChecked.Value && it_q4.IsChecked.Value)
            {
                if (e_q1.IsChecked.Value && e_q2.IsChecked.Value)
                    z5 = true;
                else if (f_q1.IsChecked.Value && f_q2.IsChecked.Value)
                    z5 = true;
                else if (sp_q1.IsChecked.Value && sp_q2.IsChecked.Value)
                    z5 = true;
                else if (ru_q1.IsChecked.Value && ru_q2.IsChecked.Value)
                    z5 = true;
                else if (gr_q1.IsChecked.Value && gr_q2.IsChecked.Value)
                    z5 = true;
                else if (l_q1.IsChecked.Value && l_q2.IsChecked.Value)
                    z5 = true;
            }
            if (sp_e1.IsChecked.Value && sp_e2.IsChecked.Value && sp_q1.IsChecked.Value && sp_q2.IsChecked.Value && sp_q3.IsChecked.Value && sp_q4.IsChecked.Value)
            {
                if (e_q1.IsChecked.Value && e_q2.IsChecked.Value)
                    z5 = true;
                else if (f_q1.IsChecked.Value && f_q2.IsChecked.Value)
                    z5 = true;
                else if (it_q1.IsChecked.Value && it_q2.IsChecked.Value)
                    z5 = true;
                else if (ru_q1.IsChecked.Value && ru_q2.IsChecked.Value)
                    z5 = true;
                else if (gr_q1.IsChecked.Value && gr_q2.IsChecked.Value)
                    z5 = true;
                else if (l_q1.IsChecked.Value && l_q2.IsChecked.Value)
                    z5 = true;
            }
            if (ru_e1.IsChecked.Value && ru_e2.IsChecked.Value && ru_q1.IsChecked.Value && ru_q2.IsChecked.Value && ru_q3.IsChecked.Value && ru_q4.IsChecked.Value)
            {
                if (e_q1.IsChecked.Value && e_q2.IsChecked.Value)
                    z5 = true;
                else if (f_q1.IsChecked.Value && f_q2.IsChecked.Value)
                    z5 = true;
                else if (it_q1.IsChecked.Value && it_q2.IsChecked.Value)
                    z5 = true;
                else if (sp_q1.IsChecked.Value && sp_q2.IsChecked.Value)
                    z5 = true;
                else if (gr_q1.IsChecked.Value && gr_q2.IsChecked.Value)
                    z5 = true;
                else if (l_q1.IsChecked.Value && l_q2.IsChecked.Value)
                    z5 = true;
            }
            if (gr_e1.IsChecked.Value && gr_e2.IsChecked.Value && gr_q1.IsChecked.Value && gr_q2.IsChecked.Value && gr_q3.IsChecked.Value && gr_q4.IsChecked.Value)
            {
                if (e_q1.IsChecked.Value && e_q2.IsChecked.Value)
                    z5 = true;
                else if (f_q1.IsChecked.Value && f_q2.IsChecked.Value)
                    z5 = true;
                else if (it_q1.IsChecked.Value && it_q2.IsChecked.Value)
                    z5 = true;
                else if (sp_q1.IsChecked.Value && sp_q2.IsChecked.Value)
                    z5 = true;
                else if (ru_q1.IsChecked.Value && ru_q2.IsChecked.Value)
                    z5 = true;
                else if (l_q1.IsChecked.Value && l_q2.IsChecked.Value)
                    z5 = true;
            }
            if (l_e1.IsChecked.Value && l_e2.IsChecked.Value && l_q1.IsChecked.Value && l_q2.IsChecked.Value && l_q3.IsChecked.Value && l_q4.IsChecked.Value)
            {
                if (e_q1.IsChecked.Value && e_q2.IsChecked.Value)
                    z5 = true;
                else if (f_q1.IsChecked.Value && f_q2.IsChecked.Value)
                    z5 = true;
                else if (it_q1.IsChecked.Value && it_q2.IsChecked.Value)
                    z5 = true;
                else if (sp_q1.IsChecked.Value && sp_q2.IsChecked.Value)
                    z5 = true;
                else if (ru_q1.IsChecked.Value && ru_q2.IsChecked.Value)
                    z5 = true;
                else if (gr_q1.IsChecked.Value && gr_q2.IsChecked.Value)
                    z5 = true;
            }
            if (p_e1.IsChecked.Value && p_e2.IsChecked.Value && p_q1.IsChecked.Value && p_q2.IsChecked.Value && p_q3.IsChecked.Value && p_q4.IsChecked.Value)
            {
                if (b_q1.IsChecked.Value && b_q2.IsChecked.Value)
                    z5 = true;
                else if (c_q1.IsChecked.Value && c_q2.IsChecked.Value)
                    z5 = true;
            }
            if (b_e1.IsChecked.Value && b_e2.IsChecked.Value && b_q1.IsChecked.Value && b_q2.IsChecked.Value && b_q3.IsChecked.Value && b_q4.IsChecked.Value)
            {
                if (p_q1.IsChecked.Value && p_q2.IsChecked.Value)
                    z5 = true;
                else if (c_q1.IsChecked.Value && c_q2.IsChecked.Value)
                    z5 = true;
            }
            if (c_e1.IsChecked.Value && c_e2.IsChecked.Value && c_q1.IsChecked.Value && c_q2.IsChecked.Value && c_q3.IsChecked.Value && c_q4.IsChecked.Value)
            {
                if (p_q1.IsChecked.Value && p_q2.IsChecked.Value)
                    z5 = true;
                else if (b_q1.IsChecked.Value && b_q2.IsChecked.Value)
                    z5 = true;
            }
            if (inf_q1.IsChecked.Value && inf_q2.IsChecked.Value)
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

        private bool IsZ8() //z8: Zweite Fremdsprache von E1-E2
        {
            bool z8 = false;

            if (e_e1.IsChecked.Value && e_e2.IsChecked.Value && e_q1.IsChecked.Value && e_q2.IsChecked.Value && e_q3.IsChecked.Value && e_q4.IsChecked.Value)
            {
                if (f_e1.IsChecked.Value && f_e2.IsChecked.Value)
                    z8 = true;
                else if (it_e1.IsChecked.Value && it_e2.IsChecked.Value)
                    z8 = true;
                else if (sp_e1.IsChecked.Value && sp_e2.IsChecked.Value)
                    z8 = true;
                else if (ru_e1.IsChecked.Value && ru_e2.IsChecked.Value)
                    z8 = true;
                else if (gr_e1.IsChecked.Value && gr_e2.IsChecked.Value)
                    z8 = true;
                else if (l_e1.IsChecked.Value && l_e2.IsChecked.Value)
                    z8 = true;
            }
            else if (f_e1.IsChecked.Value && f_e2.IsChecked.Value && f_q1.IsChecked.Value && f_q2.IsChecked.Value && f_q3.IsChecked.Value && f_q4.IsChecked.Value)
            {
                if (e_e1.IsChecked.Value && e_e2.IsChecked.Value)
                    z8 = true;
                else if (it_e1.IsChecked.Value && it_e2.IsChecked.Value)
                    z8 = true;
                else if (sp_e1.IsChecked.Value && sp_e2.IsChecked.Value)
                    z8 = true;
                else if (ru_e1.IsChecked.Value && ru_e2.IsChecked.Value)
                    z8 = true;
                else if (gr_e1.IsChecked.Value && gr_e2.IsChecked.Value)
                    z8 = true;
                else if(l_e1.IsChecked.Value && l_e2.IsChecked.Value)
                    z8 = true;
            }
            else if (it_e1.IsChecked.Value && it_e2.IsChecked.Value && it_q1.IsChecked.Value && it_q2.IsChecked.Value && it_q3.IsChecked.Value && it_q4.IsChecked.Value)
            {
                if (e_e1.IsChecked.Value && e_e2.IsChecked.Value)
                    z8 = true;
                else if (f_e1.IsChecked.Value && f_e2.IsChecked.Value)
                    z8 = true;
                else if (sp_e1.IsChecked.Value && sp_e2.IsChecked.Value)
                    z8 = true;
                else if (ru_e1.IsChecked.Value && ru_e2.IsChecked.Value)
                    z8 = true;
                else if (gr_e1.IsChecked.Value && gr_e2.IsChecked.Value)
                    z8 = true;
                else if (l_e1.IsChecked.Value && l_e2.IsChecked.Value)
                    z8 = true;
            }
            else if (sp_e1.IsChecked.Value && sp_e2.IsChecked.Value && sp_q1.IsChecked.Value && sp_q2.IsChecked.Value && sp_q3.IsChecked.Value && sp_q4.IsChecked.Value)
            {
                if (e_e1.IsChecked.Value && e_e2.IsChecked.Value)
                    z8 = true;
                else if (f_e1.IsChecked.Value && f_e2.IsChecked.Value)
                    z8 = true;
                else if (it_e1.IsChecked.Value && it_e2.IsChecked.Value)
                    z8 = true;
                else if (ru_e1.IsChecked.Value && ru_e2.IsChecked.Value)
                    z8 = true;
                else if (gr_e1.IsChecked.Value && gr_e2.IsChecked.Value)
                    z8 = true;
                else if (l_e1.IsChecked.Value && l_e2.IsChecked.Value)
                    z8 = true;
            }
            else if (ru_e1.IsChecked.Value && ru_e2.IsChecked.Value && ru_q1.IsChecked.Value && ru_q2.IsChecked.Value && ru_q3.IsChecked.Value && ru_q4.IsChecked.Value)
            {
                if (e_e1.IsChecked.Value && e_e2.IsChecked.Value)
                    z8 = true;
                else if (f_e1.IsChecked.Value && f_e2.IsChecked.Value)
                    z8 = true;
                else if (it_e1.IsChecked.Value && it_e2.IsChecked.Value)
                    z8 = true;
                else if (sp_e1.IsChecked.Value && sp_e2.IsChecked.Value)
                    z8 = true;
                else if (gr_e1.IsChecked.Value && gr_e2.IsChecked.Value)
                    z8 = true;
                else if (l_e1.IsChecked.Value && l_e2.IsChecked.Value)
                    z8 = true;
            }
            else if (gr_e1.IsChecked.Value && gr_e2.IsChecked.Value && gr_q1.IsChecked.Value && gr_q2.IsChecked.Value && gr_q3.IsChecked.Value && gr_q4.IsChecked.Value)
            {
                if (e_e1.IsChecked.Value && e_e2.IsChecked.Value)
                    z8 = true;
                else if (f_e1.IsChecked.Value && f_e2.IsChecked.Value)
                    z8 = true;
                else if (it_e1.IsChecked.Value && it_e2.IsChecked.Value)
                    z8 = true;
                else if (sp_e1.IsChecked.Value && sp_e2.IsChecked.Value)
                    z8 = true;
                else if (ru_e1.IsChecked.Value && ru_e2.IsChecked.Value)
                    z8 = true;
                else if (l_e1.IsChecked.Value && l_e2.IsChecked.Value)
                    z8 = true;
            }
            else if (l_e1.IsChecked.Value && l_e2.IsChecked.Value && l_q1.IsChecked.Value && l_q2.IsChecked.Value && l_q3.IsChecked.Value && l_q4.IsChecked.Value)
            {
                if (e_e1.IsChecked.Value && e_e2.IsChecked.Value)
                    z8 = true;
                else if (f_e1.IsChecked.Value && f_e2.IsChecked.Value)
                    z8 = true;
                else if (it_e1.IsChecked.Value && it_e2.IsChecked.Value)
                    z8 = true;
                else if (sp_e1.IsChecked.Value && sp_e2.IsChecked.Value)
                    z8 = true;
                else if (ru_e1.IsChecked.Value && ru_e2.IsChecked.Value)
                    z8 = true;
                else if (gr_e1.IsChecked.Value && gr_e2.IsChecked.Value)
                    z8 = true;
            }

            return z8;
        }

        private bool IsZ9() //z9: PW/Ec von E1-E2 (optional alternierend) und Q1/2
        {
            if ((pw_e1.IsChecked.Value ^ ec_e1.IsChecked.Value) && ((pw_e2.IsChecked.Value && pw_q1.IsChecked.Value && pw_q2.IsChecked.Value) || (ec_e2.IsChecked.Value && ec_q1.IsChecked.Value && ec_q2.IsChecked.Value)))
                return true;
            else
                return false;
        }

        private bool IsZ10() //z10: 2 LKs
        {
            int k = 0;
            bool[] lks = new bool[] { d_lk.IsChecked.Value, e_lk.IsChecked.Value, f_lk.IsChecked.Value, it_lk.IsChecked.Value, sp_lk.IsChecked.Value, ru_lk.IsChecked.Value, gr_lk.IsChecked.Value, l_lk.IsChecked.Value, mu_lk.IsChecked.Value, ku_lk.IsChecked.Value, g_lk.IsChecked.Value, pw_lk.IsChecked.Value, ec_lk.IsChecked.Value, ek_lk.IsChecked.Value, evrel_lk.IsChecked.Value, kathrel_lk.IsChecked.Value, m_lk.IsChecked.Value, b_lk.IsChecked.Value, c_lk.IsChecked.Value, p_lk.IsChecked.Value, inf_lk.IsChecked.Value, pe_lk.IsChecked.Value };
            for (int i = 0; i < lks.Length; i++)
                if (lks[i])
                    k++;

            if (k == 2)
                return true;
            else
                return false;
        }

        private bool IsZ11() //z11: Fremdsprache, Mathematik oder NW als LK1
        {
            if (e_lk.IsChecked.Value || f_lk.IsChecked.Value || it_lk.IsChecked.Value || sp_lk.IsChecked.Value || ru_lk.IsChecked.Value || gr_lk.IsChecked.Value || l_lk.IsChecked.Value || m_lk.IsChecked.Value || b_lk.IsChecked.Value || c_lk.IsChecked.Value || p_lk.IsChecked.Value)
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
                MessageBox.Show("Politik und Wirtschaft/Wirtschaftswissenschaften wurde nicht in der Einführungsphase sowie durchgängig in den ersten beiden Halbjahren der Qualifikationsphase belegt.");
                return;
            }
            if (!IsZ10())
            {
                MessageBox.Show("Es wurden mehr/weniger als zwei LKs belegt.");
                return;
            }
            if (!IsZ11())
            {
                MessageBox.Show("Ein LK muss eine fortgeführte Fremdsprache, eine Naturwissenschaft oder Mathematik sein.");
                return;
            }

            Course[] courses = new Course[] { getCourseD(), getCourseE(), getCourseF(), getCourseIt(), getCourseSp(), getCourseRu(), getCourseGr(), getCourseL(), getCourseMu(), getCourseKu(), getCourseDs(), getCourseG(), getCoursePw(), getCourseEc(), getCourseLaw(), getCoursePhil(), getCourseGeo(), getCourseEvrel(), getCourseKathrel(), getCourseEth(), getCourseM(), getCourseB(), getCourseC(), getCourseP(), getCourseInf(), getCoursePe() };

            ChosenExams chosenExams = new ChosenExams(mainWindow, courses, exams, studentId);
            chosenExams.Show();
            this.Close();
        }

        private void e_lk_Checked(object sender, RoutedEventArgs e)
        {
            e_e1.IsChecked = true;
            e_e2.IsChecked = true;
            e_q1.IsChecked = true;
            e_q2.IsChecked = true;
            e_q3.IsChecked = true;
            e_q4.IsChecked = true;

            e_e1.IsEnabled = false;
            e_e2.IsEnabled = false;
            e_q1.IsEnabled = false;
            e_q2.IsEnabled = false;
            e_q3.IsEnabled = false;
            e_q4.IsEnabled = false;
        }

        private void e_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            e_e1.IsEnabled = true;
            e_e2.IsEnabled = true;
            e_q1.IsEnabled = true;
            e_q2.IsEnabled = true;
            e_q3.IsEnabled = true;
            e_q4.IsEnabled = true;
        }

        private void f_lk_Checked(object sender, RoutedEventArgs e)
        {
            f_e1.IsChecked = true;
            f_e2.IsChecked = true;
            f_q1.IsChecked = true;
            f_q2.IsChecked = true;
            f_q3.IsChecked = true;
            f_q4.IsChecked = true;

            f_e1.IsEnabled = false;
            f_e2.IsEnabled = false;
            f_q1.IsEnabled = false;
            f_q2.IsEnabled = false;
            f_q3.IsEnabled = false;
            f_q4.IsEnabled = false;
        }

        private void f_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            f_e1.IsEnabled = true;
            f_e2.IsEnabled = true;
            f_q1.IsEnabled = true;
            f_q2.IsEnabled = true;
            f_q3.IsEnabled = true;
            f_q4.IsEnabled = true;
        }

        private void it_lk_Checked(object sender, RoutedEventArgs e)
        {
            it_e1.IsChecked = true;
            it_e2.IsChecked = true;
            it_q1.IsChecked = true;
            it_q2.IsChecked = true;
            it_q3.IsChecked = true;
            it_q4.IsChecked = true;

            it_e1.IsEnabled = false;
            it_e2.IsEnabled = false;
            it_q1.IsEnabled = false;
            it_q2.IsEnabled = false;
            it_q3.IsEnabled = false;
            it_q4.IsEnabled = false;
        }

        private void it_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            it_e1.IsEnabled = true;
            it_e2.IsEnabled = true;
            it_q1.IsEnabled = true;
            it_q2.IsEnabled = true;
            it_q3.IsEnabled = true;
            it_q4.IsEnabled = true;
        }

        private void sp_lk_Checked(object sender, RoutedEventArgs e)
        {
            sp_e1.IsChecked = true;
            sp_e2.IsChecked = true;
            sp_q1.IsChecked = true;
            sp_q2.IsChecked = true;
            sp_q3.IsChecked = true;
            sp_q4.IsChecked = true;

            sp_e1.IsEnabled = false;
            sp_e2.IsEnabled = false;
            sp_q1.IsEnabled = false;
            sp_q2.IsEnabled = false;
            sp_q3.IsEnabled = false;
            sp_q4.IsEnabled = false;
        }

        private void sp_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            sp_e1.IsEnabled = true;
            sp_e2.IsEnabled = true;
            sp_q1.IsEnabled = true;
            sp_q2.IsEnabled = true;
            sp_q3.IsEnabled = true;
            sp_q4.IsEnabled = true;
        }

        private void ru_lk_Checked(object sender, RoutedEventArgs e)
        {
            ru_e1.IsChecked = true;
            ru_e2.IsChecked = true;
            ru_q1.IsChecked = true;
            ru_q2.IsChecked = true;
            ru_q3.IsChecked = true;
            ru_q4.IsChecked = true;

            ru_e1.IsEnabled = false;
            ru_e2.IsEnabled = false;
            ru_q1.IsEnabled = false;
            ru_q2.IsEnabled = false;
            ru_q3.IsEnabled = false;
            ru_q4.IsEnabled = false;
        }

        private void ru_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            ru_e1.IsEnabled = true;
            ru_e2.IsEnabled = true;
            ru_q1.IsEnabled = true;
            ru_q2.IsEnabled = true;
            ru_q3.IsEnabled = true;
            ru_q4.IsEnabled = true;
        }

        private void gr_lk_Checked(object sender, RoutedEventArgs e)
        {
            gr_e1.IsChecked = true;
            gr_e2.IsChecked = true;
            gr_q1.IsChecked = true;
            gr_q2.IsChecked = true;
            gr_q3.IsChecked = true;
            gr_q4.IsChecked = true;

            gr_e1.IsEnabled = false;
            gr_e2.IsEnabled = false;
            gr_q1.IsEnabled = false;
            gr_q2.IsEnabled = false;
            gr_q3.IsEnabled = false;
            gr_q4.IsEnabled = false;
        }

        private void gr_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            gr_e1.IsEnabled = true;
            gr_e2.IsEnabled = true;
            gr_q1.IsEnabled = true;
            gr_q2.IsEnabled = true;
            gr_q3.IsEnabled = true;
            gr_q4.IsEnabled = true;
        }

        private void l_lk_Checked(object sender, RoutedEventArgs e)
        {
            l_e1.IsChecked = true;
            l_e2.IsChecked = true;
            l_q1.IsChecked = true;
            l_q2.IsChecked = true;
            l_q3.IsChecked = true;
            l_q4.IsChecked = true;

            l_e1.IsEnabled = false;
            l_e2.IsEnabled = false;
            l_q1.IsEnabled = false;
            l_q2.IsEnabled = false;
            l_q3.IsEnabled = false;
            l_q4.IsEnabled = false;
        }

        private void l_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            l_e1.IsEnabled = true;
            l_e2.IsEnabled = true;
            l_q1.IsEnabled = true;
            l_q2.IsEnabled = true;
            l_q3.IsEnabled = true;
            l_q4.IsEnabled = true;
        }

        private void mu_lk_Checked(object sender, RoutedEventArgs e)
        {
            mu_e1.IsChecked = true;
            mu_e2.IsChecked = true;
            mu_q1.IsChecked = true;
            mu_q2.IsChecked = true;
            mu_q3.IsChecked = true;
            mu_q4.IsChecked = true;

            mu_e1.IsEnabled = false;
            mu_e2.IsEnabled = false;
            mu_q1.IsEnabled = false;
            mu_q2.IsEnabled = false;
            mu_q3.IsEnabled = false;
            mu_q4.IsEnabled = false;
        }

        private void mu_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            mu_e1.IsEnabled = true;
            mu_e2.IsEnabled = true;
            mu_q1.IsEnabled = true;
            mu_q2.IsEnabled = true;
            mu_q3.IsEnabled = true;
            mu_q4.IsEnabled = true;
        }

        private void ku_lk_Checked(object sender, RoutedEventArgs e)
        {
            ku_e1.IsChecked = true;
            ku_e2.IsChecked = true;
            ku_q1.IsChecked = true;
            ku_q2.IsChecked = true;
            ku_q3.IsChecked = true;
            ku_q4.IsChecked = true;

            ku_e1.IsEnabled = false;
            ku_e2.IsEnabled = false;
            ku_q1.IsEnabled = false;
            ku_q2.IsEnabled = false;
            ku_q3.IsEnabled = false;
            ku_q4.IsEnabled = false;
        }

        private void ku_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            ku_e1.IsEnabled = true;
            ku_e2.IsEnabled = true;
            ku_q1.IsEnabled = true;
            ku_q2.IsEnabled = true;
            ku_q3.IsEnabled = true;
            ku_q4.IsEnabled = true;
        }

        private void pw_lk_Checked(object sender, RoutedEventArgs e)
        {
            pw_e1.IsChecked = true;
            pw_e2.IsChecked = true;
            pw_q1.IsChecked = true;
            pw_q2.IsChecked = true;
            pw_q3.IsChecked = true;
            pw_q4.IsChecked = true;

            pw_e1.IsEnabled = false;
            pw_e2.IsEnabled = false;
            pw_q1.IsEnabled = false;
            pw_q2.IsEnabled = false;
            pw_q3.IsEnabled = false;
            pw_q4.IsEnabled = false;
        }

        private void pw_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            pw_e1.IsEnabled = true;
            pw_e2.IsEnabled = true;
            pw_q1.IsEnabled = true;
            pw_q2.IsEnabled = true;
            pw_q3.IsEnabled = true;
            pw_q4.IsEnabled = true;
        }

        private void ec_lk_Checked(object sender, RoutedEventArgs e)
        {
            ec_e1.IsChecked = true;
            ec_e2.IsChecked = true;
            ec_q1.IsChecked = true;
            ec_q2.IsChecked = true;
            ec_q3.IsChecked = true;
            ec_q4.IsChecked = true;

            ec_e1.IsEnabled = false;
            ec_e2.IsEnabled = false;
            ec_q1.IsEnabled = false;
            ec_q2.IsEnabled = false;
            ec_q3.IsEnabled = false;
            ec_q4.IsEnabled = false;
        }

        private void ec_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            ec_e1.IsEnabled = true;
            ec_e2.IsEnabled = true;
            ec_q1.IsEnabled = true;
            ec_q2.IsEnabled = true;
            ec_q3.IsEnabled = true;
            ec_q4.IsEnabled = true;
        }

        private void ek_lk_Checked(object sender, RoutedEventArgs e)
        {
            ek_e1.IsChecked = true;
            ek_e2.IsChecked = true;
            ek_q1.IsChecked = true;
            ek_q2.IsChecked = true;
            ek_q3.IsChecked = true;
            ek_q4.IsChecked = true;

            ek_e1.IsEnabled = false;
            ek_e2.IsEnabled = false;
            ek_q1.IsEnabled = false;
            ek_q2.IsEnabled = false;
            ek_q3.IsEnabled = false;
            ek_q4.IsEnabled = false;
        }

        private void ek_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            ek_e1.IsEnabled = true;
            ek_e2.IsEnabled = true;
            ek_q1.IsEnabled = true;
            ek_q2.IsEnabled = true;
            ek_q3.IsEnabled = true;
            ek_q4.IsEnabled = true;
        }

        private void evrel_lk_Checked(object sender, RoutedEventArgs e)
        {
            evrel_e1.IsChecked = true;
            evrel_e2.IsChecked = true;
            evrel_q1.IsChecked = true;
            evrel_q2.IsChecked = true;
            evrel_q3.IsChecked = true;
            evrel_q4.IsChecked = true;

            evrel_e1.IsEnabled = false;
            evrel_e2.IsEnabled = false;
            evrel_q1.IsEnabled = false;
            evrel_q2.IsEnabled = false;
            evrel_q3.IsEnabled = false;
            evrel_q4.IsEnabled = false;
        }

        private void evrel_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            evrel_e1.IsEnabled = true;
            evrel_e2.IsEnabled = true;
            evrel_q1.IsEnabled = true;
            evrel_q2.IsEnabled = true;
            evrel_q3.IsEnabled = true;
            evrel_q4.IsEnabled = true;
        }

        private void kathrel_lk_Checked(object sender, RoutedEventArgs e)
        {
            kathrel_e1.IsChecked = true;
            kathrel_e2.IsChecked = true;
            kathrel_q1.IsChecked = true;
            kathrel_q2.IsChecked = true;
            kathrel_q3.IsChecked = true;
            kathrel_q4.IsChecked = true;

            kathrel_e1.IsEnabled = false;
            kathrel_e2.IsEnabled = false;
            kathrel_q1.IsEnabled = false;
            kathrel_q2.IsEnabled = false;
            kathrel_q3.IsEnabled = false;
            kathrel_q4.IsEnabled = false;
        }

        private void kathrel_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            kathrel_e1.IsEnabled = true;
            kathrel_e2.IsEnabled = true;
            kathrel_q1.IsEnabled = true;
            kathrel_q2.IsEnabled = true;
            kathrel_q3.IsEnabled = true;
            kathrel_q4.IsEnabled = true;
        }

        private void b_lk_Checked(object sender, RoutedEventArgs e)
        {
            b_q1.IsChecked = true;
            b_q2.IsChecked = true;
            b_q3.IsChecked = true;
            b_q4.IsChecked = true;

            b_q1.IsEnabled = false;
            b_q2.IsEnabled = false;
            b_q3.IsEnabled = false;
            b_q4.IsEnabled = false;
        }

        private void b_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            b_q1.IsEnabled = true;
            b_q2.IsEnabled = true;
            b_q3.IsEnabled = true;
            b_q4.IsEnabled = true;
        }

        private void c_lk_Checked(object sender, RoutedEventArgs e)
        {
            c_q1.IsChecked = true;
            c_q2.IsChecked = true;
            c_q3.IsChecked = true;
            c_q4.IsChecked = true;

            c_q1.IsEnabled = false;
            c_q2.IsEnabled = false;
            c_q3.IsEnabled = false;
            c_q4.IsEnabled = false;
        }

        private void c_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            c_q1.IsEnabled = true;
            c_q2.IsEnabled = true;
            c_q3.IsEnabled = true;
            c_q4.IsEnabled = true;
        }

        private void p_lk_Checked(object sender, RoutedEventArgs e)
        {
            p_q1.IsChecked = true;
            p_q2.IsChecked = true;
            p_q3.IsChecked = true;
            p_q4.IsChecked = true;

            p_q1.IsEnabled = false;
            p_q2.IsEnabled = false;
            p_q3.IsEnabled = false;
            p_q4.IsEnabled = false;
        }

        private void p_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            p_q1.IsEnabled = true;
            p_q2.IsEnabled = true;
            p_q3.IsEnabled = true;
            p_q4.IsEnabled = true;
        }

        private void inf_lk_Checked(object sender, RoutedEventArgs e)
        {
            inf_e1.IsChecked = true;
            inf_e2.IsChecked = true;
            inf_q1.IsChecked = true;
            inf_q2.IsChecked = true;
            inf_q3.IsChecked = true;
            inf_q4.IsChecked = true;

            inf_e1.IsEnabled = false;
            inf_e2.IsEnabled = false;
            inf_q1.IsEnabled = false;
            inf_q2.IsEnabled = false;
            inf_q3.IsEnabled = false;
            inf_q4.IsEnabled = false;
        }

        private void inf_lk_Unchecked(object sender, RoutedEventArgs e)
        {
            inf_e1.IsEnabled = true;
            inf_e2.IsEnabled = true;
            inf_q1.IsEnabled = true;
            inf_q2.IsEnabled = true;
            inf_q3.IsEnabled = true;
            inf_q4.IsEnabled = true;
        }

        private Course getCourseD()
        {
            Course courseD = new Course();
            courseD.Name = "Deutsch";
            courseD.Fb = 1;
            courseD.LK = d_lk.IsChecked.Value;
            courseD.E1 = d_e1.IsChecked.Value ? 0 : -1;
            courseD.E2 = d_e2.IsChecked.Value ? 0 : -1;
            courseD.Q1 = d_q1.IsChecked.Value ? 0 : -1;
            courseD.Q2 = d_q2.IsChecked.Value ? 0 : -1;
            courseD.Q3 = d_q3.IsChecked.Value ? 0 : -1;
            courseD.Q4 = d_q4.IsChecked.Value ? 0 : -1;

            return courseD;
        }

        private Course getCourseE()
        {
            Course courseE = new Course();
            courseE.Name = "Englisch";
            courseE.Fb = 1;
            courseE.LK = e_lk.IsChecked.Value;
            courseE.E1 = e_e1.IsChecked.Value ? 0 : -1;
            courseE.E2 = e_e2.IsChecked.Value ? 0 : -1;
            courseE.Q1 = e_q1.IsChecked.Value ? 0 : -1;
            courseE.Q2 = e_q2.IsChecked.Value ? 0 : -1;
            courseE.Q3 = e_q3.IsChecked.Value ? 0 : -1;
            courseE.Q4 = e_q4.IsChecked.Value ? 0 : -1;

            return courseE;
        }

        private Course getCourseF()
        {
            Course courseF = new Course();
            courseF.Name = "Französisch";
            courseF.Fb = 1;
            courseF.LK = f_lk.IsChecked.Value;
            courseF.E1 = f_e1.IsChecked.Value ? 0 : -1;
            courseF.E2 = f_e2.IsChecked.Value ? 0 : -1;
            courseF.Q1 = f_q1.IsChecked.Value ? 0 : -1;
            courseF.Q2 = f_q2.IsChecked.Value ? 0 : -1;
            courseF.Q3 = f_q3.IsChecked.Value ? 0 : -1;
            courseF.Q4 = f_q4.IsChecked.Value ? 0 : -1;

            return courseF;
        }

        private Course getCourseIt()
        {
            Course courseIt = new Course();
            courseIt.Name = "Italienisch";
            courseIt.Fb = 1;
            courseIt.LK = it_lk.IsChecked.Value;
            courseIt.E1 = it_e1.IsChecked.Value ? 0 : -1;
            courseIt.E2 = it_e2.IsChecked.Value ? 0 : -1;
            courseIt.Q1 = it_q1.IsChecked.Value ? 0 : -1;
            courseIt.Q2 = it_q2.IsChecked.Value ? 0 : -1;
            courseIt.Q3 = it_q3.IsChecked.Value ? 0 : -1;
            courseIt.Q4 = it_q4.IsChecked.Value ? 0 : -1;

            return courseIt;
        }

        private Course getCourseSp()
        {
            Course courseSp = new Course();
            courseSp.Name = "Spanisch";
            courseSp.Fb = 1;
            courseSp.LK = sp_lk.IsChecked.Value;
            courseSp.E1 = sp_e1.IsChecked.Value ? 0 : -1;
            courseSp.E2 = sp_e2.IsChecked.Value ? 0 : -1;
            courseSp.Q1 = sp_q1.IsChecked.Value ? 0 : -1;
            courseSp.Q2 = sp_q2.IsChecked.Value ? 0 : -1;
            courseSp.Q3 = sp_q3.IsChecked.Value ? 0 : -1;
            courseSp.Q4 = sp_q4.IsChecked.Value ? 0 : -1;

            return courseSp;
        }

        private Course getCourseRu()
        {
            Course courseRu = new Course();
            courseRu.Name = "Russisch";
            courseRu.Fb = 1;
            courseRu.LK = ru_lk.IsChecked.Value;
            courseRu.E1 = ru_e1.IsChecked.Value ? 0 : -1;
            courseRu.E2 = ru_e2.IsChecked.Value ? 0 : -1;
            courseRu.Q1 = ru_q1.IsChecked.Value ? 0 : -1;
            courseRu.Q2 = ru_q2.IsChecked.Value ? 0 : -1;
            courseRu.Q3 = ru_q3.IsChecked.Value ? 0 : -1;
            courseRu.Q4 = ru_q4.IsChecked.Value ? 0 : -1;

            return courseRu;
        }

        private Course getCourseGr()
        {
            Course courseGr = new Course();
            courseGr.Name = "Griechisch";
            courseGr.Fb = 1;
            courseGr.LK = gr_lk.IsChecked.Value;
            courseGr.E1 = gr_e1.IsChecked.Value ? 0 : -1;
            courseGr.E2 = gr_e2.IsChecked.Value ? 0 : -1;
            courseGr.Q1 = gr_q1.IsChecked.Value ? 0 : -1;
            courseGr.Q2 = gr_q2.IsChecked.Value ? 0 : -1;
            courseGr.Q3 = gr_q3.IsChecked.Value ? 0 : -1;
            courseGr.Q4 = gr_q4.IsChecked.Value ? 0 : -1;

            return courseGr;
        }

        private Course getCourseL()
        {
            Course courseL = new Course();
            courseL.Name = "Latein";
            courseL.Fb = 1;
            courseL.LK = l_lk.IsChecked.Value;
            courseL.E1 = l_e1.IsChecked.Value ? 0 : -1;
            courseL.E2 = l_e2.IsChecked.Value ? 0 : -1;
            courseL.Q1 = l_q1.IsChecked.Value ? 0 : -1;
            courseL.Q2 = l_q2.IsChecked.Value ? 0 : -1;
            courseL.Q3 = l_q3.IsChecked.Value ? 0 : -1;
            courseL.Q4 = l_q4.IsChecked.Value ? 0 : -1;

            return courseL;
        }

        private Course getCourseMu()
        {
            Course courseMu = new Course();
            courseMu.Name = "Musik";
            courseMu.Fb = 1;
            courseMu.LK = mu_lk.IsChecked.Value;
            courseMu.E1 = mu_e1.IsChecked.Value ? 0 : -1;
            courseMu.E2 = mu_e2.IsChecked.Value ? 0 : -1;
            courseMu.Q1 = mu_q1.IsChecked.Value ? 0 : -1;
            courseMu.Q2 = mu_q2.IsChecked.Value ? 0 : -1;
            courseMu.Q3 = mu_q3.IsChecked.Value ? 0 : -1;
            courseMu.Q4 = mu_q4.IsChecked.Value ? 0 : -1;

            return courseMu;
        }

        private Course getCourseKu()
        {
            Course courseKu = new Course();
            courseKu.Name = "Kunst";
            courseKu.Fb = 1;
            courseKu.LK = ku_lk.IsChecked.Value;
            courseKu.E1 = ku_e1.IsChecked.Value ? 0 : -1;
            courseKu.E2 = ku_e2.IsChecked.Value ? 0 : -1;
            courseKu.Q1 = ku_q1.IsChecked.Value ? 0 : -1;
            courseKu.Q2 = ku_q2.IsChecked.Value ? 0 : -1;
            courseKu.Q3 = ku_q3.IsChecked.Value ? 0 : -1;
            courseKu.Q4 = ku_q4.IsChecked.Value ? 0 : -1;

            return courseKu;
        }

        private Course getCourseDs()
        {
            Course courseDs = new Course();
            courseDs.Name = "Darstellendes Spiel";
            courseDs.Fb = 1;
            courseDs.LK = false;
            courseDs.E1 = ds_e1.IsChecked.Value ? 0 : -1;
            courseDs.E2 = ds_e2.IsChecked.Value ? 0 : -1;
            courseDs.Q1 = ds_q1.IsChecked.Value ? 0 : -1;
            courseDs.Q2 = ds_q2.IsChecked.Value ? 0 : -1;
            courseDs.Q3 = ds_q3.IsChecked.Value ? 0 : -1;
            courseDs.Q4 = ds_q4.IsChecked.Value ? 0 : -1;

            return courseDs;
        }

        private Course getCourseG()
        {
            Course courseG = new Course();
            courseG.Name = "Geschichte";
            courseG.Fb = 2;
            courseG.LK = g_lk.IsChecked.Value;
            courseG.E1 = g_e1.IsChecked.Value ? 0 : -1;
            courseG.E2 = g_e2.IsChecked.Value ? 0 : -1;
            courseG.Q1 = g_q1.IsChecked.Value ? 0 : -1;
            courseG.Q2 = g_q2.IsChecked.Value ? 0 : -1;
            courseG.Q3 = g_q3.IsChecked.Value ? 0 : -1;
            courseG.Q4 = g_q4.IsChecked.Value ? 0 : -1;

            return courseG;
        }

        private Course getCoursePw()
        {
            Course coursePw = new Course();
            coursePw.Name = "Politik und Wirtschaft";
            coursePw.Fb = 2;
            coursePw.LK = pw_lk.IsChecked.Value;
            coursePw.E1 = pw_e1.IsChecked.Value ? 0 : -1;
            coursePw.E2 = pw_e2.IsChecked.Value ? 0 : -1;
            coursePw.Q1 = pw_q1.IsChecked.Value ? 0 : -1;
            coursePw.Q2 = pw_q2.IsChecked.Value ? 0 : -1;
            coursePw.Q3 = pw_q3.IsChecked.Value ? 0 : -1;
            coursePw.Q4 = pw_q4.IsChecked.Value ? 0 : -1;

            return coursePw;
        }

        private Course getCourseEc()
        {
            Course courseEc = new Course();
            courseEc.Name = "Wirtschaftswissens.";
            courseEc.Fb = 2;
            courseEc.LK = ec_lk.IsChecked.Value;
            courseEc.E1 = ec_e1.IsChecked.Value ? 0 : -1;
            courseEc.E2 = ec_e2.IsChecked.Value ? 0 : -1;
            courseEc.Q1 = ec_q1.IsChecked.Value ? 0 : -1;
            courseEc.Q2 = ec_q2.IsChecked.Value ? 0 : -1;
            courseEc.Q3 = ec_q3.IsChecked.Value ? 0 : -1;
            courseEc.Q4 = ec_q4.IsChecked.Value ? 0 : -1;

            return courseEc;
        }

        private Course getCourseLaw()
        {
            Course courseLaw = new Course();
            courseLaw.Name = "Rechtskunde";
            courseLaw.Fb = 2;
            courseLaw.LK = false;
            courseLaw.E1 = law_e1.IsChecked.Value ? 0 : -1;
            courseLaw.E2 = law_e2.IsChecked.Value ? 0 : -1;
            courseLaw.Q1 = law_q1.IsChecked.Value ? 0 : -1;
            courseLaw.Q2 = law_q2.IsChecked.Value ? 0 : -1;
            courseLaw.Q3 = law_q3.IsChecked.Value ? 0 : -1;
            courseLaw.Q4 = law_q4.IsChecked.Value ? 0 : -1;

            return courseLaw;
        }

        private Course getCoursePhil()
        {
            Course coursePhil = new Course();
            coursePhil.Name = "Philosophie";
            coursePhil.Fb = 2;
            coursePhil.LK = false;
            coursePhil.E1 = phil_e1.IsChecked.Value ? 0 : -1;
            coursePhil.E2 = phil_e2.IsChecked.Value ? 0 : -1;
            coursePhil.Q1 = phil_q1.IsChecked.Value ? 0 : -1;
            coursePhil.Q2 = phil_q2.IsChecked.Value ? 0 : -1;
            coursePhil.Q3 = phil_q3.IsChecked.Value ? 0 : -1;
            coursePhil.Q4 = phil_q4.IsChecked.Value ? 0 : -1;

            return coursePhil;
        }

        private Course getCourseGeo()
        {
            Course courseEk = new Course();
            courseEk.Name = "Erdkunde";
            courseEk.Fb = 2;
            courseEk.LK = ek_lk.IsChecked.Value;
            courseEk.E1 = ek_e1.IsChecked.Value ? 0 : -1;
            courseEk.E2 = ek_e2.IsChecked.Value ? 0 : -1;
            courseEk.Q1 = ek_q1.IsChecked.Value ? 0 : -1;
            courseEk.Q2 = ek_q2.IsChecked.Value ? 0 : -1;
            courseEk.Q3 = ek_q3.IsChecked.Value ? 0 : -1;
            courseEk.Q4 = ek_q4.IsChecked.Value ? 0 : -1;

            return courseEk;
        }

        private Course getCourseEvrel()
        {
            Course courseEvrel = new Course();
            courseEvrel.Name = "Ev. Religion";
            courseEvrel.Fb = 2;
            courseEvrel.LK = evrel_lk.IsChecked.Value;
            courseEvrel.E1 = evrel_e1.IsChecked.Value ? 0 : -1;
            courseEvrel.E2 = evrel_e2.IsChecked.Value ? 0 : -1;
            courseEvrel.Q1 = evrel_q1.IsChecked.Value ? 0 : -1;
            courseEvrel.Q2 = evrel_q2.IsChecked.Value ? 0 : -1;
            courseEvrel.Q3 = evrel_q3.IsChecked.Value ? 0 : -1;
            courseEvrel.Q4 = evrel_q4.IsChecked.Value ? 0 : -1;

            return courseEvrel;
        }

        private Course getCourseKathrel()
        {
            Course courseKathrel = new Course();
            courseKathrel.Name = "Kath. Religion";
            courseKathrel.Fb = 2;
            courseKathrel.LK = kathrel_lk.IsChecked.Value;
            courseKathrel.E1 = kathrel_e1.IsChecked.Value ? 0 : -1;
            courseKathrel.E2 = kathrel_e2.IsChecked.Value ? 0 : -1;
            courseKathrel.Q1 = kathrel_q1.IsChecked.Value ? 0 : -1;
            courseKathrel.Q2 = kathrel_q2.IsChecked.Value ? 0 : -1;
            courseKathrel.Q3 = kathrel_q3.IsChecked.Value ? 0 : -1;
            courseKathrel.Q4 = kathrel_q4.IsChecked.Value ? 0 : -1;

            return courseKathrel;
        }

        private Course getCourseEth()
        {
            Course courseEth = new Course();
            courseEth.Name = "Ethik";
            courseEth.Fb = 2;
            courseEth.LK = false;
            courseEth.E1 = eth_e1.IsChecked.Value ? 0 : -1;
            courseEth.E2 = eth_e2.IsChecked.Value ? 0 : -1;
            courseEth.Q1 = eth_q1.IsChecked.Value ? 0 : -1;
            courseEth.Q2 = eth_q2.IsChecked.Value ? 0 : -1;
            courseEth.Q3 = eth_q3.IsChecked.Value ? 0 : -1;
            courseEth.Q4 = eth_q4.IsChecked.Value ? 0 : -1;

            return courseEth;
        }

        private Course getCourseM()
        {
            Course courseM = new Course();
            courseM.Name = "Mathematik";
            courseM.Fb = 3;
            courseM.LK = m_lk.IsChecked.Value;
            courseM.E1 = m_e1.IsChecked.Value ? 0 : -1;
            courseM.E2 = m_e2.IsChecked.Value ? 0 : -1;
            courseM.Q1 = m_q1.IsChecked.Value ? 0 : -1;
            courseM.Q2 = m_q2.IsChecked.Value ? 0 : -1;
            courseM.Q3 = m_q3.IsChecked.Value ? 0 : -1;
            courseM.Q4 = m_q4.IsChecked.Value ? 0 : -1;

            return courseM;
        }

        private Course getCourseB()
        {
            Course courseB = new Course();
            courseB.Name = "Biologie";
            courseB.Fb = 3;
            courseB.LK = b_lk.IsChecked.Value;
            courseB.E1 = b_e1.IsChecked.Value ? 0 : -1;
            courseB.E2 = b_e2.IsChecked.Value ? 0 : -1;
            courseB.Q1 = b_q1.IsChecked.Value ? 0 : -1;
            courseB.Q2 = b_q2.IsChecked.Value ? 0 : -1;
            courseB.Q3 = b_q3.IsChecked.Value ? 0 : -1;
            courseB.Q4 = b_q4.IsChecked.Value ? 0 : -1;

            return courseB;
        }

        private Course getCourseC()
        {
            Course courseC = new Course();
            courseC.Name = "Chemie";
            courseC.Fb = 3;
            courseC.LK = c_lk.IsChecked.Value;
            courseC.E1 = c_e1.IsChecked.Value ? 0 : -1;
            courseC.E2 = c_e2.IsChecked.Value ? 0 : -1;
            courseC.Q1 = c_q1.IsChecked.Value ? 0 : -1;
            courseC.Q2 = c_q2.IsChecked.Value ? 0 : -1;
            courseC.Q3 = c_q3.IsChecked.Value ? 0 : -1;
            courseC.Q4 = c_q4.IsChecked.Value ? 0 : -1;

            return courseC;
        }

        private Course getCourseP()
        {
            Course courseP = new Course();
            courseP.Name = "Physik";
            courseP.Fb = 3;
            courseP.LK = p_lk.IsChecked.Value;
            courseP.E1 = p_e1.IsChecked.Value ? 0 : -1;
            courseP.E2 = p_e2.IsChecked.Value ? 0 : -1;
            courseP.Q1 = p_q1.IsChecked.Value ? 0 : -1;
            courseP.Q2 = p_q2.IsChecked.Value ? 0 : -1;
            courseP.Q3 = p_q3.IsChecked.Value ? 0 : -1;
            courseP.Q4 = p_q4.IsChecked.Value ? 0 : -1;

            return courseP;
        }

        private Course getCourseInf()
        {
            Course courseInf = new Course();
            courseInf.Name = "Informatik";
            courseInf.Fb = 3;
            courseInf.LK = inf_lk.IsChecked.Value;
            courseInf.E1 = inf_e1.IsChecked.Value ? 0 : -1;
            courseInf.E2 = inf_e2.IsChecked.Value ? 0 : -1;
            courseInf.Q1 = inf_q1.IsChecked.Value ? 0 : -1;
            courseInf.Q2 = inf_q2.IsChecked.Value ? 0 : -1;
            courseInf.Q3 = inf_q3.IsChecked.Value ? 0 : -1;
            courseInf.Q4 = inf_q4.IsChecked.Value ? 0 : -1;

            return courseInf;
        }

        private Course getCoursePe()
        {
            Course coursePe = new Course();
            coursePe.Name = "Sport";
            coursePe.Fb = 4;
            coursePe.LK = pe_lk.IsChecked.Value;
            coursePe.E1 = pe_e1.IsChecked.Value ? 0 : -1;
            coursePe.E2 = pe_e2.IsChecked.Value ? 0 : -1;
            coursePe.Q1 = pe_q1.IsChecked.Value ? 0 : -1;
            coursePe.Q2 = pe_q2.IsChecked.Value ? 0 : -1;
            coursePe.Q3 = pe_q3.IsChecked.Value ? 0 : -1;
            coursePe.Q4 = pe_q4.IsChecked.Value ? 0 : -1;
            coursePe.Pe3Std = pe_3std.IsChecked.Value;

            return coursePe;
        }
    }
}
