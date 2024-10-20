using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sword_of_Soul
{
    public partial class game 
    {
        private Skeleton skeleton = new Skeleton(100, 5);
        private Knight knight = new Knight(100, 5);
        private Random rand = new Random();
        private int coins = 0; 

        //Methods
        private async void punchField_Click(object sender, RoutedEventArgs e)
        {
            punchField.IsEnabled = false;

            Battle.MutualAttack(skeleton, knight);
            UpdatingProgressBar();
            if (skeleton.hitPoint <= 0)
            {
                await skeleton.Death(placeForMobs);
                pHpMobs.Value = 100;
                skeleton.hitPoint = 100;
                AddCoins();
                punchField.IsEnabled = true;
                return;
            }
            knight.attack = rand.Next(15, 30);
            await skeleton.Hit(placeForMobs);
            punchField.IsEnabled = true;

        }
        private void UpdatingProgressBar()
        {
            pHpKnight.Value = knight.hitPoint;
            pHpMobs.Value = skeleton.hitPoint;
        }
        private void AddCoins()
        {
            coins += rand.Next(3, 6);
            Coins.Text = coins.ToString() ;
        }
    }
}
