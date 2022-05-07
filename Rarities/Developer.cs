using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RecolorMod.Rarities
{
	public class Developer : ModRarity
	{
		public override Color RarityColor => Color.Lerp(new Color(0, 255, 200), new Color(204, 71, 35), RecolorUtils.Wave(Main.GlobalTimeWrappedHourly * 10f, 0f, 1f));
	}
}
