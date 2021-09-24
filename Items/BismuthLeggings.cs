using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace RecolorMod.Items
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Legs value here will result in TML expecting a X_Legs.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Legs)]
	public class BismuthLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Movement speed increased by 5%\nArmor penetration increased by 5");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 22; // Width of the item
			Item.height = 18; // Height of the item
			Item.sellPrice(platinum: 1); // How many coins the item is worth
			Item.rare = ModContent.RarityType<Rarities.UltraBlueRarity>(); // The rarity of the item
			Item.defense = 80; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.05f; // Increase the movement speed of the player
			player.armorPenetration += 5;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<BismuthBar>(30)
				.AddIngredient<Aquamarine>(5)
				.AddTile<Tiles.BismuthForgeTile>()
				.Register();
		}
	}
}
