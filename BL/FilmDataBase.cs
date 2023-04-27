using Cinema.Model;

namespace Cinema.BL
{
    public class FilmDataBase
    {
        private readonly IFilmDb? _db;
        private List<Film>? _films { get; set; }

        public FilmDataBase(IFilmDb db)
        {
            _db = db;
            _films = new List<Film>(_db.GetAllFilms());
        }

        public async Task AddFilm(string imdbId, Session[] sessions)
        {
            var newFilm = await CreateNewFilmAsync(imdbId, sessions)!;
            if (newFilm is not null)
            {
                _db?.AddNewFilm(newFilm);
                _films!.Add(newFilm);
            }
        }

        private async Task<Film?> CreateNewFilmAsync(string imdbId, Session[] sessions)
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

        public List<Film>? GetFilms()
        {
            return _films;
        }
    }
}
