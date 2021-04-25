@PostCode
Feature: GetPostCodeLocationSuccess
	

Scenario Outline: GetPostCodeLocationSuccess - Successful request to get
	Given I perform get request to endpoint for <countryCode> country code with <postCode> post code
	When I have body from get post code location response
	Then the response status code is 'OK'
		And the response has post code equal to <postCode>
		And the response has country equal to <countryName>
		And the response has country abbreviation equal to <countryCode>
		And the response has places equal to <placeName>, <state>, <stateCode>, <longitude> and <latitude>
	Examples: 
        | example description   | countryName   | countryCode | postCode | placeName     | state        | stateCode | longitude | latitude |
		| Poland address        | Poland        | PL          | 32-600   | Oświęcim      | Małopolskie  |           | 19.2333   | 50.0333  |
		| United States address | United States | US          | 90210    | Beverly Hills | California   | CA        | -118.4065 | 34.0901  |
		| Austria address       | Austria       | AT          | 1010     | Wien          |              |           | 16.3705   | 48.2077  |