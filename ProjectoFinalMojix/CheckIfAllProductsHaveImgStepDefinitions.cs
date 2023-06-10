using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using System.Xml.Linq;

namespace ProjectoFinalMojix
{
    [Binding]
    public class CheckIfAllProductsHaveImgStepDefinitions
    {
        RestClient client = new RestClient(Utils.baseURL);
        RestRequest request = new RestRequest();
        RestResponse response = new RestResponse();
        List<Object> myObjects;

        [Given(@"I have a valid API endpoint to retrieve all products")]
        public void GivenIHaveAValidAPIEndpointToRetrieveAllProducts()
        {
            request = new RestRequest("/api/product", Method.Post);
        }

        [When(@"I send a GET request to the endpoint")]
        public void WhenISendAGETRequestToTheEndpoint()
        {
            response = client.ExecuteGet(request);
        }

        [Then(@"I should receive a successful response with content")]
        public void ThenIShouldReceiveASuccessfulResponseWithContent()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Then(@"the response should contain a list of products")]
        public void ThenTheResponseShouldContainAListOfProducts()
        {
            Console.WriteLine(response.Content);
            myObjects = JsonConvert.DeserializeObject<List<Object>>(response.Content!);
            Assert.IsNotEmpty(myObjects, "List of products is empty");
            
        }

        [Then(@"each product in the list should have an image")]
        public void ThenEachProductInTheListShouldHaveAnImage()
        {
            Boolean CheckImagesInProducts = true;
            foreach (Object product in myObjects)
            {
                dynamic jsonObject = JObject.Parse(product.ToString()!);
                if (jsonObject.image == null)
                {
                    CheckImagesInProducts = false;
                }
            }
            Assert.True(CheckImagesInProducts, "Exists products with no images");
        }
    }
}
