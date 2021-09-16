using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace RecolorMod.Items
{
    public class BismuthEnchant : ModItem
    {
        //public static int Counter = 1;
        //public static int thing;
        //public static string theString;

        //public static String[] possibleQuotes = new String[]
        //{
        //    "''It sounds really weird and weird'' -blahblahbal 2021",
        //    "''they're not pretty, but they're crunchy and fat'' - pause ghost background person",
        //    "''I'm not a bully, my chicken is scary'' - illuminati background person",
        //    "''it's cool I guess, but it's kinda cool I guess'' - blasfah, 2021",
        //    "''it's not even that funny, why is it funny'' - quibop, 2021",
        //    "''Why do I have a tentacle attached to me?'' -blahblahbal 2021",
        //    "''Hey guys i ‫(edited) this message'' - Geo 2021",
        //    "''no heck you'' -quibop 2021",
        //    "***Hey*** baby * ~~:chain:~~ ‫ (edited)jjj",
        //    "''i am currently looking for the corruption so i can find the corruption'' -ennway 2021"
        //};
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Enchantment");
            Tooltip.SetDefault(
@$"Summons Bismuth Tool familiars that scales with minion damage
+5 minion slots
+10% summon damage
'It's a bit too blue.'");
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(0, 0, 255);
                }
            }
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = ModContent.RarityType<Rarities.UltraBlueRarity>();
            Item.value = Item.sellPrice(300, 500, 900, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 5;
            player.GetDamage(DamageClass.Summon) += 0.1f;
            player.GetModPlayer<RecolorPlayer>().BismuthEffect();
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient<UnboxingEssence>(50)
            .AddIngredient<Items.Aquamarine>(1700)
            .AddIngredient<ColoriteBar>(500)
            .AddTile<Tiles.BismuthForge>()
            .Register();
        }
    }
}
