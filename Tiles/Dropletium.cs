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
	public class Dropletium : ModTile
	{
		public override void SetStaticDefaults() {
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileOreFinderPriority[Type] = 450; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileShine2[Type] = true; // Modifies the draw color slightly.
			/*			Main.tileShine[Type] = 975; */// How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMerge[Type][TileID.Sand] = true;
			Main.tileMerge[TileID.Sand][Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Dropletium");
			AddMapEntry(ModContent.GetInstance<Rarities.DropletRarity>().RarityColor, name);

			DustType = DustID.Water;
			ItemDrop = ModContent.ItemType<Items.DropletiumOre>();
			SoundType = SoundID.Tink;
			SoundStyle = 1;
            MineResist = 15f;
            MinPick = 690;
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
			RecolorUtils.ColorTile(i, j, "RecolorMod/Tiles/Dropletium", "RecolorMod/Tiles/Dropletium_Dirt", ModContent.GetInstance<Rarities.DropletRarity>().RarityColor);
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

	public class DropletiumOreSystem : ModSystem
	{
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

			if (ShiniesIndex != -1)
			{
				tasks.Insert(ShiniesIndex + 1, new DropletiumOrePass("Dropletium Ore", 237.4298f));
			}
		}
	}

	public class DropletiumOrePass : GenPass
	{
		public DropletiumOrePass(string name, float loadWeight) : base(name, loadWeight)
		{
		}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
		{
			progress.Message = "Dropletium Ore";
			for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
			{
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)Main.maxTilesY - 200, (int)Main.worldSurface);
				Tile tile = Framing.GetTileSafely(x, y);
				if (tile.HasTile && tile.TileType == LiquidID.Water)
				{
					WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<Dropletium>());
				}
			}
		}
	}
	//public class DropletiumOreSystem : ModSystem
	//{
	//    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
	//    {
	//        // Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

	//        // The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
	//        // First, we find out which step "Shinies" is.
	//        int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

	//        if (ShiniesIndex != -1)
	//        {
	//            // Next, we insert our pass directly after the original "Shinies" pass. 
	//            // ExampleOrePass is a class seen bellow
	//            tasks.Insert(ShiniesIndex + 1, new CinnabarOrePass("Cinnabar Ore", 237.4298f));
	//        }
	//    }
	//}

	//public class DropletiumOrePass : GenPass
	//{
	//    public DropletiumOrePass(string name, float loadWeight) : base(name, loadWeight)
	//    {
	//    }

	//    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	//    {
	//        progress.Message = "Dropletium";
	//        for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 0.0006); i++)
	//        {
	//            WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX - 150), WorldGen.genRand.Next(Main.maxTilesY, Main.maxTilesY), WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 5), (ushort)ModContent.TileType<Dropletium>());
	//        }
	//    }
	//}
}