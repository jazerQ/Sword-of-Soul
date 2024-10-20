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
        private DispatcherTimer timer = new DispatcherTimer();
        private readonly string UriStand = @"animation/Skeleton Idle.gif";
        private readonly string UriHit = @"animation/Skeleton Hit.gif";
        private readonly string UriDeath = @"animation/Skeleton Dead.gif";
        public Skeleton(int hitPoint, int attack) : base(hitPoint, attack) { }
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
                    catch(Exception ex)
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
            
            return Task.Run(() => {
                Application.Current.Dispatcher.Invoke(() => { ImageBehavior.SetAnimatedSource(image, new BitmapImage(new Uri(UriDeath, UriKind.RelativeOrAbsolute)));
                    /*timer.Interval = TimeSpan.FromMilliseconds(1500);
                    timer.Tick += ((s, e) => {
                        timer.Stop();*/
                    
                   

                    /*});
                    timer.Start();*/
                    });
                Thread.Sleep(1200);
                Application.Current.Dispatcher.Invoke(() => Stand(image));
            }
            ) ;
            
            
        }

        
    }
    class Knight : Mob
    {
        private readonly string UriStand = @"animation/New Piskel (2).png";
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
}
