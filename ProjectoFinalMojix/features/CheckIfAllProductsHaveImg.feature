Feature: CheckIfAllProductsHaveImg

A short summary of the feature

@tag1
Scenario: CheckIfAllProductsHaveImg
    Given I have a valid API endpoint to retrieve all products
    When I send a GET request to the endpoint
    Then I should receive a successful response with content
    And the response should contain a list of products
    And each product in the list should have an image