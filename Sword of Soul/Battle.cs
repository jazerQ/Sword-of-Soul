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
        public static void MutualAttack(Mob mob, Mob knight)
        {
            mob.hitPoint -= knight.attack;
            knight.hitPoint -= mob.attack;
        }
    }
}
