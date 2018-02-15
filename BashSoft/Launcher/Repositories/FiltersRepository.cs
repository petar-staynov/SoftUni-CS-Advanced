using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Launcher
{
    public static class FiltersRepository
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter,
            int studentsToTake)
        {
            if (wantedFilter.Equals("excellent"))
            {
                FilterAndTake(wantedData, x => x >= 5, studentsToTake);
            }
            else if (wantedFilter.Equals("average"))
            {
                FilterAndTake(wantedData, x => x < 5 && x >= 3.5, studentsToTake);
            }
            else if (wantedFilter.Equals("poor"))
            {
                FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter());
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter,
            int studentsToTake)
        {
            var counterForPrinted = 0;
            foreach (var userName_Points in wantedData)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                var averageScore = userName_Points.Value.Average();
                var percentageOfFullfillments = averageScore / 100;
                var mark = percentageOfFullfillments * 4 + 2;
                if (givenFilter(mark))
                {
                    OutputWriter.DisplayStudent(userName_Points);
                    counterForPrinted++;
                }
            }
        }

        private static double Average(List<int> scoresOntasks)
        {
            int totalScore = 0;
            foreach (var score in scoresOntasks)
            {
                totalScore += score;
            }

            double percentageOfAll = totalScore / (scoresOntasks.Count * 100);
            double mark = percentageOfAll * 4 + 2;
            return mark;
        }
    }
}