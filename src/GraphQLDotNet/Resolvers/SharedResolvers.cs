using System.Collections.Generic;
using HotChocolate;
using Bench.Data;
using Bench.Models;

namespace Bench.GraphQLDotNet.Types
{
    public static class SharedResolvers
    {
        public static IEnumerable<ICharacter> GetCharacter(
            ICharacter character,
            CharacterRepository repository)
        {
            foreach (string friendId in character.Friends)
            {
                ICharacter friend = repository.GetCharacter(friendId);
                if (friend != null)
                {
                    yield return friend;
                }
            }
        }

        public static double GetHeight(Unit? unit, [Parent]ICharacter character)
            => ConvertToUnit(character.Height, unit);

        public static double GetLength(Unit? unit, [Parent]Starship starship)
            => ConvertToUnit(starship.Length, unit);

        private static double ConvertToUnit(double length, Unit? unit)
        {
            if (unit == Unit.Foot)
            {
                return length * 3.28084d;
            }
            return length;
        }
    }
}
