using System.Collections.Generic;
using Api.Common;
using Api.Models;
using DataReader.JSON.Interfaces;
using Newtonsoft.Json;

namespace DataReader.JSON
{
    class JSONReader : IFundsProvider
    {
        public IJSONLoader FileLoader { get; set; }
        
        public JSONReader(string filePath, string fileName)
        {
            FileLoader = new JSONFileLoader(filePath + fileName);
        }

        public List<FundsProperties> GetFunds()
        {
            var file = FileLoader.LoadFile();
            var funds = JsonConvert.DeserializeObject<List<FundsProperties>>(file);

            return funds;
        }


    }
}
