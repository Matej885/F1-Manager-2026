using F1_Manager_2026.Picking_Team;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls.Primitives;

namespace F1_Manager_2026
{
    // TriInfo zostáva, aby držala informácie o aktuálnom dni
    public class DayInfo
    {
        public int Day { get; set; } = 1; // Začíname dňom 1
        public bool EndOfSeason { get; set; } = false;
        public bool IsSpecialEvent { get; set; } = false;
    }

    public class Track
    {
        public int RaceDay { get; set; }
        public int Round { get; set; }
        public string Name { get; set; } = "";
        public string CountryCode { get; set; } = "";
        public string CircuitName { get; set; } = "";
        public int Laps { get; set; }
        public double Length { get; set; }
        public string RaceDistance { get; set; } = "";
        public string ImagePath { get; set; } = "";
    }

    public class Database : INotifyPropertyChanged
    {
        public Facilities PlayerFacilities { get; set; } = new Facilities();

        public class PlayerAvatar
        {
            public string Name { get; set; } = "";
            public string PhotoPath { get; set; } = "";
        }

        private static Database? instance = null;
        private static readonly object padlock = new object();

        public static Database Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Database();
                    }
                    return instance;
                }
            }
            set
            {
                instance = value;
            }
        }

        public class Facilities
        {
            public int CFD_Level { get; set; } = 1;
            public bool CFD_Enabled { get; set; } = true;
            public int WindTunnel_Level { get; set; } = 1;
            public bool WindTunnel_Enabled { get; set; } = true;
            public int powertrainDyno_Level { get; set; } = 1;
            public bool powertrainDyno_Enabled { get; set; } = true;
            public List<string> DevelopmentLog { get; set; }
            public int EngineUpgradeDaysLeft { get; set; } = -1;
            public int NextEngineUpgrade {  get; set; } = -1;
            public int AeroUpgradeDaysLeft { get; set; } = -1;
            public int NextAeroUpgrade { get; set; } = -1;
            public int ChassisUpgradeDaysLeft { get; set; } = -1;
            public int NextChassisUpgrade { get; set; } = -1;
        }

        // --- PROPERTIES ---
        public PlayerTeam PlayerTeamInstance { get; set; } = new PlayerTeam();
        public ObservableCollection<Driver> DriverList { get; set; }
        public List<F1Team> F1Teams { get; set; }
        public List<PlayerAvatar> Avatars { get; set; }

        // TU JE TO DOPLNENÉ: Inštancia pre aktuálny časový stav
        public DayInfo CurrentDayInfo { get; set; } = new DayInfo();

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Track> Calendar2026 { get; set; }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private Track _selectedTrack;
        public Track SelectedTrack
        {
            get => _selectedTrack ?? Calendar2026.First();
            set
            {
                _selectedTrack = value;
                OnPropertyChanged();
            }
        }

        // --- CONSTRUCTOR ---
        public Database()
        {
            FillCalendar();

            F1Teams = new List<F1Team>
            {
                new F1Team { Name = "Red Bull Racing", Rating = 170, LogoPath = "/Images/redbull.png" },
                new F1Team { Name = "Ferrari", Rating = 190, LogoPath = "/Images/ferrari.png" },
                new F1Team { Name = "Mercedes", Rating = 200, LogoPath = "/Images/mercedes.png" },
                new F1Team { Name = "McLaren", Rating = 185, LogoPath = "/Images/mclaren.png" },
                new F1Team { Name = "Aston Martin", Rating = 100, LogoPath = "/Images/astonmartin.png" },
                new F1Team { Name = "Audi", Rating = 140, LogoPath = "/Images/audi.png" },
                new F1Team { Name = "Alpine", Rating = 155, LogoPath = "/Images/alpine.png" },
                new F1Team { Name = "Williams", Rating = 135, LogoPath = "/Images/williams.png" },
                new F1Team { Name = "RB", Rating = 145, LogoPath = "/Images/rb.png" },
                new F1Team { Name = "Haas", Rating = 200, LogoPath = "/Images/haas.png" },
                new F1Team { Name = "Cadillac", Rating = 110, LogoPath = "/Images/cadillac.png" }
            };
            FillCalendar();
            PlayerFacilities.DevelopmentLog = new List<string>();

            DriverList = new ObservableCollection<Driver>
            {
                new Driver { Name = "Max Verstappen", Number = 1, PhotoPath = "/Images/verstappen.png", Skill = 210, Team = "Red Bull Racing", Cost = 100000000, minprestige = 85, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Lewis Hamilton", Number = 44, PhotoPath = "/Images/hamilton.png", Skill = 190, Team = "Ferrari", Cost = 95000000, minprestige = 80, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Charles Leclerc", Number = 16, PhotoPath = "/Images/leclerc.png", Skill = 205, Team = "Ferrari", Cost = 90000000, minprestige = 80, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Fernando Alonso", Number = 14, PhotoPath = "/Images/alonso.png", Skill = 190, Team = "Aston Martin", Cost = 82000000, minprestige = 60, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "George Russell", Number = 63, PhotoPath = "/Images/russell.png", Skill = 195, Team = "Mercedes", Cost = 75000000, minprestige = 75, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Carlos Sainz", Number = 55, PhotoPath = "/Images/sainz.png", Skill = 195, Team = "Williams", Cost = 75000000, minprestige = 65, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Lando Norris", Number = 4, PhotoPath = "/Images/norris.png", Skill = 180, Team = "McLaren", Cost = 85000000, minprestige = 75, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Oscar Piastri", Number = 81, PhotoPath = "/Images/piastri.png", Skill = 175, Team = "McLaren", Cost = 67000000, minprestige = 60, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Kimi Antonelli", Number = 12, PhotoPath = "/Images/antonelli.png", Skill = 190, Team = "Mercedes", Cost = 65000000, minprestige = 55, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Oliver Bearman", Number = 87, PhotoPath = "/Images/bearman.png", Skill = 180, Team = "Haas", Cost = 32000000, minprestige = 35, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Pierre Gasly", Number = 10, PhotoPath = "/Images/gasly.png", Skill = 172, Team = "Alpine", Cost = 35000000, minprestige = 45, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Gabriel Bortoleto", Number = 5, PhotoPath = "/Images/bortoleto.png", Skill = 170, Team = "Audi", Cost = 4500000, minprestige = 15, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Alex Albon", Number = 23, PhotoPath = "/Images/albon.png", Skill = 168, Team = "Williams", Cost = 50000000, minprestige = 40, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Isack Hadjar", Number = 6, PhotoPath = "/Images/hadjar.png", Skill = 165, Team = "Red Bull Racing", Cost = 4000000, minprestige = 15, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Sergio Perez", Number = 11, PhotoPath = "/Images/perez.png", Skill = 155, Team = "Cadillac", Cost = 30000000, minprestige = 30, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Valtteri Bottas", Number = 77, PhotoPath = "/Images/bottas.png", Skill = 152, Team = "Cadillac", Cost = 25000000, minprestige = 25, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Arvid Lindblad", Number = 41, PhotoPath = "/Images/lindblad.png", Skill = 150, Team = "RB", Cost = 500000, minprestige = 5, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Liam Lawson", Number = 30, PhotoPath = "/Images/lawson.png", Skill = 148, Team = "RB", Cost = 9000000, minprestige = 20, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Nico Hulkenberg", Number = 27, PhotoPath = "/Images/hulkenberg.png", Skill = 145, Team = "Audi", Cost = 30000000, minprestige = 35, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Esteban Ocon", Number = 31, PhotoPath = "/Images/ocon.png", Skill = 140, Team = "Haas", Cost = 10000000, minprestige = 30, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Franco Colapinto", Number = 43, PhotoPath = "/Images/colapinto.png", Skill = 135, Team = "Alpine", Cost = 500000, minprestige = 5, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Lance Stroll", Number = 18, PhotoPath = "/Images/stroll.png", Skill = 120, Team = "Aston Martin", Cost = 1000000, minprestige = 10, IsF2 = false, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Laurens van Hoepen", Number = 24, PhotoPath = "/Images/helmet.png", Skill = 88, Team = "Free Agent", Cost = 200000, minprestige = 5, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Roman Bilinski", Number = 8, PhotoPath = "/Images/helmet.png", Skill = 85, Team = "Free Agent", Cost = 120000, minprestige = 5, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Gabriele Minì", Number = 9, PhotoPath = "/Images/helmet.png", Skill = 82, Team = "Free Agent", Cost = 400000, minprestige = 15, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Cian Shields", Number = 21, PhotoPath = "/Images/helmet.png", Skill = 80, Team = "Free Agent", Cost = 600000, minprestige = 0, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Oliver Goethe", Number = 88, PhotoPath = "/Images/helmet.png", Skill = 78, Team = "Free Agent", Cost = 250000, minprestige = 10, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Mari Boya", Number = 13, PhotoPath = "/Images/helmet.png", Skill = 75, Team = "Free Agent", Cost = 180000, minprestige = 5, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Alex Dunne", Number = 15, PhotoPath = "/Images/helmet.png", Skill = 74, Team = "Free Agent", Cost = 300000, minprestige = 15, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Sebastián Montoya", Number = 86, PhotoPath = "/Images/helmet.png", Skill = 72, Team = "Free Agent", Cost = 220000, minprestige = 10, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Nikola Tsolov", Number = 99, PhotoPath = "/Images/helmet.png", Skill = 70, Team = "Free Agent", Cost = 450000, minprestige = 20, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Rafael Villagómez", Number = 32, PhotoPath = "/Images/helmet.png", Skill = 68, Team = "Free Agent", Cost = 700000, minprestige = 0, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Dino Beganovic", Number = 7, PhotoPath = "/Images/helmet.png", Skill = 65, Team = "Free Agent", Cost = 380000, minprestige = 15, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "John Bennett", Number = 25, PhotoPath = "/Images/helmet.png", Skill = 63, Team = "Free Agent", Cost = 650000, minprestige = 0, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Rafael Câmara", Number = 45, PhotoPath = "/Images/helmet.png", Skill = 62, Team = "Free Agent", Cost = 500000, minprestige = 0, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Kush Maini", Number = 36, PhotoPath = "/Images/helmet.png", Skill = 60, Team = "Free Agent", Cost = 260000, minprestige = 10, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Joshua Dürksen", Number = 20, PhotoPath = "/Images/helmet.png", Skill = 59, Team = "Free Agent", Cost = 350000, minprestige = 0, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Colton Herta", Number = 98, PhotoPath = "/Images/helmet.png", Skill = 58, Team = "Free Agent", Cost = 800000, minprestige = 0, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Martinius Stenshorne", Number = 34, PhotoPath = "/Images/helmet.png", Skill = 55, Team = "Free Agent", Cost = 240000, minprestige = 10, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Emerson Fittipaldi Jr.", Number = 50, PhotoPath = "/Images/helmet.png", Skill = 52, Team = "Free Agent", Cost = 850000, minprestige = 0, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Nico Varrone", Number = 22, PhotoPath = "/Images/helmet.png", Skill = 50, Team = "Free Agent", Cost = 110000, minprestige = 5, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Ritomo Miyata", Number = 3, PhotoPath = "/Images/helmet.png", Skill = 48, Team = "Free Agent", Cost = 280000, minprestige = 0, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Tasanapol Inthraphuvasak", Number = 17, PhotoPath = "/Images/helmet.png", Skill = 45, Team = "Free Agent", Cost = 900000, minprestige = 0, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 },
                new Driver { Name = "Noel León", Number = 19, PhotoPath = "/Images/helmet.png", Skill = 40, Team = "Free Agent", Cost = 150000, minprestige = 5, IsF2 = true, Points = 0, Wins = 0, Podiums = 0 }
            };



            Avatars = new List<PlayerAvatar>
            {
                new PlayerAvatar { Name = "Man Head 1", PhotoPath = "/Images/Head1.png" },
                new PlayerAvatar { Name = "Man Head 2", PhotoPath = "/Images/Head2.png" },
                new PlayerAvatar { Name = "Man Head 3", PhotoPath = "/Images/Head3.png" },
                new PlayerAvatar { Name = "Man Head 4", PhotoPath = "/Images/Head4.png" },
                new PlayerAvatar { Name = "Man Head 5", PhotoPath = "/Images/Head5.png" },
                new PlayerAvatar { Name = "Woman Head 1", PhotoPath = "/Images/Head6.png" },
                new PlayerAvatar { Name = "Woman Head 2", PhotoPath = "/Images/Head6.png" },
                new PlayerAvatar { Name = "Woman Head 3", PhotoPath = "/Images/Head8.png" },
                new PlayerAvatar { Name = "Woman Head 4", PhotoPath = "/Images/Head9.png" },
                new PlayerAvatar { Name = "Woman Head 5", PhotoPath = "/Images/Head10.png" }
            };
        }
        
        public void AddDevelopmentLog(string message)
        {
            PlayerFacilities.DevelopmentLog.Insert(0, $"[{DateTime.Now.ToString("HH:mm")}] {message}");

            if (PlayerFacilities.DevelopmentLog.Count > 10)
            {
                PlayerFacilities.DevelopmentLog.RemoveAt(PlayerFacilities.DevelopmentLog.Count - 1);
            }
            
        }
        public void FillCalendar()
        {

            Calendar2026 = new List<Track>
            {
    new Track { Round = 1, RaceDay = 14, Name = "AUSTRALIAN GRAND PRIX", CountryCode = "AUS", CircuitName = "Albert Park Circuit", Laps = 58, Length = 5.278, RaceDistance = "306.124 km", ImagePath = "/Images/australia1.png" },
    new Track { Round = 2, RaceDay = 28, Name = "CHINESE GRAND PRIX", CountryCode = "CHN", CircuitName = "Shanghai International Circuit", Laps = 56, Length = 5.451, RaceDistance = "305.066 km", ImagePath = "/Images/china.png" },
    new Track { Round = 3, RaceDay = 42, Name = "JAPANESE GRAND PRIX", CountryCode = "JPN", CircuitName = "Suzuka International Racing Course", Laps = 53, Length = 5.807, RaceDistance = "307.471 km", ImagePath = "/Images/japan.png" },
    new Track { Round = 4, RaceDay = 56, Name = "MIAMI GRAND PRIX", CountryCode = "USA", CircuitName = "Miami International Autodrome", Laps = 57, Length = 5.412, RaceDistance = "308.326 km", ImagePath = "/Images/miami.png" },
    new Track { Round = 5, RaceDay = 70, Name = "CANADIAN GRAND PRIX", CountryCode = "CAN", CircuitName = "Circuit Gilles-Villeneuve", Laps = 70, Length = 4.361, RaceDistance = "305.270 km", ImagePath = "/Images/canada1.png" },
    new Track { Round = 6, RaceDay = 84, Name = "MONACO GRAND PRIX", CountryCode = "MON", CircuitName = "Circuit de Monaco", Laps = 78, Length = 3.337, RaceDistance = "260.286 km", ImagePath = "/Images/monaco.png" },
    new Track { Round = 7, RaceDay = 98, Name = "BARCELONA-CATALUNYA GRAND PRIX", CountryCode = "ESP", CircuitName = "Circuit de Barcelona-Catalunya", Laps = 66, Length = 4.657, RaceDistance = "307.236 km", ImagePath = "/Images/barcelona.png" },
    new Track { Round = 8, RaceDay = 112, Name = "AUSTRIAN GRAND PRIX", CountryCode = "AUT", CircuitName = "Red Bull Ring", Laps = 71, Length = 4.318, RaceDistance = "306.452 km", ImagePath = "/Images/austria.png" },
    new Track { Round = 9, RaceDay = 126, Name = "BRITISH GRAND PRIX", CountryCode = "GBR", CircuitName = "Silverstone Circuit", Laps = 52, Length = 5.891, RaceDistance = "306.198 km", ImagePath = "/Images/britain.png" },
    new Track { Round = 10, RaceDay = 140, Name = "BELGIAN GRAND PRIX", CountryCode = "BEL", CircuitName = "Circuit de Spa-Francorchamps", Laps = 44, Length = 7.004, RaceDistance = "308.052 km", ImagePath = "/Images/belgium.png" },
    new Track { Round = 11, RaceDay = 154, Name = "HUNGARIAN GRAND PRIX", CountryCode = "HUN", CircuitName = "Hungaroring", Laps = 70, Length = 4.381, RaceDistance = "306.630 km", ImagePath = "/Images/hungary.png" },
    new Track { Round = 12, RaceDay = 168, Name = "DUTCH GRAND PRIX", CountryCode = "NED", CircuitName = "Circuit Zandvoort", Laps = 72, Length = 4.259, RaceDistance = "306.587 km", ImagePath = "/Images/netherlands.png" },
    new Track { Round = 13, RaceDay = 182, Name = "ITALIAN GRAND PRIX", CountryCode = "ITA", CircuitName = "Autodromo Nazionale Monza", Laps = 53, Length = 5.793, RaceDistance = "306.720 km", ImagePath = "/Images/monza.png" },
    new Track { Round = 14, RaceDay = 196, Name = "SPANISH GRAND PRIX", CountryCode = "ESP", CircuitName = "Madrid Street Circuit", Laps = 71, Length = 5.474, RaceDistance = "306.500 km", ImagePath = "/Images/madrid.png" },
    new Track { Round = 15, RaceDay = 210, Name = "AZERBAIJAN GRAND PRIX", CountryCode = "AZE", CircuitName = "Baku City Circuit", Laps = 51, Length = 6.003, RaceDistance = "306.049 km", ImagePath = "/Images/azerbaijan.png" },
    new Track { Round = 16, RaceDay = 224, Name = "SINGAPORE GRAND PRIX", CountryCode = "SIN", CircuitName = "Marina Bay Street Circuit", Laps = 62, Length = 4.940, RaceDistance = "306.143 km", ImagePath = "/Images/singapore.png" },
    new Track { Round = 17, RaceDay = 238, Name = "UNITED STATES GRAND PRIX", CountryCode = "USA", CircuitName = "Circuit of the Americas", Laps = 56, Length = 5.513, RaceDistance = "308.405 km", ImagePath = "/Images/cota.png" },
    new Track { Round = 18, RaceDay = 245, Name = "MEXICO CITY GRAND PRIX", CountryCode = "MEX", CircuitName = "Autódromo Hermanos Rodríguez", Laps = 71, Length = 4.304, RaceDistance = "305.354 km", ImagePath = "/Images/mexico.png" },
    new Track { Round = 19, RaceDay = 252, Name = "SÃO PAULO GRAND PRIX", CountryCode = "BRA", CircuitName = "Autódromo José Carlos Pace", Laps = 71, Length = 4.309, RaceDistance = "305.879 km", ImagePath = "/Images/brazil.png" },
    new Track { Round = 20, RaceDay = 259, Name = "LAS VEGAS GRAND PRIX", CountryCode = "USA", CircuitName = "Las Vegas Strip Circuit", Laps = 50, Length = 6.201, RaceDistance = "309.958 km", ImagePath = "/Images/vegas.png" },
    new Track { Round = 21, RaceDay = 266, Name = "QATAR GRAND PRIX", CountryCode = "QAT", CircuitName = "Lusail International Circuit", Laps = 57, Length = 5.419, RaceDistance = "308.611 km", ImagePath = "/Images/qatar.png" },
    new Track { Round = 22, RaceDay = 273, Name = "ABU DHABI GRAND PRIX", CountryCode = "UAE", CircuitName = "Yas Marina Circuit", Laps = 58, Length = 5.281, RaceDistance = "306.183 km", ImagePath = "/Images/abudhabi.png" }
                };
        }


        public void InitializeTeam(int choice)
        {
            switch (choice)
            {
                case 1:
                    PlayerTeamInstance.teamName = "Minardi F1 Team";
                    PlayerTeamInstance.Budget = 20000000;
                    PlayerTeamInstance.Prestige = 0;
                    PlayerTeamInstance.teamclothespath = "/Images/clothes_minardi.png";
                    PlayerTeamInstance.PathToCar = "/Images/Minardi_Car.jpg";
                    PlayerTeamInstance.suitpath = "/Images/suit_minardi.png";
                    break;
                case 2:
                    PlayerTeamInstance.teamName = "Alfa Romeo F1 Team";
                    PlayerTeamInstance.Budget = 50000000;
                    PlayerTeamInstance.Prestige = 40;
                    PlayerTeamInstance.teamclothespath = "/Images/clothes_alfaromeo.png";
                    PlayerTeamInstance.PathToCar = "/Images/AlfaRomeo_Car.jpg";
                    PlayerTeamInstance.suitpath = "/Images/suit_alfa.png";
                    break;
                case 3:
                    PlayerTeamInstance.teamName = "BMW Sauber F1 Team";
                    PlayerTeamInstance.Budget = 80000000;
                    PlayerTeamInstance.Prestige = 70;
                    PlayerTeamInstance.teamclothespath = "/Images/clothes_BMW.jpg";
                    PlayerTeamInstance.PathToCar = "/Images/BMW_Car.jpg";
                    PlayerTeamInstance.suitpath = "/Images/suit_bmw.png";
                    break;
                case 4:
                    PlayerTeamInstance.teamName = "Siemens Racing F1 Team";
                    PlayerTeamInstance.Prestige = 120;
                    PlayerTeamInstance.Budget = 120000000;
                    PlayerTeamInstance.teamclothespath = "/Images/clothes_Siemens.jpg";
                    PlayerTeamInstance.PathToCar = "/Images/Siemens_Car.jpg";
                    PlayerTeamInstance.suitpath = "/Images/suit_siemens.png";
                    break;
            }
        }
    }
}