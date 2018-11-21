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