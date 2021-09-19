using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod.Items
{
	public class Wetwood : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Wetwood");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 999;
		}

		public override void SetDefaults() 
		{
			Item.autoReuse = true;
			Item.consumable = true;
            //Item.createTile = ModContent.TileType<Tiles.Coughwood>();
            Item.width = 24;
			Item.useTurn = true;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.maxStack = 999;
			Item.useAnimation = 15;
			Item.height = 22;
		}

		//public override void AddRecipes() 
		//{
		//	Recipe recipe = CreateRecipe();
		//	recipe.AddIngredient(ItemID.DirtBlock, 10);
		//	recipe.AddTile(TileID.WorkBenches);
		//	recipe.Register();
		//}
	}
}