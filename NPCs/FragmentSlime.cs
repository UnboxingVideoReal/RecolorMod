using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace RecolorMod.NPCs
{
	public class FragmentSlime : ModNPC
	{
		public ref float AI_Timer => ref NPC.ai[1];

        public override void SetStaticDefaults()
        {
			//DisplayName.SetDefault("Vortex Slime");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.KingSlime];
		}

        public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.KingSlime);
			NPC.damage = 150;
			NPC.alpha = 0;
			NPC.color = Color.White;
			NPC.defense = 65;
			NPC.lifeMax = 150000;
			AnimationType = NPCID.KingSlime;
			AIType = -1; // Use vanilla zombie's type when executing AI code. (This also means it will try to despawn during daytime) // Use vanilla zombie's type when executing animation code. Important to also match Main.npcFrameCount[NPC.type] in SetStaticDefaults.
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot) { 
			npcLoot.Add(ItemDropRule.Common(ItemID.Gel));
			npcLoot.Add(ItemDropRule.Common(ItemID.FragmentNebula));
			npcLoot.Add(ItemDropRule.Common(ItemID.FragmentSolar));
			npcLoot.Add(ItemDropRule.Common(ItemID.FragmentStardust));
		}

		//public override float SpawnChance(NPCSpawnInfo spawnInfo) {
		//	return SpawnCondition.StardustTower.Chance * 40f;
		//}

        public override void AI()
        {
			AI_Timer++;
			if (AI_Timer >= 150f)
			{
				var num627 = 10000f;
				var vector71 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height / 2);
				var num628 = 100;
				int num629 = ModContent.NPCType<NPCs.VortexSlime>();
				int num700 = ProjectileID.DeathLaser;
				//Terraria.Audio.SoundEngine.PlaySound(2, (int)NPC.position.X, (int)NPC.position.Y, 33);
				var num630 = (float)Math.Atan2(vector71.Y - (Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f), vector71.X - (Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f));
				for (var num631 = 0f; num631 <= 4f; num631 += 0.4f)
				{
					var num632 = NPC.NewNPC((int)vector71.X, (int)vector71.Y, num629);
					Main.projectile[num632].timeLeft = 600;
					Main.projectile[num632].tileCollide = false;
					num632 = NPC.NewNPC((int)vector71.X, (int)vector71.Y, num629);
					Main.projectile[num632].timeLeft = 600;
					Main.projectile[num632].tileCollide = false;
						var num635 = Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), vector71.X, vector71.Y, (float)(Math.Cos(num630 + num631) * num627 * -1.0), (float)(Math.Sin(num630 + num631) * num627 * -1.0), num700, num628, 0f, 0, 0f, 0f);
						Main.projectile[num635].timeLeft = 600;
						Main.projectile[num635].tileCollide = false;
						num635 = Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), vector71.X, vector71.Y, (float)(Math.Cos(num630 - num631) * num627 * -1.0), (float)(Math.Sin(num630 - num631) * num627 * -1.0), num700, num628, 0f, 0, 0f, 0f);
						Main.projectile[num635].timeLeft = 600;
						Main.projectile[num635].tileCollide = false;
				}
				AI_Timer = 0f;
				return;
			}
			return;
		}
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Visuals.Sun,

				// Sets the description of this NPC that is listed in the bestiary.
				//new FlavorTextBestiaryInfoElement("Th.")
			});
		}

		//public override void HitEffect(int hitDirection, double damage) {
		//	// Spawn confetti when this zombie is hit.
		//	for (int i = 0; i < 10; i++) {
		//		int dustType = Main.rand.Next(139, 143);
		//		var dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, dustType);

		//		dust.velocity.X += Main.rand.NextFloat(-0.05f, 0.05f);
		//		dust.velocity.Y += Main.rand.NextFloat(-0.05f, 0.05f);
				
		//		dust.scale *= 1f + Main.rand.NextFloat(-0.03f, 0.03f);
		//	}
		//}
	}
}
