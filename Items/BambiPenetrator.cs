using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.GameContent.Creative;

namespace RecolorMod.Items
{
    public class BambiPenetrator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bambi Penetrator");
            Tooltip.SetDefault("Increases armor penetration by a lot");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = ModContent.RarityType<Rarities.Bambi>();
            Item.value = Item.sellPrice(900, 900, 900, 900);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.armorPenetration += int.MaxValue - 10000; 
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient<UnboxingEssence>(100)
            .AddIngredient(ItemID.SharkToothNecklace)
            .AddIngredient<Developer.UnboxingBar>(1000)
            .AddIngredient<phone>()
            .AddTile<Tiles.BismuthForgeTile>()
            .Register();
        }
    }
}
