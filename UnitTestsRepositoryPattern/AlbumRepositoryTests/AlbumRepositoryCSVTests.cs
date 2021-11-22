using RepositoryExercise;
using RepositoryExercise.Repositories;
using System.IO;
using System.Linq;
using Xunit;

namespace UnitTestsRepositoryPattern
{
    public class AlbumRepositoryCSVTests
    {
        private readonly string path = "..\\..\\..\\CSV TestFiles\\AlbumTest.csv";
        private readonly AlbumRepositoryCSV albumRepository;
        private const string deleteMessage= "Album deleted successfully";
        private const string updateMessage= "Album updated";

        public AlbumRepositoryCSVTests()
        {
            albumRepository = new(path);

        }
        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        public void GetAlbumById_ReturnAlbumWithSameId(int targetId)
        {
            //Act
            var album = albumRepository.GetAlbumById(targetId);

            //Assert
            Assert.Equal(album.Id, targetId);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void GetAlbumById_ReturnAlbumNull(int tagertId)
        {
            //Act
            var album = albumRepository.GetAlbumById(tagertId);

            //Assert
            Assert.Null(album);
        }

        [Theory]
        [InlineData("Chris Crone")]
        [InlineData("Bob Dylan")]
        public void GetAlbumByArtist_ReturnAlbumWithSameArtist(string targetArtist)
        {
            //Act
            var albums = albumRepository.GetAlbumByArtist(targetArtist);

            //Assert
            Assert.Equal(albums.ElementAt(0).Artist, targetArtist);
        }

        [Theory]
        [InlineData("ana are gogosi")]
        [InlineData("veselie")]
        public void GetAlbumByArtist_ReturnEmptyListAlbumsWithArtistNotFound(string targetArtist)
        {
            //Act
            var albums = albumRepository.GetAlbumByArtist(targetArtist);

            //Assert
            Assert.Empty(albums);
        }


        [Theory]
        [InlineData("Turn me on")]
        [InlineData("Purple Rain")]
        public void GetAlbumByTitle_ReturnAlbumWithSameTitle(string targetTitle)
        {
            //Act
            var albums = albumRepository.GetAlbumByTitle(targetTitle);

            //Assert
            Assert.Equal(albums.ElementAt(0).Title, targetTitle);
        }

        [Theory]
        [InlineData("asfva")]
        [InlineData("czxvxz")]
        public void GetAlbumByTitle_ReturnNullListAlbumWithSpecifiedTitleNotFound(string targetTitle)
        {
            //Act
            var albums = albumRepository.GetAlbumByTitle(targetTitle);

            //Assert
            Assert.Empty(albums);
        }



        [Theory]
        [ClassData(typeof(AlbumRepositoryTestDataInsert))]
        public void InsertAlbum_GetByIdReturnsInsertedAlbum(Album albumToInsert)
        {
            //Arrange
            albumRepository.InsertAlbum(albumToInsert);

            //Act
            var album = albumRepository.GetAlbumById(albumToInsert.Id);

            //Assert
            Assert.Equal(album.Id, albumToInsert.Id);
        }


        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void DeleteAlbum_ReturnsCorrectMessage(int tagertId)
        {
            //Act
            string message =albumRepository.DeleteAlbum(tagertId);

            //Assert
            Assert.Equal(deleteMessage,message);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void DeleteAlbum_AlbumWithThatIdNotInTheCurrentContext(int tagertId)
        {
            //Act
            string message = albumRepository.DeleteAlbum(tagertId);

            //Assert
            Assert.NotEqual(deleteMessage, message);
        }

        [Theory]
        [InlineData(2,"Title","Gigel")]
        [InlineData(3,"Artist","Dorel")]
        public void UpdateAlbum_ReturnsCorrectMessage(int tagertId,string property,string value)
        {
            //Act
            string message = albumRepository.UpdateAlbum(tagertId,property,value);

            //Assert
            Assert.Equal(updateMessage, message);
        }

        [Theory]
        [InlineData(10, "Title", "Gigel")]
        [InlineData(20, "Artist", "Dorel")]
        public void UpdateAlbum_AlbumWithThatIdNotInTheCurrentContext(int tagertId, string property, string value)
        {
            //Act
            string message = albumRepository.UpdateAlbum(tagertId, property, value);

            //Assert
            Assert.NotEqual(updateMessage, message);
        }


        [Theory]
        [InlineData("..\\..\\..\\CSV TestFilesSave\\","AlbumTest")]
        public void SaveAlbum_FileSavedProperly(string pathSave,string fileName)
        {
            //Act
            var newFileName=albumRepository.Save(pathSave,fileName);

            //Assert
            Assert.True(File.Exists(pathSave+newFileName+".csv"));
        }
    }
}
