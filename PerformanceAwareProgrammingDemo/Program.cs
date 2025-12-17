// See https://aka.ms/new-console-template for more information

using PerformanceConsoleApp;
using PerformanceConsoleApp.Voorbeelden;

const int count = 10_000_000;
var studentenList = CreateTestData(count);
Console.WriteLine($">> Running with {studentenList.Count} students. <<");

PrintTitel("List vs Dictionary");
ListVsDictionary.Run(studentenList);
PrintTitel("Sequential vs Parallel");
SequentialvsParallel.Run(studentenList);
PrintTitel("Concatenation vs StringBuilder");
ConcatenationvsStringBuilder.Run(studentenList, runRegularConcatenation: false); // Want zal allicht vastlopen
PrintTitel("Substring vs Span");
SubstringVsSpan.Run(studentenList);
PrintTitel("Class vs Struct");
ClassvsStruct.Run(studentenList);
PrintTitel("File caching");
FileCaching.Run(10000);
PrintTitel("SIMD (Single Instruction Multiple Data)");
SIMD.Run(100_000_000);


void PrintTitel(string title)
{
    Console.WriteLine();
    Console.WriteLine(title);
    Console.WriteLine(new string('-', title.Length));
}

List<Student> CreateTestData(int count = 10_000_000)
{
    var studentenList = new List<Student>();

    for(int i = 0; i < count; i++)
        studentenList.Add(new Student
        {
            Id = i,
            Email = $"student{i}@student.hogent.fake",
            IsGeslaagd = i % 2 == 0
        });
    return studentenList;
}

namespace PerformanceConsoleApp
{
    public class Student
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsGeslaagd { get; set; }
    }

    public struct StudentStruct
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsGeslaagd { get; set; }
    }
}