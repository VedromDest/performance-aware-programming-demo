using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PerformanceConsoleApp.Voorbeelden;

public static class SequentialvsParallel
{
    public static void Run(List<Student> studenten)
    {
        // Sequential
        var stopwatch = Stopwatch.StartNew();
        foreach (var student in studenten)
        {
            if(!IsEmailOk(student.Email))
                Console.WriteLine($"Email {student.Email} is not valid.");
        }
        stopwatch.Stop();
        Console.WriteLine($"Time taken checking emails sequential: {stopwatch.ElapsedMilliseconds}ms");
        
        // Parallel
        stopwatch.Restart();
        Parallel.ForEach(studenten, student => {             
            if(!IsEmailOk(student.Email))
                Console.WriteLine($"Email {student.Email} is not valid."); 
        });
        stopwatch.Stop();
        Console.WriteLine($"Time taken checking emails parallel: {stopwatch.ElapsedMilliseconds}ms");
    }

    private static bool IsEmailOk(string email)
    {
        return Regex.IsMatch(email, @"^(.+)@(student.hogent)(\..+)$");
    }
}