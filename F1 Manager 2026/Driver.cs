using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager_2026
{
    public class Driver
    {
        private string? _team;
        public string? Name { get; set; }
        public int Number { get; set; }
        public string? PhotoPath { get; set; }
        public string?   SuitPath { get; private set; }
        public int Skill { get; set; }
        public int Cost { get; set; }

        public string? Team
        {
            get => _team;
            set
            {
                _team = value;
                UpdateSuitPath();
            }
        }

        public string FormattedCost
        {
            get
            {
                double costValue = (Skill - 60) * 0.8;
                return "COST: $" + costValue.ToString("F1") + "M";
            }
        }

        private void UpdateSuitPath()
        {
            string folder = "/Images/";
            if (_team == null) { SuitPath = folder + "suit_default.png"; return; }

            SuitPath = _team switch
            {
                "McLaren" => folder + "suit_mclaren.png",
                "Ferrari" => folder + "suit_ferrari.png",
                "Red Bull Racing" => folder + "RB_suit.png",
                "Mercedes" => folder + "suit_mercedes.png",
                "Aston Martin" => folder + "suit_astonmartin.png",
                "Alpine" => folder + "suit_alpine.png",
                "Haas" => folder + "suit_haas.png",
                "RB" => folder + "suit_RBJ.png",
                "Williams" => folder + "suit_williams1.png",
                "Cadillac" => folder + "suit_cadillac.png",
                "Audi" => folder + "suit_audi.png",
                "Siemens Racing F1 Team" => folder + "suit_siemens.png",
                "Minardi F1 Team" => folder + "suit_minardi.png",
                "BMW Sauber F1 Team" => folder + "suit_bmw.png",
                "Alfa Romeo F1 Team" => folder + "suit_alfa.png",
                _ => folder + "suit_default.png"
            };
        }
    }
}
