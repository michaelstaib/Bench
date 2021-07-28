using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.StarWars.Data
{
    [Index(nameof(Title), IsUnique = true)]
    [Index(nameof(EpisodeId), IsUnique = true)]
    public class Film
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = default!;

        public int EpisodeId { get; set; }

        [Required]
        [StringLength(4000)]
        public string OpeningCrawl { get; set; } = default!;

        public int DirectorId { get; set; }

        public Director Director { get; set; } = default!;

        public DateTime ReleaseDate { get; set; }

        public DateTime Edited { get; set; }

        public DateTime Created { get; set; }

        public ICollection<Producer> Producers { get; set; } =
            new List<Producer>();

        public ICollection<Person> People { get; set; } =
            new List<Person>();

        public ICollection<Species> Species { get; set; } =
            new List<Species>();

        public ICollection<Planet> Planets { get; set; } =
            new List<Planet>();
        
        public ICollection<Starship> Starships { get; set; } =
            new List<Starship>();
    }
}
