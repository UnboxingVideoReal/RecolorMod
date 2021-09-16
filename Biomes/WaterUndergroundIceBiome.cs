//using ExxoAvalonOrigins.Common.Systems;
//using Microsoft.Xna.Framework.Graphics;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

//namespace ExxoAvalonOrigins.Biomes
//{
//	public class ContagionUndergroundIceBiome : ModBiome
//	{
//		public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("ExxoAvalonOrigins/ContagionWaterStyle");
//		public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.Find<ModUndergroundBackgroundStyle>("ExxoAvalonOrigins/ContagionUndergroundIceBackgroundStyle");

//		public override int Music => MusicID.Ice; //Mod.GetSoundSlot(SoundType.Music, "Assets/Sounds/Music/41_UndergroundContagion.ogg");

//		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

//		//public override string BestiaryIcon => ExxoAvalonOrigins.AssetPath + "Textures/Bestiary/ContagionBestiary.png";
//		//public override string BackgroundPath => base.BackgroundPath; // ExxoAvalonOrigins.AssetPath + "Textures/Bestiary/UndergroundContagionBackgroundBestiary.png"
//		//public override Color? BackgroundColor => Color.Lime;

//		//public override void SetStaticDefaults() {
//		//	DisplayName.SetDefault("Underground Contagion");
//		//}

//		public override bool IsBiomeActive(Player player) {
//			return (player.ZoneSnow /*&& player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight*/) &&
//				ModContent.GetInstance<ickyTileCount>().ickyBlockCount >= 200; 
//				//Math.Abs(player.position.ToTileCoordinates().X - Main.maxTilesX / 2) < Main.maxTilesX / 6;
//		}
//		//public override float GetWeight(Player player) {
//		//	int distanceToCenter = Math.Abs(player.position.ToTileCoordinates().X - Main.maxTilesX / 2);
//		//	if (distanceToCenter <= Main.maxTilesX / 12) {
//		//		return 1f;
//		//	}
//		//	else {
//		//		return 1f - (distanceToCenter - Main.maxTilesX / 12) / (Main.maxTilesX / 12);
//		//	}
//		//}
//	}
//}
