using RepositoryExercise.Repositories;
using System.IO;
using Xunit;

namespace UnitTestsRepositoryPattern
{
    public class AlbumRepositoryXMLTests
    {
        private readonly string path = "..\\..\\..\\XML TestFiles\\AlbumTest.xml";
        private readonly AlbumRepositoryXML albumRepository;

        public AlbumRepositoryXMLTests()
        {
            albumRepository = new(path);

        }

        [Theory]
        [InlineData("..\\..\\..\\XML TestFilesSave\\", "AlbumTest")]
        public void SaveAlbum_FileSavedProperly(string pathSave, string fileName)
        {
            //Act
            var newFileName = albumRepository.Save(pathSave, fileName);

            //Assert
            Assert.True(File.Exists(pathSave + newFileName + ".xml"));
        }
    }
}
