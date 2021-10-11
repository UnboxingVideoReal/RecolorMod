using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RecolorMod.Biomes.Bambi
{
    public class BambiWaterStyle : ModWaterStyle
    {
        public override int ChooseWaterfallStyle() => Find<ModWaterfallStyle>("RecolorMod/BambiWaterfallStyle").Slot;

        public override int GetSplashDust() => DustID.GreenFairy;

        public override int GetDropletGore() => GoreID.WaterDripJungle;

        //public override void LightColorMultiplier(ref float r, ref float g, ref float b) {
        //	r = 255f;
        //	g = 0f;
        //	b = 255f;
        //}

        public override Color BiomeHairColor()
            => Color.Green;
    }
}