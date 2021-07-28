using System.Collections.Generic;

namespace HotChocolate.StarWars.Data.Tools.Dtos
{
    internal interface IResponse<T>
    {
        List<T> results { get; set; }

        string next { get; set; }
    }
}
