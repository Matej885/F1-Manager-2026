using System.Media;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace F1_Manager_2026.Picking_Team
{
    /// <summary>
    /// Logika pre okno Drivers_Pick.xaml
    /// </summary>
    public partial class Drivers_Pick : Window
    {
        public Drivers_Pick()
        {
            InitializeComponent();
            LoadDataToUI();
            ResetMoney();
        }

        private void ResetMoney()
        {
            BudgetDisplay.Text = $"{Database.Instance.PlayerTeamInstance.Budget.ToString("N0")}$";
        }
        private void LoadDataToUI()
        {
            var allDrivers = Database.Instance.DriverList; 
            if (allDrivers != null)
                DriversItemsControl.ItemsSource = allDrivers;
        }

        private void DriverCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border kliknutyBorder && kliknutyBorder.DataContext is Driver kliknutyJazdec)
            {
                // 1. Získame názov tímu, ktorý sme si vybrali v MainMenu
                string mojTim = Database.Instance.PlayerTeamInstance.teamName;

                if (timesselected < 1)
                {
                    if (kliknutyJazdec.Cost > Database.Instance.PlayerTeamInstance.Budget)
                    {
                        MessageBox.Show($"Not enough money for: {kliknutyJazdec.Name}!", "Info", MessageBoxButton.OK, MessageBoxImage.Hand);
                        return;
                    }
                    else
                    {
                        MediaPlayer player = new MediaPlayer();
                        player.Open(new Uri("Sounds/signing.wav", UriKind.Relative));
                        player.Play();
                        Database.Instance.PlayerTeamInstance.Budget -= (decimal)kliknutyJazdec.Cost;
                        // 2. Nastavíme jazdcovi náš tím -> toto automaticky zmení SuitPath v triede Drivers
                        kliknutyJazdec.Team = mojTim;
                        // 3. Uložíme výber do globálneho stavu
                        Database.Instance.PlayerTeamInstance.driver1name = kliknutyJazdec.Name;
                        Database.Instance.PlayerTeamInstance.driver1rating = kliknutyJazdec.Skill;
                        Database.Instance.PlayerTeamInstance.driver1cost = kliknutyJazdec.Cost;
                        MessageBox.Show($"Jazdec {kliknutyJazdec.Name} úspešne podpísaný za {mojTim}!");
                        ResetMoney();
                        timesselected++;
                    }
                }
                else
                {
                    if (kliknutyJazdec.Cost > Database.Instance.PlayerTeamInstance.Budget)
                    {
                        MessageBox.Show($"Not enough money for: {kliknutyJazdec.Name}!", "Info", MessageBoxButton.OK, MessageBoxImage.Hand);
                        return;
                    }
                    else
                    {
                        MediaPlayer player = new MediaPlayer();
                        player.Open(new Uri("Sounds/signing.wav", UriKind.Relative));
                        player.Play();
                        Database.Instance.PlayerTeamInstance.Budget -= (decimal)kliknutyJazdec.Cost;
                        // 2. Nastavíme jazdcovi náš tím -> toto automaticky zmení SuitPath v triede Drivers
                        kliknutyJazdec.Team = mojTim;
                        // 3. Uložíme výber do globálneho stavu
                        Database.Instance.PlayerTeamInstance.driver2name = kliknutyJazdec.Name;
                        Database.Instance.PlayerTeamInstance.driver2rating = kliknutyJazdec.Skill;
                        Database.Instance.PlayerTeamInstance.driver2cost = kliknutyJazdec.Cost;
                        MessageBox.Show($"Jazdec {kliknutyJazdec.Name} úspešne podpísaný za {mojTim}!");
                        ResetMoney();
                        timesselected++;
                        MessageBox.Show("You have selected 2 drivers, you cannot select more!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                }
            }
        }

        // Táto metóda rieši Border pri vstupe myši
        private void DriverCard_MouseEnter(object sender, MouseEventArgs e)
        {
            // Pretypujeme sender na Border, aby sme k nemu mali prístup
            Border b = sender as Border;

            if (b != null)
            {
                // Nastavenie červeného okraja a hrúbky 4
                b.BorderBrush = Brushes.Red;
                b.BorderThickness = new Thickness(4);

                // Mierne zosvetlenie pozadia pre efekt "hover"
                b.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            }
        }

        // Táto metóda vráti Border do pôvodného stavu pri odchode myši
        private void DriverCard_MouseLeave(object sender, MouseEventArgs e)
        {
            Border b = sender as Border;

            if (b != null)
            {
                // Návrat k pôvodnej šedej farbe (#333333) a hrúbke 2
                b.BorderBrush = new SolidColorBrush(Color.FromRgb(51, 51, 51));
                b.BorderThickness = new Thickness(2);

                // Návrat k pôvodnému tmavému pozadiu (#1A1A1A)
                b.Background = new SolidColorBrush(Color.FromRgb(26, 26, 26));
            }
        }
        private void DriverCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 1. Získame Border, na ktorý sa kliklo (Poradil Gemini) ---
            Border kliknutyBorder = (Border)sender;

            // 2. Vytiahneme si jazdca, ktorý patrí k tejto karte (vďaka Bindingu)
            Drivers kliknutyJazdec = (Drivers)kliknutyBorder.DataContext;

            // 3. Získame si zoznam všetkých jazdcov, aby sme v nich mohli hľadať
            List<Drivers> vsetciJazdci = Drivers.GetAllDrivers();

            // 4. Vytvoríme si prázdnu premennú, kam si uložíme výsledok
            Drivers najdenyJazdec = null;

            // 5. Prejdeme všetkých jazdcov jedného po druhom
            foreach (Drivers j in vsetciJazdci)
            {
                // Hladame meno jazdca v liste podla zdroja Bindingu z borderu
                if (j.Name == kliknutyJazdec.Name)
                {
                    PlayerTeam playerTeam = new PlayerTeam
                    {
                        driver1name = j.Name,
                        driver1rating = j.Skill,
                    };
                    playerTeam.driver1cost = j.Cost;
                    j.Team = playerTeam.teamName;
                    Drivers drivers = new Drivers();
                    Drivers_Pick pick = new Drivers_Pick();
                    pick.Show();
                    this.Close();
                    MessageBox.Show($"Vybral si jazdca: {playerTeam.driver1name} s ratingom {playerTeam.driver1rating}!");
                }
                else
                {
                    // Ak nie, pokračujeme v hľadaní ďalšieho jazdca
                    continue;
                }
            }
        }
    }
}