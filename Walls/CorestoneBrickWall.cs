using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace RecolorMod.Walls
{
	public class CorestoneBrickWall : ModWall
	{
		public override void SetStaticDefaults() {
			Main.wallHouse[Type] = true;
			DustType = DustID.Lava;
			ItemDrop = ModContent.ItemType<Items.CorestoneBrickWall>();
			AddMapEntry(new Color(208, 58, 40));
		}
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			r = 0.5f;
			g = 0f;
			b = 0f;
		}
	}
}