using CharacterSelect.Domain.Enum;

namespace CharacterSelect.Domain.Character;

public sealed class Necromancer : Entity.Character
{
    public Necromancer(string name) : base(name, CharacterClass.Necromancer)
    {
        Health = 85;
        Strength = 5;
        Intelligence = 18;
        Agility = 9;
        Mana = 30;
        Luck = 11;
    }
}