using Bench.Models;
using GraphQL.Types;

namespace Bench.GraphQLDotNet.Types
{
    public class EpisodeType : EnumerationGraphType<Episode>
    {
        public EpisodeType()
        {
            Name = "Episode";
        }
    }
}
