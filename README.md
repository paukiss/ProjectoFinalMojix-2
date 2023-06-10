## Final Project Mojix

This project was developed using .NET 6.0 and consists of a series of automated tests using the following dependencies:

- **Newtonsoft.Json**: A popular library for working with JSON objects in .NET.
- **NUnit**: A unit testing framework for .NET.
- **RestSharp**: A library for making HTTP requests and working with RESTful APIs.
- **SpecFlow**: A behavior-driven testing (BDD) framework that allows writing tests in natural language.
- **SpecFlow.Allure**: An extension for SpecFlow that enables generating test reports using Allure.
- **SpecFlow.NUnit**: An integration between SpecFlow and NUnit.
- **SpecFlow.Tools.MsBuild.Generation**: A tool for generating SpecFlow code files during compilation.

## *Test Cases*

Four test cases have been developed to validate different aspects of the system:

1. *AuthenticationAPIStepDefinitions*: This test case verifies the authentication functionality of the API.
2. *CheckIfAllProductsHaveImgStepDefinitions*: This test case ensures that all products have an associated image.
3. *GetCategories*: This test case verifies the functionality of retrieving categories from the API.
4. *PostProductStepDefinitions*: This test case validates the functionality of posting a product to the API.

Each test case is implemented using the Behavior-Driven Testing (BDD) approach provided by SpecFlow, allowing for easy understanding of requirements and test scenarios using natural language.

This project utilizes .NET 6.0 and the aforementioned dependencies to develop and execute the automated tests.

## Test Report

A test report has been generated using GitHub Actions and GitHub Pages. The report can be found at the following link:

[Test Report](https://paukiss.github.io/ProjectoFinalMojix-2)

The report provides an overview of the results of the automated tests and helps identify any issues or errors encountered during test execution.

This test report is a valuable tool for assessing the quality and status of the project, providing detailed documentation of the results obtained from the automated tests.

Get Fun!! 🤓💻