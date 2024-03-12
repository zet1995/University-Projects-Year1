using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_7
{
    internal class Barbarian :Character
    {
        public Barbarian(string Name) : base(Name)
        {
            MaxHealthPoints = 18;
            MaxEnergyPoints = 12;
            HealthPoints = MaxHealthPoints;
            EnergyPoints = MaxEnergyPoints;
        }
        public void SwingAxe(Character target)
        {
            if (isKnockedOut)
            {
                return;
            }

            if (EnergyPoints >= 3)
            {
                Console.WriteLine($"{Name} the barbarian swung his mighty axe at {target.Name}.");
                EnergyPoints -= 3;
                target.HealthPoints -= 3;
            }
        }
    }
}
