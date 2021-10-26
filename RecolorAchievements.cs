using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Chat;
using Terraria.ModLoader;

namespace RecolorMod
{
    public class RecolorAchievements 
    {
        public static bool achievementActive = true; 
        public static void AwardAchievement(string name, string tooltip, Color textColor, string stuffs)
        {
            if (achievementActive)
            {
                RecolorUtils.DisplayLocalizedText($"[c/{Main.OurFavoriteColor.Hex3()}:{Main.player[Main.myPlayer].name}] {stuffs} [c/{textColor.Hex3()}:{name}]!\n''{tooltip}''");
                RecolorUtils.PlayAchievementSound();
                achievementActive = false;
            }
        }
    }
}
