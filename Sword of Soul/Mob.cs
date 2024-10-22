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
using System.ComponentModel.Design;

namespace Sword_of_Soul
{
    public class UriState
    {
        public string UriStand { get; set; }
        public string UriHit { get; set; }
        public string UriDeath { get; set; }
        public Image image { get; set; }
    }
    class Feature
    {
        public int hitPoint;
        public int attack;
        public Feature(int hitPoint, int attack)
        {
            this.hitPoint = hitPoint;
            this.attack = attack;
        }
    }
    public interface State
    {
        void State(string uri);
    }
    public class MobState : UriState, State
    {
        public void State(string uri)
        {

            
            ImageBehavior.SetAnimatedSource(image, new BitmapImage(new Uri(uri, UriKind.RelativeOrAbsolute)));
            

                
            
        }
        
    }

    public class MobStand
    {
        public MobStand(UriState uriState)
        {
            this.mobState.UriStand = uriState.UriStand;
            this.mobState.UriHit = uriState.UriHit;
            this.mobState.UriDeath = uriState.UriDeath;
            this.mobState.image = uriState.image;
        }

        private MobState mobState = new MobState();
        public void Stand()
        {
            mobState.State(mobState.UriStand);
        }
        public Task Hit()
        {
            mobState.State(mobState.UriHit);
            return Task.Run(() => Task.Delay(300));
        }
        public Task Death()
        {
            mobState.State(mobState.UriDeath);
            return Task.Run(() => Task.Delay(800)) ;
        }
    }
    
    class Mob
    {
        protected UriState uriState = new UriState();
        public Feature feature;
        public MobStand state;
        
        public Mob(int hitPoint, int attack,Image image)
        {
            this.feature = new Feature(hitPoint, attack);

            
            this.uriState.image = image;
            state = new MobStand(uriState);

        }
       
        public virtual Mob Clone()
        {
            Mob newMob = new Mob(this.feature.hitPoint, this.feature.attack, this.uriState.image)
            {
                feature = new Feature(this.feature.hitPoint, this.feature.attack),


            };
            return newMob;
        }

    }
    class Skeleton : Mob
    {
         
        public Skeleton(int hitPoint, int attack, Image image) : base(hitPoint, attack, image) 
        {
            uriState.UriStand = @"animation/Skeleton Idle.gif";
            uriState.UriHit = @"animation/Skeleton Hit.gif";
            uriState.UriDeath = @"animation/Skeleton Dead.gif";
            state = new MobStand(uriState);
        }
        
        public override Mob Clone()
        {
            Mob newMob = new Skeleton(this.feature.hitPoint, this.feature.attack, this.uriState.image);
            
            return newMob;
        }


    }
    class Knight
    {
        private static Knight _knight;
        public Feature feature;
        public string name { get; set; }
        public static Knight Instance(int hitPoint, int attack, string name)
        {
            if(_knight == null)
            {
                _knight = new Knight(hitPoint, attack, name);
            }
            return _knight;
        }
        protected Knight(int hitPoint, int attack, string name) 
        {
            this.feature = new Feature(hitPoint, attack);
            
            this.name = name;
        }
    }
    
    class Zombie : Mob
    {

        public Zombie(int hitPoint, int attack, Image image) : base(hitPoint, attack,image)
        {
            uriState.UriStand = @"C:\Users\user\source\repos\Sword of Soul\Sword of Soul\images\zombie.png";
            uriState.UriHit = @"C:\Users\user\source\repos\Sword of Soul\Sword of Soul\images\zombie hit.png";
            uriState.UriDeath = @"C:\Users\user\source\repos\Sword of Soul\Sword of Soul\images\zombie die.png";
            state = new MobStand(uriState);
        }
        
        public override Mob Clone()
        {
            Mob newMob = new Zombie(this.feature.hitPoint, this.feature.attack, this.uriState.image);

            return newMob;
        }
    }
    class Ghost : Mob
    {
         public Ghost(int hitPoint, int attack, Image image) : base(hitPoint, attack, image) {
            uriState.UriStand = @"C:\Users\user\source\repos\Sword of Soul\Sword of Soul\images\ghost.png";
            uriState.UriHit = @"C:\Users\user\source\repos\Sword of Soul\Sword of Soul\images\ghostHit.png";
            uriState.UriDeath = @"C:\Users\user\source\repos\Sword of Soul\Sword of Soul\images\ghost die.png";
            state = new MobStand(uriState);
         }
         public override Mob Clone()
         {
             Mob newMob = new Ghost(this.feature.hitPoint, this.feature.attack, this.uriState.image);

             return newMob;
         }
    }
}
