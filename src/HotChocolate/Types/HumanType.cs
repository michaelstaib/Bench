using System.Threading.Tasks;
using Bench.HotChocolate.Resolvers;
using Bench.Models;
using HotChocolate.Types;

namespace Bench.HotChocolate.Types
{
    public class HumanType : ObjectType<Human>
    {
        protected override void Configure(IObjectTypeDescriptor<Human> descriptor)
        {
            descriptor.Interface<CharacterType>();

            descriptor.Field(t => t.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.AppearsIn)
                .Type<ListType<EpisodeType>>();

            descriptor.Field<SharedResolvers>(t => t.GetCharacter(default, default))
                .Type<ListType<CharacterType>>()
                .Name("friends");

            descriptor.Field<SharedResolvers>(t => t.GetHeight(default, default))
                .Type<FloatType>()
                .Argument("unit", a => a.Type<UnitType>())
                .Name("height");

            descriptor.Field<SharedResolvers>(t => t.GetNameHashAsync(default))
                .Name("nameHash");

            descriptor.Field<SharedResolvers>(t => t.GetNameDelayedAsync(default))
                .Name("nameDelayed");
        }
    }
}
