Feature: Range Attack Skill

@mytag
Scenario: 01 Range attack should hit character on mid lane
	Given The following characters
		| ID      | Name  | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills           |
		| Elf_A   | Elf   | 30    | 30 | 30      | 30      | 0   | 10    | Range_One_First  |
		| Troll_A | Troll | 30    | 30 | 15      | 15      | 0   | 5     |                  |
		| Troll_B | Troll | 30    | 30 | 30      | 30      | 0   | 5     |                  |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Troll_A' is assigned to team 'B' on position 'Front_1'
	And Character 'Troll_B' is assigned to team 'B' on position 'Middle_1'
	When Fight between 'A' and 'B' starts
	Then Team 'A' won
	And Replay acctions are
	| Action_Order | Attacker_ID | Attacker_Position | Defender_ID | Defender_Position | Defender_New_Hp | Attacker_DMG_dealt |
	| 1            | Elf_A       | Front_1           | Troll_B     | Middle_1          | 0               | 30                 |
	| 2            | Troll_A     | Front_1           | Elf_A       | Front_1           | 15              | 15                 |
	| 3            | Elf_A       | Front_1           | Troll_A     | Front_1           | 0               | 30                 |

Scenario: 02 Range attack should hit character on rear lane
	Given The following characters
		| ID      | Name  | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills           |
		| Elf_A   | Elf   | 30    | 30 | 30      | 30      | 0   | 10    | Range_One_First  |
		| Troll_A | Troll | 30    | 30 | 15      | 15      | 0   | 5     |                  |
		| Troll_B | Troll | 30    | 30 | 30      | 30      | 0   | 5     |                  |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Troll_A' is assigned to team 'B' on position 'Front_1'
	And Character 'Troll_B' is assigned to team 'B' on position 'Rear_1'
	When Fight between 'A' and 'B' starts
	Then Team 'A' won
	And Replay acctions are
	| Action_Order | Attacker_ID | Attacker_Position | Defender_ID | Defender_Position | Defender_New_Hp | Attacker_DMG_dealt |
	| 1            | Elf_A       | Front_1           | Troll_B     | Rear_1            | 0               | 30                 |
	| 2            | Troll_A     | Front_1           | Elf_A       | Front_1           | 15              | 15                 |
	| 3            | Elf_A       | Front_1           | Troll_A     | Front_1           | 0               | 30                 |

Scenario: 03 Range attack should hit character on mid lane then rear lane and front at the end
	Given The following characters
		| ID      | Name  | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills           |
		| Elf_A   | Elf   | 61    | 61 | 30      | 30      | 0   | 10    | Range_One_First  |
		| Troll_F | Troll | 30    | 30 | 15      | 15      | 0   | 5     |                  |
		| Troll_M | Troll | 30    | 30 | 30      | 30      | 0   | 5     |                  |
		| Troll_R | Troll | 30    | 30 | 30      | 30      | 0   | 5     |                  |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Troll_F' is assigned to team 'B' on position 'Front_1'
	And Character 'Troll_M' is assigned to team 'B' on position 'Middle_2'
	And Character 'Troll_R' is assigned to team 'B' on position 'Rear_3'
	When Fight between 'A' and 'B' starts
	Then Team 'A' won
	And Replay acctions are
	| Action_Order | Attacker_ID | Attacker_Position | Defender_ID | Defender_Position | Defender_New_Hp | Attacker_DMG_dealt |
	| 1            | Elf_A       | Front_1           | Troll_M     | Middle_2          | 0               | 30                 |
	| 2            | Troll_F     | Front_1           | Elf_A       | Front_1           | 46              | 15                 |
	| 3            | Troll_R     | Rear_3            | Elf_A       | Front_1           | 16              | 30                 |
	| 4            | Elf_A       | Front_1           | Troll_R     | Rear_3            | 0               | 30                 |
	| 5            | Troll_F     | Front_1           | Elf_A       | Front_1           | 1               | 15                 |
	| 6            | Elf_A       | Front_1           | Troll_F     | Front_1           | 0               | 30                 |

Scenario: 04 Range attack should hit first character on middle lane
	Given The following characters
		| ID       | Name  | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills          |
		| Elf_A    | Elf   | 31    | 31 | 40      | 40      | 0   | 10    | Range_One_First |
		| Troll_M1 | Troll | 40    | 40 | 15      | 15      | 0   | 5     |                 |
		| Troll_M3 | Troll | 30    | 30 | 30      | 30      | 0   | 5     |                 |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Troll_M1' is assigned to team 'B' on position 'Middle_1'
	And Character 'Troll_M3' is assigned to team 'B' on position 'Middle_3'
	When Fight between 'A' and 'B' starts
	Then Team 'A' won
	And Replay acctions are
	| Action_Order | Attacker_ID | Attacker_Position | Defender_ID | Defender_Position | Defender_New_Hp | Attacker_DMG_dealt |
	| 1            | Elf_A       | Front_1           | Troll_M1    | Middle_1          | 0               | 40                 |
	| 2            | Troll_M3    | Middle_3          | Elf_A       | Front_1           | 1               | 30                 |
	| 3            | Elf_A       | Front_1           | Troll_M3    | Middle_3          | 0               | 30                 |