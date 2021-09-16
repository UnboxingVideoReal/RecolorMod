using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace RecolorMod.Items
{
	[AutoloadBossHead]
	public class SoulOfTwilight : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Soul of Twilight");
			Tooltip.SetDefault("'The essence of combined creatures'");
			
			// Registers a vertical animation with 4 frames and each one will last 5 ticks (1/12 second)
			// Reminder, (4, 6) is an example of an Item that draws a new frame every 6 ticks
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
			
			ItemID.Sets.AnimatesAsSoul[Item.type] = true; // Makes the Item have a 4-frame animation while in world (not held.)
			ItemID.Sets.ItemIconPulse[Item.type] = true; // The Item pulses while in the player's inventory
			ItemID.Sets.ItemNoGravity[Item.type] = true; // Makes the Item have no gravity
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25; // Configure the amount of this Item that's needed to research it in Journey mode.
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.maxStack = 999;
			Item.value = 1000000; // Makes the Item worth 1 gold.
			Item.rare = ItemRarityID.Expert/*ModContent.RarityType<Rarities.UltraBlueRarity>()*/;
		}

		//public override void PostUpdate() {
		//	Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale); // Makes this Item glow when thrown out of inventory.
		//}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		//public override void AddRecipes() {
		//	CreateRecipe()
		//		.AddIngredient<ExampleItem>()
		//		.AddTile<Tiles.Furniture.ExampleWorkbench>()
		//		.Register();
		//}
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
