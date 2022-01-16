Feature: RepositoryGetRoutine
	Get a routine

Scenario: Get a routine for 1342
	Given I chose a four-digit number with two unique digits 1342
	When I get a routine
	Then the ascending number should be 1234
	And the descending number should be 4321
	And the result number should be 3087

Scenario: Get a routine for 8082
	Given I chose a four-digit number with two unique digits 8082
	When I get a routine
	Then the ascending number should be 0288
	And the descending number should be 8820
	And the result number should be 8532