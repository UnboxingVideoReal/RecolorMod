using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod.Items
{
	public class CopperKnife : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("CopperKnife"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			//Tooltip.SetDefault("This is a basic modded sword.");
		}

		public override void SetDefaults() 
		{
			Item.CloneDefaults(ItemID.ThrowingKnife);
			Item.sellPrice(0, 0, 0, 10);
			Item.damage = 15;
			Item.shoot = ModContent.ProjectileType<Projectiles.CopperKnifeProjectile>();
			Item.DamageType = DamageClass.Throwing;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CopperBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}