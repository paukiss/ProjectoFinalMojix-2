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
            Console.WriteLine("Setup");
        }

        [Test]
        public void PrimerTestGet()
        {
            Console.WriteLine("it is ok");
        }
    }
}