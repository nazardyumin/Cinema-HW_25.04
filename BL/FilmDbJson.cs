using Cinema.Model;
using System.Text.Json;

namespace Cinema.BL
{
    public class FilmDbJson : IFilmDb
    {
        public void AddNewFilm(Film newFilm)
        {
            var oldDb = GetAllFilms();
            var newDb = oldDb.Append(newFilm);
            var file = JsonSerializer.Serialize(newDb);
            File.WriteAllText("films.json", file);
        }

        public IEnumerable<Film> GetAllFilms()
        {
            var file = File.ReadAllText("films.json");
            return JsonSerializer.Deserialize<IEnumerable<Film>>(file)!;
        }
    }
}
