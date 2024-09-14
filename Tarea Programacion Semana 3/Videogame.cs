using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana_3_Progra
{
    internal class Videogame
    {
        private Player player;
        private List<Individual> enemy;
        private int currentTurn;

        public Videogame(Player player, List<Individual> enemy)
        {
            this.player = player;
            this.enemy = enemy;
            currentTurn = 0;
        }

        public void StartVideogame()
        {
            Console.WriteLine("Beginning of the game");
            while (player.Health > 0 && enemy.Count > 0)
            {
                if (currentTurn == 0)
                {
                    TurnOfPlayer();
                }
                else
                {
                    TurnOfEnemy();
                }

                currentTurn = (currentTurn + 1) % 2;
            }
        }

        private void TurnOfPlayer()
        {
            Console.WriteLine("It´s your turn. Choose the enemy you want to attack");
            for (int i = 0; i < enemy.Count; i++)
            {
                Console.WriteLine($"Enemy {i + 1} - Health: {enemy[i].Health}");
            }

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > enemy.Count)
            {
                Console.WriteLine("Select a valid enemy");
            }

            Individual selectedEnemy = enemy[choice - 1];
            selectedEnemy.DamageReceived(player.ReturnTheDamage());
            Console.WriteLine($"You attacked an enemy {choice} and you caused {player.ReturnTheDamage()} of damage");

            if (selectedEnemy.Health <= 0)
            {
                Console.WriteLine($"The enemy {choice} has been defeated");
                enemy.Remove(selectedEnemy);
            }

            if (enemy.Count == 0)
            {
                Console.WriteLine("Victory achieved");
                Console.ReadLine();
            }
        }

        private void TurnOfEnemy()
        {
            foreach (Individual enemy in enemy)
            {
                if (enemy.Health > 0)
                {
                    int damageReceived = 0;

                    if (enemy is EnemyRanged enemyRanged)
                    {
                        enemyRanged.Attack();
                        damageReceived = enemyRanged.ReturnTheDamage();
                    }
                    else if (enemy is EnemyMelee enemyMelee)
                    {
                        damageReceived = enemyMelee.ReturnTheDamage();
                    }

                    player.DamageReceived(damageReceived);
                    Console.WriteLine($"An enemy has attacked you and you received {damageReceived} of damage");

                    if (player.Health <= 0)
                    {
                        Console.WriteLine("You are dead");
                        Console.ReadLine();
                        break;
                    }
                }
            }
        }


    }
}
