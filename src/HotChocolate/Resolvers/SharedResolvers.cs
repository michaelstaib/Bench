using System.Collections.Generic;
using HotChocolate;
using Bench.Data;
using Bench.Models;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Text;
using System;

namespace Bench.HotChocolate.Resolvers
{
    public class SharedResolvers
    {
        private readonly MD5 _md5 = MD5.Create();

        public IEnumerable<ICharacter> GetCharacter(
            [Parent] ICharacter character,
            [Service] CharacterRepository repository)
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

        public double GetHeight(Unit? unit, [Parent] ICharacter character)
            => ConvertToUnit(character.Height, unit);

        public double GetLength(Unit? unit, [Parent] Starship starship)
            => ConvertToUnit(starship.Length, unit);

        private double ConvertToUnit(double length, Unit? unit)
        {
            if (unit == Unit.Foot)
            {
                return length * 3.28084d;
            }
            return length;
        }

        public Task<string> GetNameHashAsync([Parent] Human human) =>
            Task.Run(() =>
            {
                byte[] buffer = Encoding.UTF8.GetBytes(human.Name);
                buffer = _md5.ComputeHash(buffer);
                return Convert.ToBase64String(buffer);
            });

        public async Task<string> GetNameDelayedAsync([Parent] Human human)
        {
            await Task.Delay(50);
            return human.Name;
        }
    }
}
