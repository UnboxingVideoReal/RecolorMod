using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RecolorMod.Items;
using RecolorMod.Items.Developer;
using RecolorMod.Tiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using RecolorMod.Rarities;

namespace RecolorMod.Dedicated.Items.TrueDedicatedStuff
{
	public class SoulOfTheDedicated : ModItem
	{

		public int frameCounter;

		public int frame;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the Dedicated");
			Tooltip.SetDefault($@"[i:{ModContent.ItemType<UnboxingEnchant>()}] Effects of Unboxing's Enchantment
[i:{ModContent.ItemType<Enchants.QuibopEnchant>()}] 5 knives will orbit around you
[i:{ModContent.ItemType<Enchants.BlahEnchant>()}] Double");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1; // Configure the amount of this Item that's needed to research it in Journey mode.
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			RecolorUtils.DedicatedItemStuff(tooltips);
		}

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 46;
			Item.accessory = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
			Item.value = Item.buyPrice(100); // Makes the Item worth 1 gold.
			Item.rare = ModContent.RarityType<TrueDedicated>();
		}

		//public override void PostUpdate()
		//{
		//	Lighting.AddLight(Item.Center, ModContent.GetInstance<TrueDedicated>().RarityColor.ToVector3() * 0.55f * Main.essScale); // Makes this Item glow when thrown out of inventory.
		//}

		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frameI, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Dedicated/Items/TrueDedicatedStuff/SoulOfTheDedicated_Animated").Value;
			spriteBatch.Draw(texture, position, GetCurrentFrame(Item, ref frame, ref frameCounter, 13, 13), Color.White, 0f, origin, scale, SpriteEffects.None, 0f);
			Texture2D texture2 = ModContent.Request<Texture2D>("RecolorMod/Dedicated/Items/TrueDedicatedStuff/SoulOfTheDedicated_Unboxing").Value;
			spriteBatch.Draw(texture2, position, GetCurrentFrame(Item, ref frame, ref frameCounter, 13, 13), ModContent.GetInstance<Developer>().RarityColor, 0f, origin, scale, SpriteEffects.None, 0f);
			return false;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			ModContent.GetInstance<Enchants.BlahEnchant>().UpdateAccessory(player, hideVisual);
			ModContent.GetInstance<Enchants.TorraEnchant>().UpdateAccessory(player, hideVisual);
			ModContent.GetInstance<Enchants.QuibopEnchant>().UpdateAccessory(player, hideVisual);
		}

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Dedicated/Items/TrueDedicatedStuff/SoulOfTheDedicated_Animated").Value;
            spriteBatch.Draw(texture, Item.position - Main.screenPosition, GetCurrentFrame(Item, ref frame, ref frameCounter, 13, 13), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			Texture2D texture2 = ModContent.Request<Texture2D>("RecolorMod/Dedicated/Items/TrueDedicatedStuff/SoulOfTheDedicated_Unboxing").Value;
			spriteBatch.Draw(texture2, Item.position - Main.screenPosition, GetCurrentFrame(Item, ref frame, ref frameCounter, 13, 13), ModContent.GetInstance<Developer>().RarityColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			return false;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe(2)
				.AddIngredient<DedicatedBar>(15)
				.AddIngredient<UnboxingEssence>(15)
				// other emchants...
				.AddIngredient<UnboxingEnchant>()
				.AddIngredient<OmegaFragment>(15)
				.AddTile<BismuthForgeTile>()
				.Register();
		}

		public static Rectangle GetCurrentFrame(Item item, ref int frame, ref int frameCounter, int frameDelay, int frameAmt, bool frameCounterUp = true)
		{
			if (frameCounter >= frameDelay)
			{
				frameCounter = -1;
				frame = ((frame != frameAmt - 1) ? (frame + 1) : 0);
			}
			if (frameCounterUp)
			{
				frameCounter++;
			}
			return new Rectangle(0, item.height * frame, item.width, item.height);
		}
	}
}
