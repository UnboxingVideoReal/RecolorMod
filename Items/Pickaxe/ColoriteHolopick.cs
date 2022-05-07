using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod.Items.Pickaxe
{
	public class ColoriteHolopick : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Colorite Holopick");
			Tooltip.SetDefault("Can mine Cinnabar");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults()
		{
			Item.damage = 330;
			Item.crit += 66;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 60;
			Item.useTime = 2;
			Item.useAnimation = 5;
			Item.useTurn = true;
			Item.pick = 500;
			Item.useStyle = 1;
			Item.knockBack = 3f;
			Item.value = Item.buyPrice(6, 55);
			Item.rare = ItemRarityID.Expert;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.tileBoost += 12;
			//Item.axe = 45;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient<ColoriteBar>(45)
				.AddIngredient<SoulOfUnbright>(30)
                .AddIngredient<SoulOfWight>(30)
                .AddIngredient<SoulOfTwilight>(30)
                .AddIngredient<BismuthPickaxe>()
                .AddTile<Tiles.BismuthForgeTile>()
				.Register();
		}

        //public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        //{
        //	Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Items/Pickaxe/NebulaPicksaw_Glow").Value;
        //	spriteBatch.Draw
        //	(
        //		texture,
        //		new Vector2
        //		(
        //			Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
        //			Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
        //		),
        //		new Rectangle(0, 0, texture.Width, texture.Height),
        //		Color.White,
        //		rotation,
        //		texture.Size() * 0.5f,
        //		scale,
        //		SpriteEffects.None,
        //		0f
        //	);
        //}
        //      public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        //      {
        //	Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Items/Pickaxe/SolarPicksaw_Glow").Value;
        //	spriteBatch.Draw
        //	(
        //		texture,
        //		new Vector2
        //		(
        //			Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
        //			Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
        //		),
        //		new Rectangle(0, 0, texture.Width, texture.Height),
        //		Color.White,
        //		texture.Size() * 0.5f,
        //		scale,
        //		SpriteEffects.None,
        //		0f
        //	);
        //	return true;
        //}
    }
}
