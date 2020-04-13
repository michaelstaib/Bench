using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Bench.Data;
using Benchmark.src.GraphQLDotNet;
using BenchmarkDotNet.Attributes;
using GraphQL;
using GraphQL.Server.Internal;
using HotChocolate.Execution;

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
        public async Task<IExecutionResult> HotChocolate_Three_Fields()
        {
            var request = QueryRequestBuilder.New()
                .SetQuery(Queries.ThreeFields)
                .SetServices(_services)
                .Create();

            return await _queryExecutor.ExecuteAsync(request);
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_Three_Fields()
        {
            return await _gqlDotNetExecutor.ExecuteAsync("", Queries.ThreeFields, null, null);
        }

        [Benchmark]
        public async Task<IExecutionResult> HotChocolate_SmallQuery_With_Fragments()
        {
            var request = QueryRequestBuilder.New()
                .SetQuery(Queries.SmallQuery)
                .SetServices(_services)
                .Create();

            return await _queryExecutor.ExecuteAsync(request);
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_SmallQuery_With_Fragments()
        {
            return await _gqlDotNetExecutor.ExecuteAsync("", Queries.SmallQuery, null, null);
        }

        [Benchmark]
        public async Task<IExecutionResult> HotChocolate_MediumQuery_With_Fragments()
        {
            var request = QueryRequestBuilder.New()
                .SetQuery(Queries.MediumQuery)
                .SetServices(_services)
                .Create();

            return await _queryExecutor.ExecuteAsync(request);
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_MediumQuery_With_Fragments()
        {
            return await _gqlDotNetExecutor.ExecuteAsync("", Queries.MediumQuery, null, null);
        }

        [Benchmark]
        public async Task<IExecutionResult> HotChocolate_IntrospectionQuery()
        {
            var request = QueryRequestBuilder.New()
                .SetQuery(Queries.Introspection)
                .SetServices(_services)
                .Create();

            return await _queryExecutor.ExecuteAsync(request);
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_Introspection()
        {
            return await _gqlDotNetExecutor.ExecuteAsync("", Queries.Introspection, null, null);
        }

        [Benchmark]
        public async Task<IExecutionResult> HotChocolate_Medium_Query_Plus_Introspection()
        {
            var request = QueryRequestBuilder.New()
                .SetQuery(Queries.MediumPlusIntrospection)
                .SetServices(_services)
                .Create();

            return await _queryExecutor.ExecuteAsync(request);
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_Medium_Query_Plus_Introspection()
        {
            return await _gqlDotNetExecutor.ExecuteAsync("", Queries.MediumPlusIntrospection, null, null);
        }
    }
}