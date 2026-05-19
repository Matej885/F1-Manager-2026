namespace F1_Manager_2026
{
    public class PlayerTeam
    {
        public string PlayerName { get; set; }
        public string teamName { get; set; } = "";
        public double Budget { get; set; }
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
        public double WCCPosition { get; set; }
        public double SeasonGoal { get; set; }

        // Cesty k obrázkom
        public string Engine_Path { get; set; }
        public string playerphotopath { get; set; } = "/Images/Head1.png";
        public string teamclothespath { get; set; } = "/Images/suit_default.png";
        public string suitpath { get; set; }
        public string logopath { get; set; }

        // Motor detaily
        public string EngineName { get; set; }
        public int EngineReliability { get; set; }

        // Jazdci
        public string? driver1name { get; set; }
        public double driver1cost { get; set; }
        public int driver1rating { get; set; }
        public string? driver2name { get; set; }
        public double driver2cost { get; set; }    
        public int driver2rating { get; set; }
        public string PathToCar { get; set; }
        public string PathToDriver1 { get; set; }
        public string PathToDriver2 { get; set; }
        public int WCCPosition { get; set; }
        public int SeasonGoal { get; set; }
        public double startermoney { get; set; }

        //Ciele
        public int  LowGoal { get; set; }
        public int MediumGoal { get; set; }
        public int HighGoal { get; set; }
        public int UnrealisticGoal { get; set; }
        public double startermoney { get; set; }
    }
}