using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace RecolorMod.Tiles
{
	public class UnboxingOre : ModTile
	{
		public override void SetStaticDefaults() {
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileOreFinderPriority[Type] = 600; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileShine2[Type] = true; // Modifies the draw color slightly.
/*			Main.tileShine[Type] = 975; */// How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Unboxite");
			AddMapEntry(new Color(0, 0, 0), name);

			DustType = DustID.Asphalt;
			//ItemDrop = ModContent.ItemType<Items.Huetite>();
			SoundType = SoundID.Tink;
			SoundStyle = 1;
            MineResist = 15f;
            MinPick = 410;
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
			RecolorUtils.ColorTile(i, j, "RecolorMod/Tiles/Developer/UnboxingOre", "RecolorMod/Tiles/Developer/UnboxingOre_Dirt", new Color(Main.DiscoR, 0, Main.DiscoB));
   //         Tile tile = Main.tile[i, j];
   //         Texture2D texture;
   //         //if (Main.canDrawColorTile(i, j))
   //         //{
   //         texture = ModContent.Request<Texture2D>("RecolorMod/Tiles/Huetite").Value;
   //         //}
   //         //else
   //         //{
   //         //	texture = Textur;
   //         //}
   //         Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
   //         if (Main.drawToScreen)
   //         {
   //             zero = Vector2.Zero;
   //         }
   //         Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, 16), new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);

			//Texture2D texture2 = ModContent.Request<Texture2D>("RecolorMod/Tiles/Huetite_Dirt").Value;
   //         Main.spriteBatch.Draw(texture2, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, 16), Color.White, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        }
    }
}