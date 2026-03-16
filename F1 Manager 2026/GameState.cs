using System;
using System.Collections.Generic;
using System.Text;

namespace F1_Manager_2026
{
    public static class GameState
    {
        public static int TeamChosen { get; set; }

        public static decimal Budget { get; set; }

        public static void InitializeTeam(int teamId)
        {
            TeamChosen = teamId;

            switch (teamId)
            {
                case 1: 
                    Budget = 80000000 ;
                    break;
                case 2: 
                    Budget = 140000000;
                    break;
                case 3: 
                    Budget = 180000000;
                    break;
                case 4: 
                    Budget = 210000000;
                    break;
            }
        }
    }
}
