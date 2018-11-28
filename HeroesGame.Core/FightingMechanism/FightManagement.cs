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
    public class FightManagement : IFightManagement
    {
        private readonly IOpponentPackFormationBuilder _opponentPackFormationBuilder;
        private readonly IFightMechanizm _fightMechanizm;
        private readonly IPackFormationBuilder _packFormationBuilder;
        private readonly IMercenaryManagement _mercenaryManagement;

        public FightManagement(IOpponentPackFormationBuilder opponentPackFormationBuilder, IFightMechanizm fightMechanizm,
            IPackFormationBuilder packFormationBuilder, IMercenaryManagement mercenaryManagement)
        {
            _opponentPackFormationBuilder = opponentPackFormationBuilder;
            _fightMechanizm = fightMechanizm;
            _packFormationBuilder = packFormationBuilder;
            _mercenaryManagement = mercenaryManagement;
        }

        public string GetLastFightResult()
        {
            return _fightMechanizm.GetWinningTeam() == "Opponent" ? "Player defeated" : "Player wins";
        }

        public void StartAfightAgainstTemplate(string opponentTemplateID)
        {
            _opponentPackFormationBuilder.GenerateOpponentsBaseOnTemplate(opponentTemplateID);
            var opponentCharacters = _opponentPackFormationBuilder.GetOpponentCharacters();
            foreach(var oppChar in opponentCharacters)
            {
                oppChar.SetTeam("Opponent");
            }
            var allPlayerCharacters = _mercenaryManagement.GetAllMercenariesForLoggedUser();
            var playerFormation = _packFormationBuilder.GetAll();
            var playerCharacters = new List<ICharacterInTeam>();
            foreach(var position in playerFormation.Where(x=>x.Character_ID.Length > 0))
            {
                var character = allPlayerCharacters.First(x => x.ID == position.Character_ID);
                character.SetPosition(position.Position);
                character.SetTeam("Player");
                playerCharacters.Add(character);

            }



            var allCharacters = new List<ICharacterInTeam>();
            allCharacters.AddRange(opponentCharacters);
            allCharacters.AddRange(playerCharacters);

            _fightMechanizm.SetupFight(allCharacters, "Player", "Opponent");
            _fightMechanizm.StartFight();
        }
    }
}
