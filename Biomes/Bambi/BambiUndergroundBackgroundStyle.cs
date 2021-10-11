using Terraria.ModLoader;

namespace RecolorMod.Backgrounds
{
    public class BambiUndergroundBackgroundStyle : ModUndergroundBackgroundStyle
    {
        public override void FillTextureArray(int[] textureSlots)
        {
            textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot("RecolorMod/Backgrounds/BambiUnderground0");
            textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot("RecolorMod/Backgrounds/BambiUnderground1");
            textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot("RecolorMod/Backgrounds/BambiUnderground3");
            textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot("RecolorMod/Backgrounds/BambiUnderground2");
        }
    }
}