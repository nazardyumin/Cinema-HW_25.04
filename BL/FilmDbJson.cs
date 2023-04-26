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

        public Film CreateNewFilm(string[] film, (int, DateTime)[] sessions)
        {
            var newFilm = new Film()
            {
                Title = film[0],
                Director = film[1],
                Genre = film[2],
                Description = film[3],
                Sessions = new Session[sessions.Length]
            };

            for (var i = 0; i < sessions.Length; i++)
            {
                newFilm.Sessions[i] = new Session() { Hall = sessions[i].Item1, Time = sessions[i].Item2 };
            }

            return newFilm;
        }

        public IEnumerable<Film> GetAllFilms()
        {
            var file = File.ReadAllText("films.json");
            return JsonSerializer.Deserialize<IEnumerable<Film>>(file)!;
        }
    }
}
