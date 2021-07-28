using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarWars;
using StarWars.Data.Tools.Dtos;

namespace HotChocolate.StarWars.Data.Tools
{
    class Program
    {
        static void Main(string[] args)
        {

            var context = new StarWarsContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var seed = new DatabaseInitialization();
            seed.SeedAsync(context).Wait();
            context.SaveChanges();


            // context.Database.EnsureCreated();





        }
    }

    public class DatabaseInitialization
    {
        private readonly Dictionary<string, (Film, FilmDto)> _films = new();
        private readonly Dictionary<string, (Person, PersonDto)> _people = new();
        private readonly Dictionary<string, (Planet, PlanetDto)> _planets = new();
        private readonly Dictionary<string, (Species, SpeciesDto)> _species = new();
        private readonly Dictionary<string, (Vehicle, VehicleDto)> _vehicles = new();
        private readonly Dictionary<string, (Starship, StarshipDto)> _starships = new();
        private readonly Dictionary<string, Producer> _producers = new();
        private readonly Dictionary<string, Director> _directors = new();
        private readonly Dictionary<string, Climate> _climates = new();
        private readonly Dictionary<string, Terrain> _terrains = new();
        private readonly Dictionary<string, EyeColor> _eyeColor = new();
        private readonly Dictionary<string, HairColor> _hairColor = new();
        private readonly Dictionary<string, SkinColor> _skinColor = new();
        private readonly Dictionary<string, Manufacturer> _manufacturers = new();

        public async Task SeedAsync(StarWarsContext context)
        {
            await LoadFilmsAsync();
            await LoadPeopleAsync();
            await LoadPlanetsAsync();
            await LoadSpeciesAsync();
            await LoadVehiclesAsync();
            await LoadStarshipsAsync();

            foreach (var film in _films.Select(t => t.Value.Item1))
            {
                context.Films.Add(film);
            }

            foreach (var people in _people.Select(t => t.Value.Item1))
            {
                context.People.Add(people);
            }

            foreach (var planet in _planets.Select(t => t.Value.Item1))
            {
                context.Planets.Add(planet);
            }

            foreach (var species in _species.Select(t => t.Value.Item1))
            {
                context.Species.Add(species);
            }

            foreach (var vehicle in _vehicles.Select(t => t.Value.Item1))
            {
                context.Vehicles.Add(vehicle);
            }

            foreach (var starship in _starships.Select(t => t.Value.Item1))
            {
                context.Starships.Add(starship);
            }
        }

        private async Task LoadFilmsAsync()
        {
            const string url = "https://swapi.dev/api/films";

            await foreach (var dto in FetchAsync<GetFilmsResponse, FilmDto>(url))
            {
                var film = new Film
                {
                    Title = dto.title,
                    EpisodeId = dto.episode_id,
                    Created = dto.created,
                    Edited = dto.edited,
                    OpeningCrawl = dto.opening_crawl,
                    ReleaseDate = DateTime.Parse(dto.release_date)
                };

                foreach (var name in dto.producer.Split(',').Select(t => t.Trim()).Distinct())
                {
                    if (!_producers.TryGetValue(name, out var producer))
                    {
                        producer = new Producer { Name = name };
                        _producers.Add(name, producer);
                    }

                    film.Producers.Add(producer);
                }

                if (!_directors.TryGetValue(dto.director, out var director))
                {
                    director = new Director { Name = dto.director };
                    _directors.Add(dto.director, director);
                }

                film.Director = director;

                _films.Add(dto.url, (film, dto));
            }
        }

        private async Task LoadPeopleAsync()
        {
            const string url = "https://swapi.dev/api/people";

            await foreach (var dto in FetchAsync<GetPeopleResponse, PersonDto>(url))
            {
                var person = new Person
                {
                    Name = dto.name,
                    Created = dto.created,
                    Edited = dto.edited,
                    Gender = dto.gender,
                    BirthYear = dto.birth_year,
                    Height = null,
                    Mass = null,
                    EyeColor = GetOrAddEyeColor(dto.eye_color),
                    HairColor = GetOrAddHairColor(dto.hair_color),
                    SkinColor = GetOrAddSkinColor(dto.skin_color)
                };

                if (dto.height is not null and not "unknown")
                {
                    person.Height = int.Parse(dto.height);
                }

                if (dto.mass is not null and not "unknown")
                {
                    person.Mass = double.Parse(dto.mass);
                }

                foreach (var id in dto.films)
                {
                    person.Films.Add(_films[id].Item1);
                }

                _people.Add(dto.url, (person, dto));
            }
        }

