using System.Diagnostics;

namespace PerformanceConsoleApp.Voorbeelden;

public static class SubstringVsSpan
{
    public static void Run(List<Student> studenten)
    {
        // Substring
        var stopwatch = Stopwatch.StartNew();
        foreach (var student in studenten)
        {
            var eerste6 = student.Email.Substring(0, 6);
            var laatste6 = student.Email.Substring(student.Email.Length - 7, 6);
            var eerste2 = student.Email.Substring(0, 2);
            var laatste4 = student.Email.Substring(student.Email.Length - 5, 4);
        }
        stopwatch.Stop();
        Console.WriteLine($"Time taken substring: {stopwatch.ElapsedMilliseconds}ms");
        
        // Span
        stopwatch.Restart();
        foreach (var student in studenten)
        {
            var asSpan = student.Email.AsSpan();
            var first6 = asSpan[..6];
            var last6 = asSpan.Slice(asSpan.Length-7, 6);
            var first2 = asSpan[..2];
            var last4 = asSpan.Slice(asSpan.Length-5, 4);
        }
        stopwatch.Stop();
        Console.WriteLine($"Time taken span: {stopwatch.ElapsedMilliseconds}ms");
    }
}