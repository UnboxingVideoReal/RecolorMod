using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using RecolorMod.Tiles;
using RecolorMod.Items.Developer;
using Terraria.GameContent.Creative;

namespace RecolorMod.Dedicated.Items.TorraStuff
{
    public class StarKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Key");
            Tooltip.SetDefault("Summons a star car\nIs this the real?");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            RecolorUtils.DedicatedItemStuff(tooltips);
        }

        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 18;
            Item.noMelee = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.buyPrice(2);
            Item.rare = ModContent.RarityType<Dedicated.Torra>();
            Item.mountType = ModContent.MountType<StarCar>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FallenStar, 500)
                .AddIngredient<OmegaFragment>(500)
                .AddIngredient<UnboxingBar>(100)
                .AddIngredient(ItemID.CorruptionKey)
                .AddIngredient(ItemID.CosmicCarKey)
                .AddIngredient(ItemID.CrimsonKey)
                .AddIngredient(ItemID.JungleKey)
                .AddIngredient(ItemID.HallowedKey)
                .AddIngredient(ItemID.DungeonDesertKey)
                .AddIngredient(ItemID.TempleKey)
                .AddIngredient(ItemID.FrozenKey)
                .AddTile<BismuthForgeTile>()
                .Register();
        }
    }
}
