Feature: Range Attack Skill

@mytag
Scenario: 01 Range attack should hit character on mid lane
	Given The following characters
		| ID      | Name  | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills           |
		| Elf_A   | Elf   | 30    | 30 | 30      | 30      | 0   | 10    | Range_One_Random |
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