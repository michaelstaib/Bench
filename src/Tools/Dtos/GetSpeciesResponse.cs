using System.Collections.Generic;

namespace HotChocolate.StarWars.Data.Tools.Dtos
{
    internal class GetSpeciesResponse : IResponse<SpeciesDto>
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<SpeciesDto> results { get; set; }
    }
}
