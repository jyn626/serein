using Accessibility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows.Media;
using wxpmplayer.Models;

namespace wxpmplayer.Services
{
    public class AudioPlayer
    {

        private readonly MediaPlayer _player;
        public bool isPaused = false;
        public AudioPlayer()
        {
            _player = new MediaPlayer();
        }

        public void Play(Song song)
        {
            if (isPaused)
            {
                isPaused = false;
                _player.Play();
                return;
            }

            _player.Open(new Uri(song.FilePath));
            _player.Play();
        }

        public void Resume()
        {
            _player.Play();
        }

        public void Pause()
        {
            isPaused = true;
            _player.Pause();
        }

        public void Stop()
        {
            _player.Stop();
        }

        public double GetPlaybackPositionInSeconds()
        {
            return _player.Position.TotalSeconds;
        }

        public void SetPlaybackPosition(double value)
        {
            _player.Position = TimeSpan.FromSeconds(value);
        }
    }
}
