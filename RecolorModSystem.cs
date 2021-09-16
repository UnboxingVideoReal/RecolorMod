using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RecolorMod;
using Terraria.WorldBuilding;

namespace RecolorMod
{
	public class RecolorModSystem : ModSystem
	{
        public int gbvStyle;
        public static int gbvR = 160;
        public static int gbvG = 0;
        public static int gbvB = 0;
        public override void PostUpdateEverything()
        {
            if (gbvStyle == 0)
            {
                gbvR -= 5;
                if (gbvR <= 0)
                {
                    gbvR = 0;
                    gbvStyle = 1;
                }
            }
            if (gbvStyle == 1)
            {
                gbvG += 5;
                if (gbvG >= 255)
                {
                    gbvG = 255;
                }
                if (gbvG >= 160)
                {
                    gbvB -= 5;
                    if (gbvB <= 0)
                    {
                        gbvB = 0;
                        gbvStyle = 2;
                    }
                }
            }
            if (gbvStyle == 2)
            {
                gbvG -= 5;
                if (gbvG <= 0)
                {
                    gbvG = 0;
                }
                if (gbvG <= 160)
                {
                    gbvB += 5;
                    if (gbvB >= 255)
                    {
                        gbvB = 255;
                        gbvStyle = 3;
                    }
                }
            }
            if (gbvStyle == 3)
            {
                gbvR += 5;
                if (gbvR >= 160)
                {
                    gbvR = 160;
                    gbvStyle = 0;
                }
            }
        }
    }
}
