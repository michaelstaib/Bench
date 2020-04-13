using BenchmarkDotNet.Running;


namespace Bench
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ExecutorBenchmarks>();
        }
    }
}
