using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod.Items
{
	public class MinishifterTEST : ModItem
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("test");
		}

		public override void SetDefaults() 
		{
			Item.CloneDefaults(ItemID.ThrowingKnife);
			Item.sellPrice(0, 0, 0, 10);
			Item.damage = 20;
			Item.shoot = ModContent.ProjectileType<Projectiles.Summons.Minishifter>();
			Item.DamageType = DamageClass.Throwing;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}