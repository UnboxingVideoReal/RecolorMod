using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RecolorMod.Items;
using RecolorMod.Tiles;
using System.Collections.Generic;

namespace RecolorMod.Dedicated.Items.TrueDedicatedStuff
{
	public class DedicatedBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dedicated Bar");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25; // Configure the amount of this Item that's needed to research it in Journey mode.
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			RecolorUtils.DedicatedItemStuff(tooltips);
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 30;
			Item.maxStack = 999;
			Item.value = Item.buyPrice(3); // Makes the Item worth 1 gold.
			Item.rare = ModContent.RarityType<TrueDedicated>();
		}

		public override void PostUpdate()
		{
			Lighting.AddLight(Item.Center, ModContent.GetInstance<TrueDedicated>().RarityColor.ToVector3() * 0.55f * Main.essScale); // Makes this Item glow when thrown out of inventory.
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<Aquamarine>(5)
				.AddIngredient<UnboxingEssence>(5)
				.AddIngredient<BlahStuff.BlahBar>(2)
				.AddIngredient<OmegaFragment>(15)
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
