using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace RecolorMod.Items
{
	public class BismuthForge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bismuth Forge");
			Tooltip.SetDefault("Used to smelt Bismuth ore and other Post-Moon Lord ores\nCan also be used as an Ancient Manipulator");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.maxStack = 99;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.BismuthForge>();
			Item.rare = 9;
			Item.width = 48;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.value = 100000;
			Item.useAnimation = 15;
			Item.height = 34;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<BismuthOre>(50)
				.AddIngredient<Aquamarine>(5)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}