Feature: Languages


Scenario Outline:Verify the Sign In functionality
	Given I open local host succesfully
	When I click on Sign in link
	And I provided Username "<username>" in text field
	And I provided Password "<password>" in text field
	And I tick the remember Me? checkbox
	And I click login button
	Then I logged in successfully
	When I click on Sign Out button

	Examples: 
	| username				   | password	|
	| bairi.bhavani9@gmail.com | Achhi02110 |


	
Scenario Outline:Verify the Sign In negative scenarios
	Given I open local host succesfully
	When I click on Sign in link
	And I provided Username "<username>" in text field
	And I provided Password "<password>" in text field
	And I tick the remember Me? checkbox
	And I click login button
	Then I can verify the error messages "<error message>" for username "<username>"  and password "<password>" text fields
	

	Examples: 
	| username					| password   | error message                          |
	|							| Achhi02110 | Please enter a valid email address     |
	|  bairi.bhavani9@gmail.com |			 | Password must be at least 6 characters |


	#Adding only one language and level here
	#Delete all previously added languages before the run
	Scenario Outline: Add language and choose level single record with valid details
	Given I successfullly logged into the Mars_qa Project
	When I click on language tab
	And I click on Add new button
	When I enter the add language "<languages>" in text field
	And I select a Choose language level "<levelvalue>" from drop down list
	And I click on add button
   Then I can see the "<languages>" added message

   Examples: 
	| languages | levelvalue | 
	| Mandarin   | Basic     | 

	#Adding duplicate language and level here
	Scenario Outline: Add duplicate language and choose level single record with valid details
	Given I successfullly logged into the Mars_qa Project
	When I click on language tab
	And I click on Add new button
	When I enter the add language "<languages>" in text field
	And I select a Choose language level "<levelvalue>" from drop down list
	And I click on add button
   Then I can see the "<languages>" added message
   When I want to add duplicate "<duplicatelanguage>" and "<duplicatelevel>"
   Then I can verify the error message "<error message>" for duplicate "<duplicatelanguage>" and "<duplicatelevel>" 
   
   Examples: 
	| languages | levelvalue | duplicatelanguage | duplicatelevel | error message                                         |
	| Arabic    | Basic      | Arabic            | Basic          | This language is already exist in your language list. |

   #Edit the language and level here
   #Delete previously added languages before the run
   @BB
	Scenario Outline: Edit language and choose level record with valid details
	Given I successfullly logged into the Mars_qa Project
	When I click on language tab
	And I click on Add new button 
	And I enter the add language "<languages>" in text field
	And I select a Choose language level "<levelvalue>" from drop down list
	And I click on add button
   Then I can see the "<languages>" added message
   When I want to update "<languages>" with "<languagesone>" and "<levelvalueone>" languge and level
   Then The updated "<languagesone>" and "<levelvalueone>" message should be displayed

	Examples: 
	| languages | levelvalue | languagesone | levelvalueone |
	| Italian   | Basic      | Malayalam    | Fluent      |

	#Edit the language and level here
   #Delete previously added languages before the run
   @BB
	Scenario Outline: Edit language and choose level record with invalid/blank details
	Given I successfullly logged into the Mars_qa Project
	When I click on language tab
	And I click on Add new button 
	And I enter the add language "<languages>" in text field
	And I select a Choose language level "<levelvalue>" from drop down list
	And I click on add button
   Then I can see the "<languages>" added message
   When I want to update "<languages>" with invalid/blank "<languagesone>" and "<levelvalueone>" languge and level
   Then I can verify the error messages "<error message>" for language "<languagesone>"  and level "<levelvalueone>" 

	Examples: 
	| languages | levelvalue | languagesone | levelvalueone | error message                   |
	| Italian   | Basic      |              | Fluent        | Please enter language and level |

	 #Delete the language and level here
   #Delete previously added languages before the run
   @BB
	Scenario Outline: Delete language and choose level record with valid details
	Given I successfullly logged into the Mars_qa Project
	When I click on language tab
	And I click on Add new button 
	And I enter the add language "<languages>" in text field
	And I select a Choose language level "<levelvalue>" from drop down list
	And I click on add button
   Then I can see the "<languages>" added message
   When I want to delete existing "<languages>" 
   Then The deleted "<languages>" message should be displayed

	Examples: 
	| languages | levelvalue | 
	| German    | Basic      | 
	

Scenario Outline: Add language and choose level record with valid details
	Given I successfullly logged into the Mars_qa Project
	When I click on language tab
	And I click on Add new button 
	And I enter the add language "<languages>" in text field
	And I select a Choose language level "<levelvalue>" from drop down list
	And I click on add button
   Then I can see the "<languages>" added message

	Examples: 
	| languages | levelvalue |
	| English   | Basic      |
	| French    | Fluent     |
	| Spanish   | Native/Bilingual  |
	| Hindi     | Native/Bilingual  |
