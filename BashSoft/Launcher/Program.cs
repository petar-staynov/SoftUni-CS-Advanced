using System;
using System.IO;
using SimpleJudge;

namespace Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BASHSOFT v0.99RC by pepo930");
            //IOManager.TraverseDirectory(@"D:\repos\SoftUni-CS-Advanced\BashSoft"); //WORKS

            //StudentsRepository.InitialiseData(); //WORKS
            //Unity Pesho 6
            //Unity Ivan 3
            //C# Mitko 5
            //StudentsRepository.GetAllStudentsFromCourse("Unity"); //WORKS
            //StudentsRepository.GetStudentScoresFromCourse("C#", "Ivan"); //WORKS


            //Tester.CompareContents($"{SessionData.currentPath}\\Tests\\test2.txt", $"{SessionData.currentPath}\\Tests\\test3.txt"); //WORKS

            //IOManager.CreateDirInCurrentFolder("pesho"); //WORKS

            //IOManager.TraverseDirectory(0); //WORKS

            //PART 3
            //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(20);

            //IOManager.CreateDirectoryInCurrentFolder("*pesho");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");

            //EVERYTHING SHOULD WORK
            InputReader.StartReadingCommands();
        }
    }
}