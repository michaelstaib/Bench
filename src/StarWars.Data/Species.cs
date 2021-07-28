using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.StarWars.Data
{
    [Index(nameof(Name), IsUnique = true)]
    public class Species
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;

        public string? Classification { get; set; }

        public string? Designation { get; set; }

        public int? AverageLifespan { get; set; }

        public int? HomeworldId { get; set; }

        public Planet? Homeworld { get; set; }

        public string? Language { get; set; }

        public DateTime Created { get; set; }

        public DateTime Edited { get; set; }

        public ICollection<SkinColor> SkinColors { get; set; } =
            new List<SkinColor>();

        public ICollection<HairColor> HairColors { get; set; } =
            new List<HairColor>();

        public ICollection<EyeColor> EyeColors { get; set; } =
            new List<EyeColor>();

        public ICollection<Film> Films { get; set; } =
            new List<Film>();

        public ICollection<Person> People { get; set; } =
            new List<Person>();

    }
}
