using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace RepositoryExercise.Repositories
{
    public class AlbumRepositoryXML : AlbumRepository
    {
        private readonly XmlSerializer xmlSerializer = new(typeof(List<Album>), new XmlRootAttribute("Albums"));
        public AlbumRepositoryXML(string pathXML)
        {
            using (StreamReader streamReader = new(pathXML))
            {
                albums = (List<Album>)xmlSerializer.Deserialize(streamReader);
            }
        }
        public override void Save(string path)
        {
            using (StreamWriter streamWriter = new(path))
            {
                xmlSerializer.Serialize(streamWriter, albums);
            }
        }
    }
}
