using Bench.Models;
using GraphQL.Types;

namespace Bench.GraphQLDotNet.Types
{
    public class UnitType : EnumerationGraphType<Unit>
    {
        public UnitType()
        {
            Name = "Unit";
        }
    }
}
