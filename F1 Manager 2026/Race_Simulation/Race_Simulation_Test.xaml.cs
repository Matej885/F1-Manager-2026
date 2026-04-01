using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace F1_Manager_2026.Race_Simulation
{
    public partial class Race_Simulation_Test : Window
    {
        // Trieda pre riadok v tabuľke výsledkov
        public class RaceResultRow
        {
            public int Position { get; set; }
            public string Name { get; set; } = "";
            public double AvgPos { get; set; }
        }

        public Race_Simulation_Test()
        {
            InitializeComponent();
        }

        private void StartSim_Click(object sender, RoutedEventArgs e)
        {
            var db = Database.Instance;
            var rnd = new Random();

            // Dictionary na ukladanie súčtu pozícií pre každého jazdca
            Dictionary<string, double> positionSums = new Dictionary<string, double>();
            var allDrivers = db.DriverList.ToList();

            // Počet opakovaní simulácie pre získanie stabilného priemeru
            int totalSimulations = 50;

            for (int sim = 0; sim < totalSimulations; sim++)
            {
                List<string> currentRaceOrder = new List<string>();
                var availableDrivers = new List<Driver>(allDrivers);

                while (availableDrivers.Count > 0)
                {
                    double totalWeight = 0;
                    var weights = new Dictionary<string, double>();

                    foreach (var d in availableDrivers)
                    {
                        var team = db.F1Teams.FirstOrDefault(t => t.Name == d.Team);
                        int teamPower = (team != null) ? team.Rating : 0;

                        // 1. Základný výkon: Schopnosť jazdca + Sila auta
                        double basePerformance = d.Skill + teamPower;

                        // 2. Náhoda (Luck Factor): rozptyl 0.8 až 1.2
                        double luck = rnd.Next(80, 121) / 100.0;

                        // 3. Finálna váha: Umocnenie na 1.8 pre reálnejšie rozdiely
                        double finalWeight = Math.Pow(basePerformance * luck, 1.8);

                        weights[d.Name] = finalWeight;
                        totalWeight += finalWeight;
                    }

                    // Logika "Váženého žrebovania" (Ruleta)
                    double draw = rnd.NextDouble() * totalWeight;
                    double cumulativeWeight = 0;
                    Driver selectedDriver = availableDrivers.Last();

                    foreach (var d in availableDrivers)
                    {
                        cumulativeWeight += weights[d.Name];
                        if (draw <= cumulativeWeight)
                        {
                            selectedDriver = d;
                            break;
                        }
                    }

                    currentRaceOrder.Add(selectedDriver.Name);
                    availableDrivers.Remove(selectedDriver);
                }

                // Po skončení jedných pretekov pripočítame dosiahnuté pozície (i + 1)
                for (int i = 0; i < currentRaceOrder.Count; i++)
                {
                    string name = currentRaceOrder[i];
                    if (!positionSums.ContainsKey(name)) positionSums[name] = 0;
                    positionSums[name] += (i + 1);
                }
            }

            // SPRACOVANIE VÝSLEDKOV:
            // 1. Vypočítame surový priemer a zoradíme od najlepšieho (najnižšie číslo)
            var sortedStats = positionSums
                .Select(kvp => new
                {
                    Name = kvp.Key,
                    RawAvg = kvp.Value / totalSimulations
                })
                .OrderBy(s => s.RawAvg)
                .ToList();

            // 2. Mapujeme na finálnu triedu RaceResultRow a priradíme vizuálnu pozíciu
            var finalResults = new List<RaceResultRow>();
            for (int i = 0; i < sortedStats.Count; i++)
            {
                finalResults.Add(new RaceResultRow
                {
                    Position = i + 1, // Tu sa nastaví 1, 2, 3... namiesto 0
                    Name = sortedStats[i].Name,
                    AvgPos = Math.Round(sortedStats[i].RawAvg, 2)
                });
            }

            // 3. Zobrazenie v ListView
            ResultsListView.ItemsSource = finalResults;
        }
    }
}