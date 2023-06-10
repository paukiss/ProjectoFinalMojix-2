using RestSharp.Authenticators.OAuth2;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using SpecFlow.Internal.Json;
using RestSharp.Authenticators;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Gherkin;

namespace ProjectoFinalMojix
{
    [Binding]
    public class PostProductStepDefinitions
    {
        RestClient client = new RestClient();
        RestRequest request = new RestRequest();
        RestResponse response = new RestResponse();
        String json = "";

        [Given(@"I have a valid API endpoint for creating a product")]
        public void GivenIHaveAValidAPIEndpointForCreatingAProduct()
        {
            client = new RestClient(Utils.baseURL);
            request = new RestRequest("/api/product", Method.Post);
            request.AddHeader("Authorization", "Bearer " + Utils.token);
        }

        [Given(@"I have the necessary data to create a product")]
        public void GivenIHaveTheNecessaryDataToCreateAProduct()
        {
            json = "{\"name\":\"Purple Glasses\",\"description\":\"Purple Glasses\",\"image\":\"purple-glasses.jpg\",\"price\":\"19.99\",\"categoryId\":7}";
            request.AddStringBody(json, ContentType.Json);
        }

        [When(@"I send a POST request to the API endpoint with the product data")]
        public void WhenISendAPOSTRequestToTheAPIEndpointWithTheProductData()
        {
            response = client.ExecutePost(request);
            Console.WriteLine(response.Content);
        }

        [Then(@"I should receive a successfully response")]
        public void ThenIShouldReceiveASuccessfullyResponse()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Then(@"the response should contain the created product details")]
        public void ThenTheResponseShouldContainTheCreatedProductDetails()
        {
            string jsonString = JsonConvert.SerializeObject(response.Content);
            dynamic jsonObject = JObject.Parse(response.Content!);
            Assert.IsNotNull(jsonObject.id);
        }

        [Then(@"the product should be successfully created in the system")]
        public void ThenTheProductShouldBeSuccessfullyCreatedInTheSystem()
        {
            dynamic jsonObject = JObject.Parse(response.Content!);
            int productId = jsonObject.id;
            bool productExists = VerifyProductExists(productId);
            Assert.IsTrue(productExists, "The product was not successfully created in the system.");
        }

        private bool VerifyProductExists(int productId)
        {
            return productId >= 0;
        }
    }
}
