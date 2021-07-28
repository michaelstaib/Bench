using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.StarWars.Data
{
    [Index(nameof(Name), IsUnique = true)]
    public class Planet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;
        public int? RotationPeriod { get; set; }
        public int? OrbitalPeriod { get; set; }
        public int? Diameter { get; set; }
        public string? Gravity { get; set; }
        public double? SurfaceWater { get; set; }
        public double? Population { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }

        public ICollection<Climate> Climates { get; set; } =
            new List<Climate>();

        public ICollection<Terrain> Terrains { get; set; } =
            new List<Terrain>();

        public ICollection<Person> Residents { get; set; } =
            new List<Person>();

        public ICollection<Film> Films { get; set; } =
            new List<Film>();
    }
}
