namespace F1_Manager_2026
{
    public class PlayerTeam
    {
        public string PlayerName { get; set; }
        public string teamName { get; set; } = "";
        public decimal Budget { get; set; }
        public int Prestige { get; set; }

        // Výkonnostné štatistiky
        public int EnginePower { get; set; } = 1;
        public int AeroPower { get; set; } = 1;
        public int ChassisPower { get; set; } = 1;

        // AUTOMATICKÝ VÝPOČET SILY TÍMU
        public int TeamPower => EnginePower + AeroPower + ChassisPower;

        // Levely vylepšení
        public int AeroUpgradeLevel { get; set; } = 1;
        public int ChassisUpgradeLevel { get; set; } = 1;
        public int Engine_UpgradeLevel { get; set; } = 1;

        // Cesty k obrázkom
        public string Engine_Path { get; set; }
        public string playerphotopath { get; set; } = "/Images/Head1.png";
        public string teamclothespath { get; set; } = "/Images/suit_default.png";

        // Motor detaily
        public string EngineName { get; set; }
        public int EngineReliability { get; set; }

        // Jazdci
        public string? driver1name { get; set; }
        public int driver1cost { get; set; }
        public int driver1rating { get; set; }
        public string? driver2name { get; set; }
        public int driver2cost { get; set; }
        public int driver2rating { get; set; }
    }
}