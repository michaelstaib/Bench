using BenchmarkDotNet.Running;


namespace Bench
{
    class Program
    {
        static void Main(string[] args)
        {
            new ExecutorBenchmarks().GQLDotNet_Introspection().Wait();

            BenchmarkRunner.Run<ExecutorBenchmarks>();
        }
    }
}
