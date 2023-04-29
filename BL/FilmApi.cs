using Cinema.Model;

namespace Cinema.BL
{
    public static class FilmApi
    {
        public static async Task<ApiResponse?> GetInfoById(string id)
        {
            using var http = new HttpClient();
            var url = $"https://www.omdbapi.com/?&i={id}&plot=full&apikey=95992181";
            ApiResponse? response;

            try
            {
                response = await http.GetFromJsonAsync(url, typeof(ApiResponse)) as ApiResponse;
            }
            catch
            {
                return null;
            }
            return response;
        }
    }
}
