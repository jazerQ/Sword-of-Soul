using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Sword_of_Soul
{
     
    
    public partial class WelcomeWindow
    {
        
        private Task WelcomeAnimation()
        {

            
            return Task.Run(() =>
            {
                JazerQStudioWelcomeAnimation<DoubleAnimation> jazerQStudioWelcomeAnimation = new JazerQStudioWelcomeAnimation<DoubleAnimation>(
                sourceImage1,
                durationImage1,
                animationImage
                );
                Music music = new Music();
                music.PlayCurrentTrack();
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    
                    FromToAnimation(jazerQStudioWelcomeAnimation._ImageAnimation, IntroImage.Opacity, 1);
                    jazerQStudioWelcomeAnimation.StartAnimation(IntroImage);
                    jazerQStudioWelcomeAnimation.StartAnimation(IntroLabel);
                }));
                Task.Delay(7000).Wait();
                
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    Clos();
                }));
            });
            
            
        }
    }
}
