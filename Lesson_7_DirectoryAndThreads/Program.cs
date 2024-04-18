using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopWatch = new Stopwatch();

        string destinationPath = @"C:\Users\Schule8\OneDrive\Desktop\CopiedFolders";
        string[] sourcePaths =
        {
            @"C:\Users\Schule8\OneDrive\Desktop\Practice_CSharp\Lesson_9\Folder-1.zip",
            @"C:\Users\Schule8\OneDrive\Desktop\Practice_CSharp\Lesson_9\Folder-2.zip",
            @"C:\Users\Schule8\OneDrive\Desktop\Practice_CSharp\Lesson_9\Folder-3.zip",
            @"C:\Users\Schule8\OneDrive\Desktop\Practice_CSharp\Lesson_9\Folder-4.zip",
            @"C:\Users\Schule8\OneDrive\Desktop\Practice_CSharp\Lesson_9\Folder-5.zip"
        };

        stopWatch.Start();
        try
        {
            CopyFolders(destinationPath, sourcePaths);
            stopWatch.Stop();

            Console.WriteLine($"Time: {stopWatch.Elapsed} sec");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void CopyFolders(string destinationPath, params string[] sourcePaths)
    {
        foreach (string sourcePath in sourcePaths)
        {
            string folderName = Path.GetFileName(sourcePath);
            string newFolderPath = Path.Combine(destinationPath, folderName);

            foreach (string file in Directory.GetFiles(sourcePath))
            {
                File.Copy(file, Path.Combine(newFolderPath, Path.GetFileName(file)), true);
            }
        }
    }
}
