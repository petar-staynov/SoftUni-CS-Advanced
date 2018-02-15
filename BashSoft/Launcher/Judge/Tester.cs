using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Launcher;

namespace SimpleJudge
{
    public static class Tester
    {
        public static void CompareContents(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageNewLine("Reading files...");

            try
            {
                string mismatchPath = GetMismatchPath(expectedOutputPath);

                string[] userOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                bool hasMismatches;
                string[] mistamtches =
                    GetLineWithPossibleMismatches(userOutputLines, expectedOutputLines, out hasMismatches);

                //Print Output
                PrintOutput(mistamtches, hasMismatches, mismatchPath);
                OutputWriter.WriteMessageNewLine("Files read!");
            }
            catch (FileNotFoundException)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath(string.Empty));
            }
        }

        private static string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string dirPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = dirPath + @"\Mismatches.txt";
            return finalPath;
        }

        private static string[] GetLineWithPossibleMismatches(
            string[] userOutputLines, string[] expectedOutputLines, out bool hasMismatches)
        {
            hasMismatches = false;
            string output = string.Empty;

            string[] mismatches = new string[userOutputLines.Length];

            OutputWriter.WriteMessageNewLine("Comparing files...");

            int minOutputLine = expectedOutputLines.Length;
            if (userOutputLines.Length != expectedOutputLines.Length)
            {
                hasMismatches = true;
                minOutputLine = Math.Min(userOutputLines.Length, expectedOutputLines.Length);
                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes());
            }

            for (int i = 0; i < minOutputLine; i++)
            {
                string outputLine = userOutputLines[i];
                string expectedLine = expectedOutputLines[i];
                if (outputLine != expectedLine)
                {
                    //create mismatch line in Mismatches.txr
                    output = string.Format($"Mismatch as line {i} -- expected: {expectedLine}, got: {outputLine}");
                    output += Environment.NewLine;
                    hasMismatches = true;
                }
                else
                {
                    output = outputLine;
                    output += Environment.NewLine;
                }

                mismatches[i] = output;
            }

            return mismatches;
        }

        private static void PrintOutput(
            string[] mismatches, bool hasMismatches, string mismatchPath)
        {
            if (hasMismatches)
            {
                foreach (var line in mismatches)
                {
                    OutputWriter.WriteMessageNewLine(line);
                }

                try
                {
                    File.WriteAllLines(mismatchPath, mismatches);
                }
                catch (DirectoryNotFoundException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidPath(mismatchPath));
                }
                return;
            }
        }
    }
}