using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod.Items.Pickaxe
{
	public class StardustPicksaw : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stardust Picksaw");
			Tooltip.SetDefault("Can mine Bismuth");
		}

		public override void SetDefaults()
		{
			Item.damage = 130;
			Item.crit += 30;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 60;
			Item.useTime = 5;
			Item.useAnimation = 10;
			Item.useTurn = true;
			Item.pick = 315;
			Item.useStyle = 1;
			Item.knockBack = 5f;
			Item.value = Item.buyPrice(0, 95);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.tileBoost += 5;
			Item.axe = 40;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.Picksaw)
				.AddIngredient(ItemID.StardustPickaxe)
				.AddIngredient(ItemID.FragmentStardust, 20)
				.AddIngredient(ItemID.LunarBar, 15)
				.AddIngredient<Aquamarine>(5)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Items/Pickaxe/StardustPicksaw_Glow").Value;
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			float rotation = 0f;
			Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Items/Pickaxe/StardustPicksaw_Glow").Value;
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
			return true;
		}
	}
}
