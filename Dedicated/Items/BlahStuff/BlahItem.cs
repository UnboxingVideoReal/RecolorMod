using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using RecolorMod.Items.Developer;
using RecolorMod.Items;
using RecolorMod.Tiles;

namespace RecolorMod.Dedicated.Items.BlahStuff
{
    public class BlahItem : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quibop's Knife");
            Tooltip.SetDefault("Critical Chance increased by 100\nRight-Click to shoot a barrage of knives");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            RecolorUtils.DedicatedItemStuff(tooltips);
        }
        public override void SetDefaults()
        {
            Item.damage = 151000;
            Item.crit += 100;
            Item.DamageType = ModContent.GetInstance<DedicatedClass>();
            Item.width = 30;
            Item.height = 32;
            Item.useTime = 1;
            Item.useAnimation = 3;
            Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 10f;
            Item.value = Item.buyPrice(1, 95);
            Item.rare = ModContent.RarityType<Dedicated.Blah>();
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<BlahBar>(50)
                .AddIngredient<OmegaFragment>(100)
                .AddIngredient(ItemID.ChainKnife)
                .AddIngredient(ItemID.FlyingKnife)
                .AddIngredient(ItemID.PoisonedKnife, 500)
                .AddIngredient(ItemID.PsychoKnife)
                .AddIngredient(ItemID.ShadowFlameKnife)
                .AddIngredient(ItemID.ThrowingKnife, 500)
                .AddTile<BismuthForgeTile>()
                .Register();
        }
    }
}
