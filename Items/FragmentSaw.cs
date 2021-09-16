using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod.Items
{
	public class FragmentSaw : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("CopperKnife"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			//Tooltip.SetDefault("This is a basic modded sword.");
		}

		public override void SetDefaults() 
		{
			Item.sellPrice(1, 3, 5, 10);
			Item.damage = 7532;
			Item.shootSpeed = 25;
			Item.useTime = 12;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.rare = ItemRarityID.Master;
			Item.width = 54;
			Item.height = 56;
			Item.shoot = ModContent.ProjectileType<Projectiles.FragmentSawProjectile>();
			Item.DamageType = DamageClass.Ranged;
		}

		//public override void AddRecipes() 
		//{
		//	Recipe recipe = CreateRecipe();
		//	recipe.AddIngredient(ItemID.CopperBar, 1);
		//	recipe.AddTile(TileID.Anvils);
		//	recipe.Register();
		//}
	}
}