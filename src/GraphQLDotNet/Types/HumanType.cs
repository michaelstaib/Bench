using Bench.Data;
using Bench.Models;
using GraphQL;
using GraphQL.Types;

namespace Bench.GraphQLDotNet.Types
{
    public class HumanType : ObjectGraphType<Human>
    {
        public HumanType(CharacterRepository repository)
        {
            Name = "Human";

            Interface<CharacterType>();

            Field<NonNullGraphType<IdGraphType>>(
                "id", 
                resolve: ctx => ctx.Source.Id);
            Field(t => t.Name, nullable: true);
            Field<ListGraphType<CharacterType>>(
                "friends",
                resolve: context => SharedResolvers.GetCharacter(context.Source, repository));
            Field<ListGraphType<EpisodeType>>(
                "appearsIn", 
                resolve: ctx => ctx.Source.AppearsIn);
            Field(t => t.HomePlanet);
            Field<FloatGraphType>(
                "height",
                arguments: new QueryArguments(
                    new QueryArgument<UnitType> { Name = "unit" }),
                resolve: context => SharedResolvers.GetHeight(context.GetArgument<Unit?>("unit"), context.Source));
        }
    }
}
