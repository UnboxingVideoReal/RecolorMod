using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod.Projectiles
{
    public class VileBulletP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vile Bullet");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.DemonScythe);
            Projectile.width = 2; // The width of Projectile hitbox
            Projectile.height = 20; // The height of Projectile hitbox
            Projectile.aiStyle = -1;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            if (Projectile.localAI[0] == 0)
            {
                Projectile.localAI[0] = 1;
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item17, Projectile.Center);
            }
            if (++Projectile.localAI[1] > 30 && Projectile.localAI[1] < 120)
                Projectile.velocity *= 1.03f;
            
            for (int i = 0; i < 3; i++)
            {
                int d = Dust.NewDust(Projectile.Center, 0, 0, DustID.GreenBlood, 0f, 0f, 150);
                float velrando = Main.rand.Next(20, 31) / 10;
                Main.dust[d].velocity = Projectile.velocity / velrando;
                Main.dust[d].noGravity = true;
            }

            if (Projectile.timeLeft < 180)
                Projectile.tileCollide = true;

            RecolorUtils.GetBulletRotation(Projectile);
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 300);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            RecolorGlobalProjectile.XWay(4, Projectile.position, ModContent.ProjectileType<VileBulletNoSplit>(), 10, Projectile.damage, Projectile.knockBack);
            return base.OnTileCollide(oldVelocity);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            RecolorGlobalProjectile.XWay(4, Projectile.position, ModContent.ProjectileType<VileBulletNoSplit>(), 10, damage, knockback);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            RecolorGlobalProjectile.XWay(4, Projectile.position, ModContent.ProjectileType<VileBulletNoSplit>(), 10, damage, Projectile.knockBack);
        }
    }

    public class VileBulletNoSplit : ModProjectile
    {
        public override string Texture => ModContent.GetInstance<VileBulletP>().Texture;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vile Bullet");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.DemonScythe);
            Projectile.width = 2; // The width of Projectile hitbox
            Projectile.height = 20; // The height of Projectile hitbox
            Projectile.aiStyle = -1;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            if (Projectile.localAI[0] == 0)
            {
                Projectile.localAI[0] = 1;
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item17, Projectile.Center);
            }
            if (++Projectile.localAI[1] > 30 && Projectile.localAI[1] < 120)
                Projectile.velocity *= 1.03f;

            for (int i = 0; i < 3; i++)
            {
                int d = Dust.NewDust(Projectile.Center, 0, 0, DustID.GreenBlood, 0f, 0f, 150);
                float velrando = Main.rand.Next(20, 31) / 10;
                Main.dust[d].velocity = Projectile.velocity / velrando;
                Main.dust[d].noGravity = true;
            }

            if (Projectile.timeLeft < 180)
                Projectile.tileCollide = true;

            RecolorUtils.GetBulletRotation(Projectile);
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 300);
        }
    }
}
