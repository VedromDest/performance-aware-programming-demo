using System.Diagnostics;
using System.Numerics;

namespace PerformanceConsoleApp.Voorbeelden;

public static class SIMD
{
    public static void Run(int size)
    {
        Console.WriteLine("SIMD available at hardware level: " + Vector.IsHardwareAccelerated);

        // drie arrays van type float
        float[] a, b, c;
        
        // zelfde lengte
        a = new float[size];
        b = new float[size];
        c = new float[size];
        
        // a en b worden gevuld met random waarden
        Random rnd = new Random();
        for (int i = 0; i < size; i++)
        {
            a[i] = (float) rnd.NextDouble() * rnd.Next(10000);
            b[i] = a[i] / i;
        }
        
        // c wordt gevuld met de som van a en b
        var stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < a.Length; i++)
        {
            c[i] = a[i] + b[i];
        }
        stopwatch.Stop();
        Console.WriteLine($"Time taken one-by-one: {stopwatch.ElapsedMilliseconds}ms");
        
        // SIMD variant
        int simdWidth = Vector<float>.Count; // hangt af van CPU
        stopwatch.Restart();
        int j = 0;
        for (; j <= size - simdWidth; j += simdWidth)
        {
            var va = new Vector<float>(a, j); // kent zelf zijn width
            var vb = new Vector<float>(b, j); // kent zelf zijn width
            var vc = va + vb; // vectoren optellen (dit is de SIMD-operatie)    
            vc.CopyTo(c, j);
        }
        // Kan zijn dat lengte lijst geen exact veelvoud simdWidth is.
        // We mogen niet vergeten de overschot er door te draaien.
        for (; j < size; j++)
            c[j] = a[j] + b[j];
        stopwatch.Stop();
        Console.WriteLine($"Time taken SIMD: {stopwatch.ElapsedMilliseconds}ms");
    }
    
}