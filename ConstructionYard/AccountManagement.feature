Feature: AccountManagement
	

@mytag
Scenario: 01 Successful login
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	When I try to login for 'test' and password 'test'
	Then Logged account id is 'ID_1'

Scenario: 02 Failed login
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	When I try to login for 'test' and password 'wrong'
	Then Logged account id is 'none'