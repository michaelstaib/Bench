using HotChocolate.Execution.Configuration;
using HotChocolate.StarWars.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StarWarsRequestExecutorBuilderExtensions
    {
        public static IRequestExecutorBuilder AddStarWars(this IRequestExecutorBuilder builder)
        {
            return builder;
        }
    }
}
