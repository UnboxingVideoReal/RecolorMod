using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod.Projectiles
{
	public class HueBulletProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Hue Bullet"); // Name of the Projectile. It can be appear in chat
			/*ProjectileID.Sets.CountsAsHoming[Projectile.type] = true;*/ // Tell the game that it is a homing Projectile
		}

		// Setting the default parameters of the Projectile
		// You can check most of Fields and Properties here https://github.com/tModLoader/tModLoader/wiki/Projectile-Class-Documentation
		public override void SetDefaults() {
			Projectile.width = 2; // The width of Projectile hitbox
			Projectile.height = 20; // The height of Projectile hitbox

			Projectile.aiStyle = ProjectileID.SniperBullet; // The ai style of the Projectile (0 means custom AI). For more please reference the source code of Terraria
			Projectile.DamageType = DamageClass.Ranged; // What type of damage does this Projectile affect?
			Projectile.friendly = true; // Can the Projectile deal damage to enemies?
			Projectile.hostile = false; // Can the Projectile deal damage to the player?
			Projectile.ignoreWater = true; // Does the Projectile's speed be influenced by water?
			Projectile.light = 1f; // How much light emit around the Projectile
			Projectile.tileCollide = false; // Can the Projectile collide with tiles?
			Projectile.timeLeft = 600; //The live time for the Projectile (60 = 1 second, so 600 is 10 seconds)
		}

        // Custom AI
        public override void AI()
        {
            //Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), (Vector2)Projectile.position.X, (float)Projectile.position.Y, ModContent.ProjectileType<HueBulletProjectile>(), Projectile.damage, Projectile.knockBack, 255, 0, 0);
            Projectile.ai[0] += 1f;
            if (Projectile.alpha < 170)
            {
                for (var num26 = 0; num26 < 10; num26++)
                {
                    var x2 = Projectile.position.X - Projectile.velocity.X / 10f * num26;
                    var y2 = Projectile.position.Y - Projectile.velocity.Y / 10f * num26;
                    int num27;
                    //num27 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 119, 0f, 0f, 0, default(Color), 1f);
                    //Main.dust[num27].alpha = Projectile.alpha;
                    //Main.dust[num27].position.X = x2;
                    //Main.dust[num27].position.Y = y2;
                    //Main.dust[num27].velocity *= 0f;
                    //Main.dust[num27].noGravity = true;
                }
            }
            var num28 = (float)Math.Sqrt(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y);
            var num29 = Projectile.localAI[0];
            if (num29 == 0f)
            {
                Projectile.localAI[0] = num28;
                num29 = num28;
            }
            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= 25;
            }
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }
            var num30 = Projectile.position.X;
            var num31 = Projectile.position.Y;
            var num32 = 300f;
            var flag = false;
            var num33 = 0;
            if (Projectile.ai[1] == 0f)
            {
                for (var num34 = 0; num34 < 200; num34++)
                {
                    if (Main.npc[num34].active && !Main.npc[num34].dontTakeDamage && !Main.npc[num34].friendly && Main.npc[num34].lifeMax > 5 && (Projectile.ai[1] == 0f || Projectile.ai[1] == num34 + 1))
                    {
                        var num35 = Main.npc[num34].position.X + Main.npc[num34].width / 2;
                        var num36 = Main.npc[num34].position.Y + Main.npc[num34].height / 2;
                        var num37 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num35) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num36);
                        if (num37 < num32 && Collision.CanHit(new Vector2(Projectile.position.X + Projectile.width / 2, Projectile.position.Y + Projectile.height / 2), 1, 1, Main.npc[num34].position, Main.npc[num34].width, Main.npc[num34].height))
                        {
                            num32 = num37;
                            num30 = num35;
                            num31 = num36;
                            flag = true;
                            num33 = num34;
                        }
                    }
                }
                if (flag)
                {
                    Projectile.ai[1] = num33 + 1;
                }
                flag = false;
            }
            if (Projectile.ai[1] != 0f)
            {
                var num38 = (int)(Projectile.ai[1] - 1f);
                if (Main.npc[num38].active)
                {
                    var num39 = Main.npc[num38].position.X + Main.npc[num38].width / 2;
                    var num40 = Main.npc[num38].position.Y + Main.npc[num38].height / 2;
                    var num41 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num39) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num40);
                    if (num41 < 1000f)
                    {
                        flag = true;
                        num30 = Main.npc[num38].position.X + Main.npc[num38].width / 2;
                        num31 = Main.npc[num38].position.Y + Main.npc[num38].height / 2;
                    }
                }
            }
            if (flag)
            {
                var num42 = num29;
                var vector = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                var num43 = num30 - vector.X;
                var num44 = num31 - vector.Y;
                var num45 = (float)Math.Sqrt(num43 * num43 + num44 * num44);
                num45 = num42 / num45;
                num43 *= num45;
                num44 *= num45;
                var num46 = 8;
                Projectile.velocity.X = (Projectile.velocity.X * (num46 - 1) + num43) / num46;
                Projectile.velocity.Y = (Projectile.velocity.Y * (num46 - 1) + num44) / num46;
            }
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
        }
    }
}
