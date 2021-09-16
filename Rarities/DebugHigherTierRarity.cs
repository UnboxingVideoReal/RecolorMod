using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RecolorMod.Rarities
{
	public class DebugHigherTierRarity : ModRarity
	{
		public override Color RarityColor => new Color(0, 0, 0);

		public override int GetPrefixedRarity(int offset, float valueMult) {
			if (offset < 0) { // If the offset is -1 or -2 (a negative modifier).
				return ModContent.RarityType<DebugRarity>(); // Make the rarity of items that have this rarity with a negative modifier the lower tier one.
			}

			return Type; // no 'higher' tier to go to, so return the type of this rarity.
		}
	}
}
