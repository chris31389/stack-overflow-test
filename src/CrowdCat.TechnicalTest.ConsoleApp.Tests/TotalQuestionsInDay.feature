Feature: Summary Totals for a day
	In order to understand how well used stack overflow is per day
	As a Data Scientist
	I want to be told a summary of how much it is used for the day

@HappyPath
Scenario: Total Questions for single day
	Given I have the date "2020-02-26"
	When I start the console application
	Then I should see the total number of questions

@HappyPath
Scenario: Total View Count for all questions for single day
	Given I have the date "2020-02-26"
	When I start the console application
	Then I should see the total of view counts
	
@HappyPath
Scenario: Distinct tags in alphabetical order for all questions for single day
	Given I have the date "2020-02-26"
	When I start the console application
	Then I should see the tags in distinct alphabetical order