using BenchmarkDotNet.Running;


namespace Bench
{
    class Program
    {
        static void Main(string[] args)
        {
            // new ExecutorBenchmarks().HotChocolate_Small_Query_With_Async().Wait();
            new ExecutorBenchmarks().GQLDotNet_Small_Query_With_Async().Wait();

            BenchmarkRunner.Run<ExecutorBenchmarks>();
        }
    }
}
