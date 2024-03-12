using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_7
{
    class Mage : Character
    {
        public Mage(string Name) : base(Name) 
        {
            MaxHealthPoints = 8;
            MaxEnergyPoints = 8;
            HealthPoints = MaxHealthPoints;
            EnergyPoints = MaxEnergyPoints;
        }
        public void ThrowFireball(Character target)
        {
            if (isKnockedOut)
            {
                return;
            }
            if (EnergyPoints >= 2)
            {
                Console.WriteLine($"{Name} the mage threw a fireball at {target.Name}.");
                target.HealthPoints -= 2;
                EnergyPoints -= 2;
            }
        }

        public void Heal(Character target)
        {
            if (isKnockedOut)
            {
                return;
            }
            if (EnergyPoints >= 1)
            {
                EnergyPoints -= 1;
                target.HealthPoints += 5;
            }  
        }

    }
}
