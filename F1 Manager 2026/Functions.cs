using System;
using System.Collections.Generic;
using System.Windows.Media;

public class Functions
{
    // Musíme vytvoriť prehrávač TU (ako field), aby nezanikol po skončení funkcie
    private MediaPlayer effectPlayer = new MediaPlayer();
    public List<string> GetMusicList()
    {
        string musicPath = "Sounds/";
        return new List<string>
        {
            musicPath + "Bad As I Used To Be - Chris Stapleton.wav",
            musicPath + "The Chain - Fleetwood Mac.wav",
            musicPath + "More Than A Feeling - Boston.wav",
            musicPath + "Fortunate Son - Creedence Clearwater Revival.wav",
            musicPath + "Real Gone - Sheryl Crow.wav",
            musicPath + "Formula 1 Theme - Brian Tyler.wav",
            musicPath + "Down Under - Men At Work.wav",
        };
    }

    public void Button_Effect()
    {
        // 1. MediaPlayer nepoužíva .Source =, ale .Open()
        // 2. Potrebuje Uri objekt, nie iba string
        effectPlayer.Open(new Uri("Sounds/On_Button.wav", UriKind.Relative));

        // Vrátime zvuk na začiatok, ak by sa klikalo rýchlo po sebe
        effectPlayer.Position = TimeSpan.Zero;
        effectPlayer.Volume = 0.5;
        effectPlayer.Play();
    }
}