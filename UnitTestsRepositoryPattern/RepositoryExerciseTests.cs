using RepositoryExercise;
using System.IO;
using System.Linq;
using Xunit;

namespace UnitTestsRepositoryPattern
{
    public class RepositoryExerciseTests
    {
        private readonly string path = "..\\..\\..\\AlbumTest.csv";
        private readonly AlbumRepository albumRepository;
        private const string deleteMessage= "Album deleted successfully";
        private const string updateMessage= "Album updated";

        public RepositoryExerciseTests()
        {
            albumRepository = new(path);
        }
        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        public void GetAlbumById_ReturnAlbumWithSameId(int targetId)
        {
            var album = albumRepository.GetAlbumById(targetId);

            Assert.Equal(album.Id, targetId);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void GetAlbumById_ReturnAlbumNull(int tagertId)
        {
            var album = albumRepository.GetAlbumById(tagertId);

            Assert.Null(album);
        }

        [Theory]
        [InlineData("Chris Crone")]
        [InlineData("Bob Dylan")]
        public void GetAlbumByArtist_ReturnAlbumWithSameArtist(string targetArtist)
        {
            var albums = albumRepository.GetAlbumByArtist(targetArtist);

            Assert.Equal(albums.ElementAt(0).Artist, targetArtist);
        }

        [Theory]
        [InlineData("ana are gogosi")]
        [InlineData("veselie")]
        public void GetAlbumByArtist_ReturnEmptyListAlbumsWithArtistNotFound(string targetArtist)
        {
            var albums = albumRepository.GetAlbumByArtist(targetArtist);

            Assert.Empty(albums);
        }


        [Theory]
        [InlineData("Turn me on")]
        [InlineData("Purple Rain")]
        public void GetAlbumByTitle_ReturnAlbumWithSameTitle(string targetTitle)
        {
            var albums = albumRepository.GetAlbumByTitle(targetTitle);

            Assert.Equal(albums.ElementAt(0).Title, targetTitle);
        }

        [Theory]
        [InlineData("asfva")]
        [InlineData("czxvxz")]
        public void GetAlbumByTitle_ReturnNullListAlbumWithSpecifiedTitleNotFound(string targetTitle)
        {
            var albums = albumRepository.GetAlbumByTitle(targetTitle);

            Assert.Empty(albums);
        }



        [Theory]
        [ClassData(typeof(RepositoryTestData))]
        public void InsertAlbum_GetByIdReturnsInsertedAlbum(Album albumToInsert)
        {
            albumRepository.InsertAlbum(albumToInsert);

            var album = albumRepository.GetAlbumById(albumToInsert.Id);

            Assert.Equal(album.Id, albumToInsert.Id);
        }


        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void DeleteAlbum_ReturnsCorrectMessage(int tagertId)
        {
            string message=albumRepository.DeleteAlbum(tagertId);


            Assert.Equal(deleteMessage,message);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void DeleteAlbum_AlbumWithThatIdNotInTheCurrentContext(int tagertId)
        {
            string message = albumRepository.DeleteAlbum(tagertId);

            Assert.NotEqual(deleteMessage, message);
        }

        [Theory]
        [InlineData(2,"Title","Gigel")]
        [InlineData(3,"Artist","Dorel")]
        public void UpdateAlbum_ReturnsCorrectMessage(int tagertId,string property,string value)
        {
            string message = albumRepository.UpdateAlbum(tagertId,property,value);


            Assert.Equal(updateMessage, message);
        }

        [Theory]
        [InlineData(10, "Title", "Gigel")]
        [InlineData(20, "Artist", "Dorel")]
        public void UpdateAlbum_AlbumWithThatIdNotInTheCurrentContext(int tagertId, string property, string value)
        {
            string message = albumRepository.UpdateAlbum(tagertId, property, value);


            Assert.NotEqual(updateMessage, message);
        }

        [Fact]
        public void SaveAlbum_FileSavedProperly()
        {

            var pathSave = "..\\..\\..\\AlbumsSave.csv";

            albumRepository.Save(pathSave);

            Assert.True(File.Exists(pathSave));
        }

    }
}
