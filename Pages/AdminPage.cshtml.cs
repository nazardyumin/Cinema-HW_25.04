using Cinema.BL;
using Cinema.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.Pages
{
    public class AdminPageModel : PageModel
    {
        public FilmDataBase? Db { get; set; }

        public AdminPageModel()
        {
            Db = new(new FilmDbJson());
        }

        public async Task OnPost()
        {
            if (!string.IsNullOrEmpty(Request.Form["id"]))
            {
                var id = Request.Form["id"];
                var count = Request.Form["hall"].Count;
                List<Session> sessions = new();

                for (var i = 0; i < count; i++)
                {
                    var correctYear = !string.IsNullOrEmpty(Request.Form["year"][i]);
                    var correctMonth = !string.IsNullOrEmpty(Request.Form["month"][i]);
                    var correctDay = !string.IsNullOrEmpty(Request.Form["day"][i]);
                    var correctMinute = !string.IsNullOrEmpty(Request.Form["minute"][i]);

                    if (correctYear && correctMonth && correctDay && correctMinute)
                    {
                        sessions.Add(new Session(
                            int.Parse(Request.Form["hall"][i]),
                            int.Parse(Request.Form["year"][i]),
                            int.Parse(Request.Form["month"][i]),
                            int.Parse(Request.Form["day"][i]),
                            int.Parse(Request.Form["hour"][i]),
                            int.Parse(Request.Form["minute"][i])));
                    }
                    else if (correctYear && correctMonth && correctDay && !correctMinute)
                    {
                        sessions.Add(new Session(
                            int.Parse(Request.Form["hall"][i]),
                            int.Parse(Request.Form["year"][i]),
                            int.Parse(Request.Form["month"][i]),
                            int.Parse(Request.Form["day"][i]),
                            int.Parse(Request.Form["hour"][i])));
                    }
                    else if (!correctMinute && !correctYear)
                    {
                        sessions.Add(new Session(
                        int.Parse(Request.Form["hall"][i]),
                        int.Parse(Request.Form["hour"][i]))
                        );
                    }
                    else
                    {
                        sessions.Add(new Session(
                            int.Parse(Request.Form["hall"][i]),
                            int.Parse(Request.Form["hour"][i]),
                            int.Parse(Request.Form["minute"][i]))
                            );
                    }
                }
                await Db!.AddFilm(id, sessions.ToArray());
            }
        }
    }
}