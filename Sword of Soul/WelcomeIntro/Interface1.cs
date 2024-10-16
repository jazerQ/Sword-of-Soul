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
    abstract class Animate<T> where T : AnimationTimeline
    {
        protected ImageSource _ImageSource;
        protected int _duration;
        public T _ImageAnimation;
        public Animate(string welcomeImageSource, int duration, T ImageAnimation)
        {
            _ImageSource = ImageConverter.ConvertStringToImageSource(welcomeImageSource);
            _duration = duration;
            _ImageAnimation = ImageAnimation;
        }
        public Animate(int duration, T ImageAnimation)
        {
            
            _duration = duration;
            _ImageAnimation = ImageAnimation;
        }
        public abstract void StartAnimation(Image image);
        public abstract void StartAnimation(Label label);

    }
}
