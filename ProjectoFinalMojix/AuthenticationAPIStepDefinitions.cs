using Gherkin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SpecFlow.Internal.Json;
using System;
using System.Net;
using System.Text.Json.Nodes;
using TechTalk.SpecFlow;

namespace ProjectoFinalMojix
{
    [Binding]
    public class AuthenticationAPIStepDefinitions
    {
        RestClient client = new RestClient(Utils.baseURL);
        RestRequest request = new RestRequest("/api/authenticate", Method.Post);
        String json = "";

        [Given(@"A value user ""([^""]*)"" and value password ""([^""]*)""")]
        public void GivenAValueUserAndValuePassword(string username, string password)
        {
            json = "{\r\n  \"username\": \"" + username + "\",\r\n  \"password\": \"" + password + "\"\r\n}";
        }

        [When(@"I send a request to login")]
        public void WhenISendARequestToLogin()
        {
            request.AddStringBody(json, ContentType.Json);
        }

        [Then(@"I expect a token value")]
        public void ThenIExpectATokenValue()
        {
            var response = client.Execute(request);
            string jsonString = JsonConvert.SerializeObject(response.Content);
            dynamic jsonObject = JObject.Parse(response.Content!);
            Utils.token = jsonObject.token;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
