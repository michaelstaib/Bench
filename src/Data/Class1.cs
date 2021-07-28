using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StarWars
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
    }

    [Index(nameof(Name), IsUnique = true)]
    public class Producer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;

        public ICollection<Film> Films { get; set; } =
            new List<Film>();
    }

    [Index(nameof(Name), IsUnique = true)]
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;
    }

    [Index(nameof(Name), IsUnique = true)]
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;

        public string? BirthYear { get; set; }

        public string? EyeColor { get; set; }

        public string? Gender { get; set; }

        public string? HairColor { get; set; }

        public int? Height { get; set; }

        public double? Mass { get; set; }

        public string? SkinColor { get; set; }

        public int? HomeworldId { get; set; }

        public Planet? Homeworld { get; set; }

        public int? SpeciesId { get; set; }

        public Species? Species { get; set; }

        public DateTime Edited { get; set; }

        public DateTime Created { get; set; }

        public ICollection<Film> Films { get; set; } =
            new List<Film>();
    }

    public class Species
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }

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

    [Index(nameof(Name), IsUnique = true)]
    public class Climate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;
    }

    [Index(nameof(Name), IsUnique = true)]
    public class Terrain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;
    }

    public class StarWarsContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=StarWars.db");
        }

        public DbSet<Film> Films { get; set; } = default!;

        public DbSet<Person> People { get; set; } = default!;

        public DbSet<Producer> Producers { get; set; } = default!;

        public DbSet<Director> Directors { get; set; } = default!;
    }
}
