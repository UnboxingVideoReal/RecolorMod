using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RecolorMod.Rarities
{
	public class Developer : ModRarity
	{
		public override Color RarityColor => new Color(Main.DiscoR, 0, Main.DiscoB);
	}
}
