using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using F1_Manager_2026.Menu; // Pridané pre prácu s Image
using System.IO;

namespace F1_Manager_2026
{
    public partial class Options : Window
    {
        public bool isplaying = true;
        public SoundPlayer soundPlayer;
        private List<string> playlist;
        private int currentTrackIndex = 0;
        private Functions functions = new Functions();
        Functions Functions = new Functions();
        public Options()
        {
            InitializeComponent();

            playlist = functions.GetMusicList();
            soundPlayer = new SoundPlayer();

            // Spustenie základných prvkov
            PlayCurrentTrack();

            // Spustenie videí (vlnovka a pozadie)
            Music_Visualizer.Play();
            options_Media_Element.Play();

            // Nastavenie počiatočnej ikony
            UpdateVolumeButtonIcon();
        }

        private void PlayCurrentTrack()
        {
            try
            {
                soundPlayer.SoundLocation = playlist[currentTrackIndex];
                soundPlayer.PlayLooping();

                if (Song_Title_Label != null)
                {
                    string name = System.IO.Path.GetFileNameWithoutExtension(playlist[currentTrackIndex]);
                    Song_Title_Label.Text = name.Replace("_", " ").ToUpper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba pri prehrávaní hudby: " + ex.Message);
            }
        }

        // --- HLAVNÁ ZMENA: Metóda na zmenu ikony ---
        private void UpdateVolumeButtonIcon()
        {
            // Keďže je Image vo vnútri ControlTemplate, musíme ho tam nájsť
            var volumeImg = Volume_Button.Template.FindName("Volume_Icon", Volume_Button) as Image;

            if (volumeImg != null)
            {
                // Určíme názov súboru podľa stavu isplaying
                string imageName = isplaying ? "volume_on.png" : "volume_off.png";

                // Vytvoríme novú cestu k obrázku (pack URI je najistejšia cesta vo WPF)
                volumeImg.Source = new BitmapImage(new Uri($"pack://application:,,,/Images/{imageName}"));
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) // Volume ON/OFF
        {
            functions.Button_Effect();
            if (isplaying)
            {
                soundPlayer.Stop();
                isplaying = false;
                Music_Visualizer.Pause();
            }
            else
            {
                PlayCurrentTrack();
                isplaying = true;
                Music_Visualizer.Play();
            }

            // Po každom kliknutí aktualizujeme ikonu
            UpdateVolumeButtonIcon();
        }

        // --- Ostatné metódy zostávajú rovnaké ---
        private void MediaRepeat(object sender, RoutedEventArgs e)
        {
            options_Media_Element.Position = TimeSpan.FromSeconds(0);
            options_Media_Element.Play();
        }

        private void WaveRepeat(object sender, RoutedEventArgs e)
        {
            Music_Visualizer.Position = TimeSpan.FromSeconds(0);
            Music_Visualizer.Play();
        }

        private void Next_Song_Button_Click(object sender, RoutedEventArgs e)
        {
            currentTrackIndex++;
            if (currentTrackIndex >= playlist.Count) currentTrackIndex = 0;

            if (isplaying)
            {
                PlayCurrentTrack();
            }
            else
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(playlist[currentTrackIndex]);
                Song_Title_Label.Text = name.Replace("_", " ").ToUpper();
            }
        }

        private void Career_Create_Button_Click(object sender, RoutedEventArgs e)
        {
            Picking_Team.Main_TeamChoosing _TeamChoosing = new Picking_Team.Main_TeamChoosing();
            _TeamChoosing.Show();
            this.Close();
        }

        private void Continue_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("save.json"))
            {
                MessageBox.Show("Nemas vytvoreny ziaden save", "Warning!!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Database.Instance = SaveGame.Load();
            MainCareerMenu mainCareerMenu = new MainCareerMenu();
            mainCareerMenu.Show();
            this.Close();
            
            
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Continue_Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Functions.Button_Effect();
        }
    }
}