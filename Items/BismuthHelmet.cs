using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace RecolorMod.Items
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Head)]
	public class BismuthHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases all damage by 10%");
		}

		public override void SetDefaults()
		{
			Item.width = 32; // Width of the item
			Item.height = 26; // Height of the item
			Item.sellPrice(1); // How many coins the item is worth
			Item.rare = ModContent.RarityType<Rarities.UltraBlueRarity>(); // The rarity of the item
			Item.defense = 85; // The amount of defense the item will give when equipped
		}

		// IsArmorSet determines what armor pieces are needed for the setbonus to take effect
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<BismuthChestplate>() && legs.type == ModContent.ItemType<BismuthLeggings>();
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player)
		{
			NPC npc = new NPC();
			player.setBonus = "Summons a baby skeletron head to follow you around\nIncreases damage by 20%\nAll bosses are inflicted with ichor"; // This is the setbonus tooltip
			player.GetDamage(DamageClass.Generic) += 0.2f;
			player.AddBuff(BuffID.BabySkeletronHead, 1);
            if (npc.boss)
            {
                npc.ichor = true;
            }
        }

		public override void UpdateEquip(Player player)
        {
			player.GetDamage(DamageClass.Generic) += 0.1f;
			//if (npc.boss)
   //         {
			//	npc.knockBackResist += 0.2f;
			//}
		}
        public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<BismuthBar>(45)
				.AddIngredient<Aquamarine>(5)
				.AddTile<Tiles.BismuthForge>()
				.Register();
		}
	}
}
