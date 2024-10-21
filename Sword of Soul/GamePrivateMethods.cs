using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sword_of_Soul
{
    public partial class game 
    {
        
        private Knight knight = new Knight(100, 5);
        
        private static Random rand = new Random();
        private static Mob[] Mobs = new Mob[] { new Skeleton(100,rand.Next(5,8)), new Ghost(100, rand.Next(20, 30)), new Zombie(100, rand.Next(10, 16)) };
        private static Mob Mob = Mobs[rand.Next(0,3)];
        private int coins = 0; 

        //Methods
        private async void punchField_Click(object sender, RoutedEventArgs e)
        {
            punchField.IsEnabled = false;

            Battle.MutualAttack(Mob, knight);
            UpdatingProgressBar();
            if (Mob.hitPoint <= 0)
            {
                await Mob.Death(placeForMobs);
                Mob = Mobs[rand.Next(0, 3)].Clone();
                Mob.Stand(placeForMobs);
                pHpMobs.Value = Mob.hitPoint;
                Mob.hitPoint = 100;
                AddCoins();
                punchField.IsEnabled = true;
                return;
            }
            knight.attack = rand.Next(15, 30);
            await Mob.Hit(placeForMobs);
            punchField.IsEnabled = true;

        }
        private void UpdatingProgressBar()
        {
            pHpKnight.Value = knight.hitPoint;
            pHpMobs.Value = Mob.hitPoint;
        }
        private void AddCoins()
        {
            coins += rand.Next(3, 6);
            Coins.Text = coins.ToString() ;
        }
    }
}
