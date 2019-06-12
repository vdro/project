Feature: SpecFlowFeature1

Scenario: My example scenario
Given AzureController initiated with dependencies
When calling the TriggerLogicApp with below AzureModel
| FirstName | LastName | Email             | PhoneNumber |
| Test      | SpecFlow | email@example.com | 555         |
Then something happens
