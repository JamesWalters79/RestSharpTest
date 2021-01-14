using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RestSharpTest.Hooks
{
    [Binding]
    public class Helper
    {
        public IRestResponse response;
        public RestClient client;

        [BeforeScenario]
        public void BeforeScenario()
        {
            client = new RestClient("https://dog.ceo");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            client = null;
            response = null;
        }
    }
}
