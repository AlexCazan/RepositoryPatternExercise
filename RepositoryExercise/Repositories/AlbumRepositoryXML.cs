using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        public override void Save(string path,string fileName)
        {
            string fileNameSave = String.Format("{0}__{1}", fileName + "_UpdatedAt", DateTime.Now.ToString("yyyyMMddhhmmss"));
            var sb = new StringBuilder(path);
            sb.Append(fileNameSave).Append(".xml");
            using (StreamWriter streamWriter = new(sb.ToString()))
            {
                xmlSerializer.Serialize(streamWriter, albums);
            }
        }
    }
}
