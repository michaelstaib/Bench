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

namespace Tools
{
    class Program
    {
        static void Main(string[] args)
        {

            var context = new StarWarsContext();


            var seed = new DatabaseInitialization();
            seed.SeedAsync(context).Wait();


            context.Database.EnsureCreated();





        }
    }

    public class DatabaseInitialization
    {
        private readonly Dictionary<string, (Film, FilmDto)> _films = new();
        private readonly Dictionary<string, (Person, PersonDto)> _people = new();
        private readonly Dictionary<string, (Planet, PlanetDto)> _planets = new();
        private readonly Dictionary<string, Producer> _producers = new();
        private readonly Dictionary<string, Director> _directors = new();
        private readonly Dictionary<string, Climate> _climates = new();
        private readonly Dictionary<string, Terrain> _terrains = new();

        public async Task SeedAsync(StarWarsContext context)
        {
            await LoadFilmsAsync();
            await LoadPeopleAsync();
        }

        private async Task LoadFilmsAsync()
        {
            using var client = new HttpClient { BaseAddress = new Uri("https://swapi.dev/api/films") };
            using var result = await client.GetAsync(string.Empty);
            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadFromJsonAsync<GetFilmsResponse>();

            foreach (var filmDto in response!.results)
            {
                var film = new Film
                {
                    Title = filmDto.title,
                    EpisodeId = filmDto.episode_id,
                    Created = filmDto.created,
                    Edited = filmDto.edited,
                    OpeningCrawl = filmDto.opening_crawl,
                    ReleaseDate = DateTime.Parse(filmDto.release_date)
                };

                foreach (var name in filmDto.producer.Split(',').Select(t => t.Trim()).Distinct())
                {
                    if (!_producers.TryGetValue(name, out var producer))
                    {
                        producer = new Producer { Name = name };
                        _producers.Add(name, producer);
                    }

                    film.Producers.Add(producer);
                }

                if (!_directors.TryGetValue(filmDto.director, out var director))
                {
                    director = new Director { Name = filmDto.director };
                    _directors.Add(filmDto.director, director);
                }

                film.Director = director;

                _films.Add(filmDto.url, (film, filmDto));
            }
        }

        private async Task LoadPeopleAsync()
        {
            using var client = new HttpClient();
            var next = "https://swapi.dev/api/people";

            do
            {
                using var result = await client.GetAsync(next);
                result.EnsureSuccessStatusCode();

                var response = await result.Content.ReadFromJsonAsync<GetPeopleResponse>();

                foreach (var dto in response!.results)
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
                        EyeColor = dto.eye_color,
                        HairColor = dto.hair_color,
                        SkinColor = dto.skin_color,
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

                next = response.next;
            } while (next is not null);
        }

        private async Task LoadPlanetsAsync()
        {
            using var client = new HttpClient();
            var next = "https://swapi.dev/api/planets";

            do
            {
                using var result = await client.GetAsync(next);
                result.EnsureSuccessStatusCode();

                var response = await result.Content.ReadFromJsonAsync<GetPlanetsResponse>();

                foreach (var dto in response!.results)
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

                next = response.next;
            } while (next is not null);
        }
    }

    public class FilmDto
    {
        public string title { get; set; }
        public int episode_id { get; set; }
        public string opening_crawl { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public string release_date { get; set; }
        public List<string> characters { get; set; }
        public List<string> planets { get; set; }
        public List<string> starships { get; set; }
        public List<string> vehicles { get; set; }
        public List<string> species { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }

    public class GetFilmsResponse
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<FilmDto> results { get; set; } = default!;
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class PersonDto
    {
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
        public List<string> films { get; set; }
        public List<string> species { get; set; }
        public List<string> vehicles { get; set; }
        public List<string> starships { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }

    public class GetPeopleResponse
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<PersonDto> results { get; set; }
    }

    public class PlanetDto
    {
        public string name { get; set; }
        public string rotation_period { get; set; }
        public string orbital_period { get; set; }
        public string diameter { get; set; }
        public string climate { get; set; }
        public string gravity { get; set; }
        public string terrain { get; set; }
        public string surface_water { get; set; }
        public string population { get; set; }
        public List<string> residents { get; set; }
        public List<string> films { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }

    public class GetPlanetsResponse
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<PlanetDto> results { get; set; }
    }






}
