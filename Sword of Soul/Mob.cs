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
using System.Timers;
using System.CodeDom;
using System.Windows.Media.Animation;

namespace Sword_of_Soul
{
    abstract class Mob
    {
        protected string UriStand;
        protected string UriHit;
        protected string UriDeath;
        public int hitPoint;
        public int attack;
        public Mob(int hitPoint, int attack)
        {
            this.hitPoint = hitPoint;
            this.attack = attack;
        }
        public abstract void Stand(Image image);
        public abstract Task Hit(Image image);
        public abstract Task Death(Image image);
    }
    class Skeleton : Mob
    {
         
        public Skeleton(int hitPoint, int attack) : base(hitPoint, attack) 
        {
            UriStand = @"animation/Skeleton Idle.gif";
            UriHit = @"animation/Skeleton Hit.gif";
            UriDeath = @"animation/Skeleton Dead.gif";
        }
        public override void Stand(Image image)
        {
            ImageBehavior.SetAnimatedSource(image, new BitmapImage(new Uri(UriStand, UriKind.RelativeOrAbsolute)));
        }
        public override Task Hit(Image image)
        {

            return Task.Run(() =>
            {
                try
                {
                    Application.Current.Dispatcher.Invoke(() => ImageBehavior.SetAnimatedSource(image, new BitmapImage(new Uri(UriHit, UriKind.RelativeOrAbsolute))));
                    Thread.Sleep(400);
                    Application.Current.Dispatcher.Invoke(() => Stand(image));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });




        }
        /*private void Timer_tick_Death(object sender, EventArgs e)
        {
            timer.Stop();
           
        }*/
        public override Task Death(Image image)
        {

            return Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    ImageBehavior.SetAnimatedSource(image, new BitmapImage(new Uri(UriDeath, UriKind.RelativeOrAbsolute)));
                    /*timer.Interval = TimeSpan.FromMilliseconds(1500);
                    timer.Tick += ((s, e) => {
                        timer.Stop();*/



                    /*});
                    timer.Start();*/
                });
                Thread.Sleep(1200);
                
            }
            );


        }


    }
    class Knight : Mob
    {
        public Knight(int hitPoint, int attack) : base(hitPoint, attack) { }
        public override void Stand(Image image)
        {
            ImageBehavior.SetAnimatedSource(image, new BitmapImage(new Uri(UriStand, UriKind.RelativeOrAbsolute)));
        }
        public override Task Hit(Image image)
        {
            throw new NotImplementedException();
        }
        public override Task Death(Image image)
        {
            throw new NotImplementedException();
        }
    }
    class SimpleMob : Mob
    {
        
        public SimpleMob(int hitPoint, int attack) : base(hitPoint, attack) { }
        public override void Stand(Image image)
        {
            image.Source = ImageConverter.ConvertStringToImageSource(UriStand);
        }
        public override Task Hit(Image image)
        {

            return Task.Run(() =>
            {
                try
                {
                    Application.Current.Dispatcher.Invoke(() => image.Source = ImageConverter.ConvertStringToImageSource(UriHit));
                    Thread.Sleep(100);
                    Application.Current.Dispatcher.Invoke(() => Stand(image));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
        public override Task Death(Image image)
        {

            return Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    image.Source = ImageConverter.ConvertStringToImageSource(UriDeath);
                    /*timer.Interval = TimeSpan.FromMilliseconds(1500);
                    timer.Tick += ((s, e) => {
                        timer.Stop();*/



                    /*});
                    timer.Start();*/
                });
                Thread.Sleep(300);
                
            }
            );
        }
    }
    class Zombie : SimpleMob
    {
        
        public Zombie(int hitPoint, int attack) : base(hitPoint, attack) {
            UriStand = @"C:\Users\user\source\repos\Sword of Soul\Sword of Soul\images\zombie.png";
            UriHit = @"C:\Users\user\source\repos\Sword of Soul\Sword of Soul\images\zombie hit.png";
            UriDeath = @"C:\Users\user\source\repos\Sword of Soul\Sword of Soul\images\zombie die.png";
        }
    }
    class Ghost : SimpleMob
    {
         public Ghost(int hitPoint, int attack) : base(hitPoint, attack) {
            UriStand = @"C:\Users\user\source\repos\Sword of Soul\Sword of Soul\images\ghost.png";
            UriHit = @"C:\Users\user\source\repos\Sword of Soul\Sword of Soul\images\ghostHit.png";
            UriDeath = @"C:\Users\user\source\repos\Sword of Soul\Sword of Soul\images\ghost die.png";

        }
    }
}
