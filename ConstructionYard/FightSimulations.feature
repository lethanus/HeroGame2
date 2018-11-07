Feature: FightSimulations
	Fighting 

@mytag
Scenario: 01 Fast Elf killing Goblin in first turn
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed |
		| Elf_A    | Elf    | 20    | 20 | 10  | 5   | 10    |
		| Golbin_B | Golbin | 10    | 10 | 5   | 0   | 5     |
	And Character 'Elf_A' is assigned to team 'A'
	And Character 'Golbin_B' is assigned to team 'B'
	When Fight between 'A' and 'B' turn 1 ends
	Then The following characters status is
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed |
		| Elf_A    | Elf    | 20    | 20 | 10  | 5   | 10    |
		| Golbin_B | Golbin | 10    | 0  | 5   | 0   | 5     |



Scenario: 02 Goblins are hurting each other after 1 turn
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed |
		| Golbin_A | Golbin | 10    | 10 | 5   | 0   | 5     |
		| Golbin_B | Golbin | 10    | 10 | 5   | 0   | 5     |
	And Character 'Golbin_A' is assigned to team 'A'
	And Character 'Golbin_B' is assigned to team 'B'
	When Fight between 'A' and 'B' turn 1 ends
	Then The following characters status is
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed |
		| Golbin_A | Golbin | 10    | 5  | 5   | 0   | 5     |
		| Golbin_B | Golbin | 10    | 5  | 5   | 0   | 5     |


Scenario: 03 Elf is to weak for a Troll
	Given The following characters
		| ID      | Name  | MaxHp | Hp  | Att | Def | Speed |
		| Elf_A   | Elf   | 20    | 20  | 10  | 5   | 10    |
		| Troll_B | Troll | 100   | 100 | 15  | 5   | 5     |
	And Character 'Elf_A' is assigned to team 'A'
	And Character 'Troll_B' is assigned to team 'B'
	When Fight between 'A' and 'B' turn 2 ends
	Then The following characters status is
		| ID      | Name  | MaxHp | Hp | Att | Def | Speed |
		| Elf_A   | Elf   | 20    | 0  | 10  | 5   | 10    |
		| Troll_B | Troll | 100   | 90 | 15  | 5   | 5     |

Scenario: 04 Two fast Elfs killing two Goblins in first turn
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed |
		| Elf_A    | Elf    | 20    | 20 | 10  | 5   | 10    |
		| Elf_B    | Elf    | 20    | 20 | 10  | 5   | 10    |
		| Golbin_A | Golbin | 10    | 10 | 5   | 0   | 5     |
		| Golbin_B | Golbin | 10    | 10 | 5   | 0   | 5     |
	And Character 'Elf_A' is assigned to team 'A'
	And Character 'Elf_B' is assigned to team 'A'
	And Character 'Golbin_A' is assigned to team 'B'
	And Character 'Golbin_B' is assigned to team 'B'
	When Fight between 'A' and 'B' turn 1 ends
	Then The following characters status is
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed |
		| Elf_A    | Elf    | 20    | 20 | 10  | 5   | 10    |
		| Elf_B    | Elf    | 20    | 20 | 10  | 5   | 10    |
		| Golbin_A | Golbin | 10    | 0  | 5   | 0   | 5     |
		| Golbin_B | Golbin | 10    | 0  | 5   | 0   | 5     |


Scenario: 05 Fast Elf killing many Goblins and gets wounded
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed |
		| Elf_A    | Elf    | 20    | 20 | 10  | 4   | 10    |
		| Golbin_A | Golbin | 10    | 10 | 5   | 0   | 5     |
		| Golbin_B | Golbin | 10    | 10 | 5   | 0   | 5     |
		| Golbin_C | Golbin | 10    | 10 | 5   | 0   | 5     |
		| Golbin_D | Golbin | 10    | 10 | 5   | 0   | 5     |
	And Character 'Elf_A' is assigned to team 'A'
	And Character 'Golbin_A' is assigned to team 'B'
	And Character 'Golbin_B' is assigned to team 'B'
	And Character 'Golbin_C' is assigned to team 'B'
	And Character 'Golbin_D' is assigned to team 'B'
	When Fight between 'A' and 'B' turn 4 ends
	Then The following characters status is
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed |
		| Elf_A    | Elf    | 20    | 14 | 10  | 4   | 10    |
		| Golbin_A | Golbin | 10    | 0  | 5   | 0   | 5     |
		| Golbin_B | Golbin | 10    | 0  | 5   | 0   | 5     |
		| Golbin_C | Golbin | 10    | 0  | 5   | 0   | 5     |
		| Golbin_D | Golbin | 10    | 0  | 5   | 0   | 5     |