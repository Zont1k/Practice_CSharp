using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

class Program
{
    static int copiedFilesCount = 0;
    static object locker = new object();

    static void Main(string[] args)
    {
        Stopwatch stopWatch = new Stopwatch();

        string destinationPath = @"C:\Users\Schule8\OneDrive\Desktop\CopiedFolders";
        string[] sourcePaths =
        {
            @"C:\Users\Schule8\RiderProjects\Practice_CSharp\Lesson_7_DirectoryAndThreads\Folder-1.zip",
            @"C:\Users\Schule8\RiderProjects\Practice_CSharp\Lesson_7_DirectoryAndThreads\Folder-2.zip",
            @"C:\Users\Schule8\RiderProjects\Practice_CSharp\Lesson_7_DirectoryAndThreads\Folder-3.zip",
            @"C:\Users\Schule8\RiderProjects\Practice_CSharp\Lesson_7_DirectoryAndThreads\Folder-4.zip",
            @"C:\Users\Schule8\RiderProjects\Practice_CSharp\Lesson_7_DirectoryAndThreads\Folder-5.zip"
        };

        stopWatch.Start();
        try
        {
            CopyFolders(destinationPath, sourcePaths);
            stopWatch.Stop();

            Console.WriteLine($"Time: {stopWatch.Elapsed} sec");
            Console.WriteLine($"Copied files count: {copiedFilesCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void CopyFolders(string destinationPath, params string[] sourcePaths)
    {
        Thread[] threads = new Thread[sourcePaths.Length];

        for (int i = 0; i < sourcePaths.Length; i++)
        {
            string sourcePath = sourcePaths[i];
            threads[i] = new Thread(() => CopyFile(sourcePath, destinationPath));
            threads[i].Start();
        }
        
        foreach (Thread thread in threads)
        {
            thread.Join();
        }
    }

    static void CopyFile(string sourcePath, string destinationPath)
    {
        string fileName = Path.GetFileName(sourcePath);
        string newFolderPath = Path.Combine(destinationPath, fileName);
        File.Copy(sourcePath, newFolderPath, true);

        lock (locker)
        {
            copiedFilesCount++;
        }
    }
}
