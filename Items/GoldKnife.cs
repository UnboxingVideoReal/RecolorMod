using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod.Items
{
	public class GoldKnife : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Golden Knife");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 999;
		}

		public override void SetDefaults() 
		{
			Item.CloneDefaults(ItemID.ThrowingKnife);
			Item.sellPrice(0, 0, 0, 10);
			Item.damage = 20;
			Item.shoot = ModContent.ProjectileType<Projectiles.GoldKnifeProjectile>();
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