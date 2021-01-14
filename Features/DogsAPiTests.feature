Feature: Dogs API Tests

@basic
Scenario: Status code is OK for valid request to LIST All
	When the user submits a valid request to dog API to list all breeds
	Then the status code is OK

@content
Scenario: Content type is JSON for valid request to LIST All
	When the user submits a valid request to dog API to list all breeds
	Then the content type is JSON