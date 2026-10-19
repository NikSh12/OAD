using CharacterSelect.Domain.Enum;

namespace CharacterSelect.Domain.Character;

public sealed class Archer : Entity.Character
{
    public Archer(string name) : base(name, CharacterClass.Archer)
    {
        Health = 90;
        Strength = 8;
        Intelligence = 9;
        Agility = 17;
        Mana = 12;
        Luck = 14;
    }
}