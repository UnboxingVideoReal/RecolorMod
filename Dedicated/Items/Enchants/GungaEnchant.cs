using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using RecolorMod.Tiles;
using Terraria.GameContent.Creative;
using RecolorMod.Classes;

namespace RecolorMod.Dedicated.Items.Enchants
{
    public class GungaEnchant : ModItem
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
            DisplayName.SetDefault("Gunga Enchantment");
            Tooltip.SetDefault(
@$"Gunga Bombs will orbit around you
+300 and x3 max health
+50% [c/{RecolorUtils.ClericColor.Hex3()}:cleric] damage
'ok'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //public override void ModifyTooltips(List<TooltipLine> tooltips)
        //{
        //    foreach (TooltipLine tooltipLine in tooltips)
        //    {
        //        if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
        //        {
        //            tooltipLine.overrideColor = new Color(0, 0, 255);
        //        }
        //    }
        //}
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = ModContent.RarityType<Gunga>();
            Item.value = Item.sellPrice(500, 500, 900, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 300;
            player.statLifeMax2 *= 3;
            player.GetDamage<ClericClass>() += 0.5f;
            player.GetModPlayer<RecolorPlayer>().GungaEnchant();
        }
        //public override void AddRecipes()
        //{
        //    CreateRecipe()
        //    .AddIngredient<BlahStuff.BlahBar>(100)
        //    .AddIngredient<BlahStuff.BlahItem>()
        //    .AddTile<BismuthForgeTile>()
        //    .Register();
        //}
    }
}
