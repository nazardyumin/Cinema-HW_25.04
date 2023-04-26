using Cinema.Model;

namespace Cinema.BL
{
    public interface IFilmDb
    {
        public void AddNewFilm(Film newFilm);
        public Film CreateNewFilm(string[] film, (int, DateTime)[] sessions);
        public IEnumerable<Film> GetAllFilms();     
    }
}
