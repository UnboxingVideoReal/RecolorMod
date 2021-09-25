using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace RecolorMod.Dedicated.Tiles.Blah
{
	public class BlahBarTile : ModTile
	{
		public override void SetStaticDefaults() {
			Main.tileShine[Type] = 1100;
			Main.tileSolid[Type] = true;
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);

			AddMapEntry(RecolorUtils.ColorSwap(new Color(221, 221, 221), new Color(252, 66, 0), 4f), Language.GetText("MapObject.MetalBar")); // localized text for "Metal Bar"
		}

		public override bool Drop(int i, int j) {
			Tile t = Main.tile[i, j];
			int style = t.frameX / 18;
			if (style == 0) // It can be useful to share a single tile with multiple styles. This code will let you drop the appropriate bar if you had multiple.
			{
				Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Dedicated.Items.BlahStuff.BlahBar>());
			}

			return base.Drop(i, j);
		}

        public override bool HasSmartInteract()
        {
            return false;
        }

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
            Tile tile = Main.tile[i, j];
            Texture2D texture;
            //if (Main.canDrawColorTile(i, j))
            //{
            texture = ModContent.Request<Texture2D>("RecolorMod/Dedicated/Tiles/Blah/BlahBarTile_Glow").Value;
            //}
            //else
            //{
            //	texture = Textur;
            //}
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, 16), Color.White, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        }
	}
}