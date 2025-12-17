using System.Diagnostics;

namespace PerformanceConsoleApp.Voorbeelden;

public static class FileCaching
{
    public static void Run(int count)
    {
        var sqlStatementsLibrary = new SqlStatementsLibrary();
        var stopwatch = Stopwatch.StartNew();
        string query = string.Empty;
        for (int i = 0; i < count; i++)
        {
            query = sqlStatementsLibrary.MijnSuperQuery;
        }
        stopwatch.Stop();
        Console.WriteLine($"Time taken reading sql statements from file: {stopwatch.ElapsedMilliseconds}ms");
        
        var cachedSqlStatementsLibrary = new CachedSqlStatementsLibrary();
        stopwatch.Restart();
        string queryCached = string.Empty;
        for (int i = 0; i < count; i++)
        {
            queryCached = cachedSqlStatementsLibrary.MijnSuperQuery;
        }        
        stopwatch.Stop();
        Console.WriteLine($"Time taken reading sql statements from file (cached): {stopwatch.ElapsedMilliseconds}ms");
    }
}

public class SqlStatementsLibrary()
{
    private const string ContentRoot = "Queries/";

    public string MijnSuperQuery => 
        GetQuery(nameof(MijnSuperQuery));

    private static string GetQuery(string queryName) =>
        File.ReadAllText(ContentRoot + queryName + ".sql");
}

public class CachedSqlStatementsLibrary()
{
    private const string QueryRoot = "Queries/";
    private string? _mijnSuperQuery;
    
    public string MijnSuperQuery => 
        _mijnSuperQuery ??= GetQuery(nameof(MijnSuperQuery));

    private static string GetQuery(string queryName) =>
        File.ReadAllText(QueryRoot + queryName + ".sql");
}