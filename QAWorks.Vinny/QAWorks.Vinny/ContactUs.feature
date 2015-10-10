Feature: ContactUs
  As an end user
  I want a contact us page
  So that I can find out more about QAWorks exciting services

@contactUs

Scenario: Valid Submission
	Given I am on the QAWoks Staging Contact Us page
	Then I should be able to contact QAWorks with the following information
	| Fields | Values   |
	| Name   | J.Bloggs |
	| Email   | j.Bloggs@qaworks.com                      |
	| Message | please contact me I want to find out more |
	

Scenario Outline: Validation Messages on Invalid Submission
	Given I am on the QAWoks Staging Contact Us page
	When I submit the form with "<name>", "<email>", "<message>" with one of the fields left blank or with an invalid email
	Then I should see the appropriate "<ValidationMessage>" validation
Examples: 
	| name     | email                 | message                | ValidationMessage            |
	| ""       | j.Bloggs@qaworks.com  | This is a test message | Your name is required        |
	| J.Bloggs | ""                    | This is a test message | An Email address is required |
	| J.Bloggs | invalidFormat@qaworks | This is a test message | Invalid Email Address        |
	| J.Bloggs | j.Bloggs@qaworks.com  | ""                     | Please type your message     |
	
	