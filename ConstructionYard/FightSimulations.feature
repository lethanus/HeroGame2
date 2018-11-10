Feature: FightSimulations
	Fighting 

@mytag
Scenario: 01 Fast Elf killing Goblin in first turn
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills         |
		| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    | Min_Dmg_Attack |
		| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Goblin_B' is assigned to team 'B' on position 'Front_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills         |
		| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    | Min_Dmg_Attack |
		| Goblin_B | Goblin | 10    | 0  | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
	And Team 'A' won


Scenario: 02 Goblins are hurting each other
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills         |
		| Goblin_A | Goblin | 10    | 10 | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
		| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
	And Character 'Goblin_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Goblin_B' is assigned to team 'B' on position 'Front_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills         |
		| Goblin_A | Goblin | 10    | 5  | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
		| Goblin_B | Goblin | 10    | 0  | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
	And Team 'A' won

Scenario: 03 Elf is to weak for a Troll
	Given The following characters
		| ID      | Name  | MaxHp | Hp  | Min_Att | Max_Att | Def | Speed | Skills         |
		| Elf_A   | Elf   | 20    | 20  | 10      | 10      | 5   | 10    | Min_Dmg_Attack |
		| Troll_B | Troll | 100   | 100 | 15      | 15      | 5   | 5     | Min_Dmg_Attack |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Troll_B' is assigned to team 'B' on position 'Front_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID      | Name  | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills         |
		| Elf_A   | Elf   | 20    | 0  | 10      | 10      | 5   | 10    | Min_Dmg_Attack |
		| Troll_B | Troll | 100   | 90 | 15      | 15      | 5   | 5     | Min_Dmg_Attack |
	And Team 'B' won

Scenario: 04 Two fast Elfs killing two Goblins in first turn
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills         |
		| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    | Min_Dmg_Attack |
		| Elf_B    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    | Min_Dmg_Attack |
		| Goblin_A | Goblin | 10    | 10 | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
		| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Elf_B' is assigned to team 'A' on position 'Front_2'
	And Character 'Goblin_A' is assigned to team 'B' on position 'Front_1'
	And Character 'Goblin_B' is assigned to team 'B' on position 'Front_2'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills         |
		| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    | Min_Dmg_Attack |
		| Elf_B    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    | Min_Dmg_Attack |
		| Goblin_A | Goblin | 10    | 0  | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
		| Goblin_B | Goblin | 10    | 0  | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
	And Team 'A' won

Scenario: 05 Fast Elf killing many Goblins and gets wounded
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills         |
		| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 4   | 10    | Min_Dmg_Attack |
		| Goblin_A | Goblin | 10    | 10 | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
		| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
		| Goblin_C | Goblin | 10    | 10 | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
		| Goblin_D | Goblin | 10    | 10 | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Goblin_A' is assigned to team 'B' on position 'Front_1'
	And Character 'Goblin_B' is assigned to team 'B' on position 'Front_2'
	And Character 'Goblin_C' is assigned to team 'B' on position 'Front_3'
	And Character 'Goblin_D' is assigned to team 'B' on position 'Middle_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills         |
		| Elf_A    | Elf    | 20    | 14 | 10      | 10      | 4   | 10    | Min_Dmg_Attack |
		| Goblin_A | Goblin | 10    | 0  | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
		| Goblin_B | Goblin | 10    | 0  | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
		| Goblin_C | Goblin | 10    | 0  | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
		| Goblin_D | Goblin | 10    | 0  | 5       | 5       | 0   | 5     | Min_Dmg_Attack |
	And Team 'A' won

	Scenario: 06 Elf is not able to damage Human Palladin
	Given The following characters
		| ID      | Name  | MaxHp | Hp  | Min_Att | Max_Att | Def | Speed | Skills         |
		| Elf_A   | Elf   | 20    | 20  | 10      | 10      | 5   | 10    | Min_Dmg_Attack |
		| Human_B | Human | 100   | 100 | 40      | 40      | 25  | 9     | Min_Dmg_Attack |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Human_B' is assigned to team 'B' on position 'Front_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID      | Name  | MaxHp | Hp  | Min_Att | Max_Att | Def | Speed | Skills         |
		| Elf_A   | Elf   | 20    | 0   | 10      | 10      | 5   | 10    | Min_Dmg_Attack |
		| Human_B | Human | 100   | 100 | 40      | 40      | 25  | 9     | Min_Dmg_Attack |
	And Team 'B' won