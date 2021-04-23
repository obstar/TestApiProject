@PostCode
Feature: GetPostCodeSuccess


Scenario: GetPostCodeSuccess - Successful request
	Given I perform get request for '90210' post code endpoint
	Then the post code get request is 'OK'
		And the post code get request headers are correct