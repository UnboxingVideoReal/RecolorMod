using Microsoft.Xna.Framework;
using RecolorMod.Common.Systems;
using Terraria.GameContent.Creative;

namespace RecolorMod.Items
			Tooltip.SetDefault("holy shit");
				return !NPC.AnyNPCs(ModContent.NPCType<NPCs.BambiBoss>());

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
	}