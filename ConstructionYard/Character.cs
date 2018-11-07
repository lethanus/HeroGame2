namespace ConstructionYard
{
    public class Character
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int Att { get; set; }
        public int Def { get; set; }
        public int Speed { get; set; }

        public override bool Equals(object obj)
        {
            var toCompare = obj as Character;

            if (ID == toCompare.ID &&
                Name == toCompare.Name &&
                MaxHp == toCompare.MaxHp &&
                Hp == toCompare.Hp &&
                Att == toCompare.Att &&
                Def == toCompare.Def &&
                Speed == toCompare.Speed)
                return true;
            var nl = System.Environment.NewLine;
            throw new System.Exception($"There are some diffs:{nl} Expected: {ToString()}{nl} Actual: {toCompare.ToString()}");
        }

        public override string ToString()
        {
            return $"ID:{ID} Name:{Name} MaxHp:{MaxHp} Hp:{Hp} Att:{Att} Def:{Def} Speed:{Speed}"; 
        }
    }
}