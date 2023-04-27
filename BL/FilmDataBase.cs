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
            var newFilm = await _db?.CreateNewFilmAsync(imdbId, sessions)!;
            if (newFilm is not null) 
            {
                _db?.AddNewFilm(newFilm);
                _films!.Add(newFilm);
            }    
        }

        public List<Film>? GetFilms()
        {
            return _films;
        }
    }
}
