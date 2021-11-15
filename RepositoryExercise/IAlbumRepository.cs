using System.Collections.Generic;

namespace RepositoryExercise
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> GetAlbums();
        Album GetAlbumById(int albumId);
        IEnumerable<Album> GetAlbumByArtist(string artist);
        IEnumerable<Album> GetAlbumByTitle(string title);
        void InsertAlbum(Album album);
        string DeleteAlbum(int albumId);
        string UpdateAlbum(int id,string property,string value);
        void Save(string path);

    }
}
