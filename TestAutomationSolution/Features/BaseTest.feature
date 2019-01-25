Feature: Main Page Tests
	Verification of the page title

Scenario: Verifying title of the Home page test
	Given I am navigated to Google page
	When I am redirected to Google main page
	Then I see that page title equals to Google