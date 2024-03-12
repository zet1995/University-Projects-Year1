using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_7
{
     class Character
    {
        private int _healthPoints;
        private int _energyPoints;
        public string Name { get; private set; }
        public int MaxHealthPoints { get; protected set; }
        public int MaxEnergyPoints { get; protected set; }

        public int HealthPoints
        {
            get
            { return _healthPoints; }
            internal set
            {
                if (value < MaxHealthPoints) { _healthPoints = value; }
                else { _healthPoints = MaxHealthPoints; }
            }
        }

        public int EnergyPoints
        {
            get { return _energyPoints; }
            internal set
            {
                if (value < MaxEnergyPoints) { _energyPoints = value; }
                else { _energyPoints = MaxEnergyPoints; }
            }
        }

        public Character(string Name)
        {
            this.Name = Name;

        }

        public bool isKnockedOut { get { return HealthPoints <= 0; } }

        public void Rest()
        {
            if (!isKnockedOut)
            {
                EnergyPoints = MaxEnergyPoints;
                HealthPoints = MaxHealthPoints;
            }
        }
    }
}
