Feature: Inventory management


@mytag
Scenario: 01 Adding few items to empty inventory
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Inventory already contains items below
	| ID | Name | Amount | Category |
	And Items dictionary contains items below
	| ID   | Name     | Category |
	| TR_1 | Rat tail | Trophy   |
	When Adding item with ID 'TR_1' with amount '5' to inventory
	Then Inventory should have items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 5      | Trophy   |


Scenario: 02 Adding few items to not empty inventory
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Inventory already contains items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 5      | Trophy   |
	And Items dictionary contains items below
	| ID   | Name     | Category |
	| TR_1 | Rat tail | Trophy   |
	When Adding item with ID 'TR_1' with amount '5' to inventory
	Then Inventory should have items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 10     | Trophy   |


Scenario: 03 Reducing amuont of items
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Inventory already contains items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 10      | Trophy   |
	And Items dictionary contains items below
	| ID   | Name     | Category |
	| TR_1 | Rat tail | Trophy   |
	When Removing item with ID 'TR_1' with amount '5' to inventory
	Then Inventory should have items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 5      | Trophy   |