using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace RecolorMod.Tiles
{
	public class CorestoneBrick : ModTile
	{
		public override void SetStaticDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileBlendAll[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileMerge[TileID.Ash][Type] = true;
			Main.tileMerge[Type][TileID.Ash] = true;
			Main.tileLighted[Type] = true;
			SoundType = SoundID.Tink;
			DustType = DustID.Lava;
			ItemDrop = ModContent.ItemType<Items.CorestoneBrick>();
			AddMapEntry(new Color(237, 64, 53));
			// todo: implement
			// SetModTree(new Trees.ExampleTree());
		}
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			r = 0.5f;
			g = 0f;
			b = 0f;
		}
	}
}