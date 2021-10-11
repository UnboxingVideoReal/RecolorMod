using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.Config;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.Audio;
using MonoMod.RuntimeDetour.HookGen;
using System.Reflection;
using Terraria.Graphics.Shaders;
using Terraria.Graphics.Effects;

namespace RecolorMod
{
	public class RecolorMod : Mod
	{
		public static RecolorMod ModInstance;
		public static Effect GreenScreenFog;
		public static Texture2D GreenSky;
		public RecolorMod()
		{
			ModInstance = this;
		}
		public override void Load()
		{
			Main.versionNumber = $"Terraria v1.4.1.2\nRecolor Mod v{ModLoader.GetMod("RecolorMod").Version}";

		}
	}
}