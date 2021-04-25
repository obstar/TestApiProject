@PostCode
Feature: GetPostCodeLocationBoundaryValue

Scenario: GetPostCodeLocationBoundaryValue - Success get request with max boundary value for post code
	Given I perform get request to endpoint for PL country code with 99-440 post code
	Then the response status code is 'OK'

Scenario: GetPostCodeLocationBoundaryValue - Failed get request above max boundary value for post code
	Given I perform get request to endpoint for PL country code with 99-441 post code
	Then the response status code is 'Not Found'

Scenario: GetPostCodeLocationBoundaryValue - Success get request with min boundary value for post code
	Given I perform get request to endpoint for PL country code with 00-001 post code
	Then the response status code is 'OK'

Scenario: GetPostCodeLocationBoundaryValue - Failed get request below min boundary value for post code
	Given I perform get request to endpoint for PL country code with 00-000 post code
	Then the response status code is 'Not Found'