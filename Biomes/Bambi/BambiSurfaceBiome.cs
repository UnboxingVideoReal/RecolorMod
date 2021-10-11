using RecolorMod.Common.Systems;
using Microsoft.Xna.Framework;
using System;
using RecolorMod;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Assets;
using Microsoft.Xna.Framework.Graphics;

namespace RecolorMod.Biomes.Bambi
{
    public class BambiSurfaceBiome : ModBiome
    {
        public override bool IsPrimaryBiome => true;
        public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("RecolorMod/BambiWaterStyle"); // Sets a water style for when inside this biome
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("RecolorMod/BambiSurfaceBackgroundStyle");
        public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Normal;

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/BambiomeSurface"); // Mod.GetSoundSlot(SoundType.Music, "Assets/Sounds/Music/34_Contagion.ogg");

        public override string BestiaryIcon => base.BestiaryIcon;
        public override string BackgroundPath => base.BackgroundPath;
        public override Color? BackgroundColor => Color.Green;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Bambiome");
        }
        public override bool IsBiomeActive(Player player)
        {
            bool b1 = ModContent.GetInstance<bambiTC>().bambiBC >= 200;
            //bool b2 = Math.Abs(player.position.ToTileCoordinates().X - Main.maxTilesX / 2) < Main.maxTilesX / 6;
            bool b3 = player.ZoneSkyHeight || player.ZoneOverworldHeight;
            return b1 && b3;
        }
    }
}
