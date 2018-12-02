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
	And Number of quest to be generated is '1'
	And The chance of getting level '1' quests is set to '10000' of '10000'
	And The chance of getting level '2' quests is set to '2500' of '10000'
	And The chance of getting level '3' quests is set to '1000' of '10000'
	And The chance of getting level '4' quests is set to '100' of '10000'
	And Randomzer for quests level will always return '9000'
	When Player will refresh and regenerate quests
	Then List of quests should contain
	| ID  | Level | Name                 | FormationID | WinRewards |
	| Q_1 | 1     | Defeat - Goblin pack | T_1         |            |


Scenario: 02 Generating three the same quests
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
	And Number of quest to be generated is '3'
	And The chance of getting level '1' quests is set to '10000' of '10000'
	And The chance of getting level '2' quests is set to '2500' of '10000'
	And The chance of getting level '3' quests is set to '1000' of '10000'
	And The chance of getting level '4' quests is set to '100' of '10000'
	And Randomzer for quests level will always return '9000'
	When Player will refresh and regenerate quests
	Then List of quests should contain
	| ID  | Level | Name                 | FormationID | WinRewards |
	| Q_1 | 1     | Defeat - Goblin pack | T_1         |            |
	| Q_2 | 1     | Defeat - Goblin pack | T_1         |            |
	| Q_3 | 1     | Defeat - Goblin pack | T_1         |            |


Scenario: 03 Generating one level 4 quest 
	Given Some mercenary templates
	| Level | Name   | HP_range | Min_Attack_range | Defence_range | Speed_range | Attack_add_for_max |
	| 1     | Goblin | 18-22    | 8-12             | 8-12          | 8-10        | 4                  |
	| 2     | Goblin | 22-26    | 12-16            | 10-14         | 9-11        | 5                  |
	| 3     | Goblin | 26-34    | 16-24            | 12-16         | 10-12       | 7                  |
	| 4     | Goblin | 40-55    | 30-40            | 18-22         | 11-13       | 10                 |
	And Have some formation templates
	| ID  | Name        | Level | F1       | F2 | F3 | M1 | M2 | M3 | M4 | R1 | R2 | R3 |
	| T_1 | Goblin pack | 1     | Goblin@1 |    |    |    |    |    |    |    |    |    |
	| T_4 | Goblin pack | 4     | Goblin@1 |    |    |    |    |    |    |    |    |    |
	And Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Number of quest to be generated is '1'
	And The chance of getting level '1' quests is set to '10000' of '10000'
	And The chance of getting level '2' quests is set to '2500' of '10000'
	And The chance of getting level '3' quests is set to '1000' of '10000'
	And The chance of getting level '4' quests is set to '100' of '10000'
	And Randomzer for quests level will always return '90'
	When Player will refresh and regenerate quests
	Then List of quests should contain
	| ID  | Level | Name                 | FormationID | WinRewards |
	| Q_1 | 4     | Defeat - Goblin pack | T_4         |            |


Scenario: 04 Generating different quests for level 2 
	Given Some mercenary templates
	| Level | Name   | HP_range | Min_Attack_range | Defence_range | Speed_range | Attack_add_for_max |
	| 1     | Goblin | 18-22    | 8-12             | 8-12          | 8-10        | 4                  |
	| 2     | Goblin | 22-26    | 12-16            | 10-14         | 9-11        | 5                  |
	| 3     | Goblin | 26-34    | 16-24            | 12-16         | 10-12       | 7                  |
	| 4     | Goblin | 40-55    | 30-40            | 18-22         | 11-13       | 10                 |
	And Have some formation templates
	| ID  | Name        | Level | F1       | F2 | F3 | M1 | M2 | M3 | M4 | R1 | R2 | R3 |
	| T_1 | Goblin pack | 2     | Goblin@1 |    |    |    |    |    |    |    |    |    |
	| T_2 | Ork pack    | 2     | Goblin@1 |    |    |    |    |    |    |    |    |    |
	| T_3 | Elf pack    | 2     | Goblin@1 |    |    |    |    |    |    |    |    |    |
	And Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Number of quest to be generated is '1000'
	And The chance of getting level '1' quests is set to '10000' of '10000'
	And The chance of getting level '2' quests is set to '2500' of '10000'
	And The chance of getting level '3' quests is set to '1000' of '10000'
	And The chance of getting level '4' quests is set to '100' of '10000'
	And Randomzer for quests level will always return '2300'
	When Player will refresh and regenerate quests
	Then List of quests should contain at least '10' quests with FormationID 'T_1' and Level '2'
	And List of quests should contain at least '10' quests with FormationID 'T_2' and Level '2'
	And List of quests should contain at least '10' quests with FormationID 'T_3' and Level '2'

Scenario: 05 Generating reward for quest on level 1
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
	And Items dictionary contains items below
	| ID   | Name  | Category | Level |
	| TR_1 | Beer  | Rewards  | 1     |
	| TR_2 | Wine  | Rewards  | 2     |
	| TR_3 | Wodka | Rewards  | 3     |
	| TR_4 | Rum   | Rewards  | 4     |
	And Reward templates have
	| ID  | Rewards | Level |
	| R_1 | 1xBeer  | 1     |
	| R_2 | 1xWine  | 2     |
	And I try to login for 'test' and password 'test'
	And Number of quest to be generated is '1'
	And The chance of getting level '1' quests is set to '10000' of '10000'
	And The chance of getting level '2' quests is set to '2500' of '10000'
	And The chance of getting level '3' quests is set to '1000' of '10000'
	And The chance of getting level '4' quests is set to '100' of '10000'
	And Randomzer for quests level will always return '9000'
	When Player will refresh and regenerate quests
	Then List of quests should contain
	| ID  | Level | Name                 | FormationID | WinRewards |
	| Q_1 | 1     | Defeat - Goblin pack | T_1         | R_1        |