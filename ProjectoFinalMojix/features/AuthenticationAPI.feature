Feature: AuthenticationAPI

A short summary of the feature

@API @Authentication
Scenario: Login
    Given A value user "admin" and value password "admin"
    When I send a request to login
    Then I expect a token value
