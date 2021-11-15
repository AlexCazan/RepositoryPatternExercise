using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RepositoryExercise
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly List<Album> albums=new();
        public AlbumRepository(string path)
        {
                using (var reader = new StreamReader(path))
                {
                    string headerLine = reader.ReadLine();
                    string s;
                    while ((s = reader.ReadLine()) != null)
                    {
                        
                        albums.Add(Album.Parse(s));

                    }
                }
        }
        public IEnumerable<Album> GetAlbums()
        {
            return albums;
        }

        public Album GetAlbumById(int albumId)
        {
            var album = albums.FirstOrDefault(x => x.Id == albumId);
            return album;
        }
        public IEnumerable<Album> GetAlbumByArtist(string artist)
        {
            var albumsByArtist=albums.Where(x => x.Artist==artist).ToList();
            return albumsByArtist;
        }
        public IEnumerable<Album> GetAlbumByTitle(string title)
        {
            var albumsByTitle = albums.Where(x => x.Title == title).ToList();
            return albumsByTitle;
        }
        public void InsertAlbum(Album album)
        {
            album.Id = albums.Last().Id + 1;
            albums.Add(album);
        }

        public string DeleteAlbum(int albumId)
        {
            Album albumToDelete = GetAlbumById(albumId);
            if(albumToDelete==null)
            {
                return "Album with that id doesn't exist";
            }
            else
            {
                albums.Remove(albumToDelete);
                return "Album deleted successfully";
            }
            
        }

        public string  UpdateAlbum(int id,string property,string value)
        {
            Album albumToUpdate=GetAlbumById(id);
            if(albumToUpdate==null)
            {
                return "Album with that id doesn't exist";
            }
            else if (property == "Artist")
            {
                albumToUpdate.Artist = value;
            }
            else 
            {
                albumToUpdate.Title = value;
            }
            return "Album updated";
        }

        public void Save(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine("Id,Artist,Title,Year,Genre,Sales,Owned,Record Label");
                foreach (var album in albums)
                {
                    writer.WriteLine(album.ToString());
                }
            }
        }
    }
}
