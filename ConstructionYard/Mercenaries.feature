Feature: Mercenaries management
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
	| Level | Name   | HP_range | Min_Attack_range | Defence_range | Speed_range | Attack_add_for_max |
	| 1     | Goblin | 18-22    | 8-12             | 8-12          | 8-10        | 4                  |
	| 2     | Goblin | 22-26    | 12-16            | 10-14         | 9-11        | 5                  |
	| 3     | Goblin | 26-34    | 16-24            | 12-16         | 10-12       | 7                  |
	| 4     | Goblin | 40-55    | 30-40            | 18-22         | 11-13       | 10                 |
	When Creating mercenary 'Goblin' of level '4'
	Then Created mercenary should have 'Hp' between '40' and '55'
	And Created mercenary should have 'Attack_Min' between '30' and '40'
	And Created mercenary should have 'Attack_Max' between '40' and '50'
	And Created mercenary should have 'Defence' between '18' and '22'
	And Created mercenary should have 'Speed' between '11' and '13'


Scenario: 04 Generating potential recruits for level 1
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Some mercenary templates
	| Level | Name   | HP_range | Min_Attack_range | Defence_range | Speed_range | Attack_add_for_max |
	| 1     | Goblin | 18-22    | 8-12             | 8-12          | 8-10        | 4                  |
	| 2     | Goblin | 22-26    | 12-16            | 10-14         | 9-11        | 5                  |
	| 3     | Goblin | 26-34    | 16-24            | 12-16         | 10-12       | 7                  |
	| 4     | Goblin | 40-55    | 30-40            | 18-22         | 11-13       | 10                 |
	And Number of recruits is set to '5'
	And The chance of getting level '1' mercenaries is set to '100' of '100'
	And Randomzer for mercenary level will always return '7'
	When User will use refresh for mercenaries
	Then Count of potential recruits generated should be '5' for user with ID 'ID_1'
	And All potential recruits should have set 'Name' to 'Goblin'
	And All potential recruits should have set 'Level' to '1'
	And All potential recruits should have set value of 'Hp' between '18' and '22'
	And All potential recruits should have set value of 'Attack_Min' between '8' and '12'
	And All potential recruits should have set value of 'Attack_Max' between '12' and '16'
	And All potential recruits should have set value of 'Defence' between '8' and '12'
	And All potential recruits should have set value of 'Speed' between '8' and '10'


Scenario: 05 Generating potential recruits for level 2
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Some mercenary templates
	| Level | Name   | HP_range | Min_Attack_range | Defence_range | Speed_range | Attack_add_for_max |
	| 1     | Goblin | 18-22    | 8-12             | 8-12          | 8-10        | 4                  |
	| 2     | Goblin | 22-26    | 12-16            | 10-14         | 9-11        | 5                  |
	| 3     | Goblin | 26-34    | 16-24            | 12-16         | 10-12       | 7                  |
	| 4     | Goblin | 40-55    | 30-40            | 18-22         | 11-13       | 10                 |
	And Number of recruits is set to '2'
	And The chance of getting level '1' mercenaries is set to '10000' of '10000'
	And The chance of getting level '2' mercenaries is set to '2500' of '10000'
	And The chance of getting level '3' mercenaries is set to '1000' of '10000'
	And The chance of getting level '4' mercenaries is set to '100' of '10000'
	And Randomzer for mercenary level will always return '2400'
	When User will use refresh for mercenaries
	Then Count of potential recruits generated should be '2' for user with ID 'ID_1'
	And All potential recruits should have set 'Name' to 'Goblin'
	And All potential recruits should have set 'Level' to '2'
	And All potential recruits should have set value of 'Hp' between '22' and '26'
	And All potential recruits should have set value of 'Attack_Min' between '12' and '16'
	And All potential recruits should have set value of 'Attack_Max' between '17' and '21'
	And All potential recruits should have set value of 'Defence' between '10' and '14'
	And All potential recruits should have set value of 'Speed' between '9' and '11'


