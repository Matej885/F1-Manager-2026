using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace F1_Manager_2026
{
    public class Database : INotifyPropertyChanged
    {

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
               new Driver { Name = "Max Verstappen", Number = 33, PhotoPath = "/Images/verstappen.png", Skill = 99, Team = "Red Bull Racing", Cost = 100000000 },
    new Driver { Name = "Charles Leclerc", Number = 16, PhotoPath = "/Images/leclerc.png", Skill = 97, Team = "Ferrari", Cost = 90000000 },
    new Driver { Name = "Lewis Hamilton", Number = 44, PhotoPath = "/Images/hamilton.png", Skill = 97, Team = "Ferrari", Cost = 90000000 },
    new Driver { Name = "Lando Norris", Number = 4, PhotoPath = "/Images/norris.png", Skill = 95, Team = "McLaren", Cost = 85000000 },
    new Driver { Name = "Fernando Alonso", Number = 14, PhotoPath = "/Images/alonso.png", Skill = 93, Team = "Aston Martin", Cost = 82000000 },
    new Driver { Name = "Carlos Sainz", Number = 55, PhotoPath = "/Images/sainz.png", Skill = 94, Team = "Williams", Cost = 75000000 },
    new Driver { Name = "George Russell", Number = 63, PhotoPath = "/Images/russell.png", Skill = 95, Team = "Mercedes", Cost = 75000000 },
    new Driver { Name = "Oscar Piastri", Number = 81, PhotoPath = "/Images/piastri.png", Skill = 92, Team = "McLaren", Cost = 67000000 },
    new Driver { Name = "Kimi Antonelli", Number = 12, PhotoPath = "/Images/antonelli.png", Skill = 89, Team = "Mercedes", Cost = 65000000 },
    new Driver { Name = "Alex Albon", Number = 23, PhotoPath = "/Images/albon.png", Skill = 80, Team = "Williams", Cost = 50000000 },
    new Driver { Name = "Pierre Gasly", Number = 10, PhotoPath = "/Images/gasly.png", Skill = 82, Team = "Alpine", Cost = 35000000 },
    new Driver { Name = "Oliver Bearman", Number = 87, PhotoPath = "/Images/bearman.png", Skill = 80, Team = "Haas", Cost = 32000000 },
    new Driver { Name = "Nico Hulkenberg", Number = 27, PhotoPath = "/Images/hulkenberg.png", Skill = 80, Team = "Audi", Cost = 30000000 },
    new Driver { Name = "Sergio Perez", Number = 11, PhotoPath = "/Images/perez.png", Skill = 77, Team = "Cadillac", Cost = 30000000 },
    new Driver { Name = "Valtteri Bottas", Number = 77, PhotoPath = "/Images/bottas.png", Skill = 75, Team = "Cadillac", Cost = 25000000 },
    new Driver { Name = "Esteban Ocon", Number = 31, PhotoPath = "/Images/ocon.png", Skill = 74, Team = "Haas", Cost = 10000000 },
    new Driver { Name = "Liam Lawson", Number = 30, PhotoPath = "/Images/lawson.png", Skill = 70, Team = "RB", Cost = 9000000 },
    new Driver { Name = "Isack Hadjar", Number = 6, PhotoPath = "/Images/hadjar.png", Skill = 87, Team = "Red Bull Racing", Cost = 4000000 },
    new Driver { Name = "Arvid Lindblad", Number = 41, PhotoPath = "/Images/lindblad.png", Skill = 66, Team = "RB", Cost = 5000000 },
    new Driver { Name = "Gabriel Bortoleto", Number = 5, PhotoPath = "/Images/bortoleto.png", Skill = 77, Team = "Audi", Cost = 4500000 },
    new Driver { Name = "Lance Stroll", Number = 18, PhotoPath = "/Images/stroll.png", Skill = 65, Team = "Aston Martin", Cost = 1000000 },
    new Driver { Name = "Franco Colapinto", Number = 43, PhotoPath = "/Images/colapinto.png", Skill = 59, Team = "Alpine", Cost = 500000 },
    new Driver { Name = "Colton Herta", Number = 4, PhotoPath = "/Images/helmet.png", Skill = 83, Team = "Hitech Pulse-Eight", Cost = 18000000 },
    new Driver { Name = "Rafael Câmara", Number = 1, PhotoPath = "/Images/helmet.png", Skill = 81, Team = "Invicta Racing", Cost = 15000000 },
    new Driver { Name = "Gabriele Minì", Number = 9, PhotoPath = "/Images/helmet.png", Skill = 82, Team = "MP Motorsport", Cost = 14000000 },
    new Driver { Name = "Nikola Tsolov", Number = 6, PhotoPath = "/Images/helmet.png", Skill = 80, Team = "Campos Racing", Cost = 12000000 },
    new Driver { Name = "Kush Maini", Number = 16, PhotoPath = "/Images/helmet.png", Skill = 80, Team = "ART Grand Prix", Cost = 10000000 },
    new Driver { Name = "Dino Beganovic", Number = 7, PhotoPath = "/Images/helmet.png", Skill = 79, Team = "DAMS Lucas Oil", Cost = 9000000 },
    new Driver { Name = "Joshua Dürksen", Number = 2, PhotoPath = "/Images/helmet.png", Skill = 79, Team = "Invicta Racing", Cost = 8500000 },
    new Driver { Name = "Alex Dunne", Number = 15, PhotoPath = "/Images/helmet.png", Skill = 79, Team = "Rodin Motorsport", Cost = 8500000 },
    new Driver { Name = "Martinius Stenshorne", Number = 14, PhotoPath = "/Images/helmet.png", Skill = 78, Team = "Rodin Motorsport", Cost = 8000000 },
    new Driver { Name = "Sebastián Montoya", Number = 11, PhotoPath = "/Images/helmet.png", Skill = 77, Team = "PREMA Racing", Cost = 7500000 },
    new Driver { Name = "Ritomo Miyata", Number = 3, PhotoPath = "/Images/helmet.png", Skill = 78, Team = "Hitech Pulse-Eight", Cost = 7000000 },
    new Driver { Name = "Laurens van Hoepen", Number = 24, PhotoPath = "/Images/helmet.png", Skill = 78, Team = "Trident", Cost = 7000000 },
    new Driver { Name = "Oliver Goethe", Number = 10, PhotoPath = "/Images/helmet.png", Skill = 77, Team = "MP Motorsport", Cost = 6000000 },
    new Driver { Name = "Mari Boya", Number = 12, PhotoPath = "/Images/helmet.png", Skill = 76, Team = "PREMA Racing", Cost = 5000000 },
    new Driver { Name = "Noel León", Number = 5, PhotoPath = "/Images/helmet.png", Skill = 76, Team = "Campos Racing", Cost = 4500000 },
    new Driver { Name = "Emerson Fittipaldi Jr.", Number = 20, PhotoPath = "/Images/helmet.png", Skill = 75, Team = "AIX Racing", Cost = 4000000 },
    new Driver { Name = "Nicolás Varrone", Number = 22, PhotoPath = "/Images/helmet.png", Skill = 76, Team = "Van Amersfoort Racing", Cost = 4000000 },
    new Driver { Name = "Roman Bilinski", Number = 8, PhotoPath = "/Images/helmet.png", Skill = 75, Team = "DAMS Lucas Oil", Cost = 3500000 },
    new Driver { Name = "Tasanapol Inthraphuvasak", Number = 17, PhotoPath = "/Images/helmet.png", Skill = 74, Team = "ART Grand Prix", Cost = 3000000 },
    new Driver { Name = "Rafael Villagómez", Number = 23, PhotoPath = "/Images/helmet.png", Skill = 74, Team = "Van Amersfoort Racing", Cost = 2500000 },
    new Driver { Name = "Cian Shields", Number = 21, PhotoPath = "/Images/helmet.png", Skill = 73, Team = "AIX Racing", Cost = 2000000 },
    new Driver { Name = "John Bennett", Number = 25, PhotoPath = "/Images/helmet.png", Skill = 73, Team = "Trident", Cost = 2000000 }
            };
        }
        public void InitializeTeam(int choice)
        {
            // Resetujeme dáta
            PlayerTeamInstance = new PlayerTeam();

            switch (choice)
            {
                case 1:
                    PlayerTeamInstance.teamName = "Minardi F1 Team";
                    PlayerTeamInstance.Budget = 20000000;
                    break;
                case 2:
                    PlayerTeamInstance.teamName = "Alfa Romeo F1 Team";
                    PlayerTeamInstance.Budget = 50000000;
                    break;
                case 3:
                    PlayerTeamInstance.teamName = "BMW Sauber F1 Team";
                    PlayerTeamInstance.Budget = 80000000;
                    break;
                case 4:
                    PlayerTeamInstance.teamName = "Siemens Racing F1 Team";
                    PlayerTeamInstance.Budget = 120000000;
                    break;
            }
        }
    }
}