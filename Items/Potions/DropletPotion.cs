using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace RecolorMod.Items.Potions
{
	public class DropletPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Does nothing.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ModContent.RarityType<Rarities.DropletRarity>();
			Item.value = Item.buyPrice(platinum: 3);
			Item.buffTime = 5400;
		}
	}
}