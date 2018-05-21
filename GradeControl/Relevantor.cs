using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeControl
{
    public class Relevantor
    {
        public Relevantor(List<CourseItem> gkItems, List<CourseItem> lkItems, List<ExamItem> exItems)
        {
            GkItems = gkItems;
            LkItems = lkItems;
            ExItems = exItems;
            quarterCourses = GetQuarterCourses();
        }

        public List<CourseItem> GkItems { get; set; }
        public List<CourseItem> LkItems { get; set; }
        public List<ExamItem> ExItems { get; set; }
        private List<QuarterCourse> quarterCourses;

        public RelevantCourse[] DetermineRelevantCourses()
        {
            int remainingGks = 24;
            RelevantCourse[] relevantCourses = new RelevantCourse[GkItems.Count];

            string bestForeignLanguage = GetBestForeignLanguage();
            bool foreignLanguageAsLk = LkItems.Any(lkItem => IsForeignLanguage(lkItem.Fach));

            string bestNW = GetBestNW();
            bool nwAsLk = LkItems.Any(lkItem => IsNW(lkItem.Fach));

            QuarterCourse[] bestPwOrEc = GetBestPwOrEc();
            bool pwOrEcAsLk = LkItems.Any(lkItem => IsPwOrEc(lkItem.Fach));

            QuarterCourse[] bestMuKuDs = GetBestMuKuDs();
            bool muKuDsAsLk = LkItems.Any(lkItem => IsMuKuDs(lkItem.Fach));

            QuarterCourse[] bestSecondary = GetBestSecondary(bestForeignLanguage, bestNW);

            QuarterCourse[] bestThird = GetBestThird(bestPwOrEc);

            remainingGks -= SetExamCoursesRelevant();

            for (int i = 0; i < quarterCourses.Count; i++)
            {
                if(!quarterCourses[i].Relevant)
                {
                    if (quarterCourses[i].Name == "Deutsch" || quarterCourses[i].Name == "Mathematik")
                    {
                        quarterCourses[i].Relevant = true;
                        if (!quarterCourses[i].Lk)
                            remainingGks--;
                    }
                    else if (quarterCourses[i].Name == "Geschichte" && (quarterCourses[i].Semester == 3 || quarterCourses[i].Semester == 4))
                    {
                        quarterCourses[i].Relevant = true;
                        if (!quarterCourses[i].Lk)
                            remainingGks--;
                    }
                    else if (quarterCourses[i].Name == bestForeignLanguage && !foreignLanguageAsLk)
                    {
                        quarterCourses[i].Relevant = true;
                        remainingGks--;
                    }
                    else if (quarterCourses[i].Name == bestNW && !nwAsLk)
                    {
                        quarterCourses[i].Relevant = true;
                        remainingGks--;
                    }
                    else if ((quarterCourses[i] == bestPwOrEc[0] || quarterCourses[i] == bestPwOrEc[1]) && !pwOrEcAsLk)
                    {
                        quarterCourses[i].Relevant = true;
                        remainingGks--;
                    }
                    else if ((quarterCourses[i] == bestMuKuDs[0] || quarterCourses[i] == bestMuKuDs[1]) && !muKuDsAsLk)
                    {
                        quarterCourses[i].Relevant = true;
                        remainingGks--;
                    }
                    else if (quarterCourses[i] == bestSecondary[0] || quarterCourses[i] == bestSecondary[1])
                    {
                        quarterCourses[i].Relevant = true;
                        remainingGks--;
                    }
                    else if (quarterCourses[i] == bestThird[0] || quarterCourses[i] == bestThird[1])
                    {
                        quarterCourses[i].Relevant = true;
                        remainingGks--;
                    }
                }
            }

            List<QuarterCourse> remainingCourses = quarterCourses.Where(item => !item.Relevant).OrderByDescending(item => item.Grade).ToList();
            int maxPeCourses = 3, counter = 0;

            while(remainingGks > 0)
            {
                QuarterCourse remainingCourse = quarterCourses.Find(item => item.Name == remainingCourses[counter].Name && item.Semester == remainingCourses[counter].Semester);
                if (remainingCourse.Name == "Sport")
                {
                    if (maxPeCourses > 0)
                    {
                        remainingCourse.Relevant = true;
                        maxPeCourses--;
                        remainingGks--;
                    }
                }
                else
                {
                    remainingCourse.Relevant = true;
                    remainingGks--;
                }

                counter++;
            }

            return GetRelevantCourses();
        }

        private RelevantCourse[] GetRelevantCourses()
        {
            List<RelevantCourse> relevantCourses = new List<RelevantCourse>();
            IEnumerable<IGrouping<string, QuarterCourse>> courseQuery = quarterCourses.GroupBy(item => item.Name);

            foreach (IGrouping<string, QuarterCourse> course in courseQuery)
            {
                List<QuarterCourse> quarters = course.OrderBy(item => item.Semester).ToList();
                bool q1 = false, q2 = false, q3 = false, q4 = false;

                if (quarters.Count > 3)
                    q4 = quarters[3].Relevant;
                if (quarters.Count > 2)
                    q3 = quarters[2].Relevant;
                if (quarters.Count > 1)
                    q2 = quarters[1].Relevant;
                if (quarters.Count > 0)
                    q1 = quarters[0].Relevant;


                relevantCourses.Add(new RelevantCourse(quarters[0].Name, q1, q2, q3, q4));
            }

            return relevantCourses.ToArray();
        }

        private List<QuarterCourse> GetQuarterCourses()
        {
            List<QuarterCourse> quarterCourses = new List<QuarterCourse>();

            for(int i = 0; i < GkItems.Count; i++)
            {
                if (GkItems[i].Q1 >= 0)
                    quarterCourses.Add(new QuarterCourse(GkItems[i].Fach, 1, false, GkItems[i].Q1));
                if (GkItems[i].Q2 >= 0)
                    quarterCourses.Add(new QuarterCourse(GkItems[i].Fach, 2, false, GkItems[i].Q2));
                if (GkItems[i].Q3 >= 0)
                    quarterCourses.Add(new QuarterCourse(GkItems[i].Fach, 3, false, GkItems[i].Q3));
                if (GkItems[i].Q4 >= 0)
                    quarterCourses.Add(new QuarterCourse(GkItems[i].Fach, 4, false, GkItems[i].Q4));
            }

            for (int i = 0; i < LkItems.Count; i++)
            {
                quarterCourses.Add(new QuarterCourse(LkItems[i].Fach, 1, true, LkItems[i].Q1, true));
                quarterCourses.Add(new QuarterCourse(LkItems[i].Fach, 2, true, LkItems[i].Q2, true));
                quarterCourses.Add(new QuarterCourse(LkItems[i].Fach, 3, true, LkItems[i].Q3, true));
                quarterCourses.Add(new QuarterCourse(LkItems[i].Fach, 4, true, LkItems[i].Q4, true));
            }

            return quarterCourses;
        }

        private int SetExamCoursesRelevant()
        {
            int gkCounter = 0;

            foreach(var exam in ExItems)
            {
                List<QuarterCourse> examCourses = quarterCourses.Where(item => item.Name == exam.Fach).ToList();

                foreach(var examCourse in examCourses)
                {
                    examCourse.Relevant = true;
                    if (!examCourse.Lk)
                        gkCounter++;
                }    
            }

            return gkCounter;
        }

        private bool IsForeignLanguage(string name)
        {
            return name == "Englisch" || name == "Französisch" || name == "Italienisch" || name == "Spanisch" || name == "Russisch" || name == "Griechisch" || name == "Latein";
        }

        private string GetBestForeignLanguage()
        {
            List<CourseItem> foreignLanguages = GkItems.Where(gkItem => IsForeignLanguage(gkItem.Fach)).ToList();
            CourseItem bestOne = foreignLanguages.OrderByDescending(item => item.Q1 + item.Q2 + item.Q3 + item.Q4).First();

            return bestOne.Fach;
        }

        private bool IsNW(string name)
        {
            return name == "Biologie" || name == "Chemie" || name == "Physik";
        }

        private bool IsNWOrInf(string name)
        {
            return name == "Biologie" || name == "Chemie" || name == "Physik" || name == "Informatik";
        }

        private string GetBestNW()
        {
            List<CourseItem> nws = GkItems.Where(gkItem => IsNW(gkItem.Fach)).ToList();
            CourseItem bestOne = nws.OrderByDescending(item => item.Q1 + item.Q2 + item.Q3 + item.Q4).First();

            return bestOne.Fach;
        }

        private bool IsPwOrEc(string name)
        {
            return name == "Politik und Wirtschaft" || name == "Wirtschaftswissens.";
        }

        private QuarterCourse[] GetBestPwOrEc()
        {
            QuarterCourse[] bestPwOrEc = new QuarterCourse[2];
            List<QuarterCourse> pw = quarterCourses.Where(item => item.Name == "Politik und Wirtschaft" && !item.Lk).OrderByDescending(item => item.Grade).ToList();
            List<QuarterCourse> ec = quarterCourses.Where(item => item.Name == "Wirtschaftswissens." && !item.Lk).OrderByDescending(item => item.Grade).ToList();

            if(pw.Count == 0)
            {
                bestPwOrEc[0] = ec[0];
                bestPwOrEc[1] = ec[1];
            }
            else if(ec.Count == 0)
            {
                bestPwOrEc[0] = pw[0];
                bestPwOrEc[1] = pw[1];
            }
            else
            {
                if (pw[0].Grade + pw[1].Grade >= ec[0].Grade + ec[1].Grade)
                {
                    bestPwOrEc[0] = pw[0];
                    bestPwOrEc[1] = pw[1];
                }
                else
                {
                    bestPwOrEc[0] = ec[0];
                    bestPwOrEc[1] = ec[1];
                }
            }

            return bestPwOrEc;
        }

        private bool IsMuKuDs(string name)
        {
            return name == "Musik" || name == "Kunst" || name == "Darstellendes Spiel";
        }

        private QuarterCourse[] GetBestMuKuDs()
        {
            QuarterCourse[] bestMuKuDs = new QuarterCourse[2];
            List<QuarterCourse> mu = quarterCourses.Where(item => item.Name == "Musik" && !item.Lk).OrderByDescending(item => item.Grade).ToList();
            List<QuarterCourse> ku = quarterCourses.Where(item => item.Name == "Kunst" && !item.Lk).OrderByDescending(item => item.Grade).ToList();
            List<QuarterCourse> ds = quarterCourses.Where(item => item.Name == "Darstellendes Spiel").OrderByDescending(item => item.Grade).ToList();

            if (mu.Count == 0)
            {
                if(ku.Count == 0)
                {
                    bestMuKuDs[0] = ds[0];
                    bestMuKuDs[1] = ds[1];
                }
                else if (ds.Count == 0)
                {
                    bestMuKuDs[0] = ku[0];
                    bestMuKuDs[1] = ku[1];
                }
                else
                {
                    if (ku[0].Grade + ku[1].Grade >= ds[0].Grade + ds[1].Grade)
                    {
                        bestMuKuDs[0] = ku[0];
                        bestMuKuDs[1] = ku[1];
                    }
                    else if (ds[0].Grade + ds[1].Grade >= ku[0].Grade + ku[1].Grade)
                    {
                        bestMuKuDs[0] = ds[0];
                        bestMuKuDs[1] = ds[1];
                    }
                }
            }
            else if (ku.Count == 0)
            {
                if (mu.Count == 0)
                {
                    bestMuKuDs[0] = ds[0];
                    bestMuKuDs[1] = ds[1];
                }
                else if (ds.Count == 0)
                {
                    bestMuKuDs[0] = mu[0];
                    bestMuKuDs[1] = mu[1];
                }
                else
                {
                    if (mu[0].Grade + mu[1].Grade >= ds[0].Grade + ds[1].Grade)
                    {
                        bestMuKuDs[0] = mu[0];
                        bestMuKuDs[1] = mu[1];
                    }
                    else if (ds[0].Grade + ds[1].Grade >= mu[0].Grade + mu[1].Grade)
                    {
                        bestMuKuDs[0] = ds[0];
                        bestMuKuDs[1] = ds[1];
                    }
                }
            }
            else if (ds.Count == 0)
            {
                if (ku.Count == 0)
                {
                    bestMuKuDs[0] = mu[0];
                    bestMuKuDs[1] = mu[1];
                }
                else if (mu.Count == 0)
                {
                    bestMuKuDs[0] = ku[0];
                    bestMuKuDs[1] = ku[1];
                }
                else
                {
                    if (mu[0].Grade + mu[1].Grade >= ku[0].Grade + ku[1].Grade)
                    {
                        bestMuKuDs[0] = mu[0];
                        bestMuKuDs[1] = mu[1];
                    }
                    else if (ku[0].Grade + ku[1].Grade >= mu[0].Grade + mu[1].Grade)
                    {
                        bestMuKuDs[0] = ku[0];
                        bestMuKuDs[1] = ku[1];
                    }
                }
            }
            else
            {
                if (mu[0].Grade + mu[1].Grade >= ku[0].Grade + ku[1].Grade && mu[0].Grade + mu[1].Grade >= ds[0].Grade + ds[1].Grade)
                {
                    bestMuKuDs[0] = mu[0];
                    bestMuKuDs[1] = mu[1];
                }
                else if (ku[0].Grade + ku[1].Grade >= mu[0].Grade + mu[1].Grade && ku[0].Grade + ku[1].Grade >= ds[0].Grade + ds[1].Grade)
                {
                    bestMuKuDs[0] = ku[0];
                    bestMuKuDs[1] = ku[1];
                }
                else if (ds[0].Grade + ds[1].Grade >= mu[0].Grade + mu[1].Grade && ds[0].Grade + ds[1].Grade >= ku[0].Grade + ku[1].Grade)
                {
                    bestMuKuDs[0] = ds[0];
                    bestMuKuDs[1] = ds[1];
                }
            }

            return bestMuKuDs;
        }

        private QuarterCourse[] GetBestSecondary(string bestForeignLanguage, string bestNW)
        {
            QuarterCourse[] bestSecondary = new QuarterCourse[2];
            int highestSum = -1;
            string bestSecondaryName = String.Empty;
            IEnumerable<IGrouping<string, QuarterCourse>> possibleSecondaries = quarterCourses.Where(item => ((IsForeignLanguage(item.Name) && item.Name != bestForeignLanguage) || (IsNWOrInf(item.Name) && item.Name != bestNW)) && !item.Lk).GroupBy(item => item.Name);

            foreach(IGrouping<string, QuarterCourse> possibleSecondary in possibleSecondaries)
            {
                List<QuarterCourse> quarters = possibleSecondary.OrderByDescending(item => item.Grade).ToList();
                if(quarters[0].Grade + quarters[1].Grade > highestSum)
                {
                    highestSum = quarters[0].Grade + quarters[1].Grade;
                    bestSecondaryName = quarters[0].Name;
                }
            }

            List<QuarterCourse> secondaries = quarterCourses.Where(item => item.Name == bestSecondaryName).OrderByDescending(item => item.Grade).ToList();
            bestSecondary[0] = secondaries[0];
            bestSecondary[1] = secondaries[1];

            return bestSecondary;
        }

        private bool IsFb2(string name)
        {
            return name == "Geschichte" || name == "Politik und Wirtschaft" || name == "Wirtschaftswissens." || name == "Rechtskunde" || name == "Philosophie" || name == "Ev. Religion" || name == "Kath. Religion" || name == "Ethik";
        }

        private QuarterCourse[] GetBestThird(QuarterCourse[] bestPwOrEc)
        {
            QuarterCourse[] bestThird = new QuarterCourse[2];

            List<QuarterCourse> thirds = quarterCourses.Where(item => IsFb2(item.Name) && !(item.Name == "Geschichte" && (item.Semester == 3 || item.Semester == 4)) && !(item == bestPwOrEc[0] && item == bestPwOrEc[1]) && !item.Lk).OrderByDescending(item => item.Grade).ToList();
            bestThird[0] = thirds[0];
            bestThird[1] = thirds[1];

            return bestThird;
        }
    }
}
