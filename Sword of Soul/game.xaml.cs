using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace Sword_of_Soul
{
    /// <summary>
    /// Логика взаимодействия для game.xaml
    /// </summary>
    public partial class game : Window
    {
        Skeleton skeleton = new Skeleton(100, 5);
        Knight knight = new Knight(100, 5);
        Random rand = new Random();
        public game()
        {
            InitializeComponent();
            Cursors.Set(this);
            Skeleton skeleton = new Skeleton(100, 5);
            skeleton.Stand(placeForMobs);
           
        }

        private async void punchField_Click(object sender, RoutedEventArgs e)
        {
            punchField.IsEnabled = false;
            
            skeleton.hitPoint -= knight.attack;
            knight.hitPoint -= skeleton.attack;
            pHpKnight.Value = knight.hitPoint;
            pHpMobs.Value = skeleton.hitPoint;
            if (skeleton.hitPoint <= 0) {
                await skeleton.Death(placeForMobs);
                pHpKnight.Value = knight.hitPoint;
                pHpMobs.Value = 100;
                skeleton.hitPoint = 100;
                punchField.IsEnabled = true;
                return;
            }
            knight.attack = rand.Next(15, 30);
            await skeleton.Hit(placeForMobs);
            punchField.IsEnabled = true;

        }
    }
}
