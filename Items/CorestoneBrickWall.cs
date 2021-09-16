using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace RecolorMod.Items
{
	public class CorestoneBrickWall : ModItem
	{
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
		}

		public override void SetDefaults() {
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 7;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createWall = ModContent.WallType<Walls.CorestoneBrickWall>(); // The ID of the wall that this Item should place when used. ModContent.WallType<T>() method returns an integer ID of the wall provided to it through its generic type argument (the type in angle brackets).

		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		//public override void AddRecipes() {
		//	CreateRecipe(4)
		//		.AddIngredient<ExampleBlock>()
		//		.AddTile<ExampleWorkbench>()
		//		.Register();
		//}
	}
}
