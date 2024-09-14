using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana_3_Progra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = CharacterCreation();

            List<Individual> enemy = new List<Individual>();
            {
                enemy.Add(new EnemyMelee(75, 25));
                enemy.Add(new EnemyRanged(60, 40, 15));
            };

            Videogame videogame = new Videogame(player, enemy);
            videogame.StartVideogame();

        }

        public static Player CharacterCreation()
        {
            int health, damage;

            Console.WriteLine("Character Creation:");
            do
            {
                Console.WriteLine("Choose your character´s health (1-100): ");
                health = int.Parse(Console.ReadLine());
            } while (health < 1 || health > 100);

            do
            {
                Console.WriteLine("Choose your character´s damage (1-100)");
                damage = int.Parse(Console.ReadLine());
            } while (damage < 1 || damage > 100);

            return new Player(health, damage);
        }
    }
}