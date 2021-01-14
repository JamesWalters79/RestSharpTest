using FluentAssertions;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;
using RestSharpTest.DataEntities;
using RestSharpTest.Hooks;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;

namespace RestSharpTest.Steps
{
    [Binding]
    public class DogTestsStepDefinitions : Helper
    {    
        [When(@"the user submits a valid request to dog API to list all breeds")]
        public void WhenTheUserSubmitsAValidRequestToDogAPIToListAllBreeds()
        {            
            response = client.Execute(new RestRequest("api/breeds/list/all", Method.GET));
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
            response = client.Execute(new RestRequest("api/breed/terrier/list", Method.GET));
        }

        [Then(@"the Scottish Terrier is a type of Terrier")]
        public void ThenTheScottishTerrierIsATypeOfTerrier()
        {
            response.Content.Should().Contain("scottish");
        }

        [When(@"the user submits a valid request to the dog API to list all types of Hound")]
        public void WhenTheUserSubmitsAValidRequestToTheDogAPIToListAllTypesOfHound()
        {
            response = client.Execute(new RestRequest("api/breed/hound/list", Method.GET));
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
            breedsResponse.Message[13].Should().Be("scottish");
        }

        [Then(@"the status is success")]
        public void ThenTheStatusIsSuccess()
        {
            Breeds breedsResponse = new JsonDeserializer().Deserialize<Breeds>(response);
            breedsResponse.Status.Should().Be("success");
        }
    }
}