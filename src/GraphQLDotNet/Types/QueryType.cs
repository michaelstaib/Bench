using Bench.Models;
using GraphQL.Types;

namespace Bench.GraphQLDotNet.Types
{
    public class QueryType : ObjectGraphType<Query>
    {
        public QueryType()
        {
            Name = "Query";

            Field<CharacterType>()
                .Name("hero")
                .Argument<EpisodeType>("episode", "")
                .Resolve(context => context.Source.GetHero(context.GetArgument<Episode>("episode")));

            Field<CharacterType>()
                .Name("character")
                .Argument<NonNullGraphType<ListGraphType<NonNullGraphType<IdGraphType>>>>("characterIds", "")
                .Resolve(context => context.Source.GetCharacter(context.GetArgument<string[]>("characterIds")));

            Field<HumanType>()
                .Name("human")
                .Argument<NonNullGraphType<IdGraphType>>("id", "")
                .Resolve(context => context.Source.GetHuman(context.GetArgument<string>("id")));

            Field<DroidType>()
                .Name("human")
                .Argument<NonNullGraphType<IdGraphType>>("id", "")
                .Resolve(context => context.Source.GetDroid(context.GetArgument<string>("id")));
        }
    }
}
