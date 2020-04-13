using System;
using System.Collections.Generic;
using Bench.Data;
using Bench.Models;
using HotChocolate.Resolvers;
using Microsoft.Extensions.DependencyInjection;

namespace Bench.GraphQLDotNet
{
    public class Query
    {
        private readonly CharacterRepository _repository;

        public Query(CharacterRepository repository)
        {
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        public ICharacter GetHero(Episode episode)
        {
            return _repository.GetHero(episode);
        }

        public Human GetHuman(string id)
        {
            return _repository.GetHuman(id);
        }

        public Droid GetDroid(string id)
        {
            return _repository.GetDroid(id);
        }

        public IEnumerable<ICharacter> GetCharacter(string[] characterIds)
        {
            foreach (string characterId in characterIds)
            {
                ICharacter character = _repository.GetCharacter(characterId);
                if (character == null)
                {
                    throw new Exception("Not found");
                }
                else
                {
                    yield return character;
                }
            }
        }
    }
}
