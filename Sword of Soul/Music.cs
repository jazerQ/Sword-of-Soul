using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sword_of_Soul
{
    internal class Music
    {
        private MediaPlayer _mediaPlayer = new MediaPlayer();
        private List<string> _playlist = new List<string> { "C:\\Users\\user\\source\\repos\\Sword of Soul\\Sword of Soul\\music\\The-Pyre(chosic.com).mp3", "C:\\Users\\user\\source\\repos\\Sword of Soul\\Sword of Soul\\music\\Ale-and-Anecdotes-MP3(chosic.com).mp3" };
        private int currentTrackIndex = 0;
        public Music()
        {
            _mediaPlayer.MediaEnded += _mediaPlayer_MediaEnded;
        }
        
        private void _mediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            currentTrackIndex++;
            if(currentTrackIndex >= _playlist.Count)
            {
                currentTrackIndex = 0;
            }
            PlayCurrentTrack();
        }

        public void PlayCurrentTrack()
        {
            _mediaPlayer.Open(new Uri(_playlist[currentTrackIndex]));
            _mediaPlayer.Play();

        }
    }
}
