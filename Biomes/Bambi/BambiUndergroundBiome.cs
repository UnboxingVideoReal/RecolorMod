using RecolorMod.Common.Systems;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod.Biomes.Bambi
{
    public class BambiUndergroundBiome : ModBiome
    {
        public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("RecolorMod/BambiWaterStyle");
        public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.Find<ModUndergroundBackgroundStyle>("RecolorMod/BambiUndergroundBackgroundStyle");

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/UndergroundBambiome"); //Mod.GetSoundSlot(SoundType.Music, "Assets/Sounds/Music/41_UndergroundContagion.ogg");

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow;

        public override string BestiaryIcon => base.BestiaryIcon;
        public override string BackgroundPath => base.BackgroundPath; // ExxoAvalonOrigins.AssetPath + "Textures/Bestiary/UndergroundContagionBackgroundBestiary.png"
        public override Color? BackgroundColor => Color.Lime;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Underground Bambiome");
        }

        public override bool IsBiomeActive(Player player)
        {
            return (player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight) &&
                ModContent.GetInstance<bambiTC>().bambiBC >= 200;
            //Math.Abs(player.position.ToTileCoordinates().X - Main.maxTilesX / 2) < Main.maxTilesX / 6;
        }
        public override float GetWeight(Player player)
        {
            int distanceToCenter = Math.Abs(player.position.ToTileCoordinates().X - Main.maxTilesX / 2);
            if (distanceToCenter <= Main.maxTilesX / 12)
            {
                return 1f;
            }
            else
            {
                return 1f - (distanceToCenter - Main.maxTilesX / 12) / (Main.maxTilesX / 12);
            }
        }
    }
}
