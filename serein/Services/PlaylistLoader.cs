using serein.Models;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using TagLib; 

namespace serein.Services
{
    public class PlaylistLoader
    {

        public static List<Song> LoadSongs(string folder)
        {
           
            string[] files = Directory.GetFiles(folder, "*.mp3");
            List<Song> songs = new();

            foreach (string file in files)
            {
                Song song = MetadataService.ReadMetadata(file);
                songs.Add(song);
            }


            return songs;
        }
    }

}
