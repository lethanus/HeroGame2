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
	And Logged account should have mercenaries
	| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
	| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
	| Elf_C    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |



Scenario: 02 Adding new mercenary to many accounts
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	| ID_2 | test2 | test2    |
	And Account 'ID_1' already have some mercenaries
	| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
	| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
	And Account 'ID_2' already have some mercenaries
	| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_D    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
	| Goblin_E | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
	When I try to login for 'test' and password 'test'
	And Player will add new mercenary
	| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_C    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
	When I try to login for 'test2' and password 'test2'
	And Player will add new mercenary
	| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_X    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
	Then Logged account id is 'ID_2'
	And Account 'ID_1' should have mercenaries
	| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
	| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
	| Elf_C    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
	And Logged account should have mercenaries
	| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_D    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
	| Goblin_E | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
	| Elf_X    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |



Scenario: 03 New mercenary should be created base on mercenary template
	Given Some mercenary templates
	| Level | Name   | HP_range | Attack_range | Defence_range | Speed_range |
	| 1     | Goblin | 18-22    | 8-12         | 8-12          | 8-10        |
	| 2     | Goblin | 22-26    | 12-16        | 10-14         | 9-11        |
	| 3     | Goblin | 26-34    | 16-24        | 12-16         | 10-12       |
	| 4     | Goblin | 40-55    | 30-40        | 18-22         | 11-13       |
	When Creating mercenary 'Goblin' of level '4'
	Then Created mercenary should have 'Hp' between '40 ' and '55'
	And Created mercenary should have 'Attack' between '30 ' and '40'
	And Created mercenary should have 'Defence' between '18 ' and '22'
	And Created mercenary should have 'Speed' between '11 ' and '13'