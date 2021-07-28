using System.Collections.Generic;

namespace StarWars.Data.Tools.Dtos
{
    internal class GetFilmsResponse : IResponse<FilmDto>
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<FilmDto> results { get; set; } = default!;
    }
}
