using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.Audio;
using RecolorMod.Common.Systems;
namespace RecolorMod.Items{	public class SaturatedEye : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Saturated Eye");
			Tooltip.SetDefault("Summons The Colorizers.");		}		public override void SetDefaults()		{			Item.consumable = true;			Item.width = 30;			Item.useTime = 45;			Item.useStyle = 4;			Item.value = 0;			Item.maxStack = 20;			Item.useAnimation = 45;			Item.height = 20;			Item.rare = ModContent.RarityType<Rarities.UltraBlueRarity>();        }        public override bool CanUseItem(Player player)        {			//if (DownedBossSystem.downedSaturationBoss)
   //         {
			//	return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Waterblaster>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Saturationator>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Retispaz>());
			//}
   //         else
            //{
				return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Waterblaster>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Saturationator>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Hueshifter>());
			//}        }        public override bool? UseItem(Player player)        {			//if (DownedBossSystem.downedSaturationBoss)
   //         {
			//	NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Waterblaster>());
			//	NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Saturationator>());
			//	NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Retispaz>());
			//	SoundEngine.PlaySound(SoundID.Roar, player.position, 0);
			//	return true;
			//}
   //         else
   //         {
				NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Waterblaster>());
				NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Saturationator>());
			    NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Hueshifter>());
			    SoundEngine.PlaySound(SoundID.Roar, player.position, 0);
				return true;
			//}        }    }}