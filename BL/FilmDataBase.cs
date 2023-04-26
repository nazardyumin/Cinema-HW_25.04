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

        public void AddFilm(string[] film, (int, DateTime)[] sessions)
        {
            var newFilm = _db?.CreateNewFilm(film, sessions);
            _db?.AddNewFilm(newFilm!);
            _films!.Add(newFilm!);
        }

        public List<Film>? GetFilms()
        {
            return _films;
        }
    }
}
