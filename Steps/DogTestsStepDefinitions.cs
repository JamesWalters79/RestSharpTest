using FluentAssertions;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;
using RestSharpTest.DataEntities;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;

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

        [When(@"the user submits a valid request to the dog API to list all types of terrier")]
        public void WhenTheUserSubmitsAValidRequestToTheDogAPIToListAllTypesOfTerrier()
        {
            RestClient client = new RestClient("https://dog.ceo");
            RestRequest request = new RestRequest("api/breed/terrier/list", Method.GET);

            response = client.Execute(request);
        }

        [Then(@"the Scottish Terrier is a type of Terrier")]
        public void ThenTheScottishTerrierIsATypeOfTerrier()
        {
            response.Content.Should().Contain("scottish");
        }

        [When(@"the user submits a valid request to the dog API to list all types of Hound")]
        public void WhenTheUserSubmitsAValidRequestToTheDogAPIToListAllTypesOfHound()
        {
            RestClient client = new RestClient("https://dog.ceo");
            RestRequest request = new RestRequest("api/breed/hound/list", Method.GET);

            response = client.Execute(request);
        }

        [Then(@"the Scottish Terrier is not a type of Hound")]
        public void ThenTheScottishTerrierIsNotATypeOfHound()
        {
            response.Content.Should().NotContain("scottish");
        }

        [Then(@"Scottish Terrier appears in the correct position in types of terrier message")]
        public void ThenScottishTerrierAppearsInTheCorrectPositionInTypesOfTerrierMessage()
        {
            Breeds breedsResponse = new JsonDeserializer().Deserialize<Breeds>(response);

            breedsResponse.Status.Should().Be("success");
            breedsResponse.Message[13].Should().Be("scottish");
        }

    }
}