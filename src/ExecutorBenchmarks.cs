using System;
using System.Threading.Tasks;
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
        private readonly IRequestExecutor _queryExecutor;
        private readonly IGraphQLExecuter<BenchSchema> _gqlDotNetExecutor;

        public ExecutorBenchmarks()
        {
            _queryExecutor = HotChocolate.Setup.Create();
            _gqlDotNetExecutor = GraphQLDotNet.Setup.Create();
        }

        [Benchmark]
        public async Task<IExecutionResult> HotChocolate_Three_Fields()
        {
            var request = new QueryRequest(new QuerySourceText(Queries.ThreeFields));

            var result = await _queryExecutor.ExecuteAsync(request);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            if (result is IQueryResult q)
            {
                q.Dispose();
            }
            
            return result;
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_Three_Fields()
        {
            var result = await _gqlDotNetExecutor.ExecuteAsync("", Queries.ThreeFields, null, null, default);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            return result;
        }

        [Benchmark]
        public async Task<IExecutionResult> HotChocolate_Small_Query_With_Async()
        {
            var request = new QueryRequest(new QuerySourceText(Queries.SmallQueryWithAsync));

            var result = await _queryExecutor.ExecuteAsync(request);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            if (result is IQueryResult q)
            {
                q.Dispose();
            }
            
            return result;
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_Small_Query_With_Async()
        {
            var result = await _gqlDotNetExecutor.ExecuteAsync("", Queries.SmallQueryWithAsync, null, null, default);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            return result;
        }

        [Benchmark]
        public async Task<IExecutionResult> HotChocolate_SmallQuery_With_Fragments()
        {
            var request = new QueryRequest(new QuerySourceText(Queries.SmallQuery));
            var result = await _queryExecutor.ExecuteAsync(request);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            if (result is IQueryResult q)
            {
                q.Dispose();
            }
            
            return result;
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_SmallQuery_With_Fragments()
        {
            var result = await _gqlDotNetExecutor.ExecuteAsync("", Queries.SmallQuery, null, null, default);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            return result;
        }

        [Benchmark]
        public async Task<IExecutionResult> HotChocolate_MediumQuery_With_Fragments()
        {
            var request = new QueryRequest(new QuerySourceText(Queries.MediumQuery));
            var result = await _queryExecutor.ExecuteAsync(request);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            if (result is IQueryResult q)
            {
                q.Dispose();
            }
            
            return result;
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_MediumQuery_With_Fragments()
        {
            var result = await _gqlDotNetExecutor.ExecuteAsync("", Queries.MediumQuery, null, null, default);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            return result;
        }

         [Benchmark]
        public async Task<IExecutionResult> HotChocolate_MediumQuery_With_Fragments_With_Async()
        {
            var request = new QueryRequest(new QuerySourceText(Queries.MediumQueryAsync));
            var result = await _queryExecutor.ExecuteAsync(request);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            if (result is IQueryResult q)
            {
                q.Dispose();
            }
            
            return result;
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_MediumQuery_With_Fragments_With_Async()
        {
            var result = await _gqlDotNetExecutor.ExecuteAsync("", Queries.MediumQueryAsync, null, null, default);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            return result;
        }

        [Benchmark]
        public async Task<IExecutionResult> HotChocolate_IntrospectionQuery()
        {
            var request = new QueryRequest(new QuerySourceText(Queries.Introspection));
            var result = await _queryExecutor.ExecuteAsync(request);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            if (result is IQueryResult q)
            {
                q.Dispose();
            }
            
            return result;
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_Introspection()
        {
            var result = await _gqlDotNetExecutor.ExecuteAsync("", Queries.Introspection, null, null, default);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            return result;
        }

        [Benchmark]
        public async Task<IExecutionResult> HotChocolate_Medium_Query_Plus_Introspection()
        {
            var request = new QueryRequest(new QuerySourceText(Queries.MediumPlusIntrospection));
            var result = await _queryExecutor.ExecuteAsync(request);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            if (result is IQueryResult q)
            {
                q.Dispose();
            }
            
            return result;
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_Medium_Query_Plus_Introspection()
        {
            var result = await _gqlDotNetExecutor.ExecuteAsync("", Queries.MediumPlusIntrospection, null, null, default);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            return result;
        }

        [Benchmark]
        public async Task<IExecutionResult> HotChocolate_Medium_Query_Plus_Introspection_With_Async()
        {
            var request = new QueryRequest(new QuerySourceText(Queries.MediumPlusIntrospectionWithAsync));
            var result = await _queryExecutor.ExecuteAsync(request);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            if (result is IQueryResult q)
            {
                q.Dispose();
            }
            
            return result;
        }

        [Benchmark]
        public async Task<ExecutionResult> GQLDotNet_Medium_Query_Plus_Introspection_With_Async()
        {
            var result = await _gqlDotNetExecutor.ExecuteAsync("", Queries.MediumPlusIntrospectionWithAsync, null, null, default);

            if (result.Errors is { })
            {
                throw new Exception("Result has errors!");
            }

            return result;
        }
    }
}