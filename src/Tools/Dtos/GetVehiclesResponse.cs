using System.Collections.Generic;

namespace HotChocolate.StarWars.Data.Tools.Dtos
{
    internal class GetVehiclesResponse : IResponse<VehicleDto>
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<VehicleDto> results { get; set; }
    }
}
