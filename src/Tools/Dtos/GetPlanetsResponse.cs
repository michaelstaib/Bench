using System.Collections.Generic;

namespace HotChocolate.StarWars.Data.Tools.Dtos
{
    internal class GetPlanetsResponse : IResponse<PlanetDto>
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<PlanetDto> results { get; set; }
    }
}
