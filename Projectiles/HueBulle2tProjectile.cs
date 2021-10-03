//using Microsoft.Xna.Framework;
//using Terraria;
//using System;
//using Terraria.ID;
//using Terraria.ModLoader;

//namespace RecolorMod.Projectiles
//{
//	// This Example show how to implement simple homing Projectile
//	// Can be tested with ExampleCustomAmmoGun
//	public class HueBullet2Projectile : ModProjectile
//	{
//        public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.RainbowRodBullet;
//        public override void SetStaticDefaults() {
//			DisplayName.SetDefault("Rainbow Bullet"); // Name of the Projectile. It can be appear in chat
//			/*ProjectileID.Sets.CountsAsHoming[Projectile.type] = true;*/ // Tell the game that it is a homing Projectile
//		}

//		// Setting the default parameters of the Projectile
//		// You can check most of Fields and Properties here https://github.com/tModLoader/tModLoader/wiki/Projectile-Class-Documentation
//		public override void SetDefaults() {
//            Projectile.CloneDefaults(ProjectileID.RainbowRodBullet);
//			Projectile.DamageType = DamageClass.Ranged; // What type of damage does this Projectile affect?
//		}

//		public override void OnHitPvp(Player target, int damage, bool crit)
//		{
//			RecolorGlobalProjectile.XWay(5, Projectile.position, ModContent.ProjectileType<HueBullet2ProjectileNoSplit>(), 15, damage, Projectile.knockBack);
//		}
//	}

//	public class HueBullet2ProjectileNoSplit : ModProjectile
//	{
//		public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.RainbowRodBullet;
//		public override void SetStaticDefaults()
//		{
//			DisplayName.SetDefault("Rainbow Bullet"); // Name of the Projectile. It can be appear in chat
//			/*ProjectileID.Sets.CountsAsHoming[Projectile.type] = true;*/ // Tell the game that it is a homing Projectile
//		}

//		// Setting the default parameters of the Projectile
//		// You can check most of Fields and Properties here https://github.com/tModLoader/tModLoader/wiki/Projectile-Class-Documentation
//		public override void SetDefaults()
//		{
//			Projectile.CloneDefaults(ProjectileID.RainbowRodBullet);
//			Projectile.DamageType = DamageClass.Ranged; // What type of damage does this Projectile affect?
//		}
//	}
//}
