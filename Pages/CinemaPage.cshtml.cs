using Cinema.BL;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.Pages
{
    public class CinemaPageModel : PageModel
    {
        public FilmDataBase? Db { get; set; }

        public CinemaPageModel()
        {
            Db = new(new FilmDbJson());
            //CreateCoupleOfFilmsForTestingAsync();
        }

        //public async Task CreateCoupleOfFilmsForTestingAsync()
        //{
        //    if (Db is not null) 
        //    {
        //        await Db.AddFilm("tt0088247", new Session[] { new Session(1, 13), new Session(4, 18), new Session(2, 23) });
        //        await Db.AddFilm("tt15326988", new Session[] { new Session(3, 11), new Session(8, 14), new Session(1, 20), new Session(2, 23) });
        //        await Db.AddFilm("tt10366206", new Session[] { new Session(4, 14), new Session(5, 16), new Session(9, 19) });
        //    }
        //}
    }
}
