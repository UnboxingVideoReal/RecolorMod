using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RecolorMod.Items;
using Terraria.Audio;

namespace RecolorMod.Projectiles
{
	public class RainbowLaser : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Rainbow Laser");
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.EyeLaser);
			AIType = ProjectileID.EyeLaser;
		}
	}
}
