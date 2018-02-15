using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SimpleJudge;

namespace Launcher
{
    public static class CommandInterpreter
    {
        public static void InterpredCommand(string input)
        {
            string[] data = input.Split();
            string command = data[0];
            switch (command)
            {
                case "open":
                    TryOpenFile(input, data);
                    break;
                case "mkdir":
                    TryCreateDirectory(input, data);
                    break;
                case "ls":
                    TryTraverseFolders(input, data);
                    break;
                case "cmp":
                    TryCompareFiles(input, data);
                    break;
                case "cdRel":
                    TryChangePathRelatively(input, data);
                    break;
                case "cdAbs":
                    TryChangePathAbsolute(input, data);
                    break;
                case "readDb":
                    TryReadDataBaseFromFile(input, data);
                    break;
                case "help":
                    TryGetHelp(input, data);
                    break;
                case "filter":
                    TryFilterAndTake(input, data);
                    break;
                case "order":
                    CommandParser(input, data);
                    break;
                case "decOrder":
                    //todo:
                    break;
                case "download":
                    //todo:
                    break;
                case "downloadAsynch":
                    //todo:
                    break;
                case "show":
                    TryShowWantedData(input, data);
                    break;
                case "clear":
                    Console.Clear();
                    break;
                default:
                    DisplayInvalidCommandMessage(input);
                    break;
            }
        }

        private static void CommandParser(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string comparison = data[2];
                string orderCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForOrderAndTake(orderCommand, takeQuantity, courseName, comparison);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryParseParametersForOrderAndTake(string orderCommand, string takeQuantity,
            string courseName, string comparison)
        {
            if (orderCommand == "order")
            {
                if (takeQuantity == "all")
                {
                    StudentsRepository.OrderAndTake(courseName, comparison);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);

                    if (hasParsed)
                    {
                        StudentsRepository.OrderAndTake(courseName, comparison, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter());
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter());
            }
        }

        private static void TryFilterAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                var courseName = data[1];
                var filter = data[2].ToLower();
                var takeComand = data[3].ToLower();
                var takeQuantity = data[4].ToLower();

                TryParseParametersForFilterAndTake(takeComand, takeQuantity, courseName, filter);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryParseParametersForFilterAndTake(string takeComand, string takeQuantity,
            string courseName, string filter)
        {
            if (takeComand.Equals("take"))
            {
                if (takeQuantity.Equals("all"))
                {
                    StudentsRepository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    var hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter());
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter());
            }
        }

        private static void TryShowWantedData(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string courseName = data[1];
                StudentsRepository.GetAllStudentsFromCourse(courseName);
            }
            else if (data.Length == 3)
            {
                string courseName = data[1];
                string userName = data[2];
                StudentsRepository.GetStudentScoresFromCourse(courseName, userName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.DisplayException($"The command '{input}' is invalid");
        }

        private static void TryGetHelp(string input, string[] data)
        {
            OutputWriter.WriteMessageNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
            OutputWriter.WriteMessageNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
            OutputWriter.WriteMessageNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
            OutputWriter.WriteMessageNewLine(string.Format("|{0, -98}|",
                "change directory - changeDirREl:relative path"));
            OutputWriter.WriteMessageNewLine(string.Format("|{0, -98}|", "change directory - changeDir:absolute path"));
            OutputWriter.WriteMessageNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
            OutputWriter.WriteMessageNewLine(string.Format("|{0, -98}|",
                "filter {courseName} excelent/average/poor  take 2/5/all students \n filterExcelent (the output is written on the console)"));
            OutputWriter.WriteMessageNewLine(string.Format("|{0, -98}|",
                "order increasing students - order {courseName} ascending/descending take 20/10/all \n (the output is written on the console)"));
            OutputWriter.WriteMessageNewLine(string.Format("|{0, -98}|",
                "download file - download: path of file (saved in current directory)"));
            OutputWriter.WriteMessageNewLine(string.Format("|{0, -98}|",
                "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
            OutputWriter.WriteMessageNewLine(string.Format("|{0, -98}|", "get help – help"));
            OutputWriter.WriteMessageNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
        }

        private static void TryReadDataBaseFromFile(string input, string[] data)
        {
            if (data.Length != 2)
            {
                DisplayInvalidCommandMessage(input);
                return;
            }

            string fileName = data[1];
            StudentsRepository.InitialiseData(fileName);
        }

        private static void TryChangePathAbsolute(string input, string[] data)
        {
            if (data.Length != 2)
            {
                DisplayInvalidCommandMessage(input);
                return;
            }

            string absolutePath = data[1];
            IOManager.ChangeCurrentDirectoryAbsolute(absolutePath);
        }

        private static void TryChangePathRelatively(string input, string[] data)
        {
            if (data.Length != 2)
            {
                DisplayInvalidCommandMessage(input);
                return;
            }

            string relPath = data[1];
            IOManager.ChageCurrentDirectoryRelative(relPath);
        }

        private static void TryCompareFiles(string input, string[] data)
        {
            if (data.Length == 3)
            {
                string firstPath = data[1];
                string secondPath = data[2];
                Tester.CompareContents(firstPath, secondPath);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryTraverseFolders(string input, string[] data)
        {
            if (data.Length == 1)
            {
                IOManager.TraverseDirectory(0);
            }
            else if (data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(data[1], out depth);

                if (hasParsed)
                {
                    IOManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber());
                }
            }
        }

        private static void TryCreateDirectory(string input, string[] data)
        {
            var folderName = data[1];
            IOManager.CreateDirInCurrentFolder(folderName);
        }

        private static void TryOpenFile(string input, string[] data)
        {
            var fileName = data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }
    }
}