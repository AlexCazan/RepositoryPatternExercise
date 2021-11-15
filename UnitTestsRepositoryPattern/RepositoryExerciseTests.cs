using RepositoryExercise;
using System.IO;
using System.Linq;
using Xunit;

namespace UnitTestsRepositoryPattern
{
    public class RepositoryExerciseTests
    {
        private readonly string Path = "..\\..\\..\\AlbumTest.csv";
        private readonly AlbumRepository AlbumRepository;
        private const string DeleteMessage= "Album deleted successfully";
        private const string UpdateMessage= "Album updated";

        public RepositoryExerciseTests()
        {
            AlbumRepository = new(Path);
        }
        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        public void GetAlbumById_ReturnAlbumWithSameId(int targetId)
        {
            var album = AlbumRepository.GetAlbumById(targetId);

            Assert.Equal(album.Id, targetId);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void GetAlbumById_ReturnAlbumNull(int tagertId)
        {
            var album = AlbumRepository.GetAlbumById(tagertId);

            Assert.Null(album);
        }

        [Theory]
        [InlineData("Chris Crone")]
        [InlineData("Bob Dylan")]
        public void GetAlbumByArtist_ReturnAlbumWithSameArtist(string targetArtist)
        {
            var albums = AlbumRepository.GetAlbumByArtist(targetArtist);

            Assert.Equal(albums.ElementAt(0).Artist, targetArtist);
        }

        [Theory]
        [InlineData("ana are gogosi")]
        [InlineData("veselie")]
        public void GetAlbumByArtist_ReturnEmptyListAlbumsWithArtistNotFound(string targetArtist)
        {
            var albums = AlbumRepository.GetAlbumByArtist(targetArtist);

            Assert.Empty(albums);
        }


        [Theory]
        [InlineData("Turn me on")]
        [InlineData("Purple Rain")]
        public void GetAlbumByTitle_ReturnAlbumWithSameTitle(string targetTitle)
        {
            var albums = AlbumRepository.GetAlbumByTitle(targetTitle);

            Assert.Equal(albums.ElementAt(0).Title, targetTitle);
        }

        [Theory]
        [InlineData("asfva")]
        [InlineData("czxvxz")]
        public void GetAlbumByTitle_ReturnNullListAlbumWithSpecifiedTitleNotFound(string targetTitle)
        {
            var albums = AlbumRepository.GetAlbumByTitle(targetTitle);

            Assert.Empty(albums);
        }



        [Theory]
        [ClassData(typeof(RepositoryTestData))]
        public void InsertAlbum_GetByIdReturnsInsertedAlbum(Album albumToInsert)
        {
            AlbumRepository.InsertAlbum(albumToInsert);

            var album = AlbumRepository.GetAlbumById(albumToInsert.Id);

            Assert.Equal(album.Id, albumToInsert.Id);
        }


        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void DeleteAlbum_ReturnsCorrectMessage(int tagertId)
        {
            string message=AlbumRepository.DeleteAlbum(tagertId);


            Assert.Equal(DeleteMessage,message);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void DeleteAlbum_AlbumWithThatIdNotInTheCurrentContext(int tagertId)
        {
            string message = AlbumRepository.DeleteAlbum(tagertId);

            Assert.NotEqual(DeleteMessage, message);
        }

        [Theory]
        [InlineData(2,"Title","Gigel")]
        [InlineData(3,"Artist","Dorel")]
        public void UpdateAlbum_ReturnsCorrectMessage(int tagertId,string property,string value)
        {
            string message = AlbumRepository.UpdateAlbum(tagertId,property,value);


            Assert.Equal(UpdateMessage, message);
        }

        [Theory]
        [InlineData(10, "Title", "Gigel")]
        [InlineData(20, "Artist", "Dorel")]
        public void UpdateAlbum_AlbumWithThatIdNotInTheCurrentContext(int tagertId, string property, string value)
        {
            string message = AlbumRepository.UpdateAlbum(tagertId, property, value);


            Assert.NotEqual(UpdateMessage, message);
        }

        [Fact]
        public void SaveAlbum_FileSavedProperly()
        {

            var pathSave = "..\\..\\..\\AlbumsSave.csv";

            AlbumRepository.Save(pathSave);

            Assert.True(File.Exists(pathSave));
        }

    }
}
