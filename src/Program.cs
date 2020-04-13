using BenchmarkDotNet.Running;


namespace Bench
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new ExecutorBenchmarks();
            var y = x.GQLDotNet_SmallQuery_With_Fragments().Result;

            // BenchmarkRunner.Run<ExecutorBenchmarks>();
        }
    }
}
