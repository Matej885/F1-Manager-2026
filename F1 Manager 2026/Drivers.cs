using System;
using System.Collections.Generic;
using System.Text;
using static F1_Manager_2026.Drivers;

namespace F1_Manager_2026
{
    public class Drivers
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string PhotoPath { get; set; } // Cesta k obrázku v Resources
        public int Skill { get; set; }
        public string Team { get; set; }

        // McLAREN
        public static Drivers Lando_Norris = new Drivers { Name = "Lando Norris", Number = 4, PhotoPath = "/Images/Drivers/norris.png", Skill = 95, Team = "McLaren" };
        public static Drivers Oscar_Piastri = new Drivers { Name = "Oscar Piastri", Number = 81, PhotoPath = "/Images/Drivers/piastri.png", Skill = 92, Team = "McLaren" };

        // FERRARI
        public static Drivers Charles_Leclerc = new Drivers { Name = "Charles Leclerc", Number = 16, PhotoPath = "/Images/Drivers/leclerc.png", Skill = 94, Team = "Ferrari" };
        public static Drivers Lewis_Hamilton = new Drivers { Name = "Lewis Hamilton", Number = 44, PhotoPath = "/Images/Drivers/hamilton.png", Skill = 93, Team = "Ferrari" };

        // RED BULL RACING
        public static Drivers Max_Verstappen = new Drivers { Name = "Max Verstappen", Number = 33, PhotoPath = "/Images/Drivers/verstappen.png", Skill = 96, Team = "Red Bull Racing" };
        public static Drivers Isack_Hadjar = new Drivers { Name = "Isack Hadjar", Number = 6, PhotoPath = "/Images/Drivers/hadjar.png", Skill = 80, Team = "Red Bull Racing" };

        // MERCEDES
        public static Drivers George_Russell = new Drivers { Name = "George Russell", Number = 63, PhotoPath = "/Images/Drivers/russell.png", Skill = 90, Team = "Mercedes" };
        public static Drivers Kimi_Antonelli = new Drivers { Name = "Kimi Antonelli", Number = 12, PhotoPath = "/Images/Drivers/antonelli.png", Skill = 84, Team = "Mercedes" };

        // ASTON MARTIN
        public static Drivers Fernando_Alonso = new Drivers { Name = "Fernando Alonso", Number = 14, PhotoPath = "/Images/Drivers/alonso.png", Skill = 88, Team = "Aston Martin" };
        public static Drivers Lance_Stroll = new Drivers { Name = "Lance Stroll", Number = 18, PhotoPath = "/Images/Drivers/stroll.png", Skill = 78, Team = "Aston Martin" };

        // ALPINE
        public static Drivers Pierre_Gasly = new Drivers { Name = "Pierre Gasly", Number = 10, PhotoPath = "/Images/Drivers/gasly.png", Skill = 85, Team = "Alpine" };
        public static Drivers Franco_Colapinto = new Drivers { Name = "Franco Colapinto", Number = 43, PhotoPath = "/Images/Drivers/colapinto.png", Skill = 82, Team = "Alpine" };

        // HAAS
        public static Drivers Oliver_Bearman = new Drivers { Name = "Oliver Bearman", Number = 87, PhotoPath = "/Images/Drivers/bearman.png", Skill = 81, Team = "Haas" };
        public static Drivers Esteban_Ocon = new Drivers { Name = "Esteban Ocon", Number = 31, PhotoPath = "/Images/Drivers/ocon.png", Skill = 83, Team = "Haas" };

        // RB (Racing Bulls)
        public static Drivers Liam_Lawson = new Drivers { Name = "Liam Lawson", Number = 30, PhotoPath = "/Images/Drivers/lawson.png", Skill = 83, Team = "RB" };
        public static Drivers Arvid_Lindblad = new Drivers { Name = "Arvid Lindblad", Number = 41, PhotoPath = "/Images/Drivers/lindblad.png", Skill = 79, Team = "RB" };

        // WILLIAMS
        public static Drivers Alex_Albon = new Drivers { Name = "Alex Albon", Number = 23, PhotoPath = "/Images/Drivers/albon.png", Skill = 86, Team = "Williams" };
        public static Drivers Carlos_Sainz = new Drivers { Name = "Carlos Sainz", Number = 55, PhotoPath = "/Images/Drivers/sainz.png", Skill = 91, Team = "Williams" };

        // CADILLAC
        public static Drivers Valtteri_Bottas = new Drivers { Name = "Valtteri Bottas", Number = 77, PhotoPath = "/Images/Drivers/bottas.png", Skill = 84, Team = "Cadillac" };
        public static Drivers Sergio_Perez = new Drivers { Name = "Sergio Perez", Number = 11, PhotoPath = "/Images/Drivers/perez.png", Skill = 82, Team = "Cadillac" };

