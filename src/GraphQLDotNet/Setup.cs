using Bench.Data;
using Bench.GraphQLDotNet.Types;
using Benchmark.src.GraphQLDotNet;
using GraphQL.Server;
using GraphQL.Server.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Bench.GraphQLDotNet
{
    public static class Setup
    {
        public static IGraphQLExecuter<BenchSchema> Create()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<CharacterRepository>()
                .AddSingleton<ReviewRepository>()
                .AddSingleton<BenchSchema>()
                .AddSingleton<QueryType>()
                .AddSingleton<CharacterType>()
                .AddSingleton<EpisodeType>()
                .AddSingleton<ReviewInputType>()
                .AddSingleton<SearchResultType>()
                .AddSingleton<StarshipType>()
                .AddSingleton<DroidType>()
                .AddSingleton<HumanType>()
                .AddSingleton<ReviewType>()
                .AddSingleton<UnitType>();
            serviceProvider.AddGraphQL();

            var o = serviceProvider.BuildServiceProvider().GetRequiredService<HumanType>();
            return serviceProvider.BuildServiceProvider().GetService<IGraphQLExecuter<BenchSchema>>();
        }
    }
}
