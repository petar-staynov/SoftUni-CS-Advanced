using System;
using System.Collections.Generic;
using System.Text;

namespace Launcher
{
    public static class ExceptionMessages
    {
        public const string ExampleExceptionMessage = "Example message!";

        public static string DataAlreadyInitialisedException()
        {
            return "Data is alreadyinitialsied";
        }

        public static string DataNotInitializedExceptionMessage()
        {
            return "The data structure must be initialized first in order to make any operations with it.";
        }

        public static string InexistingCourseInDataBase()
        {
            return "The course you are trying to get does not exist in the data base!";
        }

        public static string InexistingStudentInDataBase()
        {
            return "The user name for the student you are trying to get does not exist!";
        }

        public static string InvalidPath(string path)
        {
            return $"The folder/file \"{path}\" you are trying to access at the current address, does not exist.";
        }

        public static string UnauthorizedAccessExceptionMessage(string path)
        {
            return
                $"The folder/file \"{path}\" you are trying to get access needs a higher level of rights than you currently have";
        }

        public static string ComparisonOfFilesWithDifferentSizes()
        {
            return "Files not of equal size, certain mismatch.";
        }

        public static string ForbiddenSymbolsContainedInName()
        {
            return "The given name contains symbols that are not allowed to be used in names of files and folders.";
        }

        public static string UnableToGoHigherInPartitionHierarchy()
        {
            return "Unable to go up";
        }

        public static string UnableToParseNumber()
        {
            return "The sequence you've written is not a valid number.";
        }

        public static string InvalidStudentFilter()
        {
            return "The given filter is not one of the following: excellent/average/poor";
        }

        public static string InvalidComparisonQuery()
        {
            return "The comparison query you want, does not exist in the context of the current program!";
        }

        public static string InvalidTakeQuantityParameter()
        {
            return "The take command expected does not match the format wanted!";
        }
    }
}