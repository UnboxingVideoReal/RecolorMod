using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod.Items
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Body)]
	public class BismuthChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bismuth Chestplate");
			Tooltip.SetDefault("Immunity to Broken Armor\nMax mana increased by 200\nEffects of Panic Necklace");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 34; // Width of the item
			Item.height = 22; // Height of the item
			Item.sellPrice(platinum: 1); // How many coins the item is worth
			Item.rare = ModContent.RarityType<Rarities.UltraBlueRarity>(); // The rarity of the item
			Item.defense = 96; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.BrokenArmor] = true; // Make the player immune to Fire
			player.statManaMax2 += 200; // Increase how many mana points the player can have by 20
			player.panic = true; // Increase how many minions the player can have by one
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<BismuthBar>(50)
				.AddIngredient<Aquamarine>(5)
				.AddTile<Tiles.BismuthForgeTile>()
				.Register();
		}
	}
}
