using System.Collections.Generic;

namespace StarWars.Data.Tools.Dtos
{
    public class GetStarshipResponse : IResponse<StarshipDto>
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<StarshipDto> results { get; set; }
    }
}
