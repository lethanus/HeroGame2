﻿using System;
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
        private Logger _logger;
        private IValueRandomizer _randomizer;
        private string _winningTeam;
        private List<FightAction> actions = new List<FightAction>();

        public FightMechanizm(IValueRandomizer randomizer, Logger logger)
        {
            _randomizer = randomizer;
            SetNewLogger(logger);
        }

        public void SetNewLogger(Logger logger)
        {
            _logger = logger;
        }

        public List<Character> StartFight(List<ICharacterInTeam> startCharacters, string firstTeam, string secondTeam)
        {
            actions.Clear();
            int i = 1;
            int actionCounter = 1;
            while (!AllCharactersAreDeadInTeam(firstTeam, startCharacters) && !AllCharactersAreDeadInTeam(secondTeam, startCharacters))
            {
                _logger.LogLine($"Turn {i++} started");
                foreach (var attacker in startCharacters.OrderByDescending(x => x.getSpeed()))
                {
                    if (attacker.getHp() > 0)
                    {
                        var defender = startCharacters.FirstOrDefault(x => x.GetTeam() != attacker.GetTeam() && x.getHp() > 0);

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
            
            return startCharacters.Select(x => x.GetCharacter()).ToList();
        }

        private bool AllCharactersAreDeadInTeam(string teamName, List<ICharacterInTeam> startCharacters)
        {
            var liveSecondTeamCount = startCharacters.Count(x => x.GetTeam() != teamName && x.getHp() > 0);
            if (liveSecondTeamCount == 0)
            {
                _winningTeam = teamName;
                _logger.LogLine($"Team {_winningTeam} won");
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
            var newHP = defender.getHp() < damage ? 0 : defender.getHp() - damage;

            var isKilled = newHP == 0 ? "[Killed]" : "";
            _logger.LogLine($"[{attacker.GetTeam()}] {attacker.getName()} dealed {damage} damage to {defender.getName()} and new HP is {newHP} {isKilled}");

            return newHP;
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
