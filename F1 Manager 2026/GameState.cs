using System;

namespace F1_Manager_2026
{
    public static class GameState
    {
        // Toto je jediná inštancia dát tímu, ktorú budeme v hre používať
        public static PlayerTeam PlayerTeamInstance { get; set; } = new PlayerTeam();

        public static void InitializeTeam(int choice)
        {
            // Resetujeme dáta
            PlayerTeamInstance = new PlayerTeam();

            switch (choice)
            {
                case 1:
                    PlayerTeamInstance.teamName = "Minardi F1 Team";
                    PlayerTeamInstance.Budget = 80000000;
                    break;
                case 2:
                    PlayerTeamInstance.teamName = "Alfa Romeo F1 Team";
                    PlayerTeamInstance.Budget = 140000000;
                    break;
                case 3:
                    PlayerTeamInstance.teamName = "BMW Sauber F1 Team";
                    PlayerTeamInstance.Budget = 180000000;
                    break;
                case 4:
                    PlayerTeamInstance.teamName = "Siemens Racing F1 Team";
                    PlayerTeamInstance.Budget = 210000000;
                    break;
            }
        }
    }
}