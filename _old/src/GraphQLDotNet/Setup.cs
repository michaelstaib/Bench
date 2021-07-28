using Bench.Data;
using Bench.GraphQLDotNet.Types;
using Benchmark.src.GraphQLDotNet;
using GraphQL.Server;
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
                .AddSingleton<UnitType>()
                .AddOptions()
                .AddGraphQL()
                .AddSystemTextJson()
                .AddGraphTypes(typeof(BenchSchema))
                .Services;

            return serviceProvider.BuildServiceProvider().GetService<IGraphQLExecuter<BenchSchema>>();
        }
    }
}
