Feature: FightSimulations
	Fighting 

@mytag
Scenario: Elf hits Goblin
	Given The following characters
		| Name   | MaxHp | Hp | Att | Def | Speed |
		| Elf    | 20    | 20 | 10  | 5   | 10    |
		| Golbin | 10    | 10 | 10  | 0   | 5     |
	And Character 'Elf' is assigned to team 'A'
	And Character 'Goblin' is assigned to team 'B'
	When Fight turn 1 ends
	Then The following characters status is
		| Name   | MaxHp | Hp | Att | Def | Speed |
		| Elf    | 20    | 20 | 10  | 5   | 10    |
		| Golbin | 10    | 0  | 10  | 0   | 5     |
