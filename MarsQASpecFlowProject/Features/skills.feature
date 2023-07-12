Feature: skills

Scenario Outline: Add skill and choose level single record with valid details
	Given I successfullly logged into the Mars_qa Project
	When I click on skill tab
	And I click on skills Add new button
	When I enter the add skill "<skills>" in text field
	And I select a Choose skill level "<levelvalue>" from drop down list
	And I click on skills add button
   Then I can see the skills "<skills>" added message

   Examples:  
	| skills		| levelvalue   | 
	| Manual testing| Beginner     | 
	| Java			| Intermediate | 
	| Selenium      | Expert       | 


	Scenario Outline: Add duplicate skill and choose level single record with valid details
	Given I successfullly logged into the Mars_qa Project
	When I click on skill tab 
	And I click on skills Add new button
	When I enter the add skill "<skills>" in text field
	And I select a Choose skill level "<levelvalue>" from drop down list
	And I click on skills add button
   Then I can see the skills "<skills>" added message
   When I want to add duplicate skills "<duplicateskill>" and "<duplicatelevel>"
   Then I can verify the  error message "<error message>" for duplicate "<duplicateskill>" and "<duplicatelevel>" 
   
   Examples: 
	| skills | levelvalue   | duplicateskill | duplicatelevel | error message                                   |
	| Java   | Intermediate | Java           | Intermediate   | This skill is already exist in your skill list. |


	 @BB
	Scenario Outline: Edit skill and choose level record with valid details
	Given I successfullly logged into the Mars_qa Project
	When I click on skill tab
	And I click on skills Add new button 
	And I enter the add skill "<skills>" in text field
	And I select a Choose skill level "<levelvalue>" from drop down list
	And I click on skills add button
    Then I can see the skills "<skills>" added message
    When I want to update "<skills>" with "<skillsone>" and "<levelvalueone>" skill and level
    Then The updated skills "<skillsone>" and "<levelvalueone>" message should be displayed

	Examples: 
	| skills    | levelvalue | skillsone | levelvalueone |
	| Specflow  | Beginner   | Cucumber  | Expert        |



	