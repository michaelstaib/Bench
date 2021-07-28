using Microsoft.EntityFrameworkCore;

namespace HotChocolate.StarWars.Data
{
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
