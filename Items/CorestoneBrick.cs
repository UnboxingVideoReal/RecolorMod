using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace RecolorMod.Items
{
	public class CorestoneBrick : ModItem
	{
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
		}

		public override void SetDefaults() {
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.CorestoneBrick>();
		}
		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		//public override void AddRecipes() {
		//	CreateRecipe(10)
		//		.AddIngredient<ExampleItem>()
		//		.AddTile<Tiles.Furniture.ExampleWorkbench>()
		//		.Register();

		//	CreateRecipe() // Add multiple recipes set to one Item.
		//		.AddIngredient<ExampleWall>(4)
		//		.AddTile<Tiles.Furniture.ExampleWorkbench>()
		//		.Register();

		//	CreateRecipe()
		//		.AddIngredient<ExamplePlatform>(2)
		//		.AddTile<Tiles.Furniture.ExampleWorkbench>()
		//		.Register();
		//}
	}
}
