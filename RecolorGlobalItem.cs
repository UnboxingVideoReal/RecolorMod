using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace RecolorMod
{
    public class RecolorGlobalItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (RecolorPlayer.doItemStuff)
            {
                item.scale *= 2f;
            }
        }
        public override void UpdateInventory(Item item, Player player)
        {
            if (player.HasItem(ModContent.ItemType<Items.Debug.PlayerXY>()))
            {
                RecolorPlayer.playerX = true;
                RecolorPlayer.playerY = true;
            }
        }
    }
}
