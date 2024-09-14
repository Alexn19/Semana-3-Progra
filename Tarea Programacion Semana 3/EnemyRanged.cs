using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana_3_Progra
{
    internal class EnemyRanged : Individual
    {
        public int Bullets;

        public EnemyRanged(int health, int damage, int bullets) : base(health, damage)
        {
            Bullets = bullets;
        }

        public bool CouldAttack()
        {
            return Bullets > 0;
        }

        public void Attack()
        {
            if (CouldAttack())
            {
                Bullets--;
            }
            else
            {
                Console.WriteLine("You have no bullets left");
            }
        }

        public override int ReturnTheDamage()
        {
            if (CouldAttack())
            {
                return base.ReturnTheDamage();
            }
            else
            {
                return 0;
            }
        }
    }
}
