using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using Microsoft.Xna.Framework;
using System;
using Terraria.Localization;
using Terraria.Audio;
using RecolorMod.Common.Systems;

namespace RecolorMod.NPCs
{
    [AutoloadBossHead]
    public class Hueshifter : ModNPC
	{
        public static int secondStageHeadSlot = -1;
        public ref float AI_Timer => ref NPC.ai[1];

		public override void SetStaticDefaults()
        {
			//DisplayName.SetDefault("Vortex Slime");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Retinazer];
		}
        public override void SetDefaults() {
            NPC.CloneDefaults(NPCID.Retinazer);
            NPC.damage = 450;
			NPC.alpha = 0;
            NPC.value = 10000000f;
            NPC.color = Color.White;
			NPC.defense = 300;
			NPC.lifeMax = 2000000;
			AnimationType = NPCID.Retinazer;
			AIType = -1; // Use vanilla zombie's type when executing AI code. (This also means it will try to despawn during daytime) // Use vanilla zombie's type when executing animation code. Important to also match Main.npcFrameCount[NPC.type] in SetStaticDefaults.
		}
        public bool SecondStage = false;

        public override void Load()
        {
            //We want to give it a second boss head icon, so we register one
            string texture = BossHeadTexture + "_SecondStage"; //Our texture is called "ClassName_Head_Boss_SecondStage"
            secondStageHeadSlot = Mod.AddBossHeadTexture(texture, -1); //-1 because we already have one registered via the [AutoloadBossHead] attribute, it would overwrite it otherwise
        }

        public override void BossHeadSlot(ref int index)
        {
            int slot = secondStageHeadSlot;
            if (SecondStage && slot != -1)
            {
                //If the boss is in its second stage, display the other head icon instead
                index = slot;
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            //if (Main.rand.Next(10) == 0)
            //{
            //    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<Items.BacteriumPrimeTrophy>(), 1, false, 0, false);
            //}
            //if (Main.rand.Next(7) == 0)
            //{
            //    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<Items.BacteriumPrimeMask>(), 1, false, 0, false);
            //}
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("SoulOfTwilight").Type, 1, 5, 15));
        }

