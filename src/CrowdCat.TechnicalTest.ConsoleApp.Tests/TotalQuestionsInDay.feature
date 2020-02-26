Feature: TotalQuestionsInDay
	In order to understand how well used stack overflow is
	As a Data Scientist
	I want to be told how many questions are asked per day

@HappyPath
Scenario: Total Questions for single day
	Given I have the date "2020-02-26"
	When I start the console application
	Then I should see the total number of questions
