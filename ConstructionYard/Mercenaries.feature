﻿Feature: Mercenaries
	Managing mercenaries for account

@mytag
Scenario: 01 Adding new mercenary to account
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Account 'ID_1' already have some mercenaries
	| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
	| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
	When Player will add new mercenary
	| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_C    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
	Then Logged account id is 'ID_1'
	And Account 'ID_1' should have mercenaries
	| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
	| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
	| Elf_C    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |