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
        
        public game()
        {
            InitializeComponent();
            Cursors.Set(this);
            Mob.Stand(placeForMobs);
            pHpMobs.Value = Mob.hitPoint;
           
        }
        

        
    }
}
