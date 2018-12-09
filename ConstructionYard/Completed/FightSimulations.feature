Feature: Fight simulations
	Fighting 

@mytag
Scenario: 01 Fast Elf killing Goblin in first turn
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
		| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
		| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Goblin_B' is assigned to team 'B' on position 'Front_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID       | Hp_range |
		| Elf_A    | 20       |
		| Goblin_B | 0        |
	And Team 'A' won


Scenario: 02 Goblins are hurting each other
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
		| Goblin_A | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
		| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
	And Character 'Goblin_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Goblin_B' is assigned to team 'B' on position 'Front_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID       | Hp_range |
		| Goblin_A | 5        |
		| Goblin_B | 0        |
	And Team 'A' won

Scenario: 03 Elf is to weak for a Troll
	Given The following characters
		| ID      | Name  | MaxHp | Hp  | Min_Att | Max_Att | Def | Speed | Skills |
		| Elf_A   | Elf   | 20    | 20  | 10      | 10      | 5   | 10    |        |
		| Troll_B | Troll | 100   | 100 | 15      | 15      | 5   | 5     |        |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Troll_B' is assigned to team 'B' on position 'Front_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID      | Hp_range |
		| Elf_A   | 0        |
		| Troll_B | 90       |
	And Team 'B' won

Scenario: 04 Two fast Elfs killing two Goblins in first turn
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
		| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
		| Elf_B    | Elf    | 20    | 20 | 10      | 10      | 5   | 10    |        |
		| Goblin_A | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
		| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Elf_B' is assigned to team 'A' on position 'Front_2'
	And Character 'Goblin_A' is assigned to team 'B' on position 'Front_1'
	And Character 'Goblin_B' is assigned to team 'B' on position 'Front_2'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID       | Hp_range |
		| Elf_A    | 20       |
		| Elf_B    | 20       |
		| Goblin_A | 0        |
		| Goblin_B | 0        |
	And Team 'A' won

Scenario: 05 Fast Elf killing many Goblins and gets wounded
	Given The following characters
		| ID       | Name   | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
		| Elf_A    | Elf    | 20    | 20 | 10      | 10      | 4   | 10    |        |
		| Goblin_A | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
		| Goblin_B | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
		| Goblin_C | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
		| Goblin_D | Goblin | 10    | 10 | 5       | 5       | 0   | 5     |        |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Goblin_A' is assigned to team 'B' on position 'Front_1'
	And Character 'Goblin_B' is assigned to team 'B' on position 'Front_2'
	And Character 'Goblin_C' is assigned to team 'B' on position 'Front_3'
	And Character 'Goblin_D' is assigned to team 'B' on position 'Middle_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID       | Hp_range |
		| Elf_A    | 14       |
		| Goblin_A | 0        |
		| Goblin_B | 0        |
		| Goblin_C | 0        |
		| Goblin_D | 0        |
	And Team 'A' won

	Scenario: 06 Elf is not able to damage Human Palladin
	Given The following characters
		| ID      | Name  | MaxHp | Hp  | Min_Att | Max_Att | Def | Speed | Skills |
		| Elf_A   | Elf   | 20    | 20  | 10      | 10      | 5   | 10    |        |
		| Human_B | Human | 100   | 100 | 40      | 40      | 25  | 9     |        |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Human_B' is assigned to team 'B' on position 'Front_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID      | Hp_range |
		| Elf_A   | 0        |
		| Human_B | 100      |
	And Team 'B' won

	Scenario: 07 Damage should be between min and max values
	Given The following characters
		| ID      | Name  | MaxHp | Hp  | Min_Att | Max_Att | Def | Speed | Skills |
		| Elf_A   | Elf   | 20    | 20  | 10      | 90      | 0   | 10    |        |
		| Human_B | Human | 100   | 100 | 20      | 20      | 0   | 9     |        |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Human_B' is assigned to team 'B' on position 'Front_1'
	When Fight between 'A' and 'B' starts
	Then The following characters status is
		| ID      | Hp_range |
		| Elf_A   | 0        |
		| Human_B | 10-90    |
	And Team 'B' won


Scenario: 08 Fight replay with one shot
	Given The following characters
		| ID    | Name | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
		| Elf_A | Elf  | 20    | 20 | 30      | 30      | 5   | 10    |        |
		| Rat_A | Rat  | 10    | 10 | 1       | 1       | 0   | 5     |        |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Rat_A' is assigned to team 'B' on position 'Front_1'
	When Fight between 'A' and 'B' starts
	Then Team 'A' won
	And Replay acctions are
	| Action_Order | Attacker_ID | Attacker_Position | Defender_ID | Defender_Position | Defender_New_Hp | Attacker_DMG_dealt |
	| 1            | Elf_A       | Front_1           | Rat_A       | Front_1           | 0               | 1                  |


Scenario: 09 Fight replay with three shots
	Given The following characters
		| ID    | Name | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills |
		| Elf_A | Elf  | 20    | 20 | 30      | 30      | 5   | 10    |        |
		| Rat_A | Rat  | 50    | 50 | 7       | 7       | 0   | 5     |        |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Rat_A' is assigned to team 'B' on position 'Front_1'
	When Fight between 'A' and 'B' starts
	Then Team 'A' won
	And Replay acctions are
	| Action_Order | Attacker_ID | Attacker_Position | Defender_ID | Defender_Position | Defender_New_Hp | Attacker_DMG_dealt |
	| 1            | Elf_A       | Front_1           | Rat_A       | Front_1           | 20              | 30                 |
	| 2            | Rat_A       | Front_1           | Elf_A       | Front_1           | 18              | 2                  |
	| 3            | Elf_A       | Front_1           | Rat_A       | Front_1           | 0               | 20                 |