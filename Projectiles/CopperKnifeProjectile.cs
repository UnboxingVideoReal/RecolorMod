using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RecolorMod.Items;
using Terraria.Audio;

namespace RecolorMod.Projectiles
{
	public class CopperKnifeProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Copper Knife");
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.ThrowingKnife);
			AIType = ProjectileID.ThrowingKnife;
			Projectile.DamageType = DamageClass.Throwing;
		}
	}
}
