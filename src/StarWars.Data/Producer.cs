using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.StarWars.Data
{
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
}
