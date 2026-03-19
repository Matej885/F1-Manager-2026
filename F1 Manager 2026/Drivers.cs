using System;
using System.Collections.Generic;

namespace F1_Manager_2026
{
    public class Drivers
    {
        private string _team;
        public string Name { get; set; }
        public int Number { get; set; }
        public string PhotoPath { get; set; }
        public string SuitPath { get; private set; } // Nastavuje sa automaticky cez Team
        public int Skill { get; set; }

        public string Team
        {
            get => _team;
            set
            {
                _team = value;
                UpdateSuitPath(); // Automatická zmena kombinézy pri zmene tímu
            }
        }

        public string FormattedCost => $"COST: ${((Skill - 60) * 0.8):F1}M";

        // Logika priradenia kombinézy podľa názvu tímu
        private void UpdateSuitPath()
        {
            string folder = "/Images/";
            SuitPath = _team switch
            {
                "McLaren" => folder + "suit_mclaren.png",
                "Ferrari" => folder + "suit_ferrari.png",
                "Red Bull Racing" => folder + "RB_suit.png",
                "Mercedes" => folder + "suit_mercedes.png",
                "Aston Martin" => folder + "suit_astonmartin.png",
                "Alpine" => folder + "suit_alpine.png",
                "Haas" => folder + "suit_haas.png",
                "RB" => folder + "suit_rb.png",
                "Williams" => folder + "suit_williams1.png",
                "Cadillac" => folder + "suit_cadillac.png",
                "Audi" => folder + "suit_audi.png",
                "ART Grand Prix" => folder + "suit_art.png",
                "Invicta Racing" => folder + "suit_invicta.png",
                "MP Motorsport" => folder + "suit_mp.png",
                "Campos Racing" => folder + "suit_campos.png",
                "Rodin Motorsport" => folder + "suit_rodin.png",
                "DAMS Lucas Oil" => folder + "suit_dams.png",
                "Trident" => folder + "suit_trident.png",
                "Hitech" => folder + "suit_hitech.png",
                "Prema" => folder + "suit_prema.png",
                "Van Amersfoort Racing" => folder + "suit_var.png",
                "AIX Racing" => folder + "suit_aix.png",
                _ => folder + "suit_default.png"
            };
        }

