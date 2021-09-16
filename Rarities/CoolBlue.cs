using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace RecolorMod.Rarities
{
	public class CoolBlue : ModRarity
	{
		//public int randomColor = Main.rand.Next(1, 18);
		public override Color RarityColor => new Color(RecolorModSystem.gbvR, RecolorModSystem.gbvG, RecolorModSystem.gbvB);


		//public override int GetPrefixedRarity(int offset, float valueMult) {
		//	if (offset > 0) { // If the offset is 1 or 2 (a positive modifier).
		//		return ModContent.RarityType<AllHigherTier>(); // Make the rarity of items that have this rarity with a positive modifier the higher tier one.
		//	}

		//	return Type; // no 'lower' tier to go to, so return the type of this rarity.
		//}
	}
}
