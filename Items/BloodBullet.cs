using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace RecolorMod.Items
{
    public class BloodBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Bullets home in on enemies");
        }

        public override void SetDefaults()
        {
			Item.width = 8; // The width of Item hitbox
			Item.height = 8; // The height of Item hitbox

			Item.damage = 12; // The damage for projectiles isn't actually 8, it actually is the damage combined with the projectile and the Item together
			Item.DamageType = DamageClass.Ranged; // What type of damage does this ammo affect?

			Item.maxStack = 999; // The maximum number of items that can be contained within a single stack
			Item.consumable = true; // This marks the Item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible
			Item.knockBack = 1f; // Sets the Item's knockback. Ammunition's knockback added together with weapon and projectiles.
			Item.value = Item.sellPrice(0, 0, 15, 0); // Item price in copper coins (can be converted with Item.sellPrice/Item.buyPrice)
			Item.rare = ItemRarityID.Blue; // The color that the Item's name will be in-game.
			Item.shoot = ModContent.ProjectileType<Projectiles.BloodHoming>(); // The projectile that weapons fire when using this Item as ammunition.

			Item.ammo = AmmoID.Bullet; // Important. The first Item in an ammo class sets the AmmoID to its type
		}

        public override void AddRecipes()
        {
            CreateRecipe(100)
                .AddIngredient(ItemID.CrimtaneBar)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
