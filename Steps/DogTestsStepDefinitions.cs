using FluentAssertions;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace RestSharpTest.Steps
{
    [Binding]
    public class DogTestsStepDefinitions
    {
        IRestResponse response;

        [When(@"the user submits a valid request to dog API to list all breeds")]
        public void WhenTheUserSubmitsAValidRequestToDogAPIToListAllBreeds()
        {
            RestClient client  = new RestClient("https://dog.ceo");
            RestRequest request = new RestRequest("api/breeds/list/all", Method.GET);

            response = client.Execute(request);
        }
        
        [Then(@"the status code is OK")]
        public void ThenTheStatusCodeIsOK()
        {
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Then(@"the content type is JSON")]
        public void ThenTheContentTypeIsJSON()
        {
            response.ContentType.Should().Be("application/json");
        }
    }
}
