using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Spectre.Console;

class Program
{
    static int copiedFilesCount = 0;
    static object locker = new object();

    static void Main(string[] args)
    {
        Stopwatch stopWatch = new Stopwatch();

        var selectOption = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose an option. Do you want to manually specify paths or use the default system?")
                .PageSize(3)
                .AddChoices(new[] {
                    "Manually specify paths", "Default system" }));

        string destinationPath = "";
        List<string> sourcePaths = new List<string>();

        if (selectOption == "Manually specify paths")
        {
            destinationPath = AnsiConsole.Prompt(
                new TextPrompt<string>("[red]Enter destination path:[/]")
                    .PromptStyle("yellow")
                    .ValidationErrorMessage("Please enter a valid path")
                    .Validate(path => !string.IsNullOrEmpty(path.Trim()) && Directory.Exists(path)));

            while (true)
            {
                string sourcePath = AnsiConsole.Prompt(
                    new TextPrompt<string>("[red]Enter source path:[/]")
                        .PromptStyle("yellow")
                        .ValidationErrorMessage("Please enter a valid path")
                        .Validate(path => !string.IsNullOrEmpty(path.Trim()) && Directory.Exists(path)));

                sourcePaths.Add(sourcePath);

                string answer = AnsiConsole.Prompt(
                    new TextPrompt<string>("Do you want to insert another path? (y/n)")
                        .PromptStyle("yellow")
                        .ValidationErrorMessage("Please enter 'y' or 'n'")
                        .Validate(input => input.ToLowerInvariant() == "y" || input.ToLowerInvariant() == "n"));

                if (answer.ToLowerInvariant() != "y")
                {
                    break;
                }
            }
        }
        else if (selectOption == "Default system")
        {
            string defaultDestinationPath = "C:\\Users\\Schule8\\OneDrive\\Desktop\\CopiedFolders";

            string[] defaultSourcePaths =
            {
                "C:\\Users\\Schule8\\OneDrive\\Desktop\\Practice_CSharp\\Lesson_7_DirectoryAndThreads\\Folder-1.zip",
                "C:\\Users\\Schule8\\OneDrive\\Desktop\\Practice_CSharp\\Lesson_7_DirectoryAndThreads\\Folder-2.zip",
                "C:\\Users\\Schule8\\OneDrive\\Desktop\\Practice_CSharp\\Lesson_7_DirectoryAndThreads\\Folder-3.zip",
                "C:\\Users\\Schule8\\OneDrive\\Desktop\\Practice_CSharp\\Lesson_7_DirectoryAndThreads\\Folder-4.zip",
                "C:\\Users\\Schule8\\OneDrive\\Desktop\\Practice_CSharp\\Lesson_7_DirectoryAndThreads\\Folder-5.zip",
                "C:\\Users\\Schule8\\OneDrive\\Desktop\\Practice_CSharp\\Lesson_7_DirectoryAndThreads\\Folder-6.zip"
            };

            destinationPath = defaultDestinationPath;
            sourcePaths.AddRange(defaultSourcePaths);
        }

        stopWatch.Start();
        try
        {
            var progress = AnsiConsole.Progress()
               .Columns(new ProgressColumn[]
               {
                    new TaskDescriptionColumn(),
                    new ProgressBarColumn(),
                    new PercentageColumn(),
                    new RemainingTimeColumn(),
                    new SpinnerColumn(),
               });

            progress.Start(task =>
            {
                var globalTask = task.AddTask("[white]Global Progress[/]");
                CopyFiles(sourcePaths, destinationPath, task, globalTask);
            });

            stopWatch.Stop();

            Console.WriteLine($"Time: {stopWatch.Elapsed} sec");
            Console.WriteLine($"Copied files count: {copiedFilesCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void CopyFiles(List<string> sourcePaths, string destinationPath, ProgressContext ctx, ProgressTask globalTask)
    {
        Thread[] threads = new Thread[sourcePaths.Count];
        long totalSize = 0;

        foreach (var sourcePath in sourcePaths)
        {
            totalSize += new FileInfo(sourcePath).Length;
        }

        for (int i = 0; i < sourcePaths.Count; i++)
        {
            var task = ctx.AddTask(Path.GetFileName(sourcePaths[i]));
            threads[i] = CopyFileAsync(sourcePaths[i], destinationPath, task, globalTask, totalSize);
        }

        foreach (Thread thread in threads)
        {
            thread.Start();
        }
        foreach (Thread thread in threads)
        {
            thread.Join();
        }
    }

    static Thread CopyFileAsync(string sourcePath, string destinationPath, ProgressTask task, ProgressTask globalTask, long totalSize)
    {
        var thread = new Thread(() => Copy(sourcePath, Path.Combine(destinationPath, Path.GetFileName(sourcePath)), task, globalTask, totalSize));
        return thread;
    }

    public static void Copy(string inputFilePath, string outputFilePath, ProgressTask task, ProgressTask globalTask, long totalSize)
    {
        int bufferSize = 1024 * 1024;

        using (FileStream fileStream = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
        {
            using (FileStream fs = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                fileStream.SetLength(fs.Length);
                int bytesRead = -1;
                byte[] bytes = new byte[bufferSize];
                long totalBytesRead = 0;
                task.MaxValue(fs.Length);

                while ((bytesRead = fs.Read(bytes, 0, bufferSize)) > 0)
                {
                    fileStream.Write(bytes, 0, bytesRead);
                    totalBytesRead += bytesRead;
                    Thread.Sleep(1000);
                    task.Increment(bytesRead);
                    globalTask.Increment((double)bytesRead / totalSize * 100);
                }
            }
        }

        lock (locker)
        {
            copiedFilesCount++;
        }
    }

}
