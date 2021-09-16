using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RecolorMod.Items;
using Terraria.Audio;
using System;

namespace RecolorMod.Projectiles
{
	public class SolarFragment : ModProjectile
	{
		public ref float AI_Timer => ref Projectile.ai[1];

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.GreenLaser);
			Projectile.DamageType = DamageClass.Ranged;
		}

		//      public override void AI()
		//      {
		//	AI_Timer++;
		//	if (AI_Timer >= 150f)
		//	{
		//		var num627 = 12f;
		//		var vector71 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height / 2);
		//		var num628 = 100;
		//		int num629 = ModContent.ProjectileType<Projectiles.Fragments>();
		//		Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 33);
		//		var num630 = (float)Math.Atan2(vector71.Y - (Projectile.position.Y + Projectile.height * 0.5f), vector71.X - (Projectile.position.X + Projectile.width * 0.5f));
		//		for (var num631 = 0f; num631 <= 4f; num631 += 0.4f)
		//		{
		//			var num632 = Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), vector71.X, vector71.Y, (float)(Math.Cos(num630 + num631) * num627 * -1.0), (float)(Math.Sin(num630 + num631) * num627 * -1.0), num629, num628, 0f, 0, 0f, 0f);
		//			Main.projectile[num632].timeLeft = 600;
		//			Main.projectile[num632].tileCollide = false;
		//			num632 = Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), vector71.X, vector71.Y, (float)(Math.Cos(num630 - num631) * num627 * -1.0), (float)(Math.Sin(num630 - num631) * num627 * -1.0), num629, num628, 0f, 0, 0f, 0f);
		//			Main.projectile[num632].timeLeft = 600;
		//			Main.projectile[num632].tileCollide = false;
		//		}
		//		AI_Timer = 0f;
		//		return;
		//	}
		//	return;
		//}
	}
}