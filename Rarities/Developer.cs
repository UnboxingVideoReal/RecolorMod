using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RecolorMod.Rarities
{
	public class Developer : ModRarity
	{
		public override Color RarityColor => RecolorUtils.ColorSwap(new Color(0, 255, 200), new Color(204, 71, 35), 4f);
	}
}
