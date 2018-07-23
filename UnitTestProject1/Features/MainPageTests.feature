Feature: Main Page Tests
	Verification of the page tite
	Verification of the shop phone number

@UiTest
@ChromeLocal
@low
Scenario: Verifying title of the Home page
	Given I am navigated to Shop application main page
	Then I see that page title equals to "My Store"

@UiTest
@ChromeLocal
@low
Scenario: Verifying shop phone number on the Home page
	Given I am navigated to Shop application main page
	Then I see that shop phone number is "0123-456-787"