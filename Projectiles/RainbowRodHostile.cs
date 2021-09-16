using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RecolorMod.Items;
using Terraria.Audio;

namespace RecolorMod.Projectiles
{
	public class RainbowRodHostile : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Rainbow Rod");
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.RainbowRodBullet);
			Projectile.friendly = false;
			Projectile.hostile = true;
		}
	}
}
