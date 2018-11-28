Feature: Fight management
	

@mytag
Scenario: 01 Player team for sure should win
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
	When Player will set character with ID 'Elf_A' to position 'Front_1'
	And Player will set character with ID 'Goblin_B' to position 'Front_2'
	And Fight will be vs generated team from template 'T_1'
	Then Fight result should be 'Player wins'
	

Scenario: 02 Player team for sure should lose
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
	| Elf_A    | Elf    | 200   | 20 | 30      | 30      | 5   | 7     |        |
	| Goblin_B | Goblin | 100   | 10 | 20      | 20      | 0   | 5     |        |
	When Player will set character with ID 'Elf_A' to position 'Front_1'
	And Player will set character with ID 'Goblin_B' to position 'Front_2'
	And Fight will be vs generated team from template 'T_1'
	Then Fight result should be 'Player defeated'