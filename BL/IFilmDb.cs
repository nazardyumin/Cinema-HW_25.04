using Cinema.Model;

namespace Cinema.BL
{
    public interface IFilmDb
    {
        public void AddNewFilm(Film newFilm);
        public Task<Film?> CreateNewFilmAsync(string imdbId, Session[] sessions);
        public IEnumerable<Film> GetAllFilms();
    }
}