        // --- F1 DRIVERS ---
        public static Drivers Lando_Norris = new Drivers { Name = "Lando Norris", Number = 4, PhotoPath = "/Images/norris.png", Skill = 95, Team = "McLaren" };
        public static Drivers Oscar_Piastri = new Drivers { Name = "Oscar Piastri", Number = 81, PhotoPath = "/Images/piastri.png", Skill = 92, Team = "McLaren" };
        public static Drivers Charles_Leclerc = new Drivers { Name = "Charles Leclerc", Number = 16, PhotoPath = "/Images/leclerc.png", Skill = 94, Team = "Ferrari" };
        public static Drivers Lewis_Hamilton = new Drivers { Name = "Lewis Hamilton", Number = 44, PhotoPath = "/Images/hamilton.png", Skill = 93, Team = "Ferrari" };
        public static Drivers Max_Verstappen = new Drivers { Name = "Max Verstappen", Number = 33, PhotoPath = "/Images/verstappen.png", Skill = 96, Team = "Red Bull Racing" };
        public static Drivers Isack_Hadjar = new Drivers { Name = "Isack Hadjar", Number = 6, PhotoPath = "/Images/hadjar.png", Skill = 80, Team = "Red Bull Racing" };
        public static Drivers George_Russell = new Drivers { Name = "George Russell", Number = 63, PhotoPath = "/Images/russell.png", Skill = 90, Team = "Mercedes" };
        public static Drivers Kimi_Antonelli = new Drivers { Name = "Kimi Antonelli", Number = 12, PhotoPath = "/Images/antonelli.png", Skill = 84, Team = "Mercedes" };
        public static Drivers Fernando_Alonso = new Drivers { Name = "Fernando Alonso", Number = 14, PhotoPath = "/Images/alonso.png", Skill = 88, Team = "Aston Martin" };
        public static Drivers Lance_Stroll = new Drivers { Name = "Lance Stroll", Number = 18, PhotoPath = "/Images/stroll.png", Skill = 78, Team = "Aston Martin" };
        public static Drivers Pierre_Gasly = new Drivers { Name = "Pierre Gasly", Number = 10, PhotoPath = "/Images/gasly.png", Skill = 85, Team = "Alpine" };
        public static Drivers Franco_Colapinto = new Drivers { Name = "Franco Colapinto", Number = 43, PhotoPath = "/Images/colapinto.png", Skill = 82, Team = "Alpine" };
        public static Drivers Oliver_Bearman = new Drivers { Name = "Oliver Bearman", Number = 87, PhotoPath = "/Images/bearman.png", Skill = 81, Team = "Haas" };
        public static Drivers Esteban_Ocon = new Drivers { Name = "Esteban Ocon", Number = 31, PhotoPath = "/Images/ocon.png", Skill = 83, Team = "Haas" };
        public static Drivers Liam_Lawson = new Drivers { Name = "Liam Lawson", Number = 30, PhotoPath = "/Images/lawson.png", Skill = 83, Team = "RB" };
        public static Drivers Arvid_Lindblad = new Drivers { Name = "Arvid Lindblad", Number = 41, PhotoPath = "/Images/lindblad.png", Skill = 79, Team = "RB" };
        public static Drivers Alex_Albon = new Drivers { Name = "Alex Albon", Number = 23, PhotoPath = "/Images/albon.png", Skill = 86, Team = "Williams" };
        public static Drivers Carlos_Sainz = new Drivers { Name = "Carlos Sainz", Number = 55, PhotoPath = "/Images/sainz.png", Skill = 91, Team = "Williams" };
        public static Drivers Valtteri_Bottas = new Drivers { Name = "Valtteri Bottas", Number = 77, PhotoPath = "/Images/bottas.png", Skill = 84, Team = "Cadillac" };
        public static Drivers Sergio_Perez = new Drivers { Name = "Sergio Perez", Number = 11, PhotoPath = "/Images/perez.png", Skill = 82, Team = "Cadillac" };
        public static Drivers Nico_Hulkenberg = new Drivers { Name = "Nico Hulkenberg", Number = 27, PhotoPath = "/Images/hulkenberg.png", Skill = 84, Team = "Audi" };
        public static Drivers Gabriel_Bortoleto = new Drivers { Name = "Gabriel Bortoleto", Number = 5, PhotoPath = "/Images/bortoleto.png", Skill = 80, Team = "Audi" };

