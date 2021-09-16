using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RecolorMod.Items;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RecolorMod.Projectiles.Summons
{
	public class Minishifter : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Minishifter");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ThrowingKnife);
			AIType = ProjectileID.ThrowingKnife;
			Projectile.DamageType = DamageClass.Throwing;
		}
    }
}
