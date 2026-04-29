using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using F1_Manager_2026.Menu; // Pridané pre prácu s Image
using System.IO;
using Microsoft.Win32;

namespace F1_Manager_2026
{
    public partial class Options : Window
    {
        public bool isplaying = true;
        // Public static aby sme k nemu mali prístup z iných okien pri zatváraní
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
            if (options_Media_Element != null) options_Media_Element.Play();

            UpdateVolumeButtonIcon();
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
                        string name = System.IO.Path.GetFileNameWithoutExtension(playlist[currentTrackIndex]);
                        Song_Title_Label.Text = name.Replace("_", " ").ToUpper();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba: " + ex.Message);
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

        // --- EVENTY VOLANÉ Z XAML ---

        private void Button_Click_4(object sender, RoutedEventArgs e) // Volume ON/OFF
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
            Picking_Team.Main_TeamChoosing _TeamChoosing = new Picking_Team.Main_TeamChoosing();
            _TeamChoosing.Show();
            this.Close();
        }

        private void Continue_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("SaveGameF1MNGR.json"))
            {
                MessageBox.Show("Nemas vytvoreny ziaden save", "Warning!!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SaveGame.Load();            
            var db = Database.Instance;  
            MainCareerMenu mainCareerMenu = new MainCareerMenu();
            mainCareerMenu.Show();
            soundPlayer.Stop();
            this.Close();
            
            
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Continue_Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            functions.Button_Effect();
        }

        // --- OPAKOVANIE VIDEÍ ---

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
    }
}