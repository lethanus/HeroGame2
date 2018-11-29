Feature: Quests management


@mytag
Scenario: 01 Generating one quest
	Given Some mercenary templates
	| Level | Name   | HP_range | Min_Attack_range | Defence_range | Speed_range | Attack_add_for_max |
	| 1     | Goblin | 18-22    | 8-12             | 8-12          | 8-10        | 4                  |
	| 2     | Goblin | 22-26    | 12-16            | 10-14         | 9-11        | 5                  |
	| 3     | Goblin | 26-34    | 16-24            | 12-16         | 10-12       | 7                  |
	| 4     | Goblin | 40-55    | 30-40            | 18-22         | 11-13       | 10                 |
	And Have some formation templates
	| ID  | Name        | Level | F1       | F2 | F3 | M1 | M2 | M3 | M4 | R1 | R2 | R3 |
	| T_1 | Goblin pack | 1     | Goblin@1 |    |    |    |    |    |    |    |    |    |
	And Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	When Player will refresh and regenerate quests
	Then List of quests should contain
	| ID | Level | Name                 | FormationID | WinRewards |
	| Q1 | 1     | Defeat - Goblin pack | T_1         |            |
