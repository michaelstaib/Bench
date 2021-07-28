using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.StarWars.Data
{
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
}
