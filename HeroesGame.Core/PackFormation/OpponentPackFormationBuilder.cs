using HeroesGame.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Mercenaries;

namespace HeroesGame.PackBuilding
{
    public class OpponentPackFormationBuilder : IOpponentPackFormationBuilder
    {
        private readonly IFormationTemplateRepository _formationTemplateRepository;
        private readonly IMercenaryManagement _mercenaryManagement;
        private Dictionary<TeamPosition, Character> _team = new Dictionary<TeamPosition, Character>(); 

        public OpponentPackFormationBuilder(IFormationTemplateRepository formationTemplateRepository, IMercenaryManagement mercenaryManagement)
        {
            _formationTemplateRepository = formationTemplateRepository;
            _mercenaryManagement = mercenaryManagement;
            PopulateEmptyTeam();
        }
        public void GenerateOpponentsBaseOnTemplate(string templateID)
        {
            var template = _formationTemplateRepository.GetAll().First(x => x.ID == templateID);
            var splited = template.F1.Split('@'); 
            var character = _mercenaryManagement.GetMercenaryBaseOnTemplate(splited[0], Int32.Parse(splited[1])).CreateCharacter();
            character.ID = "F1_Goblin_1";
            _team[TeamPosition.Front_1] = character;
        } 

        public string GetOpponentCharacterIdOnPosition(TeamPosition position)
        {
            return _team[position] == null ? "" : _team[position].ID;
        }

        public List<Character> GetOpponentCharacters()
        {
            return _team.Values.Where(x=>x != null).ToList();
        }

        private void PopulateEmptyTeam()
        {
            _team.Add(TeamPosition.Front_1, null);
            _team.Add(TeamPosition.Front_2, null);
            _team.Add(TeamPosition.Front_3, null);
            _team.Add(TeamPosition.Middle_1, null);
            _team.Add(TeamPosition.Middle_2, null);
            _team.Add(TeamPosition.Middle_3, null);
            _team.Add(TeamPosition.Middle_4, null);
            _team.Add(TeamPosition.Rear_1, null);
            _team.Add(TeamPosition.Rear_2, null);
            _team.Add(TeamPosition.Rear_3, null);

        }
    }
}
