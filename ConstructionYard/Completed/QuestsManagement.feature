﻿Feature: Quests management


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
	| ID  | Level | Name                 | FormationID | RewardsID |
	| Q_1 | 1     | Defeat - Goblin pack | T_1         |           |


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
	| ID  | Level | Name                 | FormationID | RewardsID |
	| Q_1 | 1     | Defeat - Goblin pack | T_1         |           |
	| Q_2 | 1     | Defeat - Goblin pack | T_1         |           |
	| Q_3 | 1     | Defeat - Goblin pack | T_1         |           |


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
	| ID  | Level | Name                 | FormationID | RewardsID |
	| Q_1 | 4     | Defeat - Goblin pack | T_4         |           |


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
	| R_1 | 1_Beer  | 1     |
	| R_2 | 1_Wine  | 2     |
	And I try to login for 'test' and password 'test'
	And Number of quest to be generated is '1'
	And The chance of getting level '1' quests is set to '10000' of '10000'
	And The chance of getting level '2' quests is set to '2500' of '10000'
	And The chance of getting level '3' quests is set to '1000' of '10000'
	And The chance of getting level '4' quests is set to '100' of '10000'
	And Randomzer for quests level will always return '9000'
	When Player will refresh and regenerate quests
	Then List of quests should contain
	| ID  | Level | Name                 | FormationID | RewardsID |
	| Q_1 | 1     | Defeat - Goblin pack | T_1         | R_1       |


Scenario: 06 Generating reward for quests on level 2
	Given Some mercenary templates
	| Level | Name   | HP_range | Min_Attack_range | Defence_range | Speed_range | Attack_add_for_max |
	| 1     | Goblin | 18-22    | 8-12             | 8-12          | 8-10        | 4                  |
	| 2     | Goblin | 22-26    | 12-16            | 10-14         | 9-11        | 5                  |
	| 3     | Goblin | 26-34    | 16-24            | 12-16         | 10-12       | 7                  |
	| 4     | Goblin | 40-55    | 30-40            | 18-22         | 11-13       | 10                 |
	And Have some formation templates
	| ID  | Name        | Level | F1       | F2 | F3 | M1 | M2 | M3 | M4 | R1 | R2 | R3 |
	| T_1 | Goblin pack | 2     | Goblin@1 |    |    |    |    |    |    |    |    |    |
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
	| R_1 | 1_Beer  | 1     |
	| R_2 | 1_Wine  | 2     |
	And I try to login for 'test' and password 'test'
	And Number of quest to be generated is '2'
	And The chance of getting level '1' quests is set to '10000' of '10000'
	And The chance of getting level '2' quests is set to '2500' of '10000'
	And The chance of getting level '3' quests is set to '1000' of '10000'
	And The chance of getting level '4' quests is set to '100' of '10000'
	And Randomzer for quests level will always return '2400'
	When Player will refresh and regenerate quests
	Then List of quests should contain
	| ID  | Level | Name                 | FormationID | RewardsID |
	| Q_1 | 2     | Defeat - Goblin pack | T_1         | R_2       |
	| Q_2 | 2     | Defeat - Goblin pack | T_1         | R_2       |


Scenario: 07 Generating different quests for level 2 with rewards
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
	And Items dictionary contains items below
	| ID   | Name  | Category | Level |
	| TR_1 | Beer  | Rewards  | 1     |
	| TR_2 | Wine  | Rewards  | 2     |
	| TR_3 | Wodka | Rewards  | 3     |
	| TR_4 | Rum   | Rewards  | 4     |
	And Reward templates have
	| ID  | Rewards | Level |
	| R_1 | 1_Beer  | 2     |
	| R_2 | 1_Wine  | 2     |
	| R_3 | 10_Rum  | 2     |
	And I try to login for 'test' and password 'test'
	And Number of quest to be generated is '1000'
	And The chance of getting level '1' quests is set to '10000' of '10000'
	And The chance of getting level '2' quests is set to '2500' of '10000'
	And The chance of getting level '3' quests is set to '1000' of '10000'
	And The chance of getting level '4' quests is set to '100' of '10000'
	And Randomzer for quests level will always return '2300'
	When Player will refresh and regenerate quests
	Then List of quests should contain at least '10' quests with Rewards using template 'R_1'
	And List of quests should contain at least '10' quests with Rewards using template 'R_2'
	And List of quests should contain at least '10' quests with Rewards using template 'R_3'

Scenario: 08 Player team for sure should win fight for low level fight quest
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
	And Account 'ID_1' already have some mercenaries
	| ID       | Name   | MaxHp | Hp  | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A    | Elf    | 200   | 200 | 30      | 30      | 5   | 10    |        |
	| Goblin_B | Goblin | 100   | 100 | 20      | 20      | 0   | 5     |        |
	And List of quests contains
	| ID  | Level | Name                 | FormationID | RewardsID |
	| Q_1 | 1     | Defeat - Goblin pack | T_1         |           |
	When Player will set character with ID 'Elf_A' to position 'Front_1'
	And Player will set character with ID 'Goblin_B' to position 'Front_2'
	And Player will complete quest with ID 'Q_1' with result 'Completed'


