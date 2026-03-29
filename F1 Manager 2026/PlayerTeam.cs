namespace F1_Manager_2026
{
    public class PlayerTeam
    {
        public string PlayerName { get; set; }
        public string teamName { get; set; } = "";
        public decimal Budget { get; set; }
        public int Prestige { get; set; }

        // Tieto dve sú kľúčové pre Avatar_Pick
        public string playerphotopath { get; set; } = "/Images/Head1.png";
        public string teamclothespath { get; set; } = "/Images/suit_default.png";

        // Jazdci
        public string? driver1name { get; set; }
        public int driver1cost { get; set; }
        public int driver1rating { get; set; }
        public string? driver2name { get; set; }
        public int driver2cost { get; set; }
        public int driver2rating { get; set; }
        public int TeamPower { get; set; } = 50; // Sila auta
    }
}