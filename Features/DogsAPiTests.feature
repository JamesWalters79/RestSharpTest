Feature: Dogs API Tests

@basic
Scenario: Status code is OK for valid request to list all breeds
	When the user submits a valid request to dog API to list all breeds
	Then the status code is OK

@basic
Scenario: Content type is JSON for valid request to list all breeds
	When the user submits a valid request to dog API to list all breeds
	Then the content type is JSON

@scottishterrier
Scenario: Scottish Terrier is a type of Terrier
	When the user submits a valid request to the dog API to list all types of terrier
	Then the Scottish Terrier is a type of Terrier

@scottisterrier
Scenario: Scottish Terrier is not a type of Hound
	When the user submits a valid request to the dog API to list all types of Hound
	Then the Scottish Terrier is not a type of Hound

@scottishterrier
Scenario:  Scottish Terrier appears in the correct position in types of terrier message
	When the user submits a valid request to the dog API to list all types of terrier	
	Then Scottish Terrier appears in the correct position in types of terrier message
	
@scottishterrier
Scenario: Status is successfor valid request to list all types of terrier
	When the user submits a valid request to the dog API to list all types of terrier	
	Then the status is success