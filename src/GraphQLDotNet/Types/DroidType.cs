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
            Field(x => x.Id)
            Field(x => x.AppearsIn);
            Field<IEnumerable<ICharacter>>("friends", context => SharedResolvers.GetCharacter(context, repository));
            Field<>("height",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                ),)
        }
    }
    public class DroidType : ObjectType<Droid>
    {
        protected override void Configure(IObjectTypeDescriptor<Droid> descriptor)
        {
            descriptor.Interface<CharacterType>();
            descriptor.Field(t => t.Id).Type<NonNullType<IdType>>();
            descriptor.Field(t => t.AppearsIn).Type<ListType<EpisodeType>>();
            descriptor.Field<SharedResolvers>(r => r.GetCharacter(default, default))
                .Type<ListType<CharacterType>>()
                .Name("friends");
            descriptor.Field<SharedResolvers>(t => t.GetHeight(default, default))
                .Type<FloatType>()
                .Argument("unit", a => a.Type<UnitType>())
                .Name("height");
        }
    }
}