Scenario: 09 Player team for sure should lose fight for high level fight quest
	Given Some mercenary templates
	| Level | Name   | HP_range | Min_Attack_range | Defence_range | Speed_range | Attack_add_for_max |
	| 1     | Goblin | 18-22    | 8-12             | 8-12          | 8-10        | 4                  |
	| 2     | Goblin | 22-26    | 12-16            | 10-14         | 9-11        | 5                  |
	| 3     | Goblin | 26-34    | 16-24            | 12-16         | 10-12       | 7                  |
	| 4     | Goblin | 40-55    | 30-40            | 18-22         | 11-13       | 10                 |
	And Have some formation templates
	| ID  | Name        | Level | F1       | F2       | F3       | M1 | M2 | M3 | M4 | R1 | R2 | R3 |
	| T_1 | Goblin pack | 1     | Goblin@4 | Goblin@4 | Goblin@4 |    |    |    |    |    |    |    |
	And Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Account 'ID_1' already have some mercenaries
	| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A    | Elf    | 20    | 20 | 30      | 30      | 5   | 7     |        |
	| Goblin_B | Goblin | 10    | 10 | 20      | 20      | 0   | 5     |        |
	And List of quests contains
	| ID  | Level | Name                 | FormationID | RewardsID |
	| Q_1 | 1     | Defeat - Goblin pack | T_1         |           |
	When Player will set character with ID 'Elf_A' to position 'Front_1'
	And Player will set character with ID 'Goblin_B' to position 'Front_2'
	And Player will complete quest with ID 'Q_1' with result 'NotCompleted'


Scenario: 10 Complete scenario for completed quest
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
	And Items dictionary contains items below
	| ID   | Name  | Category | Level |
	| TR_1 | Beer  | Rewards  | 1     |
	| TR_2 | Wine  | Rewards  | 2     |
	| TR_3 | Wodka | Rewards  | 3     |
	| TR_4 | Rum   | Rewards  | 4     |
	And Reward templates have
	| ID  | Rewards                | Level |
	| R_1 | 1_Beer                 | 2     |
	| R_2 | 1_Wine                 | 2     |
	| R_3 | 10_Rum:15_Wodka:2_Wine | 2     |
	And Inventory already contains items below
	| ID   | Name | Amount | Category |
	| TR_2 | Wine | 3      | Rewards  |
	And Account 'ID_1' already have some mercenaries
	| ID       | Name   | MaxHp | Hp  | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A    | Elf    | 200   | 200 | 30      | 30      | 5   | 10    |        |
	| Goblin_B | Goblin | 100   | 100 | 20      | 20      | 0   | 5     |        |
	And List of quests contains
	| ID  | Level | Name                 | FormationID | RewardsID |
	| Q_1 | 1     | Defeat - Goblin pack | T_1         | R_3       |
	When Player will set character with ID 'Elf_A' to position 'Front_1'
	And Player will set character with ID 'Goblin_B' to position 'Front_2'
	And Player will complete quest with ID 'Q_1' with result 'Completed'
	Then Inventory should have items below
	| ID   | Name  | Amount | Category |
	| TR_2 | Wine  | 5      | Rewards  |
	| TR_3 | Wodka | 15     | Rewards  |
	| TR_4 | Rum   | 10     | Rewards  |
	And List of quests should contain
	| ID  | Level | Name                 | FormationID | RewardsID |

Scenario: 11 Complete scenario for not completed quest
	Given Some mercenary templates
	| Level | Name   | HP_range | Min_Attack_range | Defence_range | Speed_range | Attack_add_for_max |
	| 1     | Goblin | 18-22    | 8-12             | 8-12          | 8-10        | 4                  |
	| 2     | Goblin | 22-26    | 12-16            | 10-14         | 9-11        | 5                  |
	| 3     | Goblin | 26-34    | 16-24            | 12-16         | 10-12       | 7                  |
	| 4     | Goblin | 40-55    | 30-40            | 18-22         | 11-13       | 10                 |
	And Have some formation templates
	| ID  | Name        | Level | F1       | F2       | F3       | M1 | M2 | M3 | M4 | R1 | R2 | R3 |
	| T_1 | Goblin pack | 1     | Goblin@4 | Goblin@4 | Goblin@4 |    |    |    |    |    |    |    |
	And Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Items dictionary contains items below
	| ID   | Name  | Category | Level |
	| TR_1 | Beer  | Rewards  | 1     |
	| TR_2 | Wine  | Rewards  | 2     |
	| TR_3 | Wodka | Rewards  | 3     |
	| TR_4 | Rum   | Rewards  | 4     |
	And Reward templates have
	| ID  | Rewards                | Level |
	| R_1 | 1_Beer                 | 2     |
	| R_2 | 1_Wine                 | 2     |
	| R_3 | 10_Rum:15_Wodka:2_Wine | 2     |
	And Inventory already contains items below
	| ID   | Name | Amount | Category |
	| TR_2 | Wine | 3      | Rewards  |
	And Account 'ID_1' already have some mercenaries
	| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A    | Elf    | 20    | 20 | 30      | 30      | 5   | 10    |        |
	| Goblin_B | Goblin | 10    | 10 | 20      | 20      | 0   | 5     |        |
	And List of quests contains
	| ID  | Level | Name                 | FormationID | RewardsID |
	| Q_1 | 1     | Defeat - Goblin pack | T_1         | R_3       |
	When Player will set character with ID 'Elf_A' to position 'Front_1'
	And Player will set character with ID 'Goblin_B' to position 'Front_2'
	And Player will complete quest with ID 'Q_1' with result 'NotCompleted'
	Then Inventory should have items below
	| ID   | Name  | Amount | Category |
	| TR_2 | Wine  | 3      | Rewards  |
	And List of quests should contain
	| ID  | Level | Name                 | FormationID | RewardsID |