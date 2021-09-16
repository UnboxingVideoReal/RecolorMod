using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace RecolorMod.Items
{
	public class BismuthAxe : ModItem
	{
		public override void SetStaticDefaults() {
			//Tooltip.SetDefault("This is a modded hamaxe.");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.damage = 25;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ModContent.RarityType<Rarities.UltraBlueRarity>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true; // Automatically re-swing/re-use this item after its swinging animation is over.

			Item.axe = 400; //How much axe power the weapon has, note that the axe power displayed in-game is this value multiplied by 5
		}

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<BismuthBar>(20)
				.AddIngredient<Aquamarine>(1)
                .AddTile<Tiles.BismuthForge>()
                .Register();
        }
    }
}
