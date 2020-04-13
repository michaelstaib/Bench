using Bench.Models;
using Bench.HotChocolate.Resolvers;
using GraphQL.Types;

namespace Bench.GraphQLDotNet.Types
{
    public class StarshipType : ObjectGraphType<Starship>
    {
        public StarshipType()
        {
            Field<NonNullGraphType<IdGraphType>>("id", resolve: context => context.Source.Id);
            Field<IntGraphType>(
                "lenght",
                arguments: new QueryArguments() { new QueryArgument<UnitType>() { Name = "unit" } },
                resolve: context => SharedResolvers.GetLength(context.GetArgument<Unit>("length"), context.Source));
        }
    }
}
