using Cinema.Model;

namespace Cinema.BL
{
    public interface IFilmDb
    {
        public void AddNewFilm(Film newFilm);
        public IEnumerable<Film> GetAllFilms();
    }
}
