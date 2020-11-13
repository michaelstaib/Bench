using System.Collections.Generic;
using HotChocolate;
using Bench.Data;
using Bench.Models;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Bench.GraphQLDotNet.Types
{
    public static class SharedResolvers
    {
        private static readonly MD5 _md5 = MD5.Create();
        
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

        public static double GetHeight(Unit? unit, ICharacter character)
            => ConvertToUnit(character.Height, unit);

        public static double GetLength(Unit? unit, Starship starship)
            => ConvertToUnit(starship.Length, unit);

        private static double ConvertToUnit(double length, Unit? unit)
        {
            if (unit == Unit.Foot)
            {
                return length * 3.28084d;
            }
            return length;
        }

        public static Task<string> GetNameHashAsync([Parent] Human human) =>
            Task.Run(() =>
            {
                byte[] buffer = Encoding.UTF8.GetBytes(human.Name);
                buffer = _md5.ComputeHash(buffer);
                return Convert.ToBase64String(buffer);
            });

        public static async Task<string> GetNameDelayedAsync([Parent] Human human)
        {
            await Task.Delay(50);
            return human.Name;
        }
    }
}
