Feature: Pack Formation Building
	Mechanizm to ensure proper and valid formation in the pack for the fight


@mytag
Scenario: 01 Setting character in Front 1
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Account 'ID_1' already have some mercenaries
	| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
	| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
	When Player will set character with ID 'Elf_A' to position 'Front_1'
	Then Pack formation should look like this
	| Position | Character_ID |
	| Front_1  | Elf_A        |
	| Front_2  |              |
	| Front_3  |              |
	| Middle_1 |              |
	| Middle_2 |              |
	| Middle_3 |              |
	| Middle_4 |              |
	| Rear_1   |              |
	| Rear_2   |              |
	| Rear_3   |              |


Scenario: 02 Replacing character from the position
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Account 'ID_1' already have some mercenaries
	| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
	| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
	When Player will set character with ID 'Elf_A' to position 'Middle_1'
	When Player will set character with ID 'Goblin_B' to position 'Middle_1'
	Then Pack formation should look like this
	| Position | Character_ID |
	| Front_1  |              |
	| Front_2  |              |
	| Front_3  |              |
	| Middle_1 | Goblin_B     |
	| Middle_2 |              |
	| Middle_3 |              |
	| Middle_4 |              |
	| Rear_1   |              |
	| Rear_2   |              |
	| Rear_3   |              |


Scenario: 03 Character repositioning
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Account 'ID_1' already have some mercenaries
	| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
	| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
	When Player will set character with ID 'Elf_A' to position 'Middle_1'
	And Player will set character with ID 'Goblin_B' to position 'Front_1'
	And Player will set character with ID 'Goblin_B' to position 'Front_3'
	Then Pack formation should look like this
	| Position | Character_ID |
	| Front_1  |              |
	| Front_2  |              |
	| Front_3  | Goblin_B     |
	| Middle_1 | Elf_A        |
	| Middle_2 |              |
	| Middle_3 |              |
	| Middle_4 |              |
	| Rear_1   |              |
	| Rear_2   |              |
	| Rear_3   |              |


Scenario: 04 Building opponent formation base on template
	Given Some mercenary templates
	| Level | Name   | HP_range | Min_Attack_range | Defence_range | Speed_range | Attack_add_for_max |
	| 1     | Goblin | 18-22    | 8-12             | 8-12          | 8-10        | 4                  |
	| 2     | Goblin | 22-26    | 12-16            | 10-14         | 9-11        | 5                  |
	| 3     | Goblin | 26-34    | 16-24            | 12-16         | 10-12       | 7                  |
	| 4     | Goblin | 40-55    | 30-40            | 18-22         | 11-13       | 10                 |
	And Have some formation templates
	| ID  | Name                 | Level | F1       | F2       | F3 | M1 | M2 | M3 | M4 | R1 | R2 | R3 |
	| T_1 | Goblin pack - easy   | 1     | Goblin@1 |          |    |    |    |    |    |    |    |    |
	| T_2 | Goblin pack - normal | 2     | Goblin@2 | Goblin@2 |    |    |    |    |    |    |    |    |
	When System want to build opponent pack base on template 'T_1'
	Then Generated opponents collection should have characters below
	| ID          | Name   | Level | HP_range |
	| Front_1_Goblin_1 | Goblin | 1     | 18-22    |
	And Opponent pack formation should look like this
	| Position | Character_ID     |
	| Front_1  | Front_1_Goblin_1 |
	| Front_2  |                  |
	| Front_3  |                  |
	| Middle_1 |                  |
	| Middle_2 |                  |
	| Middle_3 |                  |
	| Middle_4 |                  |
	| Rear_1   |                  |
	| Rear_2   |                  |
	| Rear_3   |                  |


Scenario: 05 Building opponent formation base on template - many characters
	Given Some mercenary templates
	| Level | Name   | HP_range | Min_Attack_range | Defence_range | Speed_range | Attack_add_for_max |
	| 1     | Goblin | 18-22    | 8-12             | 8-12          | 8-10        | 4                  |
	| 2     | Goblin | 22-26    | 12-16            | 10-14         | 9-11        | 5                  |
	| 3     | Goblin | 26-34    | 16-24            | 12-16         | 10-12       | 7                  |
	| 4     | Goblin | 40-55    | 30-40            | 18-22         | 11-13       | 10                 |
	And Have some formation templates
	| ID  | Name                 | Level | F1       | F2       | F3 | M1 | M2       | M3 | M4       | R1       | R2 | R3       |
	| T_1 | Goblin pack - easy   | 1     | Goblin@1 |          |    |    |          |    |          |          |    |          |
	| T_2 | Goblin pack - normal | 2     | Goblin@2 | Goblin@2 |    |    | Goblin@2 |    | Goblin@1 | Goblin@4 |    | Goblin@4 |
	When System want to build opponent pack base on template 'T_2'
	Then Generated opponents collection should have characters below
	| ID                | Name   | Level | HP_range |
	| Front_1_Goblin_2  | Goblin | 1     | 22-26    |
	| Front_2_Goblin_2  | Goblin | 2     | 22-26    |
	| Middle_2_Goblin_2 | Goblin | 2     | 22-26    |
	| Middle_4_Goblin_1 | Goblin | 1     | 18-22    |
	| Rear_1_Goblin_4   | Goblin | 4     | 40-55    |
	| Rear_3_Goblin_4   | Goblin | 4     | 40-55    |
	And Opponent pack formation should look like this
	| Position | Character_ID      |
	| Front_1  | Front_1_Goblin_2  |
	| Front_2  | Front_2_Goblin_2  |
	| Front_3  |                   |
	| Middle_1 |                   |
	| Middle_2 | Middle_2_Goblin_2 |
	| Middle_3 |                   |
	| Middle_4 | Middle_4_Goblin_1 |
	| Rear_1   | Rear_1_Goblin_4   |
	| Rear_2   |                   |
	| Rear_3   | Rear_3_Goblin_4   |