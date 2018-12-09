using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.PackBuilding;
using HeroesGame.Characters;
using HeroesGame.Mercenaries;

namespace HeroesGame.FightMechanizm
{
    public enum FightResult { PlayerWins, PlayerDefeated }
    public class FightManagement : IFightManagement
    {
        private const string opponentTeamName = "Opponent";
        private const string playerTeamName = "Player";

        private readonly IOpponentPackFormationBuilder _opponentPackFormationBuilder;
        private readonly IFightMechanizm _fightMechanizm;
        private readonly IPackFormationBuilder _packFormationBuilder;
        private readonly IMercenaryManagement _mercenaryManagement;
        private List<ICharacterInTeam> _playerCharacters = new List<ICharacterInTeam>();
        private List<ICharacterInTeam> _allCharacters = new List<ICharacterInTeam>();
        private List<ICharacterInTeam> _opponentCharacters = new List<ICharacterInTeam>();


        public FightManagement(IOpponentPackFormationBuilder opponentPackFormationBuilder, IFightMechanizm fightMechanizm,
            IPackFormationBuilder packFormationBuilder, IMercenaryManagement mercenaryManagement)
        {
            _opponentPackFormationBuilder = opponentPackFormationBuilder;
            _fightMechanizm = fightMechanizm;
            _packFormationBuilder = packFormationBuilder;
            _mercenaryManagement = mercenaryManagement;
        }

        public FightResult GetLastFightResult()
        {
            return _fightMechanizm.GetWinningTeam() == opponentTeamName ? FightResult.PlayerDefeated : FightResult.PlayerWins;
        }

        public List<ICharacterInTeam> GetOpponentCharacters()
        {
            return _opponentCharacters;
        }

        public List<ICharacterInTeam> GetPlayerCharacters()
        {
            return _playerCharacters;
        }

        public void PrepareFightAgainstTemplate(string opponentTemplateID)
        {
            _opponentCharacters.Clear();
            _playerCharacters.Clear();
            _opponentPackFormationBuilder.GenerateOpponentsBaseOnTemplate(opponentTemplateID);
            var opponentCharacters = _opponentPackFormationBuilder.GetOpponentCharacters();
            foreach(var oppChar in opponentCharacters)
            {
                oppChar.SetTeam(opponentTeamName);
                _opponentCharacters.Add(oppChar);
            }
            var allPlayerCharacters = _mercenaryManagement.GetAllMercenariesForLoggedUser();
            var playerFormation = _packFormationBuilder.GetAll();
            _playerCharacters = new List<ICharacterInTeam>();
            foreach(var position in playerFormation.Where(x=>x.Character_ID.Length > 0))
            {
                var character = allPlayerCharacters.First(x => x.ID == position.Character_ID);
                character.SetPosition(position.Position);
                character.SetTeam(playerTeamName);
                _playerCharacters.Add(character);

            }

            _allCharacters.Clear();
            _allCharacters.AddRange(_opponentCharacters);
            _allCharacters.AddRange(_playerCharacters);

        }

        public void StartFight()
        {
            _fightMechanizm.StartFight(_allCharacters, playerTeamName, opponentTeamName);
        }

        public FightReplay GetFightReplay()
        {
            return new FightReplay
            {
                TeamA = GetPlayerCharacters(),
                TeamB = GetOpponentCharacters(),
                FightResult = GetLastFightResult(),
                Actions = _fightMechanizm.GetFightActions().ToDictionary(x => x.Action_Order, x => x)
            };
        }
    }
}
