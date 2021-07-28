using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using HotChocolate.StarWars.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.StarWars
{
    [ExtendObjectType()]
    public class PeopleQueries
    {
        [UsePaging] // => PeopleConnection
        // [UsePaging(ConnectionName = "BarConnection")]
        public IQueryable<Person> GetPeople(StarWarsContext context)
            => context.People;

        [NodeResolver]
        public async Task<Person> GetPersonByIdAsync(
            int id,
            StarWarsContext context,
            CancellationToken cancellationToken)
            => await context.People.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}
