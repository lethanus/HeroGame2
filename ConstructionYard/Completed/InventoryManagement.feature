Feature: Inventory management


@mytag
Scenario: 01 Adding few items to empty inventory
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Items dictionary contains items below
	| ID   | Name     | Category |
	| TR_1 | Rat tail | Trophy   |
	And Inventory already contains items below
	| ID | Name | Amount | Category |
	When Adding item with ID 'TR_1' with amount '5' to inventory
	Then Inventory should have items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 5      | Trophy   |


Scenario: 02 Adding few items to not empty inventory
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Items dictionary contains items below
	| ID   | Name     | Category |
	| TR_1 | Rat tail | Trophy   |
	And Inventory already contains items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 5      | Trophy   |
	When Adding item with ID 'TR_1' with amount '5' to inventory
	Then Inventory should have items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 10     | Trophy   |


Scenario: 03 Reducing amount of items
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Items dictionary contains items below
	| ID   | Name     | Category |
	| TR_1 | Rat tail | Trophy   |
	And Inventory already contains items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 10     | Trophy   |
	When Removing item with ID 'Rat tail' with amount '5' to inventory
	Then Inventory should have items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 5      | Trophy   |


Scenario: 04 Removing items
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Items dictionary contains items below
	| ID   | Name     | Category |
	| TR_1 | Rat tail | Trophy   |
	And Inventory already contains items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 10     | Trophy   |
	When Removing item with ID 'Rat tail' with amount '10' to inventory
	Then Inventory should have items below
	| ID   | Name     | Amount | Category |


Scenario: 05 Shouldn't remove items if amount is smaller then requested
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Items dictionary contains items below
	| ID   | Name     | Category |
	| TR_1 | Rat tail | Trophy   |
	And Inventory already contains items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 10     | Trophy   |
	When Removing item with ID 'Rat tail' with amount '15' to inventory
	Then Inventory should have items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 10     | Trophy   |