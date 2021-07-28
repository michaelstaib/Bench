using HotChocolate.Types;
using Bench.Models;

namespace Bench.HotChocolate.Types
{
    public class EpisodeType : EnumType<Episode>
    {
        protected override void Configure(IEnumTypeDescriptor<Episode> descriptor)
        {
            descriptor.Value(Episode.NewHope).Name("NEW_HOPE");
        }
    }
}