        private async Task LoadPlanetsAsync()
        {
            const string url = "https://swapi.dev/api/planets";

            await foreach (var dto in FetchAsync<GetPlanetsResponse, PlanetDto>(url))
            {
                var planet = new Planet
                {
                    Name = dto.name,
                    Created = dto.created,
                    Edited = dto.edited,
                    Diameter = null,
                    Gravity = dto.gravity,
                    OrbitalPeriod = null,
                    Population = null,
                    RotationPeriod = null,
                    SurfaceWater = null
                };

                if (dto.diameter is not null and not "unknown")
                {
                    planet.Diameter = int.Parse(dto.diameter);
                }

                if (dto.orbital_period is not null and not "unknown")
                {
                    planet.OrbitalPeriod = int.Parse(dto.orbital_period);
                }

                if (dto.rotation_period is not null and not "unknown")
                {
                    planet.RotationPeriod = int.Parse(dto.rotation_period);
                }

                if (dto.population is not null and not "unknown")
                {
                    planet.Population = double.Parse(dto.population);
                }

                if (dto.surface_water is not null and not "unknown")
                {
                    planet.SurfaceWater = double.Parse(dto.surface_water);
                }

                foreach (var name in dto.terrain.Split(',').Select(t => t.Trim()).Distinct())
                {
                    if (!_terrains.TryGetValue(name, out var terrains))
                    {
                        terrains = new Terrain { Name = name };
                        _terrains.Add(name, terrains);
                    }

                    planet.Terrains.Add(terrains);
                }

                foreach (var name in dto.climate.Split(',').Select(t => t.Trim()).Distinct())
                {
                    if (!_climates.TryGetValue(name, out var climate))
                    {
                        climate = new Climate { Name = name };
                        _climates.Add(name, climate);
                    }

                    planet.Climates.Add(climate);
                }

                foreach (var id in dto.films)
                {
                    planet.Films.Add(_films[id].Item1);
                }

                foreach (var id in dto.residents)
                {
                    planet.Residents.Add(_people[id].Item1);
                }

                _planets.Add(dto.url, (planet, dto));
            }
        }

        private async Task LoadSpeciesAsync()
        {
            const string url = "https://swapi.dev/api/species";

            await foreach (var dto in FetchAsync<GetSpeciesResponse, SpeciesDto>(url))
            {
                var species = new Species
                {
                    Name = dto.name,
                    Created = dto.created,
                    Edited = dto.edited,
                    AverageLifespan = null,
                    Classification = dto.classification,
                    Designation = dto.designation,
                    Language = dto.language,
                    Homeworld = dto.homeworld is null ? null : _planets[dto.homeworld].Item1
                };

                if (dto.average_lifespan is not null and not "unknown")
                {
                    species.AverageLifespan =
                        dto.average_lifespan == "indefinite"
                            ? -1
                            : int.Parse(dto.average_lifespan);
                }

                foreach (var name in dto.eye_colors.Split(',').Select(t => t.Trim()).Distinct())
                {
                    species.EyeColors.Add(GetOrAddEyeColor(name));
                }

                foreach (var name in dto.hair_colors.Split(',').Select(t => t.Trim()).Distinct())
                {
                    species.HairColors.Add(GetOrAddHairColor(name));
                }

                foreach (var name in dto.skin_colors.Split(',').Select(t => t.Trim()).Distinct())
                {
                    species.SkinColors.Add(GetOrAddSkinColor(name));
                }

                foreach (var id in dto.films)
                {
                    species.Films.Add(_films[id].Item1);
                }

                foreach (var id in dto.people)
                {
                    species.People.Add(_people[id].Item1);
                }

                _species.Add(dto.url, (species, dto));
            }
        }

        private async Task LoadVehiclesAsync()
        {
            const string url = "https://swapi.dev/api/vehicles";

            await foreach (var dto in FetchAsync<GetVehiclesResponse, VehicleDto>(url))
            {
                var vehicle = new Vehicle
                {
                    Name = dto.name,
                    Created = dto.created,
                    Edited = dto.edited,
                    CargoCapacity = null,
                    Consumables = dto.consumables,
                    CostInCredits = null,
                    Crew = dto.crew,
                    Length = null,
                    MaxAtmospheringSpeed = null,
                    Passengers = dto.passengers,
                    Model = dto.model,
                    VehicleClass = dto.vehicle_class,
                };

                if (dto.cargo_capacity is not null and not "unknown")
                {
                    vehicle.CargoCapacity = 
                        dto.cargo_capacity == "none" 
                            ? 0 
                            : double.Parse(dto.cargo_capacity);
                }

                if (dto.cost_in_credits is not null and not "unknown")
                {
                    vehicle.CostInCredits = double.Parse(dto.cost_in_credits);
                }

                if (dto.length is not null and not "unknown")
                {
                    vehicle.Length = double.Parse(dto.length);
                }

                if (dto.max_atmosphering_speed is not null and not "unknown")
                {
                    vehicle.MaxAtmospheringSpeed = int.Parse(dto.max_atmosphering_speed);
                }

                foreach (var name in dto.manufacturer.Split(',').Select(t => t.Trim()).Distinct())
                {
                    vehicle.Manufacturers.Add(GetOrAddManufacturer(name));
                }

                foreach (var id in dto.films)
                {
                    vehicle.Films.Add(_films[id].Item1);
                }

                foreach (var id in dto.pilots)
                {
                    vehicle.Pilots.Add(_people[id].Item1);
                }

                _vehicles.Add(dto.url, (vehicle, dto));
            }
        }

