using System.Collections.Generic;

namespace StarWars.Data.Tools.Dtos
{
    internal class GetPeopleResponse : IResponse<PersonDto>
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<PersonDto> results { get; set; }
    }
}