Scenario: 06 Generating potential recruits for level 3
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Some mercenary templates
	| Level | Name   | HP_range | Min_Attack_range | Defence_range | Speed_range | Attack_add_for_max |
	| 1     | Goblin | 18-22    | 8-12             | 8-12          | 8-10        | 4                  |
	| 2     | Goblin | 22-26    | 12-16            | 10-14         | 9-11        | 5                  |
	| 3     | Goblin | 26-34    | 16-24            | 12-16         | 10-12       | 7                  |
	| 4     | Goblin | 40-55    | 30-40            | 18-22         | 11-13       | 10                 |
	And Number of recruits is set to '3'
	And The chance of getting level '1' mercenaries is set to '10000' of '10000'
	And The chance of getting level '2' mercenaries is set to '2500' of '10000'
	And The chance of getting level '3' mercenaries is set to '1000' of '10000'
	And The chance of getting level '4' mercenaries is set to '100' of '10000'
	And Randomzer for mercenary level will always return '999'
	When User will use refresh for mercenaries
	Then Count of potential recruits generated should be '3' for user with ID 'ID_1'
	And All potential recruits should have set 'Name' to 'Goblin'
	And All potential recruits should have set 'Level' to '3'
	And All potential recruits should have set value of 'Hp' between '26' and '34'
	And All potential recruits should have set value of 'Attack_Min' between '16' and '24'
	And All potential recruits should have set value of 'Attack_Max' between '23' and '31'
	And All potential recruits should have set value of 'Defence' between '12' and '16'
	And All potential recruits should have set value of 'Speed' between '10' and '12'

Scenario: 07 Generating potential recruits for level 4
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Some mercenary templates
	| Level | Name   | HP_range | Min_Attack_range | Defence_range | Speed_range | Attack_add_for_max |
	| 1     | Goblin | 18-22    | 8-12             | 8-12          | 8-10        | 4                  |
	| 2     | Goblin | 22-26    | 12-16            | 10-14         | 9-11        | 5                  |
	| 3     | Goblin | 26-34    | 16-24            | 12-16         | 10-12       | 7                  |
	| 4     | Goblin | 40-55    | 30-40            | 18-22         | 11-13       | 10                 |
	And Number of recruits is set to '7'
	And The chance of getting level '1' mercenaries is set to '10000' of '10000'
	And The chance of getting level '2' mercenaries is set to '2500' of '10000'
	And The chance of getting level '3' mercenaries is set to '1000' of '10000'
	And The chance of getting level '4' mercenaries is set to '100' of '10000'
	And Randomzer for mercenary level will always return '2'
	When User will use refresh for mercenaries
	Then Count of potential recruits generated should be '7' for user with ID 'ID_1'
	And All potential recruits should have set 'Name' to 'Goblin'
	And All potential recruits should have set 'Level' to '4'
	And All potential recruits should have set value of 'Hp' between '40' and '55'
	And All potential recruits should have set value of 'Attack_Min' between '30' and '40'
	And All potential recruits should have set value of 'Attack_Max' between '40' and '50'
	And All potential recruits should have set value of 'Defence' between '18' and '22'
	And All potential recruits should have set value of 'Speed' between '11' and '13'

Scenario: 08 Generating potential recruits for level 1 for many first level mercenaries
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And Some mercenary templates
	| Level | Name   | HP_range | Min_Attack_range | Defence_range | Speed_range | Attack_add_for_max |
	| 1     | Goblin | 18-22    | 8-12             | 8-12          | 8-10        | 4                  |
	| 1     | Elf    | 22-26    | 12-16            | 10-14         | 9-11        | 4                  |
	| 1     | Orc    | 26-34    | 16-24            | 12-16         | 10-12       | 4                  |
	And Number of recruits is set to '100'
	And The chance of getting level '1' mercenaries is set to '100' of '100'
	And Randomzer for mercenary level will always return '7'
	When User will use refresh for mercenaries
	Then Count of potential recruits generated should be '100' for user with ID 'ID_1'
	And There are some potential recruits with 'Name' equal to 'Goblin'
	And There are some potential recruits with 'Name' equal to 'Elf'
	And There are some potential recruits with 'Name' equal to 'Orc'
	And All potential recruits should have set 'Level' to '1'

