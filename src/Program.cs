using BenchmarkDotNet.Running;

namespace Bench
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new ExecutorBenchmarks();
          var y =    x.GQLDotNet_SmallQuery().Result;


            // BenchmarkRunner.Run<ExecutorBenchmarks>();
        }
    }
}
