# Summative 7

## Challenge Description

Include a decription of the challenge here.
Summative Challenge 7 - Inheritance to Reduce and Reuse Code (Due on or before 8th March)
Open the Summative 7 Challenge project in your Digital Portfolio repository.

NOTE - Simon will talk about this code in todays lecture hereLinks to an external site..

Copy the code below into the Program.cs file.

Code Snippet
 
Console.WriteLine("Hello, Mini Heroes Quest!");
 
// Here we create some instances of characters
Character ranger = new Character("John", "ranger");
Character barbarian = new Character("Susan", "barbarian");
Character mage = new Character("Richard", "mage");
 
// This is how this should be used
barbarian.SwingAxe(ranger);
ranger.FireArrows(barbarian);
mage.Heal(ranger);
 
// This is undesirable behaviour that we want to stop happening
barbarian.FireArrows(mage);
mage.SwingAxe(barbarian);
 
public class Character
{
    private int _healthPoints;
    private int _energyPoints;
    public string Name { get; private set; }
    public int MaxHealthPoints { get; private set; }
    public int MaxEnergyPoints { get; private set; }
    public string CharacterType { get; private set; }
    public int NumberOfArrows { get; private set; }
    public int FiredArrows { get; private set; }
 
    public int HealthPoints {
        get
        { return _healthPoints; }
        private set
        {
            if (value < MaxHealthPoints) { _healthPoints = value; }
            else { _healthPoints = MaxHealthPoints; }
        }
    }
 
    public int EnergyPoints
    {
        get { return _energyPoints; }
        private set
        {
            if (value < MaxEnergyPoints) { _energyPoints = value; }
            else { _energyPoints = MaxEnergyPoints; }
        }
    }
 
    public Character(string Name, string CharacterType)
    {
        this.Name = Name;
        this.CharacterType = CharacterType;
 
        switch (CharacterType)
        {
            case "barbarian":
            {
                MaxHealthPoints = 18;
                MaxEnergyPoints = 12;
                break;
            }
            case "ranger":
            {
                    MaxHealthPoints = 10;
                    MaxEnergyPoints = 8;
                    NumberOfArrows = 10;
                break;
            }
            case "mage":
            {
                MaxHealthPoints = 8;
                MaxEnergyPoints = 8;
                break;
            }
            default:
            {
                throw new Exception("Unknown character type " +  CharacterType);
            }
        }
        _healthPoints = MaxHealthPoints;
        _energyPoints = MaxEnergyPoints;
    }
 
    public bool isKnockedOut { get { return HealthPoints <= 0; } }
 
    public void CollectArrows()
    {
        if(CharacterType == "ranger")
        {
            NumberOfArrows += FiredArrows;
        }
    }
 
    public void FireArrows(Character target)
    {
        if (CharacterType != "ranger" || isKnockedOut)
        {
            return;
        }
 
        if (NumberOfArrows > 0 && EnergyPoints >= 1)
        {
            EnergyPoints -= 1;
            NumberOfArrows--;
            FiredArrows++;
            Console.WriteLine($"{Name} the ranger shot an arrow at ${target.Name}.");
            target._healthPoints -= 1;
        }
    }
 
    public void SwingAxe(Character target)
    {
        if (CharacterType != "barbarian" || isKnockedOut)
        {
            return;
        }
 
        if (EnergyPoints >= 3)
        {
            Console.WriteLine($"{Name} the barbarian swung his mighty axe at ${target.Name}.");
            target.HealthPoints -= EnergyPoints;
        }
    }
 
    public void ThrowFireball(Character target)
    {
        if(CharacterType == "mage")
        {
            if (EnergyPoints >= 2)
            {
                Console.WriteLine($"{Name} the mage threw a fireball at {target.Name}.");
                target.HealthPoints -= 2;
                EnergyPoints -= 2;
            }
        }
    }
 
    public void Heal(Character target)
    {
        if(CharacterType == "mage")
        {
            if(EnergyPoints >= 1)
            {
                EnergyPoints -= 1;
                target.HealthPoints += 5;
            }
        }
    }
 
    public void Rest()
    {
        if(!isKnockedOut)
        {
            EnergyPoints = MaxEnergyPoints;
            HealthPoints = MaxHealthPoints;
        }
    }
}
You've been tasked to refactor some code that has been written for a fantasy game.

The goal is to make it so that it is easy to expand the number of characters in the game. Currently there are just three - a ranger, a barbarian and a mage, but they are grouped together in a single Character class.

Currently the individual character behaviour is managed using a characterType string. This is not a scalable solution, and should be removed in favour of a more extensible and scalable approach.

The reason that this is not scalable is because as you add more character types the code will get more complex. You should already be able to see how an instance of a barbarian class has datamembers about arrows - which is something only the ranger cares about.

Your job is to try to split this class into three separate classes (Ranger, Barbarian, and Mage). The three classes should inherit from a Character class, which can deal with things that are common to all characters. There are also some bugs present in the code for you to find and fix.

Characters can perform actions that are specific to their class. Some actions cost energy. A character should not be able to perform an action from another character. A character should not be able to perform an action if they are already knocked out.

The Ranger should start with their maximum of 10 hitpoints and 8 energy. The ranger starts with 10 arrows, which he can fire at other characters using 1 energy point and damaging the target for 1 hitpoint. The ranger can also collect all the arrows he has fired.

The Barbarian should start with their maximum of 18 hitpoints and 12 energy. The Barbarian can swing his axe at other characters for 3 energy, damaging them for 3 hitpoints.

The Mage should start with their maximum of 8 hitpoints and 8 energy. The Mage can throw a fireball for 2 energy, doing 2 hitpoints of damage. The mage can also Heal a target (which could be himself) by 5 hitpoints for 1 energy.

You should end up with something like this:

image.png

All characters can rest to restore their maximum health and maximum hitpoints. All characters have their own name.

Once you've refactored your code see how easy it is to add your own, fourth type of character into the system.
Good luck!

## Code Listing

```cs
// Include your C# solution code here
```

## Test Plan

Include your test plan and results here

| Test Number | Input | Expected Output | Actual Output |
|---|---|---|---|
| 1 | | | |
| 2 | | | |
| 3 | | | |
| 4 | | | |

## Feedback Request

If there is anything specific you want to ask for feedback on include that here
