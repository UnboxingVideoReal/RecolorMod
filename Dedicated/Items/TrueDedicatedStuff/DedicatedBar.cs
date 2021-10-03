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

namespace RecolorMod.Dedicated.Items.TrueDedicatedStuff
{
	public class DedicatedBar : ModItem
	{

		public int frameCounter;

		public int frame;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dedicated Bar");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99; // Configure the amount of this Item that's needed to research it in Journey mode.
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			RecolorUtils.DedicatedItemStuff(tooltips);
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = Item.buyPrice(5); // Makes the Item worth 1 gold.
			Item.rare = ModContent.RarityType<TrueDedicated>();
		}

		//public override void PostUpdate()
		//{
		//	Lighting.AddLight(Item.Center, ModContent.GetInstance<TrueDedicated>().RarityColor.ToVector3() * 0.55f * Main.essScale); // Makes this Item glow when thrown out of inventory.
		//}

		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frameI, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Dedicated/Items/TrueDedicatedStuff/DedicatedBar_Animated").Value;
			spriteBatch.Draw(texture, position, GetCurrentFrame(Item, ref frame, ref frameCounter, 6, 6), ModContent.GetInstance<TrueDedicated>().RarityColor, 0f, origin, scale, SpriteEffects.None, 0f);
			return false;
		}

		public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Dedicated/Items/TrueDedicatedStuff/DedicatedBar_Animated").Value;
            spriteBatch.Draw(texture, Item.position - Main.screenPosition, GetCurrentFrame(Item, ref frame, ref frameCounter, 6, 6), ModContent.GetInstance<TrueDedicated>().RarityColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			return false;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe(2)
				.AddIngredient<Aquamarine>(5)
				.AddIngredient<UnboxingEssence>(5)
				.AddIngredient<UnboxingBar>()
				.AddIngredient<BlahStuff.BlahBar>(2)
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
