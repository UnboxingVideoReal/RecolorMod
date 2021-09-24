using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace RecolorMod.Tiles
{
	public class BismuthForgeTile : ModTile
	{
		public override void SetStaticDefaults() {
			// Properties
			AnimationFrameHeight = 38;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			DustType = DustID.Cobalt;
			AdjTiles = new int[] { TileID.LunarCraftingStation };
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Bismuth Forge");
			AddMapEntry(Color.Cyan, name);
		}

		public override void NumDust(int x, int y, bool fail, ref int num) => num = fail ? 1 : 3;

		public override void KillMultiTile(int x, int y, int frameX, int frameY) {
			Item.NewItem(x * 16, y * 16, 32, 16, ModContent.ItemType<Items.BismuthForge>());
		}
	}
}