Scenario: 09 Successfully convincing level 1 recruit
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And There as some recruits
	| ID    | Level | Name | Hp | Attack_Min | Attack_Max | Defence | Speed |
	| Elf_A | 1     | Elf  | 20 | 10         | 20         | 10      | 5     | 
	And The chance of convincing level '1' recruits is set to '100' of '100'
	And The chance of convincing level '2' recruits is set to '50' of '100'
	And The chance of convincing level '3' recruits is set to '20' of '100'
	And The chance of convincing level '4' recruits is set to '10' of '100'
	And Randomzer for convincing recruits will always return '90'
	When Logged user will try to convince recruit with ID 'Elf_A'
	Then Logged account id is 'ID_1'
	And Logged account should have mercenaries
	| ID    | Name | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A | Elf  | 20    | 20 | 10      | 20      | 10  | 5     |        |  
	And Count of potential recruits generated should be '0' for user with ID 'ID_1'

Scenario: 10 Failing to convince level 1 recruit
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And There as some recruits
	| ID    | Level | Name | Hp | Attack_Min | Attack_Max | Defence | Speed |
	| Elf_A | 1     | Elf  | 20 | 10         | 20         | 10      | 5     | 
	And The chance of convincing level '1' recruits is set to '70' of '100'
	And The chance of convincing level '2' recruits is set to '50' of '100'
	And The chance of convincing level '3' recruits is set to '20' of '100'
	And The chance of convincing level '4' recruits is set to '10' of '100'
	And Randomzer for convincing recruits will always return '80'
	When Logged user will try to convince recruit with ID 'Elf_A'
	Then Logged account id is 'ID_1'
	And Logged account should have mercenaries
	| ID    | Name | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills | 
	And Count of potential recruits generated should be '0' for user with ID 'ID_1'

Scenario: 11 Successfully convincing level 2 recruit
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And There as some recruits
	| ID    | Level | Name | Hp | Attack_Min | Attack_Max | Defence | Speed |
	| Elf_A | 2     | Elf  | 20 | 10         | 20         | 10      | 5     | 
	And The chance of convincing level '1' recruits is set to '100' of '100'
	And The chance of convincing level '2' recruits is set to '50' of '100'
	And The chance of convincing level '3' recruits is set to '20' of '100'
	And The chance of convincing level '4' recruits is set to '10' of '100'
	And Randomzer for convincing recruits will always return '49'
	When Logged user will try to convince recruit with ID 'Elf_A'
	Then Logged account id is 'ID_1'
	And Logged account should have mercenaries
	| ID    | Name | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A | Elf  | 20    | 20 | 10      | 20      | 10  | 5     |        | 
	And Count of potential recruits generated should be '0' for user with ID 'ID_1'

Scenario: 12 Successfully convincing level 3 recruit
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And There as some recruits
	| ID    | Level | Name | Hp | Attack_Min | Attack_Max | Defence | Speed |
	| Elf_A | 3     | Elf  | 20 | 10         | 20         | 10      | 5     | 
	And The chance of convincing level '1' recruits is set to '100' of '100'
	And The chance of convincing level '2' recruits is set to '50' of '100'
	And The chance of convincing level '3' recruits is set to '20' of '100'
	And The chance of convincing level '4' recruits is set to '10' of '100'
	And Randomzer for convincing recruits will always return '1'
	When Logged user will try to convince recruit with ID 'Elf_A'
	Then Logged account id is 'ID_1'
	And Logged account should have mercenaries
	| ID    | Name | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A | Elf  | 20    | 20 | 10      | 20      | 10  | 5     |        | 
	And Count of potential recruits generated should be '0' for user with ID 'ID_1'

Scenario: 13 Successfully convincing level 4 recruit
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And There as some recruits
	| ID    | Level | Name | Hp | Attack_Min | Attack_Max | Defence | Speed |
	| Elf_A | 4     | Elf  | 20 | 10         | 20         | 10      | 5     | 
	And The chance of convincing level '1' recruits is set to '100' of '100'
	And The chance of convincing level '2' recruits is set to '50' of '100'
	And The chance of convincing level '3' recruits is set to '20' of '100'
	And The chance of convincing level '4' recruits is set to '10' of '100'
	And Randomzer for convincing recruits will always return '1'
	When Logged user will try to convince recruit with ID 'Elf_A'
	Then Logged account id is 'ID_1'
	And Logged account should have mercenaries
	| ID    | Name | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A | Elf  | 20    | 20 | 10      | 20      | 10  | 5     |        | 
	And Count of potential recruits generated should be '0' for user with ID 'ID_1'

