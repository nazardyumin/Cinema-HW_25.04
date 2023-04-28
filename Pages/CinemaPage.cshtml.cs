using Cinema.BL;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.Pages
{
    public class CinemaPageModel : PageModel
    {
        public FilmDataBase? Db { get; set; }

        public CinemaPageModel(SqliteDbContext db)
        {
            //Db = new(new FilmDbJson());
            Db = new(new FilmDbSqlite(db));
        }
    }
}
