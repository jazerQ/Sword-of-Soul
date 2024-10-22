using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sword_of_Soul
{
    public partial class game 
    {
        
        private Knight knight =Knight.Instance(1000, 5, "NN");
       
        private static Random rand = new Random();
        private static Mob[] Mobs;
        private static Mob Mob ;
        

        //Methods
        private async void punchField_Click(object sender, RoutedEventArgs e)
        {
            punchField.IsEnabled = false;

            Battle.MutualAttack(Mob, knight);
            UpdatingProgressBar();
            if (Battle.isMobDead(Mob))
            {
                await Mob.state.Death();
                Mob = Mobs[rand.Next(0, 3)].Clone();
                Mob.state.Stand();
                Mob.feature.hitPoint = 100;
                pHpMobs.Value = Mob.feature.hitPoint;
                
                AddCoins();
                punchField.IsEnabled = true;
                return;
            }
            knight.feature.attack = rand.Next(15, 30);
            await Mob.state.Hit();
            Mob.state.Stand();
            if (Battle.IsKnightDead(knight))
            {
                Shop shop = new Shop();
                shop.Show();
                this.Close();
            }
            punchField.IsEnabled = true;

        }
        private void UpdatingProgressBar()
        {
            pHpKnight.Value = knight.feature.hitPoint;
            pHpMobs.Value = Mob.feature.hitPoint;
        }
        private void AddCoins()
        {
            Money.coins += rand.Next(3, 6);
            Coins.Text = Money.coins.ToString() ;
        }
    }
}
