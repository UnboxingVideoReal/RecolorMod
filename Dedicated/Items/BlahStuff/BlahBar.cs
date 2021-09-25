using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using RecolorMod.Items.Developer;
using RecolorMod.Items;

namespace RecolorMod.Dedicated.Items.BlahStuff
{
    public class BlahBar : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blahr");
            Tooltip.SetDefault("''");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            RecolorUtils.DedicatedItemStuff(tooltips);
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.useTime = 1;
            Item.useAnimation = 3;
            Item.useTurn = true;
            Item.maxStack = 99;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.buyPrice(2);
            Item.rare = ModContent.RarityType<Dedicated.Blah>();
            Item.autoReuse = true;
            Item.createTile = ModContent.TileType<Tiles.Blah.BlahBarTile>();
        }

        //public override void AddRecipes()
        //{
        //    CreateRecipe()
        //        .AddIngredient<BlahBar>(50)
        //        .AddIngredient<AquamarineTile>(100)
        //        .AddIngredient(ItemID.ChainKnife)
        //        .AddIngredient(ItemID.FlyingKnife)
        //        .AddIngredient(ItemID.PoisonedKnife, 500)
        //        .AddIngredient(ItemID.PsychoKnife)
        //        .AddIngredient(ItemID.ShadowFlameKnife)
        //        .AddIngredient(ItemID.ThrowingKnife, 500)
        //        .AddTile<Tiles.BismuthForgeTile>()
        //        .Register();
        //}

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D glowmaskTexture = ModContent.Request<Texture2D>("RecolorMod/Dedicated/Items/Blah/BlahBar_Glow").Value;
            spriteBatch.Draw(origin: new Vector2((float)glowmaskTexture.Width / 2f, (float)glowmaskTexture.Height / 2f - 2f), texture: glowmaskTexture, position: Item.Center - Main.screenPosition, sourceRectangle: null, color: Color.White, rotation: rotation, scale: 1f, effects: SpriteEffects.None, layerDepth: 0f);
        }
    }
}
