using System.IO;
using DataReader.JSON.Interfaces;

namespace DataReader.JSON
{
    public class JSONFileLoader : IJSONLoader
    {
        private readonly string _filePath;

        public JSONFileLoader(string filePath)
        {
            _filePath = filePath;
        }

        public string LoadFile()
        {
            return File.ReadAllTextAsync(_filePath).Result;
        }

    }
}
