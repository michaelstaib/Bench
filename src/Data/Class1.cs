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

        public ICollection<Species> Species { get; set; } =
            new List<Species>();

        public ICollection<Planet> Planets { get; set; } =
            new List<Planet>();
        
        public ICollection<Starship> Starships { get; set; } =
            new List<Starship>();
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

    /// <summary>
    /// A single transport craft that does not have hyperdrive capability.
    /// </summary>
    [Index(nameof(Name), IsUnique = true)]
    public class Vehicle
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

        /// <summary>
        /// The model or official name of this vehicle. Such as "All-Terrain Attack Transport".
        /// </summary>
        public string? Model { get; set; }

        /// <summary>
        /// The cost of this vehicle new, in Galactic Credits.
        /// </summary>
        public double? CostInCredits { get; set; }

        /// <summary>
        /// The length of this vehicle in meters.
        /// </summary>
        public double? Length { get; set; }

        /// <summary>
        /// The maximum speed of this vehicle in atmosphere.
        /// </summary>
        public int? MaxAtmospheringSpeed { get; set; }

        /// <summary>
        /// The number of personnel needed to run or pilot this vehicle
        /// </summary>
        public string? Crew { get; set; }

        /// <summary>
        /// The number of non-essential people this vehicle can transport.
        /// </summary>
        public string? Passengers { get; set; }

        /// <summary>
        /// The maximum number of kilograms that this vehicle can transport.
        /// </summary>
        public double? CargoCapacity { get; set; }

        /// <summary>
        /// The maximum length of time that this vehicle can provide consumables for its
        /// entire crew without having to resupply.
        /// </summary>
        public string? Consumables { get; set; }

        /// <summary>
        /// The class of this vehicle, such as "Wheeled" or "Repulsorcraft".
        /// </summary>
        public string? VehicleClass { get; set; }

        /// <summary>
        /// The ISO 8601 date format of the time that this resource was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The ISO 8601 date format of the time that this resource was edited.
        /// </summary>
        public DateTime Edited { get; set; }

        /// <summary>
        /// The manufacturers of this vehicle.
        /// </summary>
        public ICollection<Manufacturer> Manufacturers { get; set; } =
            new List<Manufacturer>();

        public ICollection<Person> Pilots { get; set; } =
            new List<Person>();

        public ICollection<Film> Films { get; set; } =
            new List<Film>();
    }

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

        public string StarshipClass { get; set; }
        
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

    [Index(nameof(Name), IsUnique = true)]
    public class Manufacturer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;

        public ICollection<Vehicle> Vehicles { get; set; } =
            new List<Vehicle>();

        public ICollection<Starship> Starships { get; set; } =
            new List<Starship>();
    }

    [Index(nameof(Name), IsUnique = true)]
    public class Climate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;

        public ICollection<Planet> Planets { get; set; } =
            new List<Planet>();
    }

    [Index(nameof(Name), IsUnique = true)]
    public class Terrain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;

        public ICollection<Planet> Planets { get; set; } =
            new List<Planet>();
    }

    [Index(nameof(Name), IsUnique = true)]
    public class EyeColor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;

        public ICollection<Person> People { get; set; } =
            new List<Person>();

        public ICollection<Species> Species { get; set; } =
            new List<Species>();
    }

    [Index(nameof(Name), IsUnique = true)]
    public class HairColor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;

        public ICollection<Person> People { get; set; } =
            new List<Person>();

        public ICollection<Species> Species { get; set; } =
            new List<Species>();
    }

    [Index(nameof(Name), IsUnique = true)]
    public class SkinColor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = default!;

        public ICollection<Person> People { get; set; } =
            new List<Person>();

        public ICollection<Species> Species { get; set; } =
            new List<Species>();
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

        public DbSet<Planet> Planets { get; set; } = default!;

        public DbSet<Species> Species { get; set; } = default!;

        public DbSet<Vehicle> Vehicles { get; set; } = default!;

        public DbSet<Starship> Starships { get; set; } = default!;

        public DbSet<Climate> Climates { get; set; } = default!;

        public DbSet<Terrain> Terrains { get; set; } = default!;

        public DbSet<Producer> Producers { get; set; } = default!;

        public DbSet<Director> Directors { get; set; } = default!;

        public DbSet<SkinColor> SkinColors { get; set; } = default!;

        public DbSet<EyeColor> EyeColors { get; set; } = default!;

        public DbSet<HairColor> HairColors { get; set; } = default!;

        public DbSet<Manufacturer> Manufacturers { get; set; } = default!;
    }
}
