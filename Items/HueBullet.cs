using Terraria;
using Terraria.ID;
using RecolorMod;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace RecolorMod.Items
{
	// This Example class demonstrates how to make your own weapon ammo.
	// Used by ExampleCustomAmmoGun
	public class HueBullet : ModItem
	{
		public override void SetStaticDefaults() {
			/*Tooltip.SetDefault("Creates 2 clones of itself when shot");*/ // The Item's description, can be set to whatever you want.
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 999;
		}

		public override void SetDefaults() {
			Item.width = 8; // The width of Item hitbox
			Item.height = 8; // The height of Item hitbox

			Item.damage = 1000; // The damage for projectiles isn't actually 8, it actually is the damage combined with the projectile and the Item together
			Item.DamageType = DamageClass.Ranged; // What type of damage does this ammo affect?
			
			Item.maxStack = 99999; // The maximum number of items that can be contained within a single stack
			Item.consumable = true; // This marks the Item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible
			Item.knockBack = 2f; // Sets the Item's knockback. Ammunition's knockback added together with weapon and projectiles.
			Item.value = Item.sellPrice(1, 0, 0, 0); // Item price in copper coins (can be converted with Item.sellPrice/Item.buyPrice)
			Item.rare = ItemRarityID.Expert; // The color that the Item's name will be in-game.
			Item.shoot = ModContent.ProjectileType<Projectiles.HueBulletProjectile>(); // The projectile that weapons fire when using this Item as ammunition.
			
			Item.ammo = AmmoID.Bullet; // Important. The first Item in an ammo class sets the AmmoID to its type
		}

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        // Here we create recipe for 999/ExampleCustomAmmo stack from 1/ExampleItem
        public override void AddRecipes()
        {
            CreateRecipe(100)
                .AddIngredient<HuetiteBar>()
                .AddTile<Tiles.BismuthForge>()
                .Register();
        }
    }
}
