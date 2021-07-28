using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.StarWars.Data
{
    [Index(nameof(Name), IsUnique = true)]
    public class Starship
    {
        /// <summary>
        /// The ID of an object
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The name of this vehicle. The common name, such as "Sand Crawler" or "Speederbike".
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;

        public string? Model { get; set; }

        public double? CostInCredits { get; set; }

        public double? Length { get; set; }

        public int? MaxAtmospheringSpeed { get; set; }

        public string? Crew { get; set; }

        public string? Passengers { get; set; }

        public double? CargoCapacity { get; set; }

        public string? Consumables { get; set; }

        public double? HyperdriveRating { get; set; }

        public int? MGLT { get; set; }

        public string? StarshipClass { get; set; }
        
        public DateTime Created { get; set; }
        
        public DateTime Edited { get; set; }

        /// <summary>
        /// The manufacturers of this starship.
        /// </summary>
        public ICollection<Manufacturer> Manufacturers { get; set; } =
            new List<Manufacturer>();

        public ICollection<Person> Pilots { get; set; } =
            new List<Person>();

        public ICollection<Film> Films { get; set; } =
            new List<Film>();
    }
}