Scenario: 14 Successfully convincing level 4 recruit after bribery
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And There as some recruits
	| ID    | Level | Name | Hp | Attack_Min | Attack_Max | Defence | Speed |
	| Elf_A | 4     | Elf  | 20 | 10         | 20         | 10      | 5     | 
	And The chance of convincing level '1' recruits is set to '10000' of '10000'
	And The chance of convincing level '2' recruits is set to '5000' of '10000'
	And The chance of convincing level '3' recruits is set to '2000' of '10000'
	And The chance of convincing level '4' recruits is set to '1000' of '10000'
	And Randomzer for convincing recruits will always return '1290'
	And Inventory already contains items below
	| ID   | Name     | Amount | Category | Effects                         |
	| TR_1 | Rat tail | 10     | Trophy   | Mercenary_Convince_Chance_(+1%) |
	| O_1  | Other    | 5      | Other    | None                            |
	And Valid as a gifts are items
	| ID   | Name     | Amount | Category | Effects                         |
	| TR_1 | Rat tail | 10     | Trophy   | Mercenary_Convince_Chance_(+1%) |
	When Looged user will add '3' items with ID 'TR_1' as a gift 
	And Logged user will try to convince recruit with ID 'Elf_A'
	Then Logged account id is 'ID_1'
	And Logged account should have mercenaries
	| ID    | Name | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A | Elf  | 20    | 20 | 10      | 20      | 10  | 5     |        | 
	And Count of potential recruits generated should be '0' for user with ID 'ID_1'
	And Inventory should have items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 7      | Trophy   |
	| O_1  | Other    | 5      | Other    | 

Scenario: 15 Failing to convince level 4 recruit after bribery
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And There as some recruits
	| ID    | Level | Name | Hp | Attack_Min | Attack_Max | Defence | Speed |
	| Elf_A | 4     | Elf  | 20 | 10         | 20         | 10      | 5     | 
	And The chance of convincing level '1' recruits is set to '10000' of '10000'
	And The chance of convincing level '2' recruits is set to '5000' of '10000'
	And The chance of convincing level '3' recruits is set to '2000' of '10000'
	And The chance of convincing level '4' recruits is set to '1000' of '10000'
	And Randomzer for convincing recruits will always return '1310'
	And Inventory already contains items below
	| ID   | Name     | Amount | Category | Effects                         |
	| TR_1 | Rat tail | 10     | Trophy   | Mercenary_Convince_Chance_(+1%) |
	| O_1  | Other    | 5      | Other    | None                            |
	And Valid as a gifts are items
	| ID   | Name     | Amount | Category | Effects                         |
	| TR_1 | Rat tail | 10     | Trophy   | Mercenary_Convince_Chance_(+1%) |
	When Looged user will add '3' items with ID 'TR_1' as a gift 
	And Logged user will try to convince recruit with ID 'Elf_A'
	Then Logged account id is 'ID_1'
	And Logged account should have mercenaries
	| ID    | Name | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	And Count of potential recruits generated should be '0' for user with ID 'ID_1'
	And Inventory should have items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 10     | Trophy   |
	| O_1  | Other    | 5      | Other    | 