        // AUDI
        public static Drivers Nico_Hulkenberg = new Drivers { Name = "Nico Hulkenberg", Number = 27, PhotoPath = "/Images/Drivers/hulkenberg.png", Skill = 84, Team = "Audi" };
        public static Drivers Gabriel_Bortoleto = new Drivers { Name = "Gabriel Bortoleto", Number = 5, PhotoPath = "/Images/Drivers/bortoleto.png", Skill = 80, Team = "Audi" };

        /// F2 -------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // ART GRAND PRIX
        public static Drivers Tasanapol_Inthraphuvasak = new Drivers { Name = "Tasanapol Inthraphuvasak", Number = 1, Team = "ART Grand Prix", Skill = 72 };
        public static Drivers Kush_Maini = new Drivers { Name = "Kush Maini", Number = 4, Team = "ART Grand Prix", Skill = 77 };

        // INVICTA RACING
        public static Drivers Joshua_Duerksen = new Drivers { Name = "Joshua Dürksen", Number = 2, Team = "Invicta Racing", Skill = 75 };
        public static Drivers Rafael_Camara = new Drivers { Name = "Rafael Câmara", Number = 5, Team = "Invicta Racing", Skill = 78 };

        // MP MOTORSPORT
        public static Drivers Oliver_Goethe = new Drivers { Name = "Oliver Goethe", Number = 3, Team = "MP Motorsport", Skill = 76 };
        public static Drivers Gabriele_Mini = new Drivers { Name = "Gabriele Minì", Number = 21, Team = "MP Motorsport", Skill = 78 };

        // CAMPOS RACING
        public static Drivers Nikola_Tsolov = new Drivers { Name = "Nikola Tsolov", Number = 6, Team = "Campos Racing", Skill = 74 };
        public static Drivers Noel_Leon = new Drivers { Name = "Noel León", Number = 7, Team = "Campos Racing", Skill = 74 };

        // RODIN MOTORSPORT
        public static Drivers Alex_Dunne = new Drivers { Name = "Alex Dunne", Number = 8, Team = "Rodin Motorsport", Skill = 73 };
        public static Drivers Martinius_Stenshorne = new Drivers { Name = "Martinius Stenshorne", Number = 9, Team = "Rodin Motorsport", Skill = 72 };

        // DAMS LUCAS OIL
        public static Drivers Dino_Beganovic = new Drivers { Name = "Dino Beganovic", Number = 10, Team = "DAMS Lucas Oil", Skill = 77 };
        public static Drivers Roman_Bilinski = new Drivers { Name = "Roman Bilinski", Number = 12, Team = "DAMS Lucas Oil", Skill = 70 };

        // TRIDENT
        public static Drivers Laurens_Van_Hoepen = new Drivers { Name = "Laurens van Hoepen", Number = 11, Team = "Trident", Skill = 73 };
        public static Drivers Nixon_Bennett = new Drivers { Name = "Nixon Bennett", Number = 17, Team = "Trident", Skill = 68 };

        // HITECH
        public static Drivers Ritomo_Miyata = new Drivers { Name = "Ritomo Miyata", Number = 13, Team = "Hitech", Skill = 75 };
        public static Drivers Colton_Herta = new Drivers { Name = "Colton Herta", Number = 14, Team = "Hitech", Skill = 82 };

        // PREMA
        public static Drivers Sebastian_Montoya = new Drivers { Name = "Sebastian Montoya", Number = 15, Team = "Prema", Skill = 71 };
        public static Drivers Mari_Boya = new Drivers { Name = "Mari Boya", Number = 22, Team = "Prema", Skill = 72 };

        // VAN AMERSFOORT RACING (VAR)
        public static Drivers Rafael_Villagomez = new Drivers { Name = "Rafael Villagómez", Number = 16, Team = "Van Amersfoort Racing", Skill = 70 };
        public static Drivers Nicolas_Varrone = new Drivers { Name = "Nicolás Varrone", Number = 19, Team = "Van Amersfoort Racing", Skill = 71 };

        // AIX RACING
        public static Drivers Emerson_Fittipaldi = new Drivers { Name = "Emerson Fittipaldi Jr.", Number = 18, Team = "AIX Racing", Skill = 76 };
        public static Drivers Devlin_Shields = new Drivers { Name = "Devlin Shields", Number = 20, Team = "AIX Racing", Skill = 67 };

    }
}
