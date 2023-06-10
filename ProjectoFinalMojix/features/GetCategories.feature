Feature: GetCategories

A short summary of the feature

@AllCategories
Scenario: Get all categories
	Given I have a valid API endpoint for retrieving categories
	When I send a GET request to the API endpoint
	Then I should receive a successful response
