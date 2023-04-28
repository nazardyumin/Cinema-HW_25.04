using Cinema.Model;

namespace Cinema.BL
{
    public class FilmDbSqlite : IFilmDb
    {
        readonly SqliteDbContext context;

        public FilmDbSqlite(SqliteDbContext db)
        {
            context = db;
        }

        public void AddNewFilm(Film newFilm)
        {
            newFilm.Sessions = null;
            context.Films!.Add(newFilm);
            context.SaveChanges();
        }

        public IEnumerable<Film> GetAllFilms()
        {
            return context.Films!;
        }
    }
}
