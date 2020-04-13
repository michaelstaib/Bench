using System.Collections.Generic;
using Bench.Data;
using Bench.HotChocolate.Resolvers;
using Bench.Models;
using GraphQL.Types;

namespace Bench.GraphQLDotNet.Types
{
    public class DroidType : ObjectGraphType<Droid>
    {
        public DroidType(CharacterRepository repository)
        {
            Name = "Droid";
            Field(x => x.Id);
            Field(x => x.AppearsIn);
            
        }
    }
}
