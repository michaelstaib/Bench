using Bench.Data;
using Bench.Models;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;

namespace Bench.GraphQLDotNet.Types
{
    public class QueryType : ObjectGraphType
    {
        private readonly CharacterRepository _repository;

        public QueryType(CharacterRepository repository)
        {
            Name = "Query";
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));

            Field<CharacterType>()
                .Name("hero")
                .Argument<EpisodeType>("episode", "")
                .Resolve(context => _repository.GetHero(context.GetArgument<Episode>("episode")));

            Field<CharacterType>()
                .Name("character")
                .Argument<NonNullGraphType<ListGraphType<NonNullGraphType<IdGraphType>>>>("characterIds", "")
                .Resolve(context => GetCharacter(context.GetArgument<string[]>("characterIds")));

            Field<HumanType>()
                .Name("human")
                .Argument<NonNullGraphType<IdGraphType>>("id", "")
                .Resolve(context => _repository.GetHuman(context.GetArgument<string>("id")));

            Field<DroidType>()
                .Name("droid")
                .Argument<NonNullGraphType<IdGraphType>>("id", "")
                .Resolve(context => _repository.GetDroid(context.GetArgument<string>("id")));
        }

        public IEnumerable<ICharacter> GetCharacter(string[] characterIds)
        {
            foreach (string characterId in characterIds)
            {
                ICharacter character = _repository.GetCharacter(characterId);
                if (character == null)
                {
                    throw new Exception(
                        "Could not resolve a character for the " +
                        $"character-id {characterId}.");
                }
                else
                {
                    yield return character;
                }
            }
        }
    }
}
