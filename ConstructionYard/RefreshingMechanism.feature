﻿Feature: Refreshing mechanism
	This will ensure that player cannot use refresh button until given time passed

@mytag
Scenario: 01 Refreshing for the first time
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And that there was no refresh actions before for option 'Test' for account ID 'ID_1'
	And current time is set to '2018-10-15 10:00:00'
	And Refresh time for option 'Test' is set to '30' seconds
	When I try to login for 'test' and password 'test'
	And mechanizm will set refresh to 'Enabled' for option 'Test'
	And player will use refresh for 'Test' option at '2018-10-15 10:00:00'
	Then Logged account id is 'ID_1'
	And Refresh for option 'Test' is 'Disabled'


Scenario: 02 Refreshing should be disabled when time from last refresh didn't passed
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And that there are some refresh actions
	| Option | LastAction          |
	| Test   | 2018-10-15 10:00:00 |
	| Test   | 2018-10-15 10:03:00 |
	| Test   | 2018-10-15 10:05:00 |
	| Test   | 2018-10-15 10:05:00 |
	And current time is set to '2018-10-15 10:05:00'
	And Refresh time for option 'Test' is set to '30' seconds
	When I try to login for 'test' and password 'test'
	Then Logged account id is 'ID_1'
	And Refresh for option 'Test' is 'Disabled'


Scenario: 03 Refreshing should be enabled when time from last refresh already passed
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And that there are some refresh actions
	| Option | LastAction          |
	| Test   | 2018-10-15 10:00:00 |
	| Test   | 2018-10-15 10:03:00 |
	| Test   | 2018-10-15 10:05:00 |
	| Test   | 2018-10-15 10:05:00 |
	And current time is set to '2018-10-15 10:06:00'
	And Refresh time for option 'Test' is set to '30' seconds
	When I try to login for 'test' and password 'test'
	Then Logged account id is 'ID_1'
	And Refresh for option 'Test' is 'Enabled'