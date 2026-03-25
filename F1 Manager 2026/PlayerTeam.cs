namespace F1_Manager_2026
{
    public class PlayerTeam
    {
        public string teamName { get; set; } = "";
        public decimal Budget { get; set; }
        public int Prestige { get; set; } // Tvoja prestíž

        public string driver1name { get; set; } = "";
        public int driver1rating { get; set; }
        public int driver1cost { get; set; }

        public string driver2name { get; set; } = "";
        public int driver2rating { get; set; }
        public int driver2cost { get; set; }
    }
}