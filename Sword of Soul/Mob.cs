using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;
using System.Windows.Threading;
using System.Windows;

namespace Sword_of_Soul
{
    abstract class Mob
    {
        public int hitPoint;
        public int attack;
        public Mob(int hitPoint, int attack) 
        {
            this.hitPoint = hitPoint;
            this.attack = attack;
        }
        public abstract void Stand(Image image);
        public abstract void Hit(Image image);
        public abstract void Death(Image image);
    }
    class Skeleton : Mob
    {
        private readonly string UriStand = @"animation/Skeleton Idle.gif";
        private readonly string UriHit = @"animation/Skeleton Hit.gif";
        private readonly string UriDeath = @"animation/Skeleton Dead.gif";
        public Skeleton(int hitPoint, int attack) : base(hitPoint, attack) { }
        public override void Stand(Image image) 
        {
            ImageBehavior.SetAnimatedSource(image, new BitmapImage(new Uri(UriStand, UriKind.RelativeOrAbsolute)));
        }
        public override void Hit(Image image)
        {
            try
            {
                ImageBehavior.SetAnimatedSource(image, new BitmapImage(new Uri(UriHit, UriKind.RelativeOrAbsolute)));
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(700);
                timer.Tick += (s, e) =>
                {
                    timer.Stop();
                    Stand(image);
                };
                timer.Start();


                
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public override void Death(Image image)
        {
            ImageBehavior.SetAnimatedSource(image, new BitmapImage(new Uri(UriDeath, UriKind.RelativeOrAbsolute)));
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(700);
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                image.Source = null;
            };
            timer.Start();
        }
        

    }
    class Knight : Mob
    {
        private readonly string UriStand = @"animation/Knight Idle.gif";
        public Knight(int hitPoint, int attack) : base(hitPoint, attack) { }
        public override void Stand(Image image)
        {
            ImageBehavior.SetAnimatedSource(image, new BitmapImage(new Uri(UriStand, UriKind.RelativeOrAbsolute)));
        }
        public override void Hit(Image image)
        {
            throw new NotImplementedException();
        }
        public override void Death(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