        // --- F2 DRIVERS (Všetci majú default.png) ---
        public static Drivers Tasanapol_Inthraphuvasak = new Drivers { Name = "Tasanapol Inthraphuvasak", Number = 1, Team = "ART Grand Prix", Skill = 72, PhotoPath = "/Images/default.png" };
        public static Drivers Kush_Maini = new Drivers { Name = "Kush Maini", Number = 4, Team = "ART Grand Prix", Skill = 77, PhotoPath = "/Images/default.png" };
        public static Drivers Joshua_Duerksen = new Drivers { Name = "Joshua Dürksen", Number = 2, Team = "Invicta Racing", Skill = 75, PhotoPath = "/Images/default.png" };
        public static Drivers Rafael_Camara = new Drivers { Name = "Rafael Câmara", Number = 5, Team = "Invicta Racing", Skill = 78, PhotoPath = "/Images/default.png" };
        public static Drivers Oliver_Goethe = new Drivers { Name = "Oliver Goethe", Number = 3, Team = "MP Motorsport", Skill = 76, PhotoPath = "/Images/default.png" };
        public static Drivers Gabriele_Mini = new Drivers { Name = "Gabriele Minì", Number = 21, Team = "MP Motorsport", Skill = 78, PhotoPath = "/Images/default.png" };
        public static Drivers Nikola_Tsolov = new Drivers { Name = "Nikola Tsolov", Number = 6, Team = "Campos Racing", Skill = 74, PhotoPath = "/Images/default.png" };
        public static Drivers Noel_Leon = new Drivers { Name = "Noel León", Number = 7, Team = "Campos Racing", Skill = 74, PhotoPath = "/Images/default.png" };
        public static Drivers Alex_Dunne = new Drivers { Name = "Alex Dunne", Number = 8, Team = "Rodin Motorsport", Skill = 73, PhotoPath = "/Images/default.png" };
        public static Drivers Martinius_Stenshorne = new Drivers { Name = "Martinius Stenshorne", Number = 9, Team = "Rodin Motorsport", Skill = 72, PhotoPath = "/Images/default.png" };
        public static Drivers Dino_Beganovic = new Drivers { Name = "Dino Beganovic", Number = 10, Team = "DAMS Lucas Oil", Skill = 77, PhotoPath = "/Images/default.png" };
        public static Drivers Roman_Bilinski = new Drivers { Name = "Roman Bilinski", Number = 12, Team = "DAMS Lucas Oil", Skill = 70, PhotoPath = "/Images/default.png" };
        public static Drivers Laurens_Van_Hoepen = new Drivers { Name = "Laurens van Hoepen", Number = 11, Team = "Trident", Skill = 73, PhotoPath = "/Images/default.png" };
        public static Drivers Nixon_Bennett = new Drivers { Name = "Nixon Bennett", Number = 17, Team = "Trident", Skill = 68, PhotoPath = "/Images/default.png" };
        public static Drivers Ritomo_Miyata = new Drivers { Name = "Ritomo Miyata", Number = 13, Team = "Hitech", Skill = 75, PhotoPath = "/Images/default.png" };
        public static Drivers Colton_Herta = new Drivers { Name = "Colton Herta", Number = 14, Team = "Hitech", Skill = 82, PhotoPath = "/Images/default.png" };
        public static Drivers Sebastian_Montoya = new Drivers { Name = "Sebastian Montoya", Number = 15, Team = "Prema", Skill = 71, PhotoPath = "/Images/default.png" };
        public static Drivers Mari_Boya = new Drivers { Name = "Mari Boya", Number = 22, Team = "Prema", Skill = 72, PhotoPath = "/Images/default.png" };
        public static Drivers Rafael_Villagomez = new Drivers { Name = "Rafael Villagómez", Number = 16, Team = "Van Amersfoort Racing", Skill = 70, PhotoPath = "/Images/default.png" };
        public static Drivers Nicolas_Varrone = new Drivers { Name = "Nicolás Varrone", Number = 19, Team = "Van Amersfoort Racing", Skill = 71, PhotoPath = "/Images/default.png" };
        public static Drivers Emerson_Fittipaldi = new Drivers { Name = "Emerson Fittipaldi Jr.", Number = 18, Team = "AIX Racing", Skill = 76, PhotoPath = "/Images/default.png" };
        public static Drivers Devlin_Shields = new Drivers { Name = "Devlin Shields", Number = 20, Team = "AIX Racing", Skill = 67, PhotoPath = "/Images/default.png" };

        public static List<Drivers> GetAllDrivers()
        {
            return new List<Drivers>
            {
                Max_Verstappen, Lando_Norris, Charles_Leclerc, Lewis_Hamilton, Oscar_Piastri,
                Carlos_Sainz, George_Russell, Fernando_Alonso, Alex_Albon, Pierre_Gasly,
                Valtteri_Bottas, Nico_Hulkenberg, Kimi_Antonelli, Esteban_Ocon, Liam_Lawson,
                Franco_Colapinto, Sergio_Perez, Colton_Herta, Oliver_Bearman, Isack_Hadjar,
                Gabriel_Bortoleto, Arvid_Lindblad, Lance_Stroll,
                Tasanapol_Inthraphuvasak, Kush_Maini, Joshua_Duerksen, Rafael_Camara,
                Oliver_Goethe, Gabriele_Mini, Nikola_Tsolov, Noel_Leon, Alex_Dunne,
                Martinius_Stenshorne, Dino_Beganovic, Roman_Bilinski, Laurens_Van_Hoepen,
                Nixon_Bennett, Ritomo_Miyata, Sebastian_Montoya, Mari_Boya,
                Rafael_Villagomez, Nicolas_Varrone, Emerson_Fittipaldi, Devlin_Shields
            };
        }
    }
}