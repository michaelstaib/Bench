using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Bench.Data;
using BenchmarkDotNet.Attributes;
using HotChocolate.Execution;

namespace Bench
{
    [RPlotExporter, CategoriesColumn, RankColumn, MeanColumn, MedianColumn, MemoryDiagnoser]
    public class ExecutorBenchmarks
    {
        private readonly IServiceProvider _services;
        private readonly IQueryExecutor _queryExecutor;

        public ExecutorBenchmarks()
        {
            _services = new ServiceCollection()
                .AddSingleton<CharacterRepository>()
                .AddSingleton<ReviewRepository>()
                .BuildServiceProvider();

            _queryExecutor = HotChocolate.Setup.Create();

        }

        [Benchmark]
        public async Task<IExecutionResult> HotChocolate_SmallQuery()
        {
            var request = QueryRequestBuilder.New()
                .SetQuery(@"
                {
                    hero(episode: EMPIRE) {
                        id
                        name
                    }
                }
                ")
                .SetServices(_services)
                .Create();

            return await _queryExecutor.ExecuteAsync(request);
        }
    }
}