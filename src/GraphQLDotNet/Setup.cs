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
            var serivceProvider = new ServiceCollection()
                .AddSingleton<CharacterRepository>()
                .AddSingleton<ReviewRepository>()
                .AddSingleton<CharacterType>()
                .AddSingleton<DroidType>()
                .AddSingleton<EpisodeType>()
                .AddSingleton<HumanType>()
                .AddSingleton<ReviewInputType>()
                .AddSingleton<ReviewType>()
                .AddSingleton<SearchResultType>()
                .AddSingleton<StarshipType>()
                .AddSingleton<UnitType>()
                .AddSingleton<BenchSchema>();
            serivceProvider.AddGraphQL();
            return serivceProvider.BuildServiceProvider().GetService<IGraphQLExecuter<BenchSchema>>();
        }
    }
}
