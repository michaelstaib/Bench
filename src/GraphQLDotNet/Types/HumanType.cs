using Bench.Data;
using Bench.Models;
using GraphQL.Types;

namespace Bench.GraphQLDotNet.Types
{
    public class HumanType : ObjectGraphType<Human>
    {
        public HumanType(CharacterRepository repository)
        {
            Name = "Human";

            Interface<CharacterType>();

            Field(t => t.Id).Type(new NonNullGraphType<IdGraphType>());
            Field(t => t.Name, nullable: true);
            Field<ListGraphType<CharacterType>>(
                "friends",
                resolve: context => SharedResolvers.GetCharacter(context.Source, repository));
            Field(t => t.AppearsIn).Type(new ListGraphType<EpisodeType>());
            Field<FloatGraphType>(
                "height",
                arguments: new QueryArguments(
                    new QueryArgument<UnitType> { Name = "unit" }),
                resolve: context => SharedResolvers.GetHeight(context.GetArgument<Unit?>("unit"), context.Source));
        }
    }
}
