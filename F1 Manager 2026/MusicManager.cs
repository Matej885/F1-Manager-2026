using System.Windows.Media;

public static class MusicManager
{
    private static MediaPlayer mediaPlayer = new MediaPlayer();
    private static List<string> playlist;
    private static int currentTrackIndex = 0;
    private static bool isInitialized = false;

    public static void Initialize(List<string> tracks)
    {
        if (isInitialized) return; // Inicializujeme len raz za celú hru
        playlist = tracks;
        mediaPlayer.MediaEnded += (s, e) => PlayNext();
        isInitialized = true;
        Play();
    }

    public static void Play()
    {
        if (playlist == null || playlist.Count == 0) return;
        mediaPlayer.Open(new Uri(playlist[currentTrackIndex], UriKind.RelativeOrAbsolute));
        mediaPlayer.Play();
    }

    public static void PlayNext()
    {
        currentTrackIndex = (currentTrackIndex + 1) % playlist.Count;
        Play();
    }

    public static void SetVolume(double volume) => mediaPlayer.Volume = volume;
    public static double GetVolume() => mediaPlayer.Volume;

    // Metóda na získanie názvu aktuálnej skladby pre UI
    public static string GetCurrentTrackName()
    {
        if (playlist == null) return "";
        return System.IO.Path.GetFileNameWithoutExtension(playlist[currentTrackIndex]).Replace("_", " ").ToUpper();
    }
}