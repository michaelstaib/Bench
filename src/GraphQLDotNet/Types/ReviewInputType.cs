using Bench.Models;
using GraphQL.Types;

namespace Bench.GraphQLDotNet.Types
{
    public class ReviewInputType : InputObjectGraphType<Review>
    {
        public ReviewInputType() {
            Field(x => x.Stars);
            Field(x => x.Commentary);
        }
    }
}
