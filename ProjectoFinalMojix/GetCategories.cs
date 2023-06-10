using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace ProjectoFinalMojix
{
    [Binding]
    public class GetCategories
    {
        RestClient client = new RestClient(Utils.baseURL);
        RestRequest request = new RestRequest();
        RestResponse response = new RestResponse();

        [Given(@"I have a valid API endpoint for retrieving categories")]
        public void GivenIHaveAValidAPIEndpointForRetrievingCategories()
        {
            request = new RestRequest("/api/category", Method.Get);
        }

        [When(@"I send a GET request to the API endpoint")]
        public void WhenISendAGETRequestToTheAPIEndpoint()
        {
            response = client.ExecuteGet(request);
        }

        [Then(@"I should receive a successful response")]
        public void ThenIShouldReceiveASuccessfulResponse()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
