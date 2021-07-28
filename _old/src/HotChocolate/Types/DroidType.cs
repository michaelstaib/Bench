using Bench.HotChocolate.Resolvers;
using HotChocolate.Types;
using Bench.Models;

namespace Bench.HotChocolate.Types
{
    public class DroidType : ObjectType<Droid>
    {
        protected override void Configure(IObjectTypeDescriptor<Droid> descriptor)
        {
            descriptor.Implements<CharacterType>();
            descriptor.Field(t => t.Id).Type<NonNullType<IdType>>();
            descriptor.Field(t => t.AppearsIn).Type<ListType<EpisodeType>>();
            descriptor.Field<SharedResolvers>(r => r.GetCharacter(default, default)).Type<ListType<CharacterType>>().Name("friends");
            descriptor.Field<SharedResolvers>(t => t.GetHeight(default, default)).Type<FloatType>().Argument("unit", a => a.Type<UnitType>()).Name("height");
        }
    }
}
