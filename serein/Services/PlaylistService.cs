using serein.Models;
using System.IO;

namespace serein.Services
{
    public class PlaylistService
    {
        private static readonly string[] AllowedExtensions = { ".mp3", ".m4a" };
        public static List<Song> LoadSongs(string folder)
        {
            List<Song> songs = new();

            foreach(string file in Directory.EnumerateFiles(folder)) {
                string ext = Path.GetExtension(file);

                if (AllowedExtensions.Contains(ext, StringComparer.OrdinalIgnoreCase))
                 {
                    songs.Add(MetadataService.ReadMetadata(file));
                }
            }

            return songs;
        }
    }

}
