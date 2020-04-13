using HotChocolate.Types;
using Bench.Models;
using GraphQL.Types;

namespace Bench.GraphQLDotNet.Types
{
    public class ReviewType : ObjectGraphType<Review>
    {
        public ReviewType()
        {
            Field(x => x.Stars);
            Field(x => x.Commentary);
        }
    }
}
