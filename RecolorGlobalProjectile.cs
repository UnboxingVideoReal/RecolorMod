using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace RecolorMod
{
    public class RecolorGlobalProjectile : GlobalProjectile 
    {
        public static Projectile[] XWay(int num, Vector2 pos, int type, float speed, int damage, float knockback)
        {
            Projectile[] projs = new Projectile[num];
            double spread = 2 * Math.PI / num;
            for (int i = 0; i < num; i++)
                projs[i] = NewProjectileDirectSafe(pos, new Vector2(speed, speed).RotatedBy(spread * i), type, damage, knockback, Main.myPlayer);
            return projs;
        }

        public static Projectile NewProjectileDirectSafe(Vector2 pos, Vector2 vel, int type, int damage, float knockback, int owner = 255, float ai0 = 0f, float ai1 = 0f)
        {
            int p = Projectile.NewProjectile(Projectile.GetNoneSource(), pos, vel, type, damage, knockback, owner, ai0, ai1);
            return (p < 1000) ? Main.projectile[p] : null;
        }
    }
}
