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

        string destinationPath = AnsiConsole.Prompt(
            new TextPrompt<string>("[red]Enter destination path:[/]")
                .PromptStyle("yellow")
                .ValidationErrorMessage("Please enter a valid path")
                .Validate(path => !string.IsNullOrEmpty(path.Trim())));

        List<string> sourcePaths = new List<string>();

        while (true)
        {
            string sourcePath = AnsiConsole.Prompt(
                new TextPrompt<string>("[red]Enter source path:[/]")
                    .PromptStyle("yellow")
                    .ValidationErrorMessage("Please enter a valid path")
                    .Validate(path => !string.IsNullOrEmpty(path.Trim())));

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

            progress.Start(ctx =>
            {
                CopyFiles(sourcePaths, destinationPath, ctx);
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

    static void CopyFiles(List<string> sourcePaths, string destinationPath, ProgressContext ctx)
    {
        Thread[] threads = new Thread[sourcePaths.Count];

        for (int i = 0; i < sourcePaths.Count; i++)
        {
            var task = ctx.AddTask(Path.GetFileName(sourcePaths[i]));
            threads[i] = CopyFileAsync(sourcePaths[i], destinationPath, task); 
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

    static Thread CopyFileAsync(string sourcePath, string destinationPath, ProgressTask task)
    {
        var thread = new Thread(() => Copy(sourcePath, Path.Combine(destinationPath, Path.GetFileName(sourcePath)), task));
        return thread;
    }

    public static void Copy(string inputFilePath, string outputFilePath, ProgressTask task)
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
                }
            }
        }

        lock (locker)
        {
            copiedFilesCount++;
        }
    }
}
