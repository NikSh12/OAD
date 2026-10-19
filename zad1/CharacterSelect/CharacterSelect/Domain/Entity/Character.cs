using CharacterSelect.Domain.Enum;

namespace CharacterSelect.Domain.Entity;

public abstract class Character
{
    public string Name { get; set; }
    public CharacterClass Class { get; }
    public int Health { get; protected set; }
    public int Strength { get; protected set; }
    public int Intelligence { get; protected set; }
    public int Agility { get; protected set; }

    // Dwie nowe statystyki
    public int Mana { get; protected set; }
    public int Luck { get; protected set; }

    protected Character(string name, CharacterClass @class)
    {
        Name = string.IsNullOrWhiteSpace(name) ? @class.ToString() : name.Trim();
        Class = @class;
    }

    public virtual void Describe()
    {
        Console.WriteLine($"[{Class}] {Name}");
        Console.WriteLine($"  HP: {Health}");
        Console.WriteLine($"  STR: {Strength}  INT: {Intelligence}  AGI: {Agility}");
        Console.WriteLine($"  Mana: {Mana}  Luck: {Luck}");
    }

    public virtual void Attack()
    {
        int mainStat = Class switch
        {
            CharacterClass.Mage => Intelligence,
            CharacterClass.Necromancer => Intelligence,
            CharacterClass.Rogue => Agility,
            CharacterClass.Archer => Agility,
            _ => Strength
        };

        Console.WriteLine($"\n{Name} wykonuje atak!");
        Console.WriteLine($"Obrażenia: {mainStat * 3}");
    }

    public virtual void UseSpecial()
    {
        Console.WriteLine($"\n{Name} używa umiejętności specjalnej!");

        switch (Class)
        {
            case CharacterClass.Warrior:
                Console.WriteLine("Potężne uderzenie! Wróg drży ze strachu!");
                break;
            case CharacterClass.Mage:
                Console.WriteLine("Kula Ognia trafia przeciwnika płomieniami!");
                break;
            case CharacterClass.Rogue:
                Console.WriteLine("Cios z ukrycia! Przeciwnik nie widział ataku!");
                break;
            case CharacterClass.Knight:
                Console.WriteLine("Święta tarcza chroni rycerza przed niebezpieczeństwem!");
                break;
            case CharacterClass.Archer:
                Console.WriteLine("Grad strzał przeszywa powietrze!");
                break;
            case CharacterClass.Necromancer:
                Console.WriteLine("Mroczna magia przywołuje armię nieumarłych!");
                break;
        }
    }
}