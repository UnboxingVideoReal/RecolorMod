using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RecolorMod;
using Microsoft.Xna.Framework;

namespace RecolorMod.Items.Debug
{
	public class AllRarityItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("rARITYY TESDT");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.shoot = ProjectileID.PhantasmArrow;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ModContent.RarityType<Rarities.CoolBlue>();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Main.NewText("Tsewdsfcx .", 0, 255, 0);
		}
	}
}