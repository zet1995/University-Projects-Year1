// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

class program
{

    static void Main(string[] args)
    {



        Console.WriteLine("Welcome to the RPG Character Creator");
        string input;
        do
        {
            int selection;
            selection = getANumber(1, 3, new string[3] { "Select an option:", "1. Create a new character.", "2. Load an existing character." });
            string Name = string.Empty;
            string CreatureType = string.Empty;
            string CharacterClass = string.Empty;
            int HitPoints = 20;
            int Strength = 20;
            int Magic = 10;
            int Speed = 20;
            if (selection == 1) // manual character creation
            {
                Console.WriteLine("What is your character's name?");
                Name = Console.ReadLine();
                selection = getANumber(1, 5, new string[7] { "What is your character's creature type?", "1. Human.", "2. Elvish.", "3. Dwarvish.", "4. Goblin.", "5. Orcish.", "Enter a number between 1 and 5 inclusive." });
                if (selection == 1) // Human
                {
                    CreatureType = "Human";
                    HitPoints += 70;
                    Strength += 50;
                    Magic += 10;
                    Speed += 30;
                }
                else if (selection == 2) // Elf
                {
                    CreatureType = "Elvish";
                    HitPoints += 50;
                    Strength += 30;
                    Magic += 40;
                    Speed += 50;
                }
                else if (selection == 3) // Dwarf
                {
                    CreatureType = "Dwarvish";
                    HitPoints += 100;
                    Strength += 80;
                    Magic += 10;
                    Speed += 10;
                }
                else if (selection == 4) // Goblin
                {
                    CreatureType = "Goblin";
                    HitPoints += 10;
                    Strength += 10;
                    Magic += 10;
                    Speed += 40;
                }
                else if (selection == 5) // Orc
                {
                    CreatureType = "Orcish";
                    HitPoints += 120;
                    Strength += 100;
                    Speed += 20;
                }
                selection = getANumber(1, 4, new string[6] { "What is your character's class type?", "1. Warrior.", "2. Wizard.", "3. Rogue.", "4. Bard.", "Enter a number between 1 and 4 inclusive." });
                if (selection == 1) // Warrior
                {
                    CharacterClass = "Warrior";
                    Strength += 50;
                    HitPoints += 50;
                }
                else if (selection == 2) // Wizard
                {
                    CharacterClass = "Wizard";
                    Magic += 100;
                }
                else if (selection == 3) // Rogue
                {
                    CharacterClass = "Rogue";
                    HitPoints += 20;
                    Magic += 30;
                    Speed += 50;
                }
                else if (selection == 4) // Bard
                {
                    CharacterClass = "Bard";
                    HitPoints += 20;
                    Magic += 50;
                    Speed += 30;
                }
                int bonusPointsRemaining = 30;
                int bonusPointsToAdd;
                bonusPointsToAdd = getANumber(0, bonusPointsRemaining, new string[3] { $"You have {bonusPointsRemaining} bonus points to allocate to your character.", "How many points would you like to add to Hit Points?", $"Enter a number between 0 and {bonusPointsRemaining} inclusive." });
                HitPoints += bonusPointsToAdd;
                bonusPointsRemaining -= bonusPointsToAdd;
                if (bonusPointsRemaining > 0)
                {
                    bonusPointsToAdd = getANumber(0, bonusPointsRemaining, new string[3] { $"You have {bonusPointsRemaining} bonus points to allocate to your character.", "How many points would you like to add to Strength?", $"Enter a number between 0 and {bonusPointsRemaining} inclusive." });
                    Strength += bonusPointsToAdd;
                    bonusPointsRemaining -= bonusPointsToAdd;
                }
                if (bonusPointsRemaining > 0)
                {
                    bonusPointsToAdd = getANumber(0, bonusPointsRemaining, new string[4] { $"You have {bonusPointsRemaining} bonus points to allocate to your character.", "Any remaining points will be added to Speed.", "How many points would you like to add to Magic?", $"Enter a number between 0 and {bonusPointsRemaining} inclusive." });
                    Magic += bonusPointsToAdd;
                    bonusPointsRemaining -= bonusPointsToAdd;
                    Speed += bonusPointsRemaining;
                }
            }
            else if (selection == 2) // load character from file
            {
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(),
                "*.character");
                if (files.Length == 0)
                {
                    Console.WriteLine("There are no character files to load.");
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Select an option:");
                        for (int i = 0; i < files.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}.{files[i].Substring(files[i].LastIndexOf('\\') + 1)}");
                        }
                        selection = int.Parse(Console.ReadLine()) - 1;
                    } while (selection < 0 && selection > files.Length - 1);
                    /* Format is
                    Name - name
                    Type - creature type
                    Class - character class
                    Stats - HitPoints Strength Magic Speed
                    */
                    string[] lines = File.ReadAllLines(files[selection]);
                    Name = lines[0].Substring(lines[0].LastIndexOf(' ') + 1);
                    CreatureType = lines[1].Substring(lines[1].LastIndexOf(' ') + 1);
                    CharacterClass = lines[2].Substring(lines[2].LastIndexOf(' ') +
                    1);
                    lines = lines[3].Split(' ');
                    HitPoints = int.Parse(lines[2]);
                    Strength = int.Parse(lines[3]);
                    Magic = int.Parse(lines[4]);
                    Speed = int.Parse(lines[5]);
                }
            }
            Console.WriteLine($"You created {Name}, the {CreatureType} {CharacterClass} ");
            Console.WriteLine($"Hit Points - {HitPoints}");
            Console.WriteLine($"Stength - {Strength}");
            Console.WriteLine($"Magic - {Magic}");
            Console.WriteLine($"Speed - {Speed}");
            input = yesOrNo(new string[2] { "Would you like to save this character to a file?", "Enter Y for yes or N for no." });
            if (input == "Y")
            {
                StreamWriter writer = new
                StreamWriter($"{Name}_the_{CreatureType}_{CharacterClass}.character");
                writer.WriteLine($"Name - {Name}");
                writer.WriteLine($"Type - {CreatureType}");
                writer.WriteLine($"Class - {CharacterClass}");
                writer.WriteLine($"Stats - {HitPoints} {Strength} {Magic} {Speed}");
                writer.Close();
            }
            input = yesOrNo(new string[2] { "Would you like to make another character?", "Enter Y for yes or N for no." });
        } while (input == "Y");
        Console.WriteLine("Thank you for using the RPG Character Creator");
        Console.WriteLine("Goodbye");
    }
    public static int getANumber(int lowerLimit, int upperLimit, string[] options)
    {
        int result;
        do
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(options[i]);
            }
            try
            {
                result = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not a valid number");
                result = getANumber(lowerLimit, upperLimit, options);
            }
        } while (result < lowerLimit || result > upperLimit);
        return result;
    }
    public static string yesOrNo(string[] questions)
    {
        string input;
        do
        {
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine(questions[i]);
            }
            input = Console.ReadLine();
        } while (input != "Y" && input != "N");
        return input;
    }
}
