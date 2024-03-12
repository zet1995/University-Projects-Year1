using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_7
{
    internal class Ranger : Character
    {
        public int FiredArrows { get; private set; }
        public int NumberOfArrows { get; protected set; }
        public Ranger(string name) : base (name)
        {
            MaxHealthPoints = 10;
            MaxEnergyPoints = 8;
            NumberOfArrows = 10;
            HealthPoints = MaxHealthPoints;
            EnergyPoints = MaxEnergyPoints;
        }
        public void CollectArrows()
        {
            if (isKnockedOut)
            {
                return;
            }
            NumberOfArrows += FiredArrows;
        }
        public void FireArrows(Character target)
        {
            if (isKnockedOut)
            {
                return;
            }

            if (NumberOfArrows > 0 && EnergyPoints >= 1)
            {
                EnergyPoints -= 1;
                NumberOfArrows--;
                FiredArrows++;
                Console.WriteLine($"{Name} the ranger shot an arrow at {target.Name}.");
                target.HealthPoints -= 1;
            }
        }
    }
}
