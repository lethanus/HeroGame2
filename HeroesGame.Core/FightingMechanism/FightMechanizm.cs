using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Characters;
using HeroesGame.Loggers;
using HeroesGame.Core.Randomizers;

namespace HeroesGame.FightMechanizm
{
    public class FightMechanizm : IFightMechanizm
    {
        private IValueRandomizer _randomizer;
        private string _winningTeam;
        private List<FightAction> actions = new List<FightAction>();

        public FightMechanizm(IValueRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public List<Character> StartFight(List<ICharacterInTeam> startCharacters, string firstTeam, string secondTeam)
        {
            var characters = startCharacters.Select(x => x.GetCharacter().CreateCopy()).ToList<ICharacterInTeam>();
            actions.Clear();
            int i = 1;
            int actionCounter = 1;
            while (!AllCharactersAreDeadInTeam(firstTeam, characters) && !AllCharactersAreDeadInTeam(secondTeam, characters))
            {
                foreach (var attacker in characters.OrderByDescending(x => x.getSpeed()))
                {
                    if (attacker.getHp() > 0)
                    {
                        ICharacterInTeam defender = null;
                        var liveOpponents = characters.Where(x => x.GetTeam() != attacker.GetTeam() && x.getHp() > 0);
                        var skill = attacker.getSkills();
                        if(string.IsNullOrEmpty(skill))
                            defender = liveOpponents.FirstOrDefault();
                        else
                        {
                            if(skill == "Range_One_Random")
                            {
                                defender = liveOpponents.FirstOrDefault(x =>
                                x.GetPosition() == TeamPosition.Middle_1 ||
                                x.GetPosition() == TeamPosition.Middle_2 ||
                                x.GetPosition() == TeamPosition.Middle_3 ||
                                x.GetPosition() == TeamPosition.Middle_4
                                );
                                if (defender == null)
                                {
                                    defender = liveOpponents.FirstOrDefault(x =>
                                    x.GetPosition() == TeamPosition.Rear_1 ||
                                    x.GetPosition() == TeamPosition.Rear_2 ||
                                    x.GetPosition() == TeamPosition.Rear_3
                                    );
                                    if (defender == null)
                                    {
                                        defender = liveOpponents.FirstOrDefault(x =>
                                        x.GetPosition() == TeamPosition.Front_1 ||
                                        x.GetPosition() == TeamPosition.Front_2 ||
                                        x.GetPosition() == TeamPosition.Front_3
                                        );
                                    }
                                }
                            }
                        }
                        if (defender != null)
                        {
                            var newHp = CalculateNewHp(attacker, defender);
                            actions.Add(new FightAction
                            {
                                Action_Order = actionCounter++,
                                Attacker_ID = attacker.getID(),
                                Attacker_Position = attacker.GetPosition(),
                                Defender_ID = defender.getID(),
                                Defender_Position = defender.GetPosition(),
                                Defender_New_Hp = newHp,
                                Attacker_DMG_dealt = defender.getHp() - newHp
                            });
                            defender.setNewHP(newHp);
                        }
                    }
                }
            }
            
            return characters.Select(x => x.GetCharacter()).ToList();
        }

        private bool AllCharactersAreDeadInTeam(string teamName, List<ICharacterInTeam> startCharacters)
        {
            var liveSecondTeamCount = startCharacters.Count(x => x.GetTeam() != teamName && x.getHp() > 0);
            if (liveSecondTeamCount == 0)
            {
                _winningTeam = teamName;
                return true;
            }
            return false;
        }

        private int CalculateDamage(ICharacterInTeam attacker, ICharacterInTeam defender)
        {
            var attack_value = _randomizer.GetRandomValueInRange(attacker.getMin_Att(), attacker.getMax_Att(), "Attack");
            return attack_value > defender.getDef() ? attack_value - defender.getDef() : 0;
        }

        private int CalculateNewHp(ICharacterInTeam attacker, ICharacterInTeam defender)
        {
            int damage = CalculateDamage(attacker, defender);
            return defender.getHp() < damage ? 0 : defender.getHp() - damage;
        }

        public string GetWinningTeam()
        {
            return _winningTeam;
        }

        public List<FightAction> GetFightActions()
        {
            return actions;
        }
    }
}