        public override void AI()
        {
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest(true);
            }
            var dead2 = Main.player[NPC.target].dead;
            var num485 = NPC.position.X + NPC.width / 2 - Main.player[NPC.target].position.X - Main.player[NPC.target].width / 2;
            var num486 = NPC.position.Y + NPC.height - 59f - Main.player[NPC.target].position.Y - Main.player[NPC.target].height / 2;
            var num487 = (float)Math.Atan2(num486, num485) + 1.57f;
            if (num487 < 0f)
            {
                num487 += 6.283f;
            }
            else if (num487 > 6.283)
            {
                num487 -= 6.283f;
            }
            if (NPC.rotation < num487)
            {
                if (num487 - NPC.rotation > 3.1415)
                {
                    NPC.rotation -= 0.1f;
                }
                else
                {
                    NPC.rotation += 0.1f;
                }
            }
            else if (NPC.rotation > num487)
            {
                if (NPC.rotation - num487 > 3.1415)
                {
                    NPC.rotation += 0.1f;
                }
                else
                {
                    NPC.rotation -= 0.1f;
                }
            }
            if (NPC.rotation > num487 - 0.1f && NPC.rotation < num487 + 0.1f)
            {
                NPC.rotation = num487;
            }
            if (NPC.rotation < 0f)
            {
                NPC.rotation += 6.283f;
            }
            else if (NPC.rotation > 6.283)
            {
                NPC.rotation -= 6.283f;
            }
            if (NPC.rotation > num487 - 0.1f && NPC.rotation < num487 + 0.1f)
            {
                NPC.rotation = num487;
            }
            if (Main.rand.Next(5) == 0)
            {
                var num489 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + NPC.height * 0.25f), NPC.width, (int)(NPC.height * 0.5f), 5, NPC.velocity.X, 2f, 0, default(Color), 1f);
                var dust40 = Main.dust[num489];
                dust40.velocity.X = dust40.velocity.X * 0.5f;
                var dust41 = Main.dust[num489];
                dust41.velocity.Y = dust41.velocity.Y * 0.1f;
            }
            if (Main.netMode != 1 && !Main.dayTime && !dead2 && NPC.timeLeft < 10)
            {
                for (var num490 = 0; num490 < 200; num490++)
                {
                    if (num490 != NPC.whoAmI && Main.npc[num490].active && (Main.npc[num490].type == NPCID.Retinazer || Main.npc[num490].type == NPCID.Spazmatism) && Main.npc[num490].timeLeft - 1 > NPC.timeLeft)
                    {
                        NPC.timeLeft = Main.npc[num490].timeLeft - 1;
                    }
                }
            }
            if (Main.dayTime || dead2)
            {
                NPC.velocity.Y = NPC.velocity.Y - 0.04f;
                if (NPC.timeLeft > 10)
                {
                    NPC.timeLeft = 10;
                    return;
                }
                return;
            }
            else if (NPC.ai[0] == 0f)
            {
                if (NPC.ai[1] == 0f)
                {
                    var num493 = 1;
                    if (NPC.position.X + NPC.width / 2 < Main.player[NPC.target].position.X + Main.player[NPC.target].width)
                    {
                        num493 = -1;
                    }
                    var vector46 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                    var num494 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 + num493 * 300 - vector46.X;
                    var num495 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - 300f - vector46.Y;
                    var num496 = (float)Math.Sqrt(num494 * num494 + num495 * num495);
                    num496 = 7f / num496;
                    num494 *= num496;
                    num495 *= num496;
                    if (NPC.velocity.X < num494)
                    {
                        NPC.velocity.X = NPC.velocity.X + 0.1f;
                        if (NPC.velocity.X < 0f && num494 > 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X + 0.1f;
                        }
                    }
                    else if (NPC.velocity.X > num494)
                    {
                        NPC.velocity.X = NPC.velocity.X - 0.1f;
                        if (NPC.velocity.X > 0f && num494 < 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X - 0.1f;
                        }
                    }
                    if (NPC.velocity.Y < num495)
                    {
                        NPC.velocity.Y = NPC.velocity.Y + 0.1f;
                        if (NPC.velocity.Y < 0f && num495 > 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y + 0.1f;
                        }
                    }
                    else if (NPC.velocity.Y > num495)
                    {
                        NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                        if (NPC.velocity.Y > 0f && num495 < 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                        }
                    }
                    NPC.ai[2] += 1f;
                    if (NPC.ai[2] >= 600f)
                    {
                        NPC.ai[1] = 1f;
                        NPC.ai[2] = 0f;
                        NPC.ai[3] = 0f;
                        NPC.target = 255;
                        NPC.netUpdate = true;
                    }
                    else if (NPC.position.Y + NPC.height < Main.player[NPC.target].position.Y && num496 < 400f)
                    {
                        if (!Main.player[NPC.target].dead)
                        {
                            NPC.ai[3] += 1f;
                        }
                        if (NPC.ai[3] >= 60f)
                        {
                            NPC.ai[3] = 0f;
                            vector46 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                            num494 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector46.X;
                            num495 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector46.Y;
                            if (Main.netMode != 1)
                            {
                                var num499 = (NPC.type == ModContent.NPCType<Hueshifter>()) ? 49 : 20;
                                num496 = (float)Math.Sqrt(num494 * num494 + num495 * num495);
                                num496 = 9f / num496;
                                num494 *= num496;
                                num495 *= num496;
                                num494 += Main.rand.Next(-40, 41) * 0.08f;
                                num495 += Main.rand.Next(-40, 41) * 0.08f;
                                vector46.X += num494 * 15f;
                                vector46.Y += num495 * 15f;
                                var num627 = 12f;
                                var vector71 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height / 2);
                                var num628 = 100;
                                int num700 = ModContent.ProjectileType<Projectiles.RainbowLaser>();
                                //Terraria.Audio.SoundEngine.PlaySound(SoundID., (int)NPC.position.X, (int)NPC.position.Y, 33);
                                var num630 = (float)Math.Atan2(vector71.Y - (Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f), vector71.X - (Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f));
                                for (var num631 = 0f; num631 <= 4f; num631 += 0.4f)
                                {
                                    var num635 = Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), vector71.X, vector71.Y, (float)(Math.Cos(num630 + num631) * num627 * -1.0), (float)(Math.Sin(num630 + num631) * num627 * -1.0), num700, num628, 0f, 0, 0f, 0f);
                                    Main.projectile[num635].timeLeft = 600;
                                    Main.projectile[num635].tileCollide = false;
                                    Main.projectile[num635].friendly = false;
                                    Main.projectile[num635].hostile = true;
                                    num635 = Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), vector71.X, vector71.Y, (float)(Math.Cos(num630 - num631) * num627 * -1.0), (float)(Math.Sin(num630 - num631) * num627 * -1.0), num700, num628, 0f, 0, 0f, 0f);
                                    Main.projectile[num635].timeLeft = 600;
                                    Main.projectile[num635].tileCollide = false;
                                    Main.projectile[num635].friendly = false;
                                    Main.projectile[num635].hostile = true;
                                }
                                AI_Timer = 0f;
                            }
                        }
                    }
                }
                else if (NPC.ai[1] == 1f)
                {
                    NPC.rotation = num487;
                    var vector47 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                    var num502 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector47.X;
                    var num503 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector47.Y;
                    var num504 = (float)Math.Sqrt(num502 * num502 + num503 * num503);
                    num504 = 12f / num504;
                    NPC.velocity.X = num502 * num504;
                    NPC.velocity.Y = num503 * num504;
                    NPC.ai[1] = 2f;
                }
                else if (NPC.ai[1] == 2f)
                {
                    NPC.ai[2] += 1f;
                    if (NPC.ai[2] >= 25f)
                    {
                        NPC.velocity.X = NPC.velocity.X * 0.96f;
                        NPC.velocity.Y = NPC.velocity.Y * 0.96f;
                        if (NPC.velocity.X > -0.1 && NPC.velocity.X < 0.1)
                        {
                            NPC.velocity.X = 0f;
                        }
                        if (NPC.velocity.Y > -0.1 && NPC.velocity.Y < 0.1)
                        {
                            NPC.velocity.Y = 0f;
                        }
                    }
                    else
                    {
                        NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X) - 1.57f;
                    }
                    if (NPC.ai[2] >= 70f)
                    {
                        NPC.ai[3] += 1f;
                        NPC.ai[2] = 0f;
                        NPC.target = 255;
                        NPC.rotation = num487;
                        if (NPC.ai[3] >= 4f)
                        {
                            NPC.ai[1] = 0f;
                            NPC.ai[3] = 0f;
                        }
                        else
                        {
                            NPC.ai[1] = 1f;
                        }
                    }
                }
                if (NPC.life < NPC.lifeMax * 0.4)
                {
                    NPC.ai[0] = 1f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    NPC.ai[3] = 0f;
                    NPC.netUpdate = true;
                    return;
                }
                return;
            }
            else if (NPC.ai[0] == 1f || NPC.ai[0] == 2f)
            {
                if (NPC.ai[0] == 1f)
                {
                    NPC.ai[2] += 0.005f;
                    if (NPC.ai[2] > 0.5)
                    {
                        NPC.ai[2] = 0.5f;
                    }
                }
                else
                {
                    NPC.ai[2] -= 0.005f;
                    if (NPC.ai[2] < 0f)
                    {
                        NPC.ai[2] = 0f;
                    }
                }
                NPC.rotation += NPC.ai[2];
                NPC.ai[1] += 1f;
                if (NPC.ai[1] == 100f)
                {
                    NPC.ai[0] += 1f;
                    NPC.ai[1] = 0f;
                    if (NPC.ai[0] == 3f)
                    {
                        NPC.ai[2] = 0f;
                    }
                    else
                    {
                        SoundEngine.PlaySound(3, (int)NPC.position.X, (int)NPC.position.Y, 1);
                        for (var num505 = 0; num505 < 2; num505++)
                        {
                            Gore.NewGore(NPC.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 143, 1f);
                            Gore.NewGore(NPC.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
                            Gore.NewGore(NPC.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
                        }
                        for (var num506 = 0; num506 < 20; num506++)
                        {
                            Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
                        }
                        SoundEngine.PlaySound(15, (int)NPC.position.X, (int)NPC.position.Y, 0);
                        NPC.HitSound = SoundID.NPCHit4;
                    }
                }
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
                NPC.velocity.X = NPC.velocity.X * 0.98f;
                NPC.velocity.Y = NPC.velocity.Y * 0.98f;
                if (NPC.velocity.X > -0.1 && NPC.velocity.X < 0.1)
                {
                    NPC.velocity.X = 0f;
                }
                if (NPC.velocity.Y > -0.1 && NPC.velocity.Y < 0.1)
                {
                    NPC.velocity.Y = 0f;
                    return;
                }
                return;
            }
            else
            {
                SecondStage = true;
                NPC.HitSound = SoundID.NPCHit4;
                NPC.damage = (int)(NPC.defDamage * 1.5);
                NPC.defense = NPC.defDefense + 10;
                if (NPC.ai[1] == 0f)
                {
                    var vector48 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                    var num509 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector48.X;
                    var num510 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - 300f - vector48.Y;
                    var num511 = (float)Math.Sqrt(num509 * num509 + num510 * num510);
                    num511 = 8f / num511;
                    num509 *= num511;
                    num510 *= num511;
                    if (NPC.velocity.X < num509)
                    {
                        NPC.velocity.X = NPC.velocity.X + 0.15f;
                        if (NPC.velocity.X < 0f && num509 > 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X + 0.15f;
                        }
                    }
                    else if (NPC.velocity.X > num509)
                    {
                        NPC.velocity.X = NPC.velocity.X - 0.15f;
                        if (NPC.velocity.X > 0f && num509 < 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X - 0.15f;
                        }
                    }
                    if (NPC.velocity.Y < num510)
                    {
                        NPC.velocity.Y = NPC.velocity.Y + 0.15f;
                        if (NPC.velocity.Y < 0f && num510 > 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y + 0.15f;
                        }
                    }
                    else if (NPC.velocity.Y > num510)
                    {
                        NPC.velocity.Y = NPC.velocity.Y - 0.15f;
                        if (NPC.velocity.Y > 0f && num510 < 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y - 0.15f;
                        }
                    }
                    NPC.ai[2] += 1f;
                    if (NPC.ai[2] >= 300f)
                    {
                        NPC.ai[1] = 1f;
                        NPC.ai[2] = 0f;
                        NPC.ai[3] = 0f;
                        NPC.TargetClosest(true);
                        NPC.netUpdate = true;
                    }
                    vector48 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                    num509 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector48.X;
                    num510 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector48.Y;
                    NPC.rotation = (float)Math.Atan2(num510, num509) - 1.57f;
                    if (Main.netMode == 1)
                    {
                        return;
                    }
                    NPC.localAI[1] += 1f;
                    if (NPC.life < NPC.lifeMax * 0.75)
                    {
                        NPC.localAI[1] += 1f;
                    }
                    if (NPC.life < NPC.lifeMax * 0.5)
                    {
                        NPC.localAI[1] += 1f;
                    }
                    if (NPC.life < NPC.lifeMax * 0.25)
                    {
                        NPC.localAI[1] += 1f;
                    }
                    if (NPC.life < NPC.lifeMax * 0.1)
                    {
                        NPC.localAI[1] += 2f;
                    }
                    if (NPC.localAI[1] > 50f && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
                    {
                        //SecondStage = true;
                        NPC.localAI[1] = 0f;
                        var num513 = (NPC.type == ModContent.NPCType<Hueshifter>()) ? 50 : 25;
                        num511 = (float)Math.Sqrt(num509 * num509 + num510 * num510);
                        num511 = 8.5f / num511;
                        num509 *= num511;
                        num510 *= num511;
                        vector48.X += num509 * 15f;
                        vector48.Y += num510 * 15f;
                        var num627 = 12f;
                        var vector71 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height / 2);
                        var num628 = 100;
                        int num700 = ModContent.ProjectileType<Projectiles.RainbowLaser>();
                        //Terraria.Audio.SoundEngine.PlaySound(SoundID., (int)NPC.position.X, (int)NPC.position.Y, 33);
                        var num630 = (float)Math.Atan2(vector71.Y - (Main.player[NPC.target].position.Y + Main.player[NPC.target].height * 0.5f), vector71.X - (Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f));
                        for (var num631 = 0f; num631 <= 4f; num631 += 0.4f)
                        {
                            var num635 = Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), vector71.X, vector71.Y, (float)(Math.Cos(num630 + num631) * num627 * -1.0), (float)(Math.Sin(num630 + num631) * num627 * -1.0), num700, num628, 0f, 0, 0f, 0f);
                            Main.projectile[num635].timeLeft = 600;
                            Main.projectile[num635].tileCollide = false;
                            Main.projectile[num635].friendly = false;
                            Main.projectile[num635].hostile = true;
                            num635 = Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), vector71.X, vector71.Y, (float)(Math.Cos(num630 - num631) * num627 * -1.0), (float)(Math.Sin(num630 - num631) * num627 * -1.0), num700, num628, 0f, 0, 0f, 0f);
                            Main.projectile[num635].timeLeft = 600;
                            Main.projectile[num635].tileCollide = false;
                            Main.projectile[num635].friendly = false;
                            Main.projectile[num635].hostile = true;
                        }
                        AI_Timer = 0f;
                        return;
                    }
                    return;
                }
                else
                {
                    var num515 = 1;
                    if (NPC.position.X + NPC.width / 2 < Main.player[NPC.target].position.X + Main.player[NPC.target].width)
                    {
                        num515 = -1;
                    }
                    var vector49 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                    var num518 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 + num515 * 340 - vector49.X;
                    var num519 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector49.Y;
                    var num520 = (float)Math.Sqrt(num518 * num518 + num519 * num519);
                    num520 = 8f / num520;
                    num518 *= num520;
                    num519 *= num520;
                    if (NPC.velocity.X < num518)
                    {
                        NPC.velocity.X = NPC.velocity.X + 0.2f;
                        if (NPC.velocity.X < 0f && num518 > 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X + 0.2f;
                        }
                    }
                    else if (NPC.velocity.X > num518)
                    {
                        NPC.velocity.X = NPC.velocity.X - 0.2f;
                        if (NPC.velocity.X > 0f && num518 < 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X - 0.2f;
                        }
                    }
                    if (NPC.velocity.Y < num519)
                    {
                        NPC.velocity.Y = NPC.velocity.Y + 0.2f;
                        if (NPC.velocity.Y < 0f && num519 > 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y + 0.2f;
                        }
                    }
                    else if (NPC.velocity.Y > num519)
                    {
                        NPC.velocity.Y = NPC.velocity.Y - 0.2f;
                        if (NPC.velocity.Y > 0f && num519 < 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y - 0.2f;
                        }
                    }
                    vector49 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                    num518 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector49.X;
                    num519 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector49.Y;
                    NPC.rotation = (float)Math.Atan2(num519, num518) - 1.57f;
                    if (Main.netMode != 1)
                    {
                        NPC.localAI[1] += 1f;
                        if (NPC.life < NPC.lifeMax * 0.75)
                        {
                            NPC.localAI[1] += 1f;
                        }
                        if (NPC.life < NPC.lifeMax * 0.5)
                        {
                            NPC.localAI[1] += 1f;
                        }
                        if (NPC.life < NPC.lifeMax * 0.25)
                        {
                            NPC.localAI[1] += 1f;
                        }
                        if (NPC.life < NPC.lifeMax * 0.1)
                        {
                            NPC.localAI[1] += 2f;
                        }
                        if (NPC.localAI[1] > 60f && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
                        {
                            NPC.localAI[1] = 0f;
                            var num521 = 9f;
                            var num522 = 18;
                            var num523 = 100;
                            num520 = (float)Math.Sqrt(num518 * num518 + num519 * num519);
                            num520 = num521 / num520;
                            num518 *= num520;
                            num519 *= num520;
                            vector49.X += num518 * 15f;
                            vector49.Y += num519 * 15f;
                        }
                    }
                    NPC.ai[2] += 1f;
                    if (NPC.ai[2] >= 180f)
                    {
                        NPC.ai[1] = 0f;
                        NPC.ai[2] = 0f;
                        NPC.ai[3] = 0f;
                        NPC.TargetClosest(true);
                        NPC.netUpdate = true;
                        return;
                    }
                    return;
                }
            }
        }

        public override void OnKill()
        {
            NPC.SetEventFlagCleared(ref DownedBossSystem.downedHueshifter, -1);
            if (DownedBossSystem.downedSaturationator && DownedBossSystem.downedWaterBoss && DownedBossSystem.downedHueshifter)
            {
                NPC.SetEventFlagCleared(ref DownedBossSystem.downedSaturationBoss, -1);
            }
        }
        //      public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
        //	// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        //	bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
        //		// Sets the spawning conditions of this NPC that is listed in the bestiary.
        //		BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.VortexPillar,

        //		// Sets the description of this NPC that is listed in the bestiary.
        //		//new FlavorTextBestiaryInfoElement("Th.")
        //	});
        //}

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
