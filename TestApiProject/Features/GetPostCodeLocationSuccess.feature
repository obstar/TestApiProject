Feature: GetPostCodeLocationSuccess
	

Scenario: GetPostCodeLocationSuccess - Successful request for different countries
	Given I perform get request to endpoint for '<countryCode>' country code with '<postCode>' post code
	When I get address from post code get response
	Then the post code get request is 'OK'
		And the post code from response is '90210'
		And the post code from response is '90210'
	Examples:
        | example description   | countryCode | postCode |
		| Poland address        | PL          | 32-600   |
		| United States address | US          | 90210    |