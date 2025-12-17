using System.Diagnostics;
using System.Text;

namespace PerformanceConsoleApp.Voorbeelden;

public static class ConcatenationvsStringBuilder
{
    public static void Run(List<Student> studenten, bool runRegularConcatenation = false)
    {
        // regular concatenation
        if (runRegularConcatenation)
        {
            var stopwatch = Stopwatch.StartNew();
            var targString = "start";
            foreach (var student in studenten)
                targString += student.Email;
            stopwatch.Stop();
            Console.WriteLine($"Time taken concatenating: {stopwatch.ElapsedMilliseconds}ms");
        }
        else
        {
            Console.WriteLine("Regular concatenation skipped. Too slow.");
        }

        // stringbuilder
        var stopwatch2 = Stopwatch.StartNew();
        var targStringBuilder = new StringBuilder("start", studenten.Count+1);
        foreach (var student in studenten)
            targStringBuilder.Append(student.Email);
        stopwatch2.Stop();
        Console.WriteLine($"Time taken stringbuilding: {stopwatch2.ElapsedMilliseconds}ms");
    }
}