using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod.Projectiles
{
    public class SeraphFireball : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seraph Fireball");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16; // The width of Projectile hitbox
            Projectile.height = 16; // The height of Projectile hitbox

            Projectile.aiStyle = 0; // The ai style of the Projectile (0 means custom AI). For more please reference the source code of Terraria
            Projectile.friendly = false; // Can the Projectile deal damage to enemies?
            Projectile.hostile = true; // Can the Projectile deal damage to the player?
            Projectile.ignoreWater = true; // Does the Projectile's speed be influenced by water?
            Projectile.light = 1f; // How much light emit around the Projectile
            Projectile.tileCollide = false; // Can the Projectile collide with tiles?
            Projectile.timeLeft = 600; //The live time for the Projectile (60 = 1 second, so 600 is 10 seconds)
        }

        public override void AI()
        {
            if (Projectile.localAI[1] == 0)
            {
                Projectile.localAI[1] = 1;
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item20, Projectile.Center);
            }

            if (Projectile.ai[1] == 0)
            {
                float rotation = Projectile.velocity.ToRotation();
                Vector2 vel = Main.player[(int)Projectile.ai[0]].Center - Projectile.Center;
                float targetAngle = vel.ToRotation();
                Projectile.velocity = new Vector2(Projectile.velocity.Length(), 0f).RotatedBy(rotation.AngleLerp(targetAngle, Projectile.localAI[0]));

                if (Projectile.localAI[0] < 0.5f)
                    Projectile.localAI[0] += 1f / 3000f;

                if (vel.Length() < 250 || !Main.player[(int)Projectile.ai[0]].active || Main.player[(int)Projectile.ai[0]].dead || Main.player[(int)Projectile.ai[0]].ghost)
                {
                    Projectile.ai[1] = 1;
                    Projectile.netUpdate = true;
                    Projectile.timeLeft = 180;
                    Projectile.velocity.Normalize();
                }
            }
            else if (Projectile.ai[1] > 0)
            {
                if (++Projectile.ai[1] < 120)
                {
                    Projectile.velocity *= 1.03f;

                    float rotation = Projectile.velocity.ToRotation();
                    Vector2 vel = Main.player[(int)Projectile.ai[0]].Center - Projectile.Center;
                    float targetAngle = vel.ToRotation();
                    Projectile.velocity = new Vector2(Projectile.velocity.Length(), 0f).RotatedBy(rotation.AngleLerp(targetAngle, 0.025f));
                }
            }
            else //ai1 below 0 rn
            {
                Projectile.ai[1]++;
            }

            for (int i = 0; i < 3; i++) //vanilla dusts
            {
                for (int j = 0; j < 3; ++j)
                {
                    int d = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Pixie, 0.0f, 0.0f, 100, default, 1f);
                    Main.dust[d].noGravity = true;
                    Main.dust[d].velocity *= 0.1f;
                    Main.dust[d].velocity += Projectile.velocity * 0.5f;
                    Main.dust[d].position -= Projectile.velocity / 3 * j;
                }
                if (Main.rand.Next(8) == 0)
                {
                    int d = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Pixie, 0.0f, 0.0f, 100, default, 0.5f);
                    Main.dust[d].velocity *= 0.25f;
                    Main.dust[d].velocity += Projectile.velocity * 0.5f;
                }
            }
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 900);
        }
    }
}