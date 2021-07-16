using Api.DataFiles;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Api.Tests.Unit
{
    public class ApiTest
    {
        [Fact]
        public void RetrieveSingleFundByMarketCode()
        {
            //Arrange
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            //Act
            var fundId = JsonConvert
                .DeserializeObject<List<FundDetails>>(file)
                .Single(f => f.MarketCode == "SUNT")
                .Id
                .ToString();

            bool result = fundId == "7f62a638-9c7a-4445-869d-ddd35d1ce40c";

            //Assert
            Assert.True(result, "The correct object is being returned");
        }

        [Fact]
        public void RetrieveTwoFundsByMarketCode()
        {
            //Arrange
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            //Act
            var fundCount = JsonConvert
                .DeserializeObject<List<FundDetails>>(file)
                .Where(f => f.MarketCode == "EA")
                .ToList()
                .Count();

            bool result = fundCount == 2;

            //Assert
            Assert.True(result, "The correct number of objects are being returned");
        }

        [Fact]
        public void RetrieveAllFunds()
        {
            //Arrange
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            //Act
            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);
            bool result = funds.Count == 15;

            //Assert
            Assert.True(result, "All funds are being returned");
        }

        [Fact]
        public void RetrieveAllFundsByFundManager()
        {
            //Arrange
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            //Act
            var fundCount = JsonConvert
                .DeserializeObject<List<FundDetails>>(file)
                .Where(f => f.FundManager == "Comtract")
                .ToList()
                .Count();
            bool result = fundCount == 1;

            //Assert
            Assert.True(result, "All funds are being returned");
        }
    }
}
