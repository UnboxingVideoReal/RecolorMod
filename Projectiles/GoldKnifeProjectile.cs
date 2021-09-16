using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RecolorMod.Items;
using Terraria.Audio;

namespace RecolorMod.Projectiles
{
	public class GoldKnifeProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Golden Knife");
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.ThrowingKnife);
			AIType = ProjectileID.ThrowingKnife;
			Projectile.DamageType = DamageClass.Throwing;
		}
	}
}
