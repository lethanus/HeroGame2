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
            foreach (var position in TeamPositionHelper.GetTeamPositions())
                _team[position] = GenerateCharacterForPositionBaseOnTempalte(template, position);
        } 

        private Character GenerateCharacterForPositionBaseOnTempalte(FormationTemplate template, TeamPosition position)
        {
            if (string.IsNullOrEmpty(GetCharacterDescriptionOnPosition(template, position))) return null;

            var splited = GetCharacterDescriptionOnPosition(template, position).Split('@');
            var character = _mercenaryManagement.GetMercenaryBaseOnTemplate(splited[0], Int32.Parse(splited[1])).CreateCharacter();
            character.ID = $"{position}_{splited[0]}_{splited[1]}";
            character.SetPosition(position);
            return character;
        }

        private string GetCharacterDescriptionOnPosition(FormationTemplate template, TeamPosition position)
        {
            switch(position)
            {
                case TeamPosition.Front_1: return template.F1;
                case TeamPosition.Front_2: return template.F2;
                case TeamPosition.Front_3: return template.F3;
                case TeamPosition.Middle_1: return template.M1;
                case TeamPosition.Middle_2: return template.M2;
                case TeamPosition.Middle_3: return template.M3;
                case TeamPosition.Middle_4: return template.M4;
                case TeamPosition.Rear_1: return template.R1;
                case TeamPosition.Rear_2: return template.R2;
                case TeamPosition.Rear_3: return template.R3;
            }
            return "";
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
            foreach(var position in TeamPositionHelper.GetTeamPositions())
               _team.Add(position, null);
            
        }
    }
}
