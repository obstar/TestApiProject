@PostCode
Feature: GetPostCodeLocationStatusCodes
	
		
Scenario: GetPostCodeLocationStatusCodes - Failed get request with Method Not Allowed status
	Given I perform post request to endpoint for US country code with 90210 post code
	Then the response status code is 'Method Not Allowed'

Scenario: GetPostCodeLocationStatusCodes - Failed get request with Not Found status
	Given I perform get request to endpoint for PL country code with 00-000 post code
	Then the response status code is 'Not Found'