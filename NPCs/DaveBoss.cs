using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.Graphics.Shaders;
using Terraria.Graphics.Effects;
using Terraria.ModLoader.Utilities;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System.IO;

namespace RecolorMod.NPCs
{
	[AutoloadBossHead]
	public class DaveBoss : ModNPC
	{
		public bool secondPhase;
		public static int secondPhaseHead = -1;
		public ref float AI_Timer => ref NPC.ai[1];
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("dave");
		}

		public override void Load()
		{
			string texture = BossHeadTexture + "_SecondPhase";
			secondPhaseHead = Mod.AddBossHeadTexture(texture, -1);
		}

		public override void BossHeadSlot(ref int index)
		{
			int slot = secondPhaseHead;
			if (secondPhase && slot != -1)
			{
				index = slot;
			}
		}
		public override void SetDefaults()
		{
			NPC.width = 40;
			NPC.height = 64;
			NPC.damage = int.MaxValue - 1;
			NPC.defense = int.MaxValue - 1;
			NPC.lifeMax = 9999999;
			NPC.HitSound = SoundID.Item1;
			NPC.DeathSound = SoundID.Item1;
			NPC.value = 0f;
			NPC.knockBackResist = 0f;
			NPC.boss = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.scale = 4f;
			NPC.aiStyle = -1;
			secondPhase = false;
		}

		public override void AI()
		{
			if (NPC.life <= NPC.lifeMax)
			{
				if (secondPhase == false)
				{
					AI_Timer++;
					if (AI_Timer >= Main.rand.NextFloat(60f, 90f))
					{
						var num627 = 12f;
						var vector71 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height / 2);
						var num628 = 100;
						int num700 = ModContent.ProjectileType<DaveBarrage>();
						//Terraria.Audio.SoundEngine.PlaySound(SoundID., (int)NPC.position.X, (int)NPC.position.Y, 33);
						var num630 = (float)Math.Atan2(vector71.Y - (Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f), vector71.X - (Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f));
						for (var num631 = 0f; num631 <= 4f; num631 += 0.4f)
						{
							var num635 = Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), vector71.X, vector71.Y, (float)(Math.Cos(num630 + num631) * num627 * -1.0), (float)(Math.Sin(num630 + num631) * num627 * -1.0), num700, num628, 0f, 0, 0f, 0f);
							Main.projectile[num635].timeLeft = 600;
							Main.projectile[num635].tileCollide = false;
							num635 = Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), vector71.X, vector71.Y, (float)(Math.Cos(num630 - num631) * num627 * -1.0), (float)(Math.Sin(num630 - num631) * num627 * -1.0), num700, num628, 0f, 0, 0f, 0f);
							Main.projectile[num635].timeLeft = 600;
							Main.projectile[num635].tileCollide = false;
						}
						//secondPhase = true;
						AI_Timer = 0f;
						return;
					}
					Projectile.NewProjectile(Projectile.GetNoneSource(), NPC.Center.X, NPC.Center.Y, 0f, -1f, ModContent.ProjectileType<DaveBlastNoExplode>(), NPC.damage, 5f);
				}
			}
			else if (NPC.life <= NPC.lifeMax / 2)
			{
				secondPhase = true;
				AI_Timer++;
				if (AI_Timer >= Main.rand.NextFloat(30f, 40f))
				{
					var num627 = 12f;
					var vector71 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height / 2);
					var num628 = 100;
					int num700 = ModContent.ProjectileType<DaveBarrage>();
					//Terraria.Audio.SoundEngine.PlaySound(SoundID., (int)NPC.position.X, (int)NPC.position.Y, 33);
					var num630 = (float)Math.Atan2(vector71.Y - (Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f), vector71.X - (Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f));
					for (var num631 = 0f; num631 <= 4f; num631 += 0.4f)
					{
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
				Projectile.NewProjectile(Projectile.GetNoneSource(), NPC.Center.X, NPC.Center.Y, 0f, -1f, ModContent.ProjectileType<DaveBlast>(), NPC.damage, 5f);
			}
		}

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				new FlavorTextBestiaryInfoElement("Calamitas' true name is unknown. She was born in a mountainous region to a family of extremely skilled mages whose destructive powers rivaled those of demigods. They taught her how to master the vehement and volatile natures of dark magic, without giving in to the negative emotions that these powers can inflict upon the wielder. ''The dark is within all of us, but when gazing into darkness the darkness also gazes into you,'' her father told her, quoting a famous philosopher. However, one morning, after a particularly heated clash with a rivaling faction, Calamitas woke up to find her parents and siblings dead, hung on crucifixes by an angry mob. Filled with hatred and rage, Calamitas forgot what her parents had taught her, and brought devastation upon the mob, burning them with hellfire and teleporting them to the underworld to be tortured for eternity. Calamitas, defeated and sobbing, retreated to her now-vacant cave carved out in the mountainside, taking to practicing the magic of necromancy in order to revive her parents and 2 brothers. After her success in bringing back her siblings she heard an ethereal and almost-mesmerizing voice telling her to seek refuge in the Jungle. Following this, Calamitas wandered toward the Jungle, entranced by some unknown force. She found her way into the Jungle Temple, where Yharim, the man who had spoken to her, resided. He had felt her mastery over the arcane due to her immense and manic outburst of destructive power. He eventually recruited her into his army after several long and persuasive talks over what truly matters in their world. When Amidias refused to help Yharim in a ritual, to awaken a slumbering god, Yharim had Calamitas incinerate the oceans as her first mission, thus causing the Desert Scourge to go on a rampage. But, somewhere deep down in her psyche, the good in Calamitas still existed. Weeks passed, each day she argued more and more with herself over what was necessary to achieve a goal, and ultimately began distrusting Yharim. One day, Calamitas met with Yharim and attempted to convince him that his logic is flawed. Yharim heard none of it, and sent her immediately out of his throne room. That very same day, Calamitas betrayed Yharim by unleashing the ancient Golem using one of the ancient Power Cells. The Golem rampaged through the temple, distracting Yharim and his soldiers. Calamitas used this time to sneak up to Yharim's throne and procured a few documents containing some helpful information on Yharim's most valiant opponents, Braelor and Statis. When Yharim and his men obliterated the Golem he cursed Calamitas for her betrayal. Due to her being a fair distance away the curse had a less")
            });
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
			Texture2D texture2D15 = (Texture2D)ModContent.Request<Texture2D>("RecolorMod/NPCs/DaveBoss");
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (NPC.spriteDirection == 1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
			if (secondPhase)
            {
				texture2D15 = (Texture2D)ModContent.Request<Texture2D>("RecolorMod/NPCs/DaveBoss2");
			}
			else
            {
				texture2D15 = (Texture2D)ModContent.Request<Texture2D>("RecolorMod/NPCs/DaveBoss");
			}
			Vector2 vector11 = new Vector2(TextureAssets.Npc[NPC.type].Width() / 2, TextureAssets.Npc[NPC.type].Height() / 2);
			Color color36 = Color.White;
			float amount9 = 0.5f;
			int num153 = 7;
			Vector2 vector13 = NPC.Center - Main.screenPosition;
			vector13 -= new Vector2(texture2D15.Width, texture2D15.Height * NPC.scale / 2f);
			vector13 += vector11 * NPC.scale + new Vector2(0f, 4f + NPC.gfxOffY);
			spriteBatch.Draw(texture2D15, vector13, NPC.frame, NPC.GetAlpha(drawColor), NPC.rotation, vector11, NPC.scale, spriteEffects, 0f);
			return false;
        }
    }

	public class DaveBlast : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("dave blast");
			Main.projFrames[Projectile.type] = 5;
		}

		public override void SetDefaults()
		{
			Projectile.width = 36;
			Projectile.height = 36;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.damage = int.MaxValue - 1;
			Projectile.ignoreWater = true;
			Projectile.penetrate = 1;
			Projectile.Opacity = 0f;
			Projectile.timeLeft = 150;
		}

		public override void AI()
		{
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 4)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame >= 5)
			{
				Projectile.frame = 0;
			}
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GreenFairy, 0f, 0f, 50);
			Lighting.AddLight(Projectile.Center, (float)(255 - Projectile.alpha) * 0.9f / 255f, 0f, 0f);
			if (Projectile.ai[1] == 1f)
			{
				Projectile.Opacity = MathHelper.Clamp((float)Projectile.timeLeft / 60f, 0f, 1f);
			}
			else
			{
				Projectile.Opacity = MathHelper.Clamp(1f - (float)(Projectile.timeLeft - 90) / 60f, 0f, 1f);
			}
			Projectile.rotation = Projectile.velocity.ToRotation() + (float)Math.PI / 2f;
			if (Projectile.localAI[0] == 0f)
			{
				Projectile.localAI[0] = 1f;
				Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 20, 1f, 0f);
			}
			float inertia = (Main.getGoodWorld ? 80f : 100f);
			float homeSpeed = (Main.getGoodWorld ? 20f : 15f);
			float minDist = 40f;
			int target = (int)Projectile.ai[0];
			if (target >= 0 && Main.npc[target].active)
			{
				if (Projectile.Distance(Main.player[target].Center) > minDist)
				{
					Vector2 targetVec = Projectile.DirectionTo(Main.player[target].Center);
					if (targetVec.HasNaNs())
					{
						targetVec = Vector2.UnitY;
					}
					Projectile.velocity = (Projectile.velocity * (inertia - 1f) + targetVec * homeSpeed) / inertia;
				}
			}
			else if (Projectile.ai[0] != -1f)
			{
				Projectile.ai[0] = -1f;
				Projectile.netUpdate = true;
			}
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture = (Texture2D)TextureAssets.Projectile[Projectile.type];
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int drawStart = frameHeight * Projectile.frame;
			lightColor.R = (byte)(255f * Projectile.Opacity);
			Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Rectangle(0, drawStart, texture.Width, frameHeight), Projectile.GetAlpha(lightColor), Projectile.rotation, new Vector2((float)texture.Width / 2f, (float)frameHeight / 2f), Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}

		public override bool CanHitPlayer(Player target)
		{
			return Projectile.Opacity == 1f;
		}

		public override void Kill(int timeLeft)
		{
			if (Projectile.ai[1] == 0f)
			{
				float spread = (float)Math.PI * 9f / 40f;
				double startAngle = Math.Atan2(Projectile.velocity.X, Projectile.velocity.Y) - (double)(spread / 2f);
				double deltaAngle = spread / 8f;
				if (Projectile.owner == Main.myPlayer)
				{
					for (int i = 0; i < 10; i++)
					{
						double offsetAngle = startAngle + deltaAngle * (double)(i + i * i) / 2.0 + (double)(32f * (float)i);
						Projectile.NewProjectile(Projectile.GetNoneSource(), Projectile.Center.X, Projectile.Center.Y, (float)(Math.Sin(offsetAngle) * 7.0), (float)(Math.Cos(offsetAngle) * 7.0), ModContent.ProjectileType<BambiBarrage>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 1f);
						Projectile.NewProjectile(Projectile.GetNoneSource(), Projectile.Center.X, Projectile.Center.Y, (float)((0.0 - Math.Sin(offsetAngle)) * 7.0), (float)((0.0 - Math.Cos(offsetAngle)) * 7.0), ModContent.ProjectileType<BambiBarrage>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 1f);
					}
				}
			}
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GreenFairy, 0f, 0f, 50);
			for (int j = 0; j < 10; j++)
			{
				int redFire = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GreenFairy, 0f, 0f, 0, default(Color), 1.5f);
				Main.dust[redFire].noGravity = true;
				Main.dust[redFire].velocity *= 3f;
				redFire = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GreenFairy, 0f, 0f, 50);
				Main.dust[redFire].velocity *= 2f;
				Main.dust[redFire].noGravity = true;
			}
		}
	}

	public class DaveBlastNoExplode : ModProjectile
	{
        public override string Texture => ModContent.GetInstance<DaveBlast>().Texture; 
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("dave blast");
			Main.projFrames[Projectile.type] = 5;
		}

		public override void SetDefaults()
		{
			Projectile.width = 36;
			Projectile.height = 36;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.damage = int.MaxValue - 1;
			Projectile.ignoreWater = true;
			Projectile.penetrate = 1;
			Projectile.Opacity = 0f;
			Projectile.timeLeft = 150;
		}

		public override void AI()
		{
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 4)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame >= 5)
			{
				Projectile.frame = 0;
			}
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GreenFairy, 0f, 0f, 50);
			Lighting.AddLight(Projectile.Center, (float)(255 - Projectile.alpha) * 0.9f / 255f, 0f, 0f);
			if (Projectile.ai[1] == 1f)
			{
				Projectile.Opacity = MathHelper.Clamp((float)Projectile.timeLeft / 60f, 0f, 1f);
			}
			else
			{
				Projectile.Opacity = MathHelper.Clamp(1f - (float)(Projectile.timeLeft - 90) / 60f, 0f, 1f);
			}
			Projectile.rotation = Projectile.velocity.ToRotation() + (float)Math.PI / 2f;
			if (Projectile.localAI[0] == 0f)
			{
				Projectile.localAI[0] = 1f;
				Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 20, 1f, 0f);
			}
			float inertia = (Main.getGoodWorld ? 80f : 100f);
			float homeSpeed = (Main.getGoodWorld ? 20f : 15f);
			float minDist = 40f;
			int target = (int)Projectile.ai[0];
			if (target >= 0 && Main.npc[target].active)
			{
				if (Projectile.Distance(Main.player[target].Center) > minDist)
				{
					Vector2 targetVec = Projectile.DirectionTo(Main.player[target].Center);
					if (targetVec.HasNaNs())
					{
						targetVec = Vector2.UnitY;
					}
					Projectile.velocity = (Projectile.velocity * (inertia - 1f) + targetVec * homeSpeed) / inertia;
				}
			}
			else if (Projectile.ai[0] != -1f)
			{
				Projectile.ai[0] = -1f;
				Projectile.netUpdate = true;
			}
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture = (Texture2D)TextureAssets.Projectile[Projectile.type];
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int drawStart = frameHeight * Projectile.frame;
			lightColor.R = (byte)(255f * Projectile.Opacity);
			Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Rectangle(0, drawStart, texture.Width, frameHeight), Projectile.GetAlpha(lightColor), Projectile.rotation, new Vector2((float)texture.Width / 2f, (float)frameHeight / 2f), Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}

		public override bool CanHitPlayer(Player target)
		{
			return Projectile.Opacity == 1f;
		}

		//public override void Kill(int timeLeft)
		//{
		//	if (Projectile.ai[1] == 0f)
		//	{
		//		float spread = (float)Math.PI * 9f / 40f;
		//		double startAngle = Math.Atan2(Projectile.velocity.X, Projectile.velocity.Y) - (double)(spread / 2f);
		//		double deltaAngle = spread / 8f;
		//		if (Projectile.owner == Main.myPlayer)
		//		{
		//			for (int i = 0; i < 10; i++)
		//			{
		//				double offsetAngle = startAngle + deltaAngle * (double)(i + i * i) / 2.0 + (double)(32f * (float)i);
		//				Projectile.NewProjectile(Projectile.GetNoneSource(), Projectile.Center.X, Projectile.Center.Y, (float)(Math.Sin(offsetAngle) * 7.0), (float)(Math.Cos(offsetAngle) * 7.0), ModContent.ProjectileType<BambiBarrage>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 1f);
		//				Projectile.NewProjectile(Projectile.GetNoneSource(), Projectile.Center.X, Projectile.Center.Y, (float)((0.0 - Math.Sin(offsetAngle)) * 7.0), (float)((0.0 - Math.Cos(offsetAngle)) * 7.0), ModContent.ProjectileType<BambiBarrage>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 1f);
		//			}
		//		}
		//	}
		//	Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GreenFairy, 0f, 0f, 50);
		//	for (int j = 0; j < 10; j++)
		//	{
		//		int redFire = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GreenFairy, 0f, 0f, 0, default(Color), 1.5f);
		//		Main.dust[redFire].noGravity = true;
		//		Main.dust[redFire].velocity *= 3f;
		//		redFire = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GreenFairy, 0f, 0f, 50);
		//		Main.dust[redFire].velocity *= 2f;
		//		Main.dust[redFire].noGravity = true;
		//	}
		//}
	}

	public class DaveBarrage : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("dave barrage");
			Main.projFrames[Projectile.type] = 4;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 2;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 11;
			Projectile.height = 11;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.damage = int.MaxValue - 1;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 690;
		}

		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(Projectile.localAI[0]);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			Projectile.localAI[0] = reader.ReadSingle();
		}

		public override void AI()
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GreenFairy, 0f, 0f, 50);
			if (Projectile.velocity.Length() < ((Projectile.ai[1] == 0f) ? 14f : 10f))
			{
				Projectile.velocity *= 2.02f;
			}
			Projectile.rotation = Projectile.velocity.ToRotation() + (float)Math.PI / 2f;
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 4)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame > 3)
			{
				Projectile.frame = 0;
			}
			if (Projectile.timeLeft < 60)
			{
				Projectile.Opacity = MathHelper.Clamp((float)Projectile.timeLeft / 60f, 0f, 1f);
			}
			if (Projectile.localAI[0] == 0f)
			{
				Projectile.localAI[0] = 1f;
			}
			Lighting.AddLight(Projectile.Center, 0.75f, 0f, 0f);
		}

		public override bool CanHitPlayer(Player target)
		{
			return Projectile.Opacity == 1f;
		}
	}
}
