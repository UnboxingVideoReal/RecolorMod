using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace RecolorMod.Items.Developer
{
	public class UnboxingBar : ModItem
	{
		public int frameCounter;

		public int frame;

		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
			//Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(8, 8));
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 100; // Influences the inventory sort order. 59 is PlatinumBar, higher is more valuable.
		}

		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = Item.buyPrice(150); // The cost of the item in copper coins. (1 = 1 copper, 100 = 1 silver, 1000 = 1 gold, 10000 = 1 platinum)
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.rare = ModContent.RarityType<Rarities.Developer>();
			Item.consumable = true;
/*			Item.createTile = ModContent.TileType<Tiles.Developer.UnboxingBar>();*/ // The ID of the wall that this item should place when used. ModContent.TileType<T>() method returns an integer ID of the wall provided to it through its generic type argument (the type in angle brackets)..
			Item.placeStyle = 0;
		}
		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<UnboxingOre>(10)
				.AddIngredient<Aquamarine>(15)
				.AddTile<Tiles.BismuthForge>()
				.Register();
		}

		public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			Item.color = new Color(Main.DiscoR, 0, Main.DiscoB);
			Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Items/Developer/UnboxingBar_Animated").Value;
			spriteBatch.Draw(texture, position, GetCurrentFrame(Item, frame: ref this.frame, frameCounter: ref frameCounter, frameDelay: 6, frameAmt: 6), Color.White, 0f, origin, scale, SpriteEffects.None, 0f);
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Item.color = new Color(Main.DiscoR, 0, Main.DiscoB);
			Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Items/Developer/UnboxingBar_Animated").Value;
			spriteBatch.Draw(texture, Item.position - Main.screenPosition, GetCurrentFrame(Item, frame: ref frame, frameCounter: ref frameCounter, frameDelay: 6, frameAmt: 6), lightColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
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
