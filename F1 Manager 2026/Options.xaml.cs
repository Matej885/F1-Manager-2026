using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace F1_Manager_2026
{
    /// <summary>
    /// Hlavné nastavenia hry, hráč si tu nastaví preferencie kým sa dostane do herného menu
    /// 
    /// </summary>
    public partial class Options : Window
    {
        public bool isplaying = true;
        public SoundPlayer soundPlayer;
        public Options()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = "Sounds/Options_Soundtrack.wav";
            soundPlayer.PlayLooping();
            options_Media_Element.Play();
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/volume_on.png"));
            Volume_Button.Background = brush;
        }

        private void MediaRepeat(object sender, RoutedEventArgs e) //aby sa video po skončení spustilo znova
        {
            // 1. Vráti video na začiatok
            options_Media_Element.Position = TimeSpan.FromSeconds(0);

            // 2. Znova ho spustí
            options_Media_Element.Play();
        }

        private void Continue_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Keď bude load system tak ti to načíta hru basically");
        }

        private void Career_Create_Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("Images/New_Career_Photo_2.jpg", UriKind.Relative));
            imageBrush.Stretch = Stretch.UniformToFill;

            Career_Create_Button.Background = imageBrush;
            MessageBox.Show("Keď bude load system tak ti to loadne hru");
        }

        private void Career_Create_Button_Click(object sender, RoutedEventArgs e)
        {
            Picking_Team.Main_TeamChoosing _TeamChoosing = new Picking_Team.Main_TeamChoosing();
            _TeamChoosing.Show();
            this.Close();
        }

        

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (isplaying == true)
            {
                isplaying = false;
                ImageBrush brush = new ImageBrush();
                soundPlayer.Stop();
                brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/volume_off.png"));
                Volume_Button.Background = brush;
            }
            else if (isplaying == false)
            {
                isplaying= true;
                ImageBrush brush = new ImageBrush();
                soundPlayer.PlayLooping();
                brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/volume_on.png"));
                Volume_Button.Background = brush;

                soundPlayer = new SoundPlayer();
                soundPlayer.SoundLocation = "Sounds/Options_Soundtrack.wav";
                soundPlayer.PlayLooping();
            }
        }
    }

}
