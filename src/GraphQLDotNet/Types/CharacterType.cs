using GraphQL.Types;

namespace Bench.GraphQLDotNet.Types
{
    public class CharacterType : InterfaceGraphType
    {
        public CharacterType()
        {
            Name = "Character";
            Field<NonNullGraphType<IdGraphType>>("id");
            Field<StringGraphType>("name");
            Field<ListGraphType<CharacterType>>("friends");
            Field<ListGraphType<EpisodeType>>("appearsIn");
            Field<FloatGraphType>("height", 
                new QueryArguments(
                    new QueryArgument<UnitType> { Name = "unit" }));
        }
    }
}