         private async Task LoadStarshipsAsync()
        {
            const string url = "https://swapi.dev/api/starships";

            await foreach (var dto in FetchAsync<GetStarshipResponse, StarshipDto>(url))
            {
                var starship = new Starship
                {
                    Name = dto.name,
                    Created = dto.created,
                    Edited = dto.edited,
                    CargoCapacity = null,
                    Consumables = dto.consumables,
                    CostInCredits = null,
                    Crew = dto.crew,
                    Length = null,
                    MaxAtmospheringSpeed = null,
                    Passengers = dto.passengers,
                    Model = dto.model,
                    StarshipClass = dto.starship_class,
                    HyperdriveRating = null,
                    MGLT = null
                };

                if (dto.cargo_capacity is not null and not "unknown")
                {
                    starship.CargoCapacity = 
                        dto.cargo_capacity == "none" 
                            ? 0 
                            : double.Parse(dto.cargo_capacity);
                }

                if (dto.cost_in_credits is not null and not "unknown")
                {
                    starship.CostInCredits = double.Parse(dto.cost_in_credits);
                }

                if (dto.length is not null and not "unknown")
                {
                    starship.Length = double.Parse(dto.length);
                }

                if (dto.max_atmosphering_speed is not null and not "unknown" and not "n/a")
                {
                    starship.MaxAtmospheringSpeed = int.Parse(dto.max_atmosphering_speed.Trim('m', 'k'));
                }

                if (dto.hyperdrive_rating is not null and not "unknown")
                {
                    starship.HyperdriveRating = double.Parse(dto.hyperdrive_rating);
                }

                if (dto.MGLT is not null and not "unknown")
                {
                    starship.MGLT = int.Parse(dto.MGLT);
                }

                foreach (var name in dto.manufacturer.Split(',').Select(t => t.Trim()).Distinct())
                {
                    starship.Manufacturers.Add(GetOrAddManufacturer(name));
                }

                foreach (var id in dto.films)
                {
                    starship.Films.Add(_films[id].Item1);
                }

                foreach (var id in dto.pilots)
                {
                    starship.Pilots.Add(_people[id].Item1);
                }

                _starships.Add(dto.url, (starship, dto));
            }
        }

        private async IAsyncEnumerable<TDto> FetchAsync<TResponse, TDto>(string url)
            where TResponse : IResponse<TDto>
        {
            using var client = new HttpClient();
            var next = url;

            do
            {
                using var result = await client.GetAsync(next);
                result.EnsureSuccessStatusCode();

                var response = await result.Content.ReadFromJsonAsync<TResponse>();

                foreach (var dto in response.results)
                {
                    yield return dto;
                }

                next = response.next;
            } while (next is not null);
        }

        private EyeColor GetOrAddEyeColor(string s)
        {
            if (!_eyeColor.TryGetValue(s, out var eyeColor))
            {
                eyeColor = new EyeColor { Name = FormatEnumString(s) };
                _eyeColor.Add(s, eyeColor);
            }
            return eyeColor;
        }

        private HairColor GetOrAddHairColor(string s)
        {
            if (!_hairColor.TryGetValue(s, out var hairColor))
            {
                hairColor = new HairColor { Name = FormatEnumString(s) };
                _hairColor.Add(s, hairColor);
            }
            return hairColor;
        }

        private SkinColor GetOrAddSkinColor(string s)
        {
            if (!_skinColor.TryGetValue(s, out var skinColor))
            {
                skinColor = new SkinColor { Name = FormatEnumString(s) };
                _skinColor.Add(s, skinColor);
            }
            return skinColor;
        }

        private Manufacturer GetOrAddManufacturer(string s)
        {
            if (!_manufacturers.TryGetValue(s, out var manufacturer))
            {
                manufacturer = new Manufacturer { Name = s };
                _manufacturers.Add(s, manufacturer);
            }
            return manufacturer;
        }

        private static string FormatEnumString(string s)
        {
            if (s == "n/a")
            {
                return "n/a";
            }

            s = string.Join("And", s.Split(",").Select(n => n.Trim()).Select(n => char.ToUpper(n[0]) + n.Substring(1)));
            return string.Join("", s.Split("-").Select(n => char.ToUpper(n[0]) + n.Substring(1)));
        }
    }
}
