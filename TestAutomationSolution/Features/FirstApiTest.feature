Feature: FirstApiTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@ApiTests
Scenario: Verify status code of the endpoint
	Given I make Get request to the "users" endpoint and getting 200 as response
