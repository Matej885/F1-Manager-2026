using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Ink; // Potrebné pre prácu s InkCanvas (podpisom)

namespace F1_Manager_2026.Picking_Team
{
    public partial class Final_Window : Window
    {
        public Final_Window()
        {
            InitializeComponent();

            // Načítame dáta hneď pri štarte okna
            LoadContractData();
        }

        private void LoadContractData()
        {
            // Získame dáta z tvojej databázy (Singleton inštancia)
            var team = Database.Instance.PlayerTeamInstance;

            // 1. MANUÁLNE NAPLNENIE TEXTOV (Bez bindingu)
            TxtTeamName.Text = team.teamName?.ToUpper() ?? "UNKNOWN TEAM";
            TxtManagerName.Text = team.PlayerName ?? "TEAM MANAGER";
            TxtBudget.Text = team.Budget.ToString("N0") + " $";

            // Dáta jazdca 1
            TxtDriver1Name.Text = team.driver1name ?? "DRIVER 1";
            TxtDriver1Rating.Text = team.driver1rating.ToString();

            // Dáta jazdca 2
            TxtDriver2Name.Text = team.driver2name ?? "DRIVER 2";
            TxtDriver2Rating.Text = team.driver2rating.ToString();

            // 2. MANUÁLNE NAČÍTANIE OBRÁZKOV (Prevod stringov na BitmapImage)
            try
            {
                // Logo alebo auto tímu
                if (!string.IsNullOrEmpty(team.PathToCar))
                {
                    ImgTeamLogo.Source = new BitmapImage(new Uri(team.PathToCar, UriKind.RelativeOrAbsolute));
                }

                // Tímové oblečenie (Suit) - aplikujeme na oboch jazdcov
                if (!string.IsNullOrEmpty(team.suitpath))
                {
                    BitmapImage suitImg = new BitmapImage(new Uri(team.teamclothespath, UriKind.RelativeOrAbsolute));
                    ImgDriver1Suit.Source = suitImg;
                    ImgDriver2Suit.Source = suitImg;
                }

                // Fotka jazdca 1
                if (!string.IsNullOrEmpty(team.PathToDriver1))
                {
                    ImgDriver1Face.Source = new BitmapImage(new Uri(team.PathToDriver1, UriKind.RelativeOrAbsolute));
                }

                // Fotka jazdca 2
                if (!string.IsNullOrEmpty(team.PathToDriver2))
                {
                    ImgDriver2Face.Source = new BitmapImage(new Uri(team.PathToDriver2, UriKind.RelativeOrAbsolute));
                }
            }
            catch (Exception ex)
            {
                // Výpis chyby do Debug okna, ak by nejaká cesta k obrázku nefungovala
                System.Diagnostics.Debug.WriteLine("Chyba pri priraďovaní obrázkov: " + ex.Message);
            }
        }


        private void ClearSignature_Click(object sender, RoutedEventArgs e)
        {
            SignatureCanvas.Strokes.Clear();
        }

        private void BtnContinue_Click(object sender, RoutedEventArgs e)
        {
            // Kontrola, či hráč reálne niečo nakreslil na InkCanvas
            if (SignatureCanvas.Strokes.Count == 0)
            {
                return;
            }

            // Úspešné podpísanie
            MessageBox.Show("Kontrakt bol úspešne podpísaný! Vitajte v sezóne 2026.",
                            "F1 Manager 2026",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
            Application.Current.Shutdown();
        }
    }
}