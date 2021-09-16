//using ExxoAvalonOrigins.Dusts;
//using Microsoft.Xna.Framework;
//using Terraria.ModLoader;
//using static Terraria.ModLoader.ModContent;

//namespace ExxoAvalonOrigins.Biomes
//{
//	public class ContagionWaterStyle : ModWaterStyle
//	{
//		public override int ChooseWaterfallStyle() => Find<ModWaterfallStyle>("ExxoAvalonOrigins/ContagionWaterfallStyle").Slot;

//		public override int GetSplashDust() => DustType<ContagionWaterSplash>();

//		public override int GetDropletGore() => Find<ModGore>("ExxoAvalonOrigins/Contagion_Droplet").Type;

//		//public override void LightColorMultiplier(ref float r, ref float g, ref float b) {
//		//	r = 255f;
//		//	g = 0f;
//		//	b = 255f;
//		//}

//		public override Color BiomeHairColor()
//			=> Color.Lime;
//	}
//}