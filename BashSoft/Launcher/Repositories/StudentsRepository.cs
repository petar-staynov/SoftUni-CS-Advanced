using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Launcher
{
    public static class StudentsRepository
    {
        public static bool isDataInitiased = false;

        //Dictionary<course_name, Dictionary<user_name, scoresOnTasks>>>
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitialiseData(string fileName)
        {
            if (!isDataInitiased)
            {
                OutputWriter.WriteMessageNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(fileName);
            }
            else
            {
                OutputWriter.WriteMessageNewLine(ExceptionMessages.DataAlreadyInitialisedException());
            }
        }

        private static void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;

            if (File.Exists(path))
            {
                string pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
                var rgx = new Regex(pattern);

                var allInputLines = File.ReadAllLines(path);
                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!String.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                    {
                        var currentMatch = rgx.Match(allInputLines[line]);
                        string courseName = currentMatch.Groups[1].Value;
                        string username = currentMatch.Groups[2].Value;
                        int studentScoreOnTask;
                        bool hasParsedScore = Int32.TryParse(currentMatch.Groups[3].Value, out studentScoreOnTask);

                        if (hasParsedScore && studentScoreOnTask >= 0 && studentScoreOnTask <= 100)
                        {
                            if (!studentsByCourse.ContainsKey(courseName))
                            {
                                studentsByCourse.Add(courseName, new Dictionary<string, List<int>>());
                            }

                            if (!studentsByCourse[courseName].ContainsKey(username))
                            {
                                studentsByCourse[courseName].Add(username, new List<int>());
                            }

                            studentsByCourse[courseName][username].Add(studentScoreOnTask);
                        }
                    }
                }

                isDataInitiased = true;
                OutputWriter.WriteMessageNewLine("Data read!");
            }
        }

        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitiased)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return true;
                }

                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase());
            }

            OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage());
            return false;
        }

        private static bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }

            OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase());
            return false;
        }

        public static void GetStudentScoresFromCourse(string courseName, string studentUserName)
        {
            OutputWriter.WriteMessageNewLine($"{courseName}:");

            foreach (var studentMarkEntry in studentsByCourse[courseName])
            {
                OutputWriter.DisplayStudent(studentMarkEntry);
            }
        }

        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageNewLine($"{courseName}:");
                foreach (var studentMarkEntry in studentsByCourse[courseName])
                {
                    OutputWriter.DisplayStudent(studentMarkEntry);
                }
            }
        }

        public static void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                FiltersRepository.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
            }
        }

        public static void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                SorterRepository.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);
            }
        }
    }
}