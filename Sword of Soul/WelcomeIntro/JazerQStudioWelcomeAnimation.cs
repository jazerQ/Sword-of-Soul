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
    class JazerQStudioWelcomeAnimation<T> : Animate<T>
        where T : AnimationTimeline
    {
        

        public JazerQStudioWelcomeAnimation(
            string welcomeImageSource,
            int duration,
            T imageAnimation
            ) : base(
                welcomeImageSource,
                duration,
                imageAnimation
                ){ }
        
        public override void StartAnimation(Image image)
        {
            image.Source = _ImageSource;
            
            _ImageAnimation.Duration = TimeSpan.FromSeconds(_duration);
            image.BeginAnimation(Image.OpacityProperty, _ImageAnimation);
            
        }
        public override void StartAnimation(Label label)
        {
            _ImageAnimation.Duration = TimeSpan.FromSeconds(_duration);
            label.BeginAnimation(Label.OpacityProperty, _ImageAnimation);
        }
    }
}
