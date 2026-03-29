using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace F1_Manager_2026
{
    public class Database : INotifyPropertyChanged
    {
        public class PlayerAvatar
        {
            public string Name { get; set; }
            public string PhotoPath { get; set; }
        }

        private static Database instance = null;
        private static readonly object padlock = new object();

        public static Database Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Database();
                        }
                    }
                }
                return instance;
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public PlayerTeam PlayerTeamInstance { get; set; } = new PlayerTeam();
        public ObservableCollection<Driver> DriverList { get; set; }

        public Database()
        {
            DriverList = new ObservableCollection<Driver>
            {
                new Driver { Name = "Max Verstappen", Number = 33, PhotoPath = "/Images/verstappen.png", Skill = 99, Team = "Red Bull Racing", Cost = 100000000, minprestige = 85, IsF2 = false },
                new Driver { Name = "Charles Leclerc", Number = 16, PhotoPath = "/Images/leclerc.png", Skill = 97, Team = "Ferrari", Cost = 90000000, minprestige = 80, IsF2 = false },
                new Driver { Name = "Lewis Hamilton", Number = 44, PhotoPath = "/Images/hamilton.png", Skill = 97, Team = "Ferrari", Cost = 90000000, minprestige = 80, IsF2 = false },
                new Driver { Name = "Lando Norris", Number = 4, PhotoPath = "/Images/norris.png", Skill = 95, Team = "McLaren", Cost = 85000000, minprestige = 75, IsF2 = false },
                new Driver { Name = "George Russell", Number = 63, PhotoPath = "/Images/russell.png", Skill = 95, Team = "Mercedes", Cost = 75000000, minprestige = 75, IsF2 = false },
                new Driver { Name = "Carlos Sainz", Number = 55, PhotoPath = "/Images/sainz.png", Skill = 94, Team = "Williams", Cost = 75000000, minprestige = 65, IsF2 = false },
                new Driver { Name = "Fernando Alonso", Number = 14, PhotoPath = "/Images/alonso.png", Skill = 93, Team = "Aston Martin", Cost = 82000000, minprestige = 60, IsF2 = false },
                new Driver { Name = "Oscar Piastri", Number = 81, PhotoPath = "/Images/piastri.png", Skill = 92, Team = "McLaren", Cost = 67000000, minprestige = 60, IsF2 = false },
                new Driver { Name = "Kimi Antonelli", Number = 12, PhotoPath = "/Images/antonelli.png", Skill = 89, Team = "Mercedes", Cost = 65000000, minprestige = 55, IsF2 = false },
                new Driver { Name = "Pierre Gasly", Number = 10, PhotoPath = "/Images/gasly.png", Skill = 82, Team = "Alpine", Cost = 35000000, minprestige = 45, IsF2 = false },
                new Driver { Name = "Alex Albon", Number = 23, PhotoPath = "/Images/albon.png", Skill = 80, Team = "Williams", Cost = 50000000, minprestige = 40, IsF2 = false },
                new Driver { Name = "Nico Hulkenberg", Number = 27, PhotoPath = "/Images/hulkenberg.png", Skill = 80, Team = "Audi", Cost = 30000000, minprestige = 35, IsF2 = false },
                new Driver { Name = "Oliver Bearman", Number = 87, PhotoPath = "/Images/bearman.png", Skill = 80, Team = "Haas", Cost = 32000000, minprestige = 35, IsF2 = false },
                new Driver { Name = "Esteban Ocon", Number = 31, PhotoPath = "/Images/ocon.png", Skill = 74, Team = "Haas", Cost = 10000000, minprestige = 30, IsF2 = false },
                new Driver { Name = "Sergio Perez", Number = 11, PhotoPath = "/Images/perez.png", Skill = 77, Team = "Cadillac", Cost = 30000000, minprestige = 30, IsF2 = false },
                new Driver { Name = "Valtteri Bottas", Number = 77, PhotoPath = "/Images/bottas.png", Skill = 75, Team = "Cadillac", Cost = 25000000, minprestige = 25, IsF2 = false },
                new Driver { Name = "Liam Lawson", Number = 30, PhotoPath = "/Images/lawson.png", Skill = 70, Team = "RB", Cost = 9000000, minprestige = 20, IsF2 = false },
                new Driver { Name = "Gabriel Bortoleto", Number = 5, PhotoPath = "/Images/bortoleto.png", Skill = 77, Team = "Audi", Cost = 4500000, minprestige = 15, IsF2 = false },
                new Driver { Name = "Isack Hadjar", Number = 6, PhotoPath = "/Images/hadjar.png", Skill = 87, Team = "Red Bull Racing", Cost = 4000000, minprestige = 15, IsF2 = false },
                new Driver { Name = "Lance Stroll", Number = 18, PhotoPath = "/Images/stroll.png", Skill = 65, Team = "Aston Martin", Cost = 1000000, minprestige = 10, IsF2 = false },
                new Driver { Name = "Franco Colapinto", Number = 43, PhotoPath = "/Images/colapinto.png", Skill = 59, Team = "Alpine", Cost = 500000, minprestige = 5, IsF2 = false },
                new Driver { Name = "Arvid Lindblad", Number = 41, PhotoPath = "/Images/lindblad.png", Skill = 66, Team = "RB", Cost = 500000, minprestige = 5, IsF2 = false },
                // F2 jazdci
               new Driver { Name = "Rafael Câmara", Number = 1, PhotoPath = "/Images/helmet.png", Skill = 63, Team = "Invicta Racing", Cost = 500000, minprestige = 0, IsF2 = true },
                new Driver { Name = "Joshua Dürksen", Number = 2, PhotoPath = "/Images/helmet.png", Skill = 59, Team = "Invicta Racing", Cost = 350000, minprestige = 0, IsF2 = true },
                new Driver { Name = "Ritomo Miyata", Number = 3, PhotoPath = "/Images/helmet.png", Skill = 50, Team = "Hitech Pulse-Eight", Cost = 280000, minprestige = 0, IsF2 = true },
                new Driver { Name = "Colton Herta", Number = 4, PhotoPath = "/Images/helmet.png", Skill = 60, Team = "Hitech Pulse-Eight", Cost = 800000, minprestige = 0, IsF2 = true },
                new Driver { Name = "Noel León", Number = 5, PhotoPath = "/Images/helmet.png", Skill = 48, Team = "Campos Racing", Cost = 150000, minprestige = 5, IsF2 = true },
                new Driver { Name = "Nikola Tsolov", Number = 6, PhotoPath = "/Images/helmet.png", Skill = 65, Team = "Campos Racing", Cost = 450000, minprestige = 20, IsF2 = true },
                new Driver { Name = "Dino Beganovic", Number = 7, PhotoPath = "/Images/helmet.png", Skill = 53, Team = "DAMS Lucas Oil", Cost = 380000, minprestige = 15, IsF2 = true },
                new Driver { Name = "Roman Bilinski", Number = 8, PhotoPath = "/Images/helmet.png", Skill = 55, Team = "DAMS Lucas Oil", Cost = 120000, minprestige = 5, IsF2 = true },
                new Driver { Name = "Gabriele Minì", Number = 9, PhotoPath = "/Images/helmet.png", Skill = 58, Team = "MP Motorsport", Cost = 400000, minprestige = 15, IsF2 = true },
                new Driver { Name = "Oliver Goethe", Number = 10, PhotoPath = "/Images/helmet.png", Skill = 63, Team = "MP Motorsport", Cost = 250000, minprestige = 10, IsF2 = true },
                new Driver { Name = "Sebastián Montoya", Number = 11, PhotoPath = "/Images/helmet.png", Skill = 65, Team = "PREMA Racing", Cost = 220000, minprestige = 10, IsF2 = true },
                new Driver { Name = "Mari Boya", Number = 12, PhotoPath = "/Images/helmet.png", Skill = 79, Team = "PREMA Racing", Cost = 180000, minprestige = 5, IsF2 = true },
                new Driver { Name = "Martinius Stenshorne", Number = 14, PhotoPath = "/Images/helmet.png", Skill = 60, Team = "Rodin Motorsport", Cost = 240000, minprestige = 10, IsF2 = true },
                new Driver { Name = "Alex Dunne", Number = 15, PhotoPath = "/Images/helmet.png", Skill = 63, Team = "Rodin Motorsport", Cost = 300000, minprestige = 15, IsF2 = true },
                new Driver { Name = "Kush Maini", Number = 16, PhotoPath = "/Images/helmet.png", Skill = 46, Team = "ART Grand Prix", Cost = 260000, minprestige = 10, IsF2 = true },
                new Driver { Name = "Tasanapol Inthraphuvasak", Number = 17, PhotoPath = "/Images/helmet.png", Skill = 49, Team = "ART Grand Prix", Cost = 900000, minprestige = 0, IsF2 = true },
                new Driver { Name = "Emerson Fittipaldi Jr.", Number = 20, PhotoPath = "/Images/helmet.png", Skill = 53, Team = "AIX Racing", Cost = 850000, minprestige = 0, IsF2 = true },
                new Driver { Name = "Cian Shields", Number = 21, PhotoPath = "/Images/helmet.png", Skill = 58, Team = "AIX Racing", Cost = 600000, minprestige = 0, IsF2 = true },
                new Driver { Name = "Nico Varrone", Number = 22, PhotoPath = "/Images/helmet.png", Skill = 57, Team = "Van Amersfoort Racing", Cost = 110000, minprestige = 5, IsF2 = true },
                new Driver { Name = "Rafael Villagómez", Number = 23, PhotoPath = "/Images/helmet.png", Skill = 58, Team = "Van Amersfoort Racing", Cost = 700000, minprestige = 0, IsF2 = true },
                new Driver { Name = "Laurens van Hoepen", Number = 24, PhotoPath = "/Images/helmet.png", Skill = 56, Team = "Trident", Cost = 200000, minprestige = 5, IsF2 = true },
                new Driver { Name = "John Bennett", Number = 25, PhotoPath = "/Images/helmet.png", Skill = 60, Team = "Trident", Cost = 650000, minprestige = 0, IsF2 = true }


            };
        }
        public List<PlayerAvatar> Avatars { get; set; } = new List<PlayerAvatar>
{
    // MUŽSKÉ HLAVY
    new PlayerAvatar { Name = "Man Head 1", PhotoPath = "/Images/Head1.png" },
    new PlayerAvatar { Name = "Man Head 2", PhotoPath = "/Images/Head2.png" },
    new PlayerAvatar { Name = "Man Head 3", PhotoPath = "/Images/Head3.png" },
    new PlayerAvatar { Name = "Man Head 4", PhotoPath = "/Images/Head4.png" },
    new PlayerAvatar { Name = "Man Head 5", PhotoPath = "/Images/Head5.png" },

    // ŽENSKÉ HLAVY
    new PlayerAvatar { Name = "Woman Head 1", PhotoPath = "/Images/Head6.png" },
    new PlayerAvatar { Name = "Woman Head 2", PhotoPath = "/Images/Head6.png" }, // Ak máš Head7, zmeň si číslo
    new PlayerAvatar { Name = "Woman Head 3", PhotoPath = "/Images/Head8.png" },
    new PlayerAvatar { Name = "Woman Head 4", PhotoPath = "/Images/Head9.png" },
    new PlayerAvatar { Name = "Woman Head 5", PhotoPath = "/Images/Head10.png" }
};
        public void InitializeTeam(int choice)
        {
            // Resetujeme dáta;

            switch (choice)
            {
                case 1:
                    PlayerTeamInstance.teamName = "Minardi F1 Team";
                    PlayerTeamInstance.Budget = 20000000;
                    PlayerTeamInstance.Prestige = 20;
                    PlayerTeamInstance.teamclothespath = "/Images/clothes_minardi.png";
                    break;
                case 2:
                    PlayerTeamInstance.teamName = "Alfa Romeo F1 Team";
                    PlayerTeamInstance.Budget = 50000000;
                    PlayerTeamInstance.Prestige = 50;
                    PlayerTeamInstance.teamclothespath = "/Images/clothes_alfaromeo.png";
                    break;
                case 3:
                    PlayerTeamInstance.teamName = "BMW Sauber F1 Team";
                    PlayerTeamInstance.Budget = 80000000;
                    PlayerTeamInstance.Prestige = 70;
                    PlayerTeamInstance.teamclothespath = "/Images/clothes_BMW.jpg";
                    break;
                case 4:
                    PlayerTeamInstance.teamName = "Siemens Racing F1 Team";
                    PlayerTeamInstance.Budget = 120000000;
                    PlayerTeamInstance.Prestige = 90;
                    PlayerTeamInstance.teamclothespath = "/Images/clothes_Siemens.jpg";
                    break;
            }
        }
    }
}