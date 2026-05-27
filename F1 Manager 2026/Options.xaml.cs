using F1_Manager_2026.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace F1_Manager_2026
{
    public partial class Options : Window
    {
        public bool isplaying = true;
        public static MediaPlayer soundPlayer = new MediaPlayer();

        private List<string> playlist;
        private int currentTrackIndex = 0;
        private Functions functions = new Functions();

        public Options()
        {
            InitializeComponent();
            playlist = functions.GetMusicList();
            PlayCurrentTrack();

            if (Music_Visualizer != null) Music_Visualizer.Play();

            UpdateVolumeButtonIcon();

            // Bezpečné načítanie náhľadu uloženej kariéry
            LoadCareerPreview();
        }

        private void LoadCareerPreview()
        {
            try
            {
                if (File.Exists("SaveGameF1MNGR.json"))
                {
                    SaveGame.Load();
                    var db = Database.Instance;

                    if (db != null && db.PlayerTeamInstance != null)
                    {
                        // 1. Naplnenie informačnej karty dátami zo save-u
                        SavedTeamName_Label.Text = db.PlayerTeamInstance.teamName.ToUpper();
                        SavedSeason_Label.Text = $"CURRENT STATUS: DAY {db.CurrentDayInfo.Day}";
                        SavedBudget_Label.Text = $"${db.PlayerTeamInstance.Budget:N0}";

                        // Detekcia nasledujúcich pretekov
                        var nextTrack = db.CurrentDayInfo.NextUpcomingRace;
                        if (nextTrack != null)
                        {
                            SavedNextRace_Label.Text = $"{nextTrack.CountryCode} (Rnd {nextTrack.Round})";
                        }
                        else
                        {
                            SavedNextRace_Label.Text = "FINISHED";
                        }

                        // 2. Aktivácia auta vybraného tímu na pozadí, ak cesta existuje
                        if (!string.IsNullOrEmpty(db.PlayerTeamInstance.PathToCar))
                        {
                            DynamicCar_Image.Source = new BitmapImage(new Uri(db.PlayerTeamInstance.PathToCar, UriKind.RelativeOrAbsolute));
                            DynamicCar_Image.Visibility = Visibility.Visible;

                            // Skryjeme predvolený obrázok Backgrounf_Image pre úsporu pamäte
                            Backgrounf_Image.Visibility = Visibility.Collapsed;
                        }

                        // 3. Načítanie loga tímu do hornej lišty
                        if (!string.IsNullOrEmpty(db.PlayerTeamInstance.logopath))
                        {
                            TeamLogo_Image.Source = new BitmapImage(new Uri(db.PlayerTeamInstance.logopath, UriKind.RelativeOrAbsolute));
                        }

                        // Zobrazenie celého informačného panelu
                        ContinueInfo_Card.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    // Ak neexistuje save, ukážeme predvolený Backgrounf_Image
                    ContinueInfo_Card.Visibility = Visibility.Collapsed;
                    DynamicCar_Image.Visibility = Visibility.Collapsed;
                    Backgrounf_Image.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                // Poistka pri neočakávanom poškodení štruktúry JSON súboru
                ContinueInfo_Card.Visibility = Visibility.Collapsed;
                Backgrounf_Image.Visibility = Visibility.Visible;
            }
        }

        // PARALLAX EFEKT: Výpočet pohybu pozadia podľa súradníc myšky
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            // Získame aktuálnu pozíciu myšky voči oknu
            Point mousePos = e.GetPosition(this);

            // Centrujeme hodnoty okolo stredu obrazovky (od -0.5 do 0.5)
            double percentX = (mousePos.X / this.ActualWidth) - 0.5;
            double percentY = (mousePos.Y / this.ActualHeight) - 0.5;

            // Maximálny posun v pixeloch (30px je ideálna hodnota, aby to netrhalo oči)
            double maxMoveDistance = 30;

            // Výsledný jemný protipohyb
            double moveX = -percentX * maxMoveDistance;
            double moveY = -percentY * maxMoveDistance;

            // Aplikujeme posun na viditeľný obrázok pozadia
            if (Backgrounf_Image.Visibility == Visibility.Visible)
            {
                BackgroundTranslate.X = moveX;
                BackgroundTranslate.Y = moveY;
            }
            else if (DynamicCar_Image.Visibility == Visibility.Visible)
            {
                DynamicCarTranslate.X = moveX;
                DynamicCarTranslate.Y = moveY;
            }
        }

        private void PlayCurrentTrack()
        {
            try
            {
                if (playlist != null && playlist.Count > 0)
                {
                    soundPlayer.Open(new Uri(playlist[currentTrackIndex], UriKind.RelativeOrAbsolute));
                    soundPlayer.Play();
                    if (Song_Title_Label != null)
                    {
                        string name = Path.GetFileNameWithoutExtension(playlist[currentTrackIndex]);
                        Song_Title_Label.Text = name.Replace("_", " ").ToUpper();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba pri prehrávaní hudby: " + ex.Message);
            }
        }

        private void UpdateVolumeButtonIcon()
        {
            var volumeImg = Volume_Button.Template.FindName("Volume_Icon", Volume_Button) as Image;
            if (volumeImg != null)
            {
                string imageName = isplaying ? "volume_on.png" : "volume_off.png";
                volumeImg.Source = new BitmapImage(new Uri($"pack://application:,,,/Images/{imageName}"));
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) // Zvuk ON/OFF
        {
            functions.Button_Effect();
            if (isplaying)
            {
                soundPlayer.Stop();
                isplaying = false;
                if (Music_Visualizer != null) Music_Visualizer.Pause();
            }
            else
            {
                PlayCurrentTrack();
                isplaying = true;
                if (Music_Visualizer != null) Music_Visualizer.Play();
            }
            UpdateVolumeButtonIcon();
        }

        private void Next_Song_Button_Click(object sender, RoutedEventArgs e)
        {
            functions.Button_Effect();
            currentTrackIndex++;
            if (currentTrackIndex >= playlist.Count) currentTrackIndex = 0;

            PlayCurrentTrack();
            isplaying = true;
            UpdateVolumeButtonIcon();
            if (Music_Visualizer != null) Music_Visualizer.Play();
        }

        private void Career_Create_Button_Click(object sender, RoutedEventArgs e)
        {
            SaveGame.DeleteSave();
            Database.Instance = new Database();
            Database.Instance.CurrentDayInfo.Day = 1;
            Picking_Team.Main_TeamChoosing _TeamChoosing = new Picking_Team.Main_TeamChoosing();
            _TeamChoosing.Show();
            this.Close();
        }

        private void Continue_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("SaveGameF1MNGR.json"))
            {
                MessageBox.Show("Nemáš vytvorený žiaden save!", "Warning!!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SaveGame.Load();
            MainCareerMenu mainCareerMenu = new MainCareerMenu();
            mainCareerMenu.Show();
            soundPlayer.Stop();
            this.Close();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Continue_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            functions.Button_Effect();
        }

        private void WaveRepeat(object sender, RoutedEventArgs e)
        {
            Music_Visualizer.Position = TimeSpan.FromSeconds(0);
            Music_Visualizer.Play();
        }
    }
}