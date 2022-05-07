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
	public class Seraph : ModNPC
	{
		public ref float AI_Timer => ref NPC.ai[1];

        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Seraph");
			Main.npcFrameCount[NPC.type] = 4;
		}

        public override void SetDefaults() {
            NPC.CloneDefaults(NPCID.Pixie);
            NPC.damage = 101;
            NPC.defense = 41;
            NPC.aiStyle = -1;
			NPC.width = 32;
				NPC.height = 32;
            NPC.lifeMax = 1150;
            AnimationType = NPCID.Pixie;
			AIType = 22;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot) { 
			npcLoot.Add(ItemDropRule.Common(ItemID.PixieDust));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.OverworldHallow.Chance * 40f;
		}

        public override void AI()
        {
			AI_Timer++;
			if (AI_Timer >= 180f)
			{
				var num627 = 12f;
				var vector71 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height / 2);
				var num628 = 100;
				int num629 = ModContent.ProjectileType<Projectiles.SeraphFireball>();
				var num630 = (float)Math.Atan2(vector71.Y - (Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f), vector71.X - (Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f));
				for (var num631 = 0f; num631 <= 4f; num631 += 0.4f)
				{
					var num632 = Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), vector71.X, vector71.Y, (float)(Math.Cos(num630 + num631) * num627 * -1.0), (float)(Math.Sin(num630 + num631) * num627 * -1.0), num629, num628, 0f, 0, 0f, 0f);
					Main.projectile[num632].timeLeft = 600;
					Main.projectile[num632].tileCollide = false;
					num632 = Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), vector71.X, vector71.Y, (float)(Math.Cos(num630 - num631) * num627 * -1.0), (float)(Math.Sin(num630 - num631) * num627 * -1.0), num629, num628, 0f, 0, 0f, 0f);
					Main.projectile[num632].timeLeft = 600;
					Main.projectile[num632].tileCollide = false;
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
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow,

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
