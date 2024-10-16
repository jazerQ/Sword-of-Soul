using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Sword_of_Soul
{
    public partial class WelcomeWindow
    {
        private const string sourceImage1 = "C:\\Users\\user\\source\\repos\\Sword of Soul\\Sword of Soul\\images\\pngegg.png";
        private const int durationImage1 = 3;
        private DoubleAnimation animationImage = new DoubleAnimation() { 
            AutoReverse=true
        };
        private DoubleAnimation animationImage1 = new DoubleAnimation() { 
            AutoReverse = true
        };
        private void FromToAnimation(DoubleAnimation doubleAnimation, double from, double to)
        {
            doubleAnimation.From = from;
            doubleAnimation.To = to;
        }
    }
}
