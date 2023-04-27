namespace Cinema.Model
{
    public class Film
    {
        public string? ImdbId { get; set; }
        public string? Poster { get; set; }
        public string? Title { get; set; }
        public string? Director { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public Session[]? Sessions { get; set; }
    }
}
