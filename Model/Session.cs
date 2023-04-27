namespace Cinema.Model
{
    public class Session
    {
        public int Hall { get; set; }
        public DateTime Time { get; set; }

        public Session() { }

        public Session(int hall, int hour, int minute = 0)
        {
            Hall = hall;
            var now = DateTime.Now;
            Time = new DateTime(now.Year, now.Month, now.Day, hour, minute, 0);
        }

        public Session(int hall, int year, int month, int day, int hour, int minute = 0) 
        {
            Hall = hall;
            Time = new DateTime(year, month, day, hour, minute, 0);
        }
    }
}
