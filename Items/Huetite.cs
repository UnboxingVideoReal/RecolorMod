using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;

namespace RecolorMod.Items
{
	public class Huetite : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Huetite Ore");
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
			Item.rare = ItemRarityID.Expert/*ModContent.RarityType<Rarities.UltraBlueRarity>()*/;
			Item.createTile = ModContent.TileType<Tiles.Huetite>();
			Item.width = 16;
			Item.height = 16;
			Item.value = 3000;
		}

        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
			Item.color = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
		}

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Item.color = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
		}
	}
}