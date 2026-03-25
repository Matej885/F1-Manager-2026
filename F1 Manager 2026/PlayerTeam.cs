namespace F1_Manager_2026
{
    public class PlayerTeam
    {
        public string teamName = string.Empty;
        public string driver2name = string.Empty;
        public int driver2rating;
        public int driver2cost;
        public string driver1name = string.Empty;
        public int driver1rating;
        public int driver1cost;
        public decimal Budget { get; set; }

        // Ostatné premenné (driver2, body, atď.) zostávajú rovnaké...
    }
}