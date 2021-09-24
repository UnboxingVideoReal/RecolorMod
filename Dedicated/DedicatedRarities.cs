using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace RecolorMod.Dedicated
{
	public class Quibop : ModRarity
	{
		public override Color RarityColor => new Color(0.34f + 0.66f * (float)Main.DiscoR / 255f, 255, 0);
	}

	public class Blah : ModRarity
	{
		public override Color RarityColor => RecolorUtils.ColorSwap(new Color(221, 221, 221), new Color(252, 66, 0), 4f);
	}
}
