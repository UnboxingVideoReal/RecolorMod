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

	public class Torra : ModRarity
	{
		public override Color RarityColor => RecolorUtils.ColorSwap(new Color(0, 15, 40), new Color(255, 255, 0), 4f);
	}

	public class Geo : ModRarity
	{
		public override Color RarityColor => RecolorUtils.ColorSwap(new Color(255, 163, 0), new Color(0, 255, 19), 4f);
	}

	public class Omega : ModRarity
	{
		public override Color RarityColor => RecolorUtils.QuadColorSwap(new Color(0, 242, 170), new Color(254, 126, 229), new Color(254, 158, 35), new Color(0, 174, 238)/*, 4f*/);
	}

	public class TrueDedicated : ModRarity
	{
        public override Color RarityColor
        {
            get
            {
                return RecolorUtils.QuintColorSwap(ModContent.GetInstance<Quibop>().RarityColor, ModContent.GetInstance<Blah>().RarityColor, ModContent.GetInstance<Torra>().RarityColor, ModContent.GetInstance<Geo>().RarityColor, ModContent.GetInstance<Omega>().RarityColor );
            }
        }
    }
}
