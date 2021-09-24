﻿using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace RecolorMod.Items
{
	public class Aquamarine : ModItem
	{
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 15;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 60; // Influences the inventory sort order. 59 is PlatinumBar, higher is more valuable.
		}

		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 22;
			Item.maxStack = 999;
			Item.value = 1000; // The cost of the item in copper coins. (1 = 1 copper, 100 = 1 silver, 1000 = 1 gold, 10000 = 1 platinum)
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Cyan;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.AquamarineTile>(); // The ID of the wall that this item should place when used. ModContent.TileType<T>() method returns an integer ID of the wall provided to it through its generic type argument (the type in angle brackets)..
			Item.placeStyle = 0;
		}
		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		//public override void AddRecipes() {
		//	CreateRecipe()
		//		.AddIngredient<BismuthOre>(8)
		//		.AddTile(TileID.Furnaces)
		//		.Register();
		//}
	}
}
