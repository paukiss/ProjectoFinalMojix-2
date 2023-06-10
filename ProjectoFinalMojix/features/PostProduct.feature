Feature: PostProduct

A short summary of the feature

Scenario: Post a product
	Given I have a valid API endpoint for creating a product
	And I have the necessary data to create a product
	When I send a POST request to the API endpoint with the product data
	Then I should receive a successfully response
	And the response should contain the created product details
	And the product should be successfully created in the system