using System;
using System.Collections.Generic;
using System.Text;

namespace F1_Manager_2026
{
    public class GameState
    {
        public static int TeamChosen { get; set; }


        public static void InitializeTeam(int teamId)
        {
            PlayerTeam playerTeam = new PlayerTeam();
            TeamChosen = teamId;

            switch (teamId)
            {
                case 1: 
                     playerTeam.Budget = 80000000;
                    playerTeam.teamName = "Minardi";
                    break;
                case 2: 
                    playerTeam.Budget = 140000000;
                    playerTeam.teamName = "Alfa Romeo";
                    break;
                case 3: 
                    playerTeam.Budget = 180000000;
                    playerTeam.teamName = "BMW";
                    break;
                case 4: 
                    playerTeam.Budget = 210000000;
                    playerTeam.teamName = "Siemens";
                    break;
            }
        }
    }
}
