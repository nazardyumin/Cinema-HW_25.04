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

        public async Task<Film?> CreateNewFilmAsync(string imdbId, Session[] sessions)
        {
            var filmInfo = await FilmApi.GetInfoById(imdbId);

            if (filmInfo is not null)
            {
                var newFilm = new Film()
                {
                    ImdbId = imdbId,
                    Poster = filmInfo.Poster,
                    Title = filmInfo.Title,
                    Director = filmInfo.Director,
                    Genre = filmInfo.Genre,
                    Description = filmInfo.Plot,
                    Sessions = sessions
                };

                return newFilm;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Film> GetAllFilms()
        {
            var file = File.ReadAllText("films.json");
            return JsonSerializer.Deserialize<IEnumerable<Film>>(file)!;
        }
    }
}
