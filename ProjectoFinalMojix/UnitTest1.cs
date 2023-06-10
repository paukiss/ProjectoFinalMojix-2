using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ProjectoFinalMojix
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PrimerTestGet()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/{postid}", Method.Get);
            request.AddUrlSegment("postid", "1");
            var response = client.ExecuteGet(request);
            var content = response.Content;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var jsonObject = JObject.Parse(response.Content!);
            var result = jsonObject.SelectToken("title")!.ToString();
            Assert.That(result, Is.EqualTo("json-server"), "Title is not correct");
        }
    }
}