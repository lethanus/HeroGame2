Feature: Mercenaries
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
	Then Created mercenary should have 'Hp' between '40' and '55'
	And Created mercenary should have 'Attack' between '30' and '40'
	And Created mercenary should have 'Defence' between '18' and '22'
	And Created mercenary should have 'Speed' between '11' and '13'


Scenario: 04 Generating potential recruits for level 1
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Some mercenary templates
	| Level | Name   | HP_range | Attack_range | Defence_range | Speed_range |
	| 1     | Goblin | 18-22    | 8-12         | 8-12          | 8-10        |
	| 2     | Goblin | 22-26    | 12-16        | 10-14         | 9-11        |
	| 3     | Goblin | 26-34    | 16-24        | 12-16         | 10-12       |
	| 4     | Goblin | 40-55    | 30-40        | 18-22         | 11-13       |
	And Number of recruits is set to '5'
	And The chance of getting level '1' mercenaries is set to '100' of '100'
	And Randomzer for mercenary level will always return '7'
	When User with ID 'ID_1' will use refresh for mercenaries
	Then Count of potential recruits generated should be '5' for user with ID 'ID_1'
	And All potential recruits should have set 'Name' to 'Goblin'
	And All potential recruits should have set 'Level' to '1'
	And All potential recruits should have set value of 'Hp' between '18' and '22'
	And All potential recruits should have set value of 'Attack' between '8' and '12'
	And All potential recruits should have set value of 'Defence' between '8' and '12'
	And All potential recruits should have set value of 'Speed' between '8' and '10'


Scenario: 05 Generating potential recruits for level 2
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Some mercenary templates
	| Level | Name   | HP_range | Attack_range | Defence_range | Speed_range |
	| 1     | Goblin | 18-22    | 8-12         | 8-12          | 8-10        |
	| 2     | Goblin | 22-26    | 12-16        | 10-14         | 9-11        |
	| 3     | Goblin | 26-34    | 16-24        | 12-16         | 10-12       |
	| 4     | Goblin | 40-55    | 30-40        | 18-22         | 11-13       |
	And Number of recruits is set to '2'
	And The chance of getting level '1' mercenaries is set to '10000' of '10000'
	And The chance of getting level '2' mercenaries is set to '2500' of '10000'
	And The chance of getting level '3' mercenaries is set to '1000' of '10000'
	And The chance of getting level '4' mercenaries is set to '100' of '10000'
	And Randomzer for mercenary level will always return '2400'
	When User with ID 'ID_1' will use refresh for mercenaries
	Then Count of potential recruits generated should be '2' for user with ID 'ID_1'
	And All potential recruits should have set 'Name' to 'Goblin'
	And All potential recruits should have set 'Level' to '2'
	And All potential recruits should have set value of 'Hp' between '22' and '26'
	And All potential recruits should have set value of 'Attack' between '12' and '16'
	And All potential recruits should have set value of 'Defence' between '10' and '14'
	And All potential recruits should have set value of 'Speed' between '9' and '11'


Scenario: 06 Generating potential recruits for level 3
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Some mercenary templates
	| Level | Name   | HP_range | Attack_range | Defence_range | Speed_range |
	| 1     | Goblin | 18-22    | 8-12         | 8-12          | 8-10        |
	| 2     | Goblin | 22-26    | 12-16        | 10-14         | 9-11        |
	| 3     | Goblin | 26-34    | 16-24        | 12-16         | 10-12       |
	| 4     | Goblin | 40-55    | 30-40        | 18-22         | 11-13       |
	And Number of recruits is set to '3'
	And The chance of getting level '1' mercenaries is set to '10000' of '10000'
	And The chance of getting level '2' mercenaries is set to '2500' of '10000'
	And The chance of getting level '3' mercenaries is set to '1000' of '10000'
	And The chance of getting level '4' mercenaries is set to '100' of '10000'
	And Randomzer for mercenary level will always return '999'
	When User with ID 'ID_1' will use refresh for mercenaries
	Then Count of potential recruits generated should be '3' for user with ID 'ID_1'
	And All potential recruits should have set 'Name' to 'Goblin'
	And All potential recruits should have set 'Level' to '3'
	And All potential recruits should have set value of 'Hp' between '26' and '34'
	And All potential recruits should have set value of 'Attack' between '16' and '24'
	And All potential recruits should have set value of 'Defence' between '12' and '16'
	And All potential recruits should have set value of 'Speed' between '10' and '12'

Scenario: 07 Generating potential recruits for level 4
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Some mercenary templates
	| Level | Name   | HP_range | Attack_range | Defence_range | Speed_range |
	| 1     | Goblin | 18-22    | 8-12         | 8-12          | 8-10        |
	| 2     | Goblin | 22-26    | 12-16        | 10-14         | 9-11        |
	| 3     | Goblin | 26-34    | 16-24        | 12-16         | 10-12       |
	| 4     | Goblin | 40-55    | 30-40        | 18-22         | 11-13       |
	And Number of recruits is set to '7'
	And The chance of getting level '1' mercenaries is set to '10000' of '10000'
	And The chance of getting level '2' mercenaries is set to '2500' of '10000'
	And The chance of getting level '3' mercenaries is set to '1000' of '10000'
	And The chance of getting level '4' mercenaries is set to '100' of '10000'
	And Randomzer for mercenary level will always return '2'
	When User with ID 'ID_1' will use refresh for mercenaries
	Then Count of potential recruits generated should be '7' for user with ID 'ID_1'
	And All potential recruits should have set 'Name' to 'Goblin'
	And All potential recruits should have set 'Level' to '4'
	And All potential recruits should have set value of 'Hp' between '40' and '55'
	And All potential recruits should have set value of 'Attack' between '30' and '40'
	And All potential recruits should have set value of 'Defence' between '18' and '22'
	And All potential recruits should have set value of 'Speed' between '11' and '13'