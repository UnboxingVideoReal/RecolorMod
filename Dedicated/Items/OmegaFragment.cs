using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RecolorMod.Items;
using RecolorMod.Tiles;
using System.Collections.Generic;

namespace RecolorMod.Dedicated.Items
{
	public class OmegaFragment : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Omega Fragment");
			ItemID.Sets.ItemIconPulse[Item.type] = true; // The Item pulses while in the player's inventory
			ItemID.Sets.ItemNoGravity[Item.type] = true; // Makes the Item have no gravity
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25; // Configure the amount of this Item that's needed to research it in Journey mode.
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
			RecolorUtils.DedicatedItemStuff(tooltips);
        }

        public override void SetDefaults() {
			Item.width = 28;
			Item.height = 30;
			Item.maxStack = 999;
			Item.value = Item.buyPrice(0, 95); // Makes the Item worth 1 gold.
			Item.rare = ModContent.RarityType<Omega>();
		}

        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, RecolorUtils.QuadColorSwap(new Color(0, 242, 170), new Color(254, 126, 229), new Color(254, 158, 35), new Color(0, 174, 238)/*, 4f*/).ToVector3() * 0.55f * Main.essScale); // Makes this Item glow when thrown out of inventory.
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Aquamarine>(5)
				.AddIngredient(ItemID.FragmentNebula)
				.AddIngredient(ItemID.FragmentSolar)
				.AddIngredient(ItemID.FragmentStardust)
				.AddIngredient(ItemID.FragmentVortex)
				.AddTile<BismuthForgeTile>()
                .Register();
        }
    }

	// todo: implement
	// public class SoulGlobalNPC : GlobalNPC
	// {
	// 	public override void NPCLoot(NPC npc) {
	// 		if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ExamplePlayer>().ZoneExample) { // Drop this Item only in the ExampleBiome.
	// 			Item.NewItem(npc.getRect(), ItemType<ExampleSoul>()); // get the npc's hitbox rectangle and spawn an Item of choice
	// 		}
	// 	}
	// }
}
