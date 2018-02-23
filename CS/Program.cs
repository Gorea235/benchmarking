using System;
using System.Diagnostics;

namespace benchmark
{
    class Program
    {
        static double tmp;

        static void Main(string[] args)
        {
            Benchmark(ToBench, int.Parse(args[0]));
        }

        static double Benchmark(Action func, int numBenchmarks)
        {
            GC.Collect();
            func();
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan meanTime;
            TimeSpan totalTime;

            Console.WriteLine("----------------------------");
            Console.WriteLine("Starting Benchmark");
            Console.WriteLine("----------------------------");

            for (int i = 0; i < numBenchmarks; i++)
            {
                // Start the benchmark
                stopwatch.Start();

                // Call the function to benchmark
                func();

                // End the benchmark
                stopwatch.Stop();

                // Add the benchmark time to the total time
                totalTime += stopwatch.Elapsed;

                // Add the benchmark time to mean_time and if it wasn't 0, divide by 2
                if (meanTime != null)
                    meanTime = (meanTime + stopwatch.Elapsed) / 2;
                else
                    meanTime = stopwatch.Elapsed;

                // Print the current step
                Console.WriteLine("Completed step {0}\tTime spent: {1}s", i + 1, stopwatch.Elapsed.GetExplicitSeconds());

                // reset stopwatch
                stopwatch.Reset();
            }

            // Gobal time spent in the benchmark
            Console.WriteLine("----------------------------\n\n");
            Console.WriteLine("Ended benchmark!");
            Console.WriteLine("Total time spent: {0}s", totalTime.GetExplicitSeconds());
            Console.WriteLine("Mean time spent: {0}s", meanTime.GetExplicitSeconds());
            Console.WriteLine("----------------------------");

            // Return the mean time
            return meanTime.GetExplicitSeconds();
        }

        static void ToBench()
        {
            tmp = 0;
            for (long i = 0; i < 1000000000; i++)
                tmp += Math.Sqrt(i);
        }
    }

    static class StopwatchExtension
    {
        // public static double GetExplicitSeconds(this TimeSpan ts) => ts.Ticks / (double)Stopwatch.Frequency;
        public static double GetExplicitSeconds(this TimeSpan ts) => ts.TotalMilliseconds / 1000.0;
    }
}
