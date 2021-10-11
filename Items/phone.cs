using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.Audio;
using RecolorMod.Common.Systems;
using Terraria.GameContent.Creative;

namespace RecolorMod.Items{	public class phone : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Phone");
			Tooltip.SetDefault("holy shit");			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;		}		public override void SetDefaults()		{			Item.consumable = true;			Item.width = 42;			Item.useTime = 45;			Item.useStyle = 4;			Item.value = 0;			Item.maxStack = 20;			Item.useAnimation = 45;			Item.height = 48;			Item.rare = ModContent.RarityType<Rarities.Bambi>();        }        public override bool CanUseItem(Player player)        {
				return !NPC.AnyNPCs(ModContent.NPCType<NPCs.BambiBoss>());        }

        public override bool? UseItem(Player player)
        {
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.BambiBoss>());
			SoundEngine.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
        public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<UnboxingEssence>(10)
				.AddIngredient<Developer.UnboxingBar>(10)
				.AddIngredient<Dedicated.Items.TrueDedicatedStuff.DedicatedBar>(15)
				.AddIngredient<Phonewood>(50)
				.AddTile<Tiles.BismuthForgeTile>()
				.Register();
		}
	}}