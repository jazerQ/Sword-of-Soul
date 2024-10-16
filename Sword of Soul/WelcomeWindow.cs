using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Sword_of_Soul
{
     
    
    public partial class WelcomeWindow
    {
        
        private void WelcomeAnimation()
        {
            JazerQStudioWelcomeAnimation<DoubleAnimation> jazerQStudioWelcomeAnimation = new JazerQStudioWelcomeAnimation<DoubleAnimation>(
                sourceImage1,
                durationImage1,
                animationImage
                );
            FromToAnimation(jazerQStudioWelcomeAnimation._ImageAnimation, IntroImage.Opacity, 1);
            jazerQStudioWelcomeAnimation.StartAnimation(IntroImage);
            jazerQStudioWelcomeAnimation.StartAnimation(IntroLabel);
            /*jazerQStudioWelcomeAnimation._ImageAnimation = animationImage1;
            FromToAnimation(jazerQStudioWelcomeAnimation._ImageAnimation, 1, 0);
            jazerQStudioWelcomeAnimation.StartAnimation(IntroImage);
            jazerQStudioWelcomeAnimation.StartAnimation(IntroLabel);*/
        }
    }
}
