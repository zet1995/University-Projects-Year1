using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_7
{
    internal class DragonBorn : Character
    {
        public DragonBorn(string Name) : base(Name)
        {
            MaxHealthPoints = 69;
            MaxEnergyPoints = 420;
            HealthPoints = MaxHealthPoints;
            EnergyPoints = MaxEnergyPoints;
        }
        public void FireBreath(Character target)
        {
            if (isKnockedOut)
            {
                return;
            }
            if (EnergyPoints >= 50)
            {
                Console.WriteLine($"{Name} the dragonborn made {target.Name} crispy.");
                target.HealthPoints -= 10;
                EnergyPoints -= 50;
            }
        }
        public void HealingRoar(Character target)
        {
            if (isKnockedOut)
            {
                return;
            }
            if (EnergyPoints >= 100) 
            {
                Console.WriteLine($"{Name} the dragonborn healed {target.Name}.");
                target.HealthPoints += 15;
                EnergyPoints -= 100;
            }
        }

    }
}
