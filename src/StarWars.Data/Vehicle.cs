using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.StarWars.Data
{
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
}
