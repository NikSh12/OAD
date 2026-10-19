using CharacterSelect.Domain.Enum;

namespace CharacterSelect.Domain.Character;

public sealed class Knight : Entity.Character
{
    public Knight(string name) : base(name, CharacterClass.Knight)
    {
        Health = 140;
        Strength = 16;
        Intelligence = 7;
        Agility = 6;
        Mana = 10;
        Luck = 8;
    }
}