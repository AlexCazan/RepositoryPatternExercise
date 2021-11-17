using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryExercise.Repositories
{
    public abstract class AlbumRepository : IAlbumRepository
    {
        public List<Album> albums = new();
        public IEnumerable<Album> GetAlbums()
        {
            return albums;
        }

        public Album GetAlbumById(int albumId)
        {
            return albums.FirstOrDefault(x => x.Id == albumId);
        }
        public IEnumerable<Album> GetAlbumByArtist(string artist)
        {
            return albums.Where(x => x.Artist == artist).ToList();
        }
        public IEnumerable<Album> GetAlbumByTitle(string title)
        {
            return albums.Where(x => x.Title == title).ToList();
        }
        public void InsertAlbum(Album album)
        {
            album.Id = albums.Last().Id + 1;
            albums.Add(album);
        }

        public string DeleteAlbum(int albumId)
        {
            Album albumToDelete = GetAlbumById(albumId);
            if (albumToDelete == null)
            {
                return "Album with that id doesn't exist";
            }
            else
            {
                albums.Remove(albumToDelete);
                return "Album deleted successfully";
            }

        }

        public string UpdateAlbum(int id, string property, string value)
        {
            Album albumToUpdate = GetAlbumById(id);
            if (albumToUpdate == null)
            {
                return "Album with that id doesn't exist";
            }
            else if (property == "Artist")
            {
                albumToUpdate.Artist = value;
            }
            else if (property == "Title")
            {
                albumToUpdate.Title= value;
            }
            else if (property == "Year")
            {
                albumToUpdate.Year = Int32.Parse(value);
            }
            else if (property == "Genre")
            {
                albumToUpdate.Genre = value;
            }
            else if (property == "Sales")
            {
                albumToUpdate.Sales = Int32.Parse(value);
            }
            else if (property == "Owned")
            {
                albumToUpdate.Owned= bool.Parse(value);
            }
            else
            {
                albumToUpdate.RecordLabel= value;
            }
            return "Album updated";
        }

        public abstract void Save(string path);
    }

}
