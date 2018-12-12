Feature: Mass Attack Skill
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: 01 Mass attack should hit all character
	Given The following characters
		| ID      | Name  | MaxHp | Hp | Min_Att | Max_Att | Def | Speed | Skills   |
		| Elf_A   | Elf   | 30    | 30 | 30      | 30      | 0   | 10    | Mass_All |
		| Troll_F | Troll | 30    | 30 | 40      | 40      | 0   | 5     |          |
		| Troll_M | Troll | 30    | 30 | 30      | 30      | 0   | 5     |          |
		| Troll_R | Troll | 30    | 30 | 30      | 30      | 0   | 5     |          |
	And Character 'Elf_A' is assigned to team 'A' on position 'Front_1'
	And Character 'Troll_F' is assigned to team 'B' on position 'Front_1'
	And Character 'Troll_M' is assigned to team 'B' on position 'Middle_1'
	And Character 'Troll_R' is assigned to team 'B' on position 'Rear_1'
	When Fight between 'A' and 'B' starts
	Then Team 'A' won
	And Replay acctions are
	| Action_Order | Attacker_ID | Attacker_Position | Defender_ID | Defender_Position | Defender_New_Hp | Attacker_DMG_dealt |
	| 1            | Elf_A       | Front_1           | Troll_F     | Front_1           | 0               | 30                 |
	| 1            | Elf_A       | Front_1           | Troll_M     | Middle_1          | 0               | 30                 |
	| 1            | Elf_A       | Front_1           | Troll_R     | Rear_1            | 0               | 30                 |
