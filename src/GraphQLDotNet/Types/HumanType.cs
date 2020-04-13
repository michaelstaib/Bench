using System.Collections.Generic;
using Bench.Data;
using Bench.HotChocolate.Resolvers;
using Bench.Models;
using GraphQL.Types;

namespace Bench.GraphQLDotNet.Types
{
    public class HumanType : ObjectGraphType<Human>
    {
        public HumanType(CharacterRepository repository)
        {
            Name = "Human";
            
            Interface<CharacterType>();

            Field(t => t.Id).Type(new NonNullGraphType<IdGraphType>());
            Field(t => t.Name, nullable: true);
            Field<ListGraphType<CharacterType>, IEnumerable<ICharacter>>(
                "friends", : context => SharedResolvers.GetCharacter(context.Source, repository));
            Field(t => t.Id).Type(new NonNullGraphType<IdGraphType>());
        }

        protected override void Configure(IObjectTypeDescriptor<Human> descriptor)
        {
            descriptor.Interface<CharacterType>();

            descriptor.Field(t => t.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.AppearsIn)
                .Type<ListType<EpisodeType>>();

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
