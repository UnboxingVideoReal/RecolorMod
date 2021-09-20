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
}
