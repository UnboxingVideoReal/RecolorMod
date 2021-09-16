//using ExxoAvalonOrigins.Common.Systems;
//using Microsoft.Xna.Framework;
//using System;
//using ExxoAvalonOrigins;
//using Terraria;
//using Terraria.Graphics.Capture;
//using Terraria.ID;
//using Terraria.ModLoader;
//using Terraria.ModLoader.Assets;
//using Microsoft.Xna.Framework.Graphics;

//namespace ExxoAvalonOrigins.Biomes
//{
//	public class WaterSurfaceBiome : ModBiome
//	{
//		public override bool IsPrimaryBiome => true;
//		public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("ExxoAvalonOrigins/ContagionWaterStyle"); // Sets a water style for when inside this biome
//		public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("ExxoAvalonOrigins/ContagionSurfaceBackgroundStyle");
//		public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Crimson;

//		public override int Music => MusicID.OtherworldlyCrimson; // Mod.GetSoundSlot(SoundType.Music, "Assets/Sounds/Music/34_Contagion.ogg");

//		public override string BestiaryIcon => base.BestiaryIcon;
//		public override string BackgroundPath => base.BackgroundPath;
//		public override Color? BackgroundColor => Color.Lime;

//        public override void SetStaticDefaults() {
//			DisplayName.SetDefault("The Contagion");
//		}
//		public override bool IsBiomeActive(Player player) {
//			bool b1 = ModContent.GetInstance<ickyTileCount>().ickyBlockCount >= 200;
//			//bool b2 = Math.Abs(player.position.ToTileCoordinates().X - Main.maxTilesX / 2) < Main.maxTilesX / 6;
//			bool b3 = player.ZoneSkyHeight || player.ZoneOverworldHeight;
//			return b1 && b3;
//		}
//	}
//}
