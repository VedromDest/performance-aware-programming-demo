using System.Diagnostics;

namespace PerformanceConsoleApp.Voorbeelden;

public static class ListVsDictionary
{
    public static void Run(List<Student> students)
    {
        // Setup
        var studentenList = students;
        var studentenDictionary = studentenList.ToDictionary(x => x.Id);
        var idToFind = studentenList.Count / 2;

        // Find in List
        var stopwatch = Stopwatch.StartNew();
        var resultFromList = studentenList.SingleOrDefault(x => x.Id == idToFind);
        stopwatch.Stop();
        Console.WriteLine($"Time taken searching list: {stopwatch.ElapsedMilliseconds}ms");

        // Find in Dictionary
        stopwatch.Restart();
        var resultFromDict = studentenDictionary[idToFind];
        stopwatch.Stop();
        Console.WriteLine($"Time taken searching dict: {stopwatch.ElapsedMilliseconds}ms");
    }
}