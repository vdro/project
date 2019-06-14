Feature: FormTest
In order to avoid silly mistakes
As a UserForm Sender
I want to be able to fill and send form correctly


Scenario: Example Scenario with correct information provided
Given AzureController initiated with dependencies
When calling the TriggerLogicApp with below AzureModel
| FirstName | LastName | Email             | PhoneNumber |
| Test      | SpecFlow | email@example.com | 555         |
Then something happens
