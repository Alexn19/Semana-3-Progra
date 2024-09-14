using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana_3_Progra
{
    public abstract class Individual
    {
        public int Health;
        public int Damage;

        public Individual(int health, int damage)
        {
            Health = health;
            Damage = damage;
        }

        public void DamageReceived(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }

        public virtual int ReturnTheDamage()
        {
            return Damage;
        }

        public bool isitAlive()
        {
            return Health > 0;
        }
    }
}
