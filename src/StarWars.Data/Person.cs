using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.StarWars.Data
{
    [Index(nameof(Name), IsUnique = true)]
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;

        [StringLength(12)]
        public string? BirthYear { get; set; }

        public int? EyeColorId { get; set; }

        public EyeColor? EyeColor { get; set; }

        public string? Gender { get; set; }

        public int? HairColorId { get; set; }

        public HairColor? HairColor { get; set; }

        public int? Height { get; set; }

        public double? Mass { get; set; }

        public int? SkinColorId { get; set; }

        public SkinColor? SkinColor { get; set; }

        public int? HomeworldId { get; set; }

        public Planet? Homeworld { get; set; }

        public int? SpeciesId { get; set; }

        public Species? Species { get; set; }

        public DateTime Edited { get; set; }

        public DateTime Created { get; set; }

        public ICollection<Film> Films { get; set; } =
            new List<Film>();

        public ICollection<Vehicle> Vehicles { get; set; } =
            new List<Vehicle>();

        public ICollection<Starship> Starships { get; set; } =
            new List<Starship>();
    }
}
