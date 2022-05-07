using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;

namespace RecolorMod
{
	public class RecolorMenu : ModMenu
	{
		public static Asset<Texture2D> mainTexture = ModContent.Request<Texture2D>("RecolorMod/Logo");

		public override Asset<Texture2D> Logo => mainTexture;

		public override string DisplayName => "Recolor Mod";

		public override ModSurfaceBackgroundStyle MenuBackgroundStyle => ModContent.GetInstance<Backgrounds.BambiSurfaceBackgroundStyle>();

		public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
		{
			return true;
		}

        public override void OnSelected()
        {
			RecolorUtils.PlayAchievementSound();
        }
    }

	public class RecolorMenu2 : ModMenu
	{
		public static Asset<Texture2D> mainTexture = ModContent.Request<Texture2D>("RecolorMod/Logo2");

		public override Asset<Texture2D> Logo => mainTexture;

		public override string DisplayName => "?";

		public override ModSurfaceBackgroundStyle MenuBackgroundStyle => ModContent.GetInstance<Backgrounds.BambiSurfaceBackgroundStyle>();

		public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
		{
			return true;
		}
	}
}
