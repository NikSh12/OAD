using CharacterSelect.Application.Factory;
using CharacterSelect.Domain.Enum;

namespace CharacterSelect
{
    public static class Program
    {
        public static void Main()
        {
            Console.Title = "Character Select";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== WYBÓR POSTACI ===");
                Console.WriteLine("1) Wojownik");
                Console.WriteLine("2) Mag");
                Console.WriteLine("3) Łotrzyk");
                Console.WriteLine("4) Rycerz");
                Console.WriteLine("5) Łucznik");
                Console.WriteLine("6) Nekromanta");
                Console.WriteLine("0) Wyjście");
                Console.Write("Wybierz klasę [0-6]: ");

                var input = Console.ReadLine();

                if (input == "0")
                    break;

                if (!int.TryParse(input, out var choice) ||
                    choice < 1 || choice > 6)
                {
                    Pause("Niepoprawny wybór. Naciśnij Enter...");
                    continue;
                }

                var cls = (CharacterClass)choice;

                Console.Write("Podaj imię postaci (Enter = domyślne): ");
                var name = Console.ReadLine();

                var character = CharacterFactory.Create(cls, name);
                bool returnToMain = false;

                while (!returnToMain)
                {
                    Console.Clear();
                    Console.WriteLine(">>> UTWORZONO POSTAĆ!");
                    character.Describe();

                    Console.WriteLine("\n=== MENU AKCJI ===");
                    Console.WriteLine("1) Atak");
                    Console.WriteLine("2) Umiejętność specjalna");
                    Console.WriteLine("3) Powrót");
                    Console.Write("Wybierz akcję [1-3]: ");

                    var action = Console.ReadLine();

                    switch (action)
                    {
                        case "1":
                            character.Attack();
                            Pause("\nNaciśnij Enter, aby kontynuować...");
                            break;

                        case "2":
                            character.UseSpecial();
                            Pause("\nNaciśnij Enter, aby kontynuować...");
                            break;

                        case "3":
                            returnToMain = true;
                            break;

                        default:
                            Pause("Niepoprawny wybór. Naciśnij Enter...");
                            break;
                    }
                }
            }

            Console.WriteLine("\nDzięki za grę! Do zobaczenia!");
        }

        private static void Pause(string msg)
        {
            Console.WriteLine(msg);
            Console.ReadLine();
        }
    }
}