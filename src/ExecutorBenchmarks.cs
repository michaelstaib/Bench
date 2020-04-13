using Bench.Data;
using Benchmark.src.GraphQLDotNet;
using BenchmarkDotNet.Attributes;
using GraphQL;
using GraphQL.Server.Internal;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bench
{
    [RPlotExporter, CategoriesColumn, RankColumn, MeanColumn, MedianColumn, MemoryDiagnoser]
    public class ExecutorBenchmarks
    {
        private readonly IServiceProvider _services;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IGraphQLExecuter<BenchSchema> _gqlDotNetExecutor;

        public ExecutorBenchmarks()
        {
            _services = new ServiceCollection()
                .AddSingleton<CharacterRepository>()
                .AddSingleton<ReviewRepository>()
                .BuildServiceProvider();

            _queryExecutor = HotChocolate.Setup.Create();
            _gqlDotNetExecutor = GraphQLDotNet.Setup.Create();
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

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_SmallQuery()
        {
            return await _gqlDotNetExecutor.ExecuteAsync("",
                @"
                {
                    hero(episode: EMPIRE) {
                        id
                        name
                    }
                }
                ", null, null);
        }
    }
}