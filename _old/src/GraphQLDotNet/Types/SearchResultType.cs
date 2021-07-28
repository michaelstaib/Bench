using GraphQL.Types;

namespace Bench.GraphQLDotNet.Types
{
    public class SearchResultType : UnionGraphType
    {
        public SearchResultType()
        {
            Type<StarshipType>();
            Type<HumanType>();
            Type<DroidType>();
        }
    }
}
