using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RecolorMod.Items;
using Terraria.Audio;

namespace RecolorMod.Projectiles
{
	public class SaturationLaser : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Saturation Laser");
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.EyeLaser);
			AIType = ProjectileID.EyeLaser;
		}
	}
}
