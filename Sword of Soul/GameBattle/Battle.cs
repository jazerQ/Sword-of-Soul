using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Sword_of_Soul
{
    static class Battle
    {
        public static void MutualAttack(Mob mob, Knight knight)
        {
            mob.feature.hitPoint -= knight.feature.attack;

            knight.feature.hitPoint -= mob.feature.attack;
            
        }
        public static bool IsKnightDead(Knight knight)
        {
            if(knight.feature.hitPoint <= 0)
            {
                return true;
            }
            return false;
        }
        public static bool isMobDead(Mob mob)
        {
            if (mob.feature.hitPoint <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
