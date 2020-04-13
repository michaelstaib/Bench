using Bench.GraphQLDotNet.Types;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Benchmark.src.GraphQLDotNet
{
    public class BenchSchema : Schema
    {
        public BenchSchema(IServiceProvider provider)
        {
            Query = provider.GetService<QueryType>();
        }
    }
}
