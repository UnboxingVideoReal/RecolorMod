using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace RecolorMod.Rarities
{
	public class Bambi : ModRarity
	{
		public override Color RarityColor => RecolorUtils.ColorSwap(new Color(0, 255, 0), new Color(255, 0, 55), 4f);
	}
}
