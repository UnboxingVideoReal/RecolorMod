using Microsoft.Xna.Framework;
using RecolorMod.Common.Systems;

			Tooltip.SetDefault("Summons The Colorizers.");
   //         {
			//	return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Waterblaster>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Saturationator>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Retispaz>());
			//}
   //         else
            //{
				return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Waterblaster>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Saturationator>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Hueshifter>());
			//}
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
			//}