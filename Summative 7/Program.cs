using Summative_7;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Summative 7!");

Console.WriteLine("Hello, Mini Heroes Quest!");

// Here we create some instances of characters
Ranger ranger = new Ranger("John");
Barbarian barbarian = new Barbarian("Susan");
Mage mage = new Mage("Richard");
DragonBorn dragonborn = new DragonBorn("Toothless");

// This is how this should be used
barbarian.SwingAxe(ranger);
ranger.FireArrows(barbarian);
mage.Heal(ranger);

// This is undesirable behaviour that we want to stop happening

//barbarian.FireArrows(mage);
//mage.SwingAxe(barbarian);
