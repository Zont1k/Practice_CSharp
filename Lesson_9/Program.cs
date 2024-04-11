using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopWatch = new Stopwatch();

        string destinationPath = @"C:\Users\Schule8\OneDrive\Desktop\CopiedFolders";

        string[] sourcePaths = 
        { 
            @"C:\Users\Schule8\source\repos\Lesson_1\Lesson_9\Files\1\", 
            @"C:\Users\Schule8\source\repos\Lesson_1\Lesson_9\Files\2\", 
            @"C:\Users\Schule8\source\repos\Lesson_1\Lesson_9\Files\3\", 
            @"C:\Users\Schule8\source\repos\Lesson_1\Lesson_9\Files\4\", 
            @"C:\Users\Schule8\source\repos\Lesson_1\Lesson_9\Files\5\" 
        };

        stopWatch.Start();
        try
        {
            CopyFolders(destinationPath, sourcePaths);
            stopWatch.Stop();

            Console.WriteLine($"Time: {stopWatch.Elapsed} sec");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void CopyFolders(string destinationPath, params string[] sourcePaths)
    {
        foreach (string sourcePath in sourcePaths)
        {
            string foldername = new DirectoryInfo(sourcePath).Name;
            string newFolderPath = Path.Combine(destinationPath, foldername);

            if (!Directory.Exists(newFolderPath))
            {
                Directory.CreateDirectory(newFolderPath);
            }

            foreach (var file in Directory.GetFiles(sourcePath))
            {
                string dest = Path.Combine(newFolderPath, Path.GetFileName(file));
                File.Copy(file, dest, true);
            }
        }
    }
}
