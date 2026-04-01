using F1_Manager_2026.Race_Simulation;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace F1_Manager_2026.Picking_Team
{
    public partial class Avatar_Pick : Window
    {
        private string? tempSelectedPath;
        // Ak máš v triede Functions tie zvuky, uisti sa, že sú public
        Functions functions = new Functions();

        public Avatar_Pick()
        {
            InitializeComponent();

            // 1. Nastavenie mena hráča
            if (Database.Instance?.PlayerTeamInstance != null)
            {
                string name = Database.Instance.PlayerTeamInstance.PlayerName;
                PlayerNameDisplay.Text = string.IsNullOrEmpty(name) ? "MANAGER" : name.ToUpper();

                // Načítanie obleku tímu hneď pri štarte
                string? suitPath = Database.Instance.PlayerTeamInstance.teamclothespath;
                if (!string.IsNullOrEmpty(suitPath))
                {
                    try
                    {
                        PreviewSuit.Source = new BitmapImage(new Uri(suitPath, UriKind.RelativeOrAbsolute));
                    }
                    catch { /* Cesta k obrázku neexistuje */ }
                }
            }

            // 2. Naplnenie zoznamu avatarov
            // Uisti sa, že Database.Instance.Avatars nie je null
            if (Database.Instance?.Avatars != null)
            {
                AvatarsItemsControl.ItemsSource = Database.Instance.Avatars;
            }
        }

        private void AvatarCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Pozor: Tu musíš presne trafiť typ, ktorý máš v zozname (Database.PlayerAvatar)
            if (sender is Border b && b.DataContext is Database.PlayerAvatar vybrany)
            {
                if (!string.IsNullOrEmpty(vybrany.PhotoPath))
                {
                    try
                    {
                        PreviewHead.Source = new BitmapImage(new Uri(vybrany.PhotoPath, UriKind.RelativeOrAbsolute));
                        tempSelectedPath = vybrany.PhotoPath;
                        functions.Button_Effect(); // Zvuk kliknutia
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chyba pri načítaní hlavy: " + ex.Message);
                    }
                }
            }
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            functions.Button_Effect();

            if (!string.IsNullOrEmpty(tempSelectedPath))
            {
                if (Database.Instance?.PlayerTeamInstance != null)
                {
                    Database.Instance.PlayerTeamInstance.playerphotopath = tempSelectedPath;
                    Race_Simulation_Test raceSim = new Race_Simulation_Test();
                    raceSim.Show();
                    Calendar calendar = new Calendar();
                    calendar.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select your avatar head first!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Card_MouseEnter(object sender, MouseEventArgs e)
        {
            // Sem môžeš dať zvuk pre hover, ak ho máš v Functions
            // functions.Hover_Effect(); 

            if (sender is Border b)
            {
                b.BorderBrush = Brushes.Red;
                b.BorderThickness = new Thickness(2); // 3 bolo možno priveľa, skús 2
                b.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            }
        }

        private void Card_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border b)
            {
                b.BorderBrush = new SolidColorBrush(Color.FromRgb(51, 51, 51));
                b.BorderThickness = new Thickness(1);
                b.Background = new SolidColorBrush(Color.FromRgb(26, 26, 26));
            }
        }
    }
}