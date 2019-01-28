Feature: Google
	Verification of the Google Main page

Scenario: Verifying title of the Google Main page
	Given I am navigated to Google page
	When I am redirected to Google main page
	Then I see that page title equals to Google
