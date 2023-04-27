using Cinema.BL;
using Cinema.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.Pages
{
    public class AdminPageModel : PageModel
    {
        //[BindProperty]
        //public string? ImdbId { get ; set; }

        //[BindProperty]
        //public int Hall { get; set; }

        //[BindProperty]
        //public int Year { get; set; }

        //[BindProperty]
        //public int Month { get; set; }

        //[BindProperty]
        //public int Day { get; set; }

        //[BindProperty]
        //public int Hour { get; set; }

        //[BindProperty]
        //public int Minute { get; set; }
        public FilmDataBase? Db { get; set; }

        public AdminPageModel()
        {
            Db = new(new FilmDbJson());
        }

        public async Task OnGet()
        {
            if (!string.IsNullOrEmpty(Request.Query["id"]))
            {
                var id = Request.Query["id"];
                var count = Request.Query["hall"].Count;
                List<Session> sessions = new();

                for (var i = 0; i < count; i++)
                {
                    var correctYear = !string.IsNullOrEmpty(Request.Query["year"][i]);
                    var correctMonth = !string.IsNullOrEmpty(Request.Query["month"][i]);
                    var correctDay = !string.IsNullOrEmpty(Request.Query["day"][i]);
                    var correctMinute = !string.IsNullOrEmpty(Request.Query["minute"][i]);

                    if (correctYear && correctMonth && correctDay && correctMinute)
                    {
                        sessions.Add(new Session(
                            int.Parse(Request.Query["hall"][i]),
                            int.Parse(Request.Query["year"][i]),
                            int.Parse(Request.Query["month"][i]),
                            int.Parse(Request.Query["day"][i]),
                            int.Parse(Request.Query["hour"][i]),
                            int.Parse(Request.Query["minute"][i])));
                    }
                    else if (correctYear && correctMonth && correctDay && !correctMinute)
                    {
                        sessions.Add(new Session(
                            int.Parse(Request.Query["hall"][i]),
                            int.Parse(Request.Query["year"][i]),
                            int.Parse(Request.Query["month"][i]),
                            int.Parse(Request.Query["day"][i]),
                            int.Parse(Request.Query["hour"][i])));
                    }
                    else if (!correctMinute && !correctYear)
                    {
                        sessions.Add(new Session(
                        int.Parse(Request.Query["hall"][i]),
                        int.Parse(Request.Query["hour"][i]))
                        );
                    }
                    else
                    {
                        sessions.Add(new Session(
                            int.Parse(Request.Query["hall"][i]),
                            int.Parse(Request.Query["hour"][i]),
                            int.Parse(Request.Query["minute"][i]))
                            );
                    }
                }
                await Db!.AddFilm(id, sessions.ToArray());
            }
        }
    }
}