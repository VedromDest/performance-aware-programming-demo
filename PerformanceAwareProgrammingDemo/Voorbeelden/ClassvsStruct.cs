using System.Diagnostics;

namespace PerformanceConsoleApp.Voorbeelden;

public static class ClassvsStruct
{
    public static void Run(List<Student> studenten)
    {
        var studentenArray = studenten.ToArray();
        int globalCounter = 0;
        var stopwatch = Stopwatch.StartNew();
        foreach (var student in studenten)
        {
            globalCounter += student.Id;
        }
        stopwatch.Stop();
        Console.WriteLine($"Time taken adding ids from Array of Object: {stopwatch.ElapsedMilliseconds}ms");
        
        globalCounter = 0;
        var studentenStructArray = studenten
            .Select(x => new StudentStruct { Id = x.Id, Email = x.Email, IsGeslaagd = x.IsGeslaagd})
            .ToArray();
        stopwatch.Restart();
        foreach (var student in studentenStructArray)
        {
            globalCounter += student.Id;
        }
        stopwatch.Stop();
        Console.WriteLine($"Time taken adding ids from Array of Struct: {stopwatch.ElapsedMilliseconds}ms");
    }
}