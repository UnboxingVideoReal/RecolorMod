using System;
using RecolorMod;
using RecolorMod.Tiles;
using Terraria.ModLoader;

namespace RecolorMod.Common.Systems
{
	public class bambiTC : ModSystem
	{
		public int bambiBC;

		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts) {
			bambiBC = tileCounts[ModContent.TileType<BambiGrass>()] + tileCounts[ModContent.TileType<Bambistone>()];
		}
	}
}
