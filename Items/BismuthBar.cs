using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace RecolorMod.Items
{
	public class BismuthBar : ModItem
	{
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 100; // Influences the inventory sort order. 59 is PlatinumBar, higher is more valuable.
		}

		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 20000; // The cost of the item in copper coins. (1 = 1 copper, 100 = 1 silver, 1000 = 1 gold, 10000 = 1 platinum)
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.rare = ModContent.RarityType<Rarities.UltraBlueRarity>();
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.BismuthBar>(); // The ID of the wall that this item should place when used. ModContent.TileType<T>() method returns an integer ID of the wall provided to it through its generic type argument (the type in angle brackets)..
			Item.placeStyle = 0;
		}
		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<BismuthOre>(8)
				.AddIngredient<Aquamarine>(2)
				.AddTile<Tiles.BismuthForge>()
				.Register();
		}
	}
}
