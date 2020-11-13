using Bench.Data;
using Bench.HotChocolate.Types;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;

namespace Bench.HotChocolate
{
    public static class Setup
    {
        public static IRequestExecutor Create()
        {
            return new ServiceCollection()
                .AddSingleton<CharacterRepository>()
                .AddSingleton<ReviewRepository>()
                .AddGraphQLServer()
                .AddQueryType<QueryType>()
                .AddType<DroidType>()
                .AddType<HumanType>()
                .BuildRequestExecutorAsync()
                .Result;
        }
    }
}
