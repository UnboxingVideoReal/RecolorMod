using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace RecolorMod.Rarities
{
	public class DropletRarity : ModRarity
	{
		public override Color RarityColor => RecolorUtils.ColorSwap(new Color(93, 173, 236), new Color(255, 126, 203), 4f);
	}
}
