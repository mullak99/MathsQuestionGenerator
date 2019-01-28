using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;

public class Utils
{
    protected static SoundPlayer _memePlayer;

    public static void downloadAndPlayEasterEgg()
    {
        if (!Directory.Exists(Path.Combine(Path.GetTempPath(), "mullak99", "MQG"))) Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "mullak99", "MQG"));


        if (!File.Exists(Path.Combine(Path.GetTempPath(), "mullak99", "MQG", "lord.wav")))
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile("http://gaben.mullak99.co.uk/CS2.wav", Path.Combine(Path.GetTempPath(), "mullak99", "MQG", "lord.wav"));
            }
        }

        _memePlayer = new SoundPlayer(Path.Combine(Path.GetTempPath(), "mullak99", "MQG", "lord.wav"));
        _memePlayer.PlayLooping();
    }

    public static void stopEasterEgg()
    {
        _memePlayer.Stop();
    }
}
