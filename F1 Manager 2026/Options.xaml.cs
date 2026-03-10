using System;
using System.Collections.Generic;
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
        public Options()
        {
            InitializeComponent();
            SoundPlayer soundPlayer = new SoundPlayer("Sounds/Options_Soundtrack.wav");
            soundPlayer.PlayLooping();
            options_Media_Element.Play();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test test = new Test();
            test.Show();
        }
    }

}
