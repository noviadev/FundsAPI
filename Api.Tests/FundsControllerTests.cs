using System.Net;
using NUnit.Framework;
using RestSharp;

namespace Api.Tests
{
    public class Tests
    {
        private RestClient _client;
        private string _url = "http://localhost:8122/";

        [SetUp]
        public void Setup()
        {
            _client = new RestClient(_url);
        }

        
        [Test]
        public void FundsController_GetFunds_StatusCodeOK()
        {
            //Arrange
            var request = new RestRequest("get-funds", Method.GET);

            //Act
            IRestResponse response = _client.Execute(request);
            
            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void FundsController_GetSingleFund_StatusCodeOK()
        {
            //Arrange
            var request = new RestRequest("get-fund/LABORUM", Method.GET);

            //Act
            IRestResponse response = _client.Execute(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }


        [Test]
        public void FundsController_GetManagerFunds_StatusCodeOK()
        {
            //Arrange
            var request = new RestRequest("get-managerfunds/Isotrack", Method.GET);

            //Act
            IRestResponse response = _client.Execute(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }


    }
}