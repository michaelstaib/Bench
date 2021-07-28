using System.Threading.Tasks;
using BenchmarkDotNet.Running;


namespace Bench
{
    class Program
    {
        async static Task Main(string[] args)
        {
            await new ExecutorBenchmarks().HotChocolate_Medium_Query_Plus_Introspection_With_Async();
        }
        // => BenchmarkRunner.Run<ExecutorBenchmarks>();
    }
}
