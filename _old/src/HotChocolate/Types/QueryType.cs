﻿using HotChocolate.Types;
using Bench.Models;

namespace Bench.HotChocolate.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetHero(default))
                .Type<CharacterType>()
                .Argument("episode", a => a.DefaultValue(Episode.NewHope));
            descriptor.Field(t => t.GetCharacter(default, default))
                .Type<NonNullType<ListType<NonNullType<CharacterType>>>>()
                .Argument("characterIds", a => a.Type<NonNullType<ListType<NonNullType<IdType>>>>());
            descriptor.Field(t => t.GetHuman(default))
                .Argument("id", a => a.Type<NonNullType<IdType>>());
            descriptor.Field(t => t.GetDroid(default))
                .Argument("id", a => a.Type<NonNullType<IdType>>());
        }
    }

}
