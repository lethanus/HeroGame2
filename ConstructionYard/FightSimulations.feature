Feature: FightSimulations
	Fighting 

@mytag
Scenario: 01 Fast Elf killing Goblin in first turn
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed | Skills        |
		| Elf_A    | Elf    | 20    | 20 | 10  | 5   | 10    | Normal_Attack |
		| Golbin_B | Golbin | 10    | 10 | 5   | 0   | 5     | Normal_Attack |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Golbin_B' is assigned to team 'B' on position 'Front_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed | Skills        |
		| Elf_A    | Elf    | 20    | 20 | 10  | 5   | 10    | Normal_Attack |
		| Golbin_B | Golbin | 10    | 0  | 5   | 0   | 5     | Normal_Attack |
	And Team 'A' won


Scenario: 02 Goblins are hurting each other
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed | Skills        |
		| Golbin_A | Golbin | 10    | 10 | 5   | 0   | 5     | Normal_Attack |
		| Golbin_B | Golbin | 10    | 10 | 5   | 0   | 5     | Normal_Attack |
	And Character 'Golbin_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Golbin_B' is assigned to team 'B' on position 'Front_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed | Skills        |
		| Golbin_A | Golbin | 10    | 5  | 5   | 0   | 5     | Normal_Attack |
		| Golbin_B | Golbin | 10    | 0  | 5   | 0   | 5     | Normal_Attack |
	And Team 'A' won

Scenario: 03 Elf is to weak for a Troll
	Given The following characters
		| ID      | Name  | MaxHp | Hp  | Att | Def | Speed | Skills        |
		| Elf_A   | Elf   | 20    | 20  | 10  | 5   | 10    | Normal_Attack |
		| Troll_B | Troll | 100   | 100 | 15  | 5   | 5     | Normal_Attack |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Troll_B' is assigned to team 'B' on position 'Front_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID      | Name  | MaxHp | Hp | Att | Def | Speed | Skills        |
		| Elf_A   | Elf   | 20    | 0  | 10  | 5   | 10    | Normal_Attack |
		| Troll_B | Troll | 100   | 90 | 15  | 5   | 5     | Normal_Attack |
	And Team 'B' won

Scenario: 04 Two fast Elfs killing two Goblins in first turn
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed | Skills        |
		| Elf_A    | Elf    | 20    | 20 | 10  | 5   | 10    | Normal_Attack |
		| Elf_B    | Elf    | 20    | 20 | 10  | 5   | 10    | Normal_Attack |
		| Golbin_A | Golbin | 10    | 10 | 5   | 0   | 5     | Normal_Attack |
		| Golbin_B | Golbin | 10    | 10 | 5   | 0   | 5     | Normal_Attack |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Elf_B' is assigned to team 'A' on position 'Front_2'
	And Character 'Golbin_A' is assigned to team 'B' on position 'Front_1'
	And Character 'Golbin_B' is assigned to team 'B' on position 'Front_2'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed | Skills        |
		| Elf_A    | Elf    | 20    | 20 | 10  | 5   | 10    | Normal_Attack |
		| Elf_B    | Elf    | 20    | 20 | 10  | 5   | 10    | Normal_Attack |
		| Golbin_A | Golbin | 10    | 0  | 5   | 0   | 5     | Normal_Attack |
		| Golbin_B | Golbin | 10    | 0  | 5   | 0   | 5     | Normal_Attack |
	And Team 'A' won

Scenario: 05 Fast Elf killing many Goblins and gets wounded
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed | Skills        |
		| Elf_A    | Elf    | 20    | 20 | 10  | 4   | 10    | Normal_Attack |
		| Golbin_A | Golbin | 10    | 10 | 5   | 0   | 5     | Normal_Attack |
		| Golbin_B | Golbin | 10    | 10 | 5   | 0   | 5     | Normal_Attack |
		| Golbin_C | Golbin | 10    | 10 | 5   | 0   | 5     | Normal_Attack |
		| Golbin_D | Golbin | 10    | 10 | 5   | 0   | 5     | Normal_Attack |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Golbin_A' is assigned to team 'B' on position 'Front_1'
	And Character 'Golbin_B' is assigned to team 'B' on position 'Front_2'
	And Character 'Golbin_C' is assigned to team 'B' on position 'Front_3'
	And Character 'Golbin_D' is assigned to team 'B' on position 'Middle_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID       | Name   | MaxHp | Hp | Att | Def | Speed | Skills        |
		| Elf_A    | Elf    | 20    | 14 | 10  | 4   | 10    | Normal_Attack |
		| Golbin_A | Golbin | 10    | 0  | 5   | 0   | 5     | Normal_Attack |
		| Golbin_B | Golbin | 10    | 0  | 5   | 0   | 5     | Normal_Attack |
		| Golbin_C | Golbin | 10    | 0  | 5   | 0   | 5     | Normal_Attack |
		| Golbin_D | Golbin | 10    | 0  | 5   | 0   | 5     | Normal_Attack |
	And Team 'A' won

	Scenario: 06 Elf is not able to damage Human Palladin
	Given The following characters
		| ID      | Name  | MaxHp | Hp  | Att | Def | Speed | Skills        |
		| Elf_A   | Elf   | 20    | 20  | 10  | 5   | 10    | Normal_Attack |
		| Human_B | Human | 100   | 100 | 40  | 25  | 9     | Normal_Attack |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Human_B' is assigned to team 'B' on position 'Front_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID      | Name  | MaxHp | Hp  | Att | Def | Speed | Skills        |
		| Elf_A   | Elf   | 20    | 0   | 10  | 5   | 10    | Normal_Attack |
		| Human_B | Human | 100   | 100 | 40  | 25  | 9     | Normal_Attack |
	And Team 'B' won