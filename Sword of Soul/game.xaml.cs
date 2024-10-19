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
            knight.Stand(placeForKnight);
        }

        private void punchField_Click(object sender, RoutedEventArgs e)
        {
            if(skeleton == null)
            {
                return;
            }
            skeleton.hitPoint -= knight.attack;
            knight.hitPoint -= skeleton.attack;
            if(skeleton.hitPoint <= 0) {
                skeleton.Death(placeForMobs);
                skeleton = null;
                punchField.IsEnabled = false;
                pHpKnight.Value = knight.hitPoint;
                pHpMobs.Value = 0;
                return;
            }
            knight.attack = rand.Next(5,8);
            pHpKnight.Value = knight.hitPoint;
            pHpMobs.Value = skeleton.hitPoint;
            skeleton.Hit(placeForMobs);
        }
    }
}