Scenario: 16 Successfully convincing level 4 recruit after bribery using better item
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And There as some recruits
	| ID    | Level | Name | Hp | Attack_Min | Attack_Max | Defence | Speed |
	| Elf_A | 4     | Elf  | 20 | 10         | 20         | 10      | 5     | 
	And The chance of convincing level '1' recruits is set to '10000' of '10000'
	And The chance of convincing level '2' recruits is set to '5000' of '10000'
	And The chance of convincing level '3' recruits is set to '2000' of '10000'
	And The chance of convincing level '4' recruits is set to '1000' of '10000'
	And Randomzer for convincing recruits will always return '1990'
	And Inventory already contains items below
	| ID   | Name     | Amount | Category | Effects                          |
	| TR_1 | Rat tail | 10     | Trophy   | Mercenary_Convince_Chance_(+10%) |
	| O_1  | Other    | 5      | Other    | None                             |
	And Valid as a gifts are items
	| ID   | Name     | Amount | Category | Effects                          |
	| TR_1 | Rat tail | 10     | Trophy   | Mercenary_Convince_Chance_(+10%) |
	When Looged user will add '1' items with ID 'TR_1' as a gift 
	And Logged user will try to convince recruit with ID 'Elf_A'
	Then Logged account id is 'ID_1'
	And Logged account should have mercenaries
	| ID    | Name | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
	| Elf_A | Elf  | 20    | 20 | 10      | 20      | 10  | 5     |        |
	And Count of potential recruits generated should be '0' for user with ID 'ID_1'
	And Inventory should have items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 9      | Trophy   |
	| O_1  | Other    | 5      | Other    | 


Scenario: 17 List of gifts management
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And There as some recruits
	| ID    | Level | Name | Hp | Attack_Min | Attack_Max | Defence | Speed |
	| Elf_A | 4     | Elf  | 20 | 10         | 20         | 10      | 5     | 
	And The chance of convincing level '1' recruits is set to '10000' of '10000'
	And The chance of convincing level '2' recruits is set to '5000' of '10000'
	And The chance of convincing level '3' recruits is set to '2000' of '10000'
	And The chance of convincing level '4' recruits is set to '1000' of '10000'
	And Randomzer for convincing recruits will always return '90'
	And Inventory already contains items below
	| ID   | Name     | Amount | Category | Effects                          |
	| TR_1 | Rat tail | 10     | Trophy   | Mercenary_Convince_Chance_(+10%) |
	And Valid as a gifts are items
	| ID   | Name     | Amount | Category | Effects                          |
	| TR_1 | Rat tail | 10     | Trophy   | Mercenary_Convince_Chance_(+10%) |
	When List of gifts should have items below
	| ID   | Name     | Amount | Category |
	And Looged user will add '5' items with ID 'TR_1' as a gift 
	And List of gifts should have items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 5      | Trophy   |
	And Looged user will remove '3' items with ID 'TR_1' from gifts 
	And List of gifts should have items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 2      | Trophy   |
	And Logged user will try to convince recruit with ID 'Elf_A'
	And List of gifts should have items below
	| ID   | Name     | Amount | Category |



Scenario: 18 List of gifts management - corner cases
	Given Some accounts exists in system
	| ID   | Login | Password |
	| ID_1 | test  | test     |
	And I try to login for 'test' and password 'test'
	And There as some recruits
	| ID    | Level | Name | Hp | Attack_Min | Attack_Max | Defence | Speed |
	| Elf_A | 4     | Elf  | 20 | 10         | 20         | 10      | 5     | 
	And The chance of convincing level '1' recruits is set to '10000' of '10000'
	And The chance of convincing level '2' recruits is set to '5000' of '10000'
	And The chance of convincing level '3' recruits is set to '2000' of '10000'
	And The chance of convincing level '4' recruits is set to '1000' of '10000'
	And Randomzer for convincing recruits will always return '10000'
	And Inventory already contains items below
	| ID   | Name     | Amount | Category | Effects                          |
	| TR_1 | Rat tail | 10     | Trophy   | Mercenary_Convince_Chance_(+1%)  |
	And Valid as a gifts are items
	| ID   | Name     | Amount | Category | Effects                          |
	| TR_1 | Rat tail | 10     | Trophy   | Mercenary_Convince_Chance_(+1%)  |
	When List of gifts should have items below
	| ID   | Name     | Amount | Category |
	And Looged user will add '5' items with ID 'TR_1' as a gift 
	And List of gifts should have items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 5      | Trophy   |
	And Looged user will remove '10' items with ID 'TR_1' from gifts 
	And List of gifts should have items below
	| ID   | Name     | Amount | Category |
	And Looged user will add '15' items with ID 'TR_1' as a gift 
	And List of gifts should have items below
	| ID   | Name     | Amount | Category |
	| TR_1 | Rat tail | 15     | Trophy   |
	And Logged user will try to convince recruit with ID 'Elf_A'
	And List of gifts should have items below
	| ID   | Name     | Amount | Category |