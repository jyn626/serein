using serein.Models;
using System.IO;

namespace serein.Services
{
    public class PlaylistService
    {

        public static List<Song> LoadSongs(string folder)
        {
            // TODO: look for better ways to include two file types.
            string[] m4aFiles= Directory.GetFiles(folder, "*.m4a");
            string[] mp3Files= Directory.GetFiles(folder, "*.mp3");

            // songs list will stores mp3 and m4a files
            // a list of `Song` object.
            List<Song> songs = new();

            // iterate over m4a and mp3s and add them each in the songs list
            foreach (var mp3 in mp3Files) {
                // ReadMetadata returns Song(model) object containing title, filepath, artist, album image?, and duration.
                Song song = MetadataService.ReadMetadata(mp3);
                songs.Add(song);
            }
            foreach (var m4a in m4aFiles)
            {
                Song song = MetadataService.ReadMetadata(m4a);
                songs.Add(song);
            }

            return songs;
        }
    }

}
