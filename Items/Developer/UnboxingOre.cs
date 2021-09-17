using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;

namespace RecolorMod.Items.Developer
{
	public class UnboxingOre : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Unboxing Ore");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
		}

		public override void SetDefaults() {
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.rare = ModContent.RarityType<Rarities.Developer>();
			Item.createTile = ModContent.TileType<Tiles.Developer.UnboxingOre>();
			Item.width = 14;
			Item.height = 16;
			Item.value = Item.buyPrice(50, 1, 500, 900);
		}

        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
			Item.color = new Color(Main.DiscoR, 0, Main.DiscoB);
		}

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Item.color = new Color(Main.DiscoR, 0, Main.DiscoB);
		}
	}
}