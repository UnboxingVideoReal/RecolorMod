using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using RecolorMod;
using RecolorMod.Common.Systems;
using Terraria.GameContent.ItemDropRules;

namespace RecolorMod.NPCs
{
    [AutoloadBossHead]
    public class Waterblaster : ModNPC
	{
        public static int secondStageHeadSlot = -1;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Obscuritism");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.damage = 300;
			NPC.boss = true;
			NPC.netAlways = true;
			NPC.noTileCollide = true;
			NPC.lifeMax = 1200000;
			NPC.defense = 245;
			NPC.noGravity = true;
			NPC.width = 100;
			NPC.aiStyle = -1;
			NPC.npcSlots = 2f;
			NPC.value = 5000000f;
			NPC.timeLeft = 750;
			NPC.height = 110;
			NPC.knockBackResist = 0f;
            NPC.HitSound = SoundID.NPCHit1;
	        NPC.DeathSound = SoundID.NPCDeath14;
			NPC.buffImmune[BuffID.Confused] = true;
		}

        public bool SecondStage
        {
            get => NPC.ai[1] == 8f;
            set => NPC.ai[1] = value ? 8f : 0f;
        }

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
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("SoulOfUnbright").Type, 1, 20, 50));
        }

        public override void AI()
        {
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest(true);
            }
            var dead3 = Main.player[NPC.target].dead;
            var num524 = NPC.position.X + NPC.width / 2 - Main.player[NPC.target].position.X - Main.player[NPC.target].width / 2;
            var num525 = NPC.position.Y + NPC.height - 59f - Main.player[NPC.target].position.Y - Main.player[NPC.target].height / 2;
            var num526 = (float)Math.Atan2(num525, num524) + 1.57f;
            if (num526 < 0f)
            {
                num526 += 6.283f;
            }
            else if (num526 > 6.283)
            {
                num526 -= 6.283f;
            }
            var num527 = 0.15f;
            if (NPC.rotation < num526)
            {
                if (num526 - NPC.rotation > 3.1415)
                {
                    NPC.rotation -= num527;
                }
                else
                {
                    NPC.rotation += num527;
                }
            }
            else if (NPC.rotation > num526)
            {
                if (NPC.rotation - num526 > 3.1415)
                {
                    NPC.rotation += num527;
                }
                else
                {
                    NPC.rotation -= num527;
                }
            }
            if (NPC.rotation > num526 - num527 && NPC.rotation < num526 + num527)
            {
                NPC.rotation = num526;
            }
            if (NPC.rotation < 0f)
            {
                NPC.rotation += 6.283f;
            }
            else if (NPC.rotation > 6.283)
            {
                NPC.rotation -= 6.283f;
            }
            if (NPC.rotation > num526 - num527 && NPC.rotation < num526 + num527)
            {
                NPC.rotation = num526;
            }
            if (Main.rand.Next(5) == 0)
            {
                var num528 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + NPC.height * 0.25f), NPC.width, (int)(NPC.height * 0.5f), 5, NPC.velocity.X, 2f, 0, default(Color), 1f);
                var dust42 = Main.dust[num528];
                dust42.velocity.X = dust42.velocity.X * 0.5f;
                var dust43 = Main.dust[num528];
                dust43.velocity.Y = dust43.velocity.Y * 0.1f;
            }
            if (Main.dayTime || dead3)
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
                    NPC.TargetClosest(true);
                    var num530 = 12f;
                    var num531 = 0.4f;
                    var num532 = 1;
                    if (NPC.position.X + NPC.width / 2 < Main.player[NPC.target].position.X + Main.player[NPC.target].width)
                    {
                        num532 = -1;
                    }
                    var vector50 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                    var num533 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 + num532 * 400 - vector50.X;
                    var num534 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector50.Y;
                    var num535 = (float)Math.Sqrt(num533 * num533 + num534 * num534);
                    num535 = num530 / num535;
                    num533 *= num535;
                    num534 *= num535;
                    if (NPC.velocity.X < num533)
                    {
                        NPC.velocity.X = NPC.velocity.X + num531;
                        if (NPC.velocity.X < 0f && num533 > 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X + num531;
                        }
                    }
                    else if (NPC.velocity.X > num533)
                    {
                        NPC.velocity.X = NPC.velocity.X - num531;
                        if (NPC.velocity.X > 0f && num533 < 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X - num531;
                        }
                    }
                    if (NPC.velocity.Y < num534)
                    {
                        NPC.velocity.Y = NPC.velocity.Y + num531;
                        if (NPC.velocity.Y < 0f && num534 > 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y + num531;
                        }
                    }
                    else if (NPC.velocity.Y > num534)
                    {
                        NPC.velocity.Y = NPC.velocity.Y - num531;
                        if (NPC.velocity.Y > 0f && num534 < 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y - num531;
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
                    else
                    {
                        if (!Main.player[NPC.target].dead)
                        {
                            NPC.ai[3] += 1f;
                        }
                        if (NPC.ai[3] >= 60f)
                        {
                            NPC.ai[3] = 0f;
                            vector50 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                            num533 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector50.X;
                            num534 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector50.Y;
                            if (Main.netMode != 1)
                            {
                                num535 = (float)Math.Sqrt(num533 * num533 + num534 * num534);
                                num535 = 12f / num535;
                                num533 *= num535;
                                num534 *= num535;
                                num533 += Main.rand.Next(-40, 41) * 0.05f;
                                num534 += Main.rand.Next(-40, 41) * 0.05f;
                                vector50.X += num533 * 4f;
                                vector50.Y += num534 * 4f;
                                int proj = Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), vector50.X, vector50.Y, num533, num534, ModContent.ProjectileType<Projectiles.WaterFireball>(), 60, 0f, Main.myPlayer, 0f, 0f);
                                //Main.projectile[proj].GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
                            }
                        }
                    }
                }
                else if (NPC.ai[1] == 1f)
                {
                    NPC.rotation = num526;
                    var num539 = 13f;
                    var vector51 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                    var num540 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector51.X;
                    var num541 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector51.Y;
                    var num542 = (float)Math.Sqrt(num540 * num540 + num541 * num541);
                    num542 = num539 / num542;
                    NPC.velocity.X = num540 * num542;
                    NPC.velocity.Y = num541 * num542;
                    NPC.ai[1] = 2f;
                }
                else if (NPC.ai[1] == 2f)
                {
                    NPC.ai[2] += 1f;
                    if (NPC.ai[2] >= 8f)
                    {
                        NPC.velocity.X = NPC.velocity.X * 0.9f;
                        NPC.velocity.Y = NPC.velocity.Y * 0.9f;
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
                    if (NPC.ai[2] >= 42f)
                    {
                        NPC.ai[3] += 1f;
                        NPC.ai[2] = 0f;
                        NPC.target = 255;
                        NPC.rotation = num526;
                        if (NPC.ai[3] >= 10f)
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
                        for (var num543 = 0; num543 < 2; num543++)
                        {
                            Gore.NewGore(NPC.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 144, 1f);
                            Gore.NewGore(NPC.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
                            Gore.NewGore(NPC.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
                        }
                        for (var num544 = 0; num544 < 20; num544++)
                        {
                            Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
                        }
                        SoundEngine.PlaySound(15, (int)NPC.position.X, (int)NPC.position.Y, 0);
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
                NPC.HitSound = SoundID.NPCHit4;
                NPC.damage = (int)(NPC.defDamage * 1.5);
                NPC.defense = NPC.defDefense + 18;
                if (NPC.ai[1] == 0f)
                {
                    var num545 = 4f;
                    var num546 = 0.1f;
                    var num547 = 1;
                    if (NPC.position.X + NPC.width / 2 < Main.player[NPC.target].position.X + Main.player[NPC.target].width)
                    {
                        num547 = -1;
                    }
                    var vector52 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                    var num548 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 + num547 * 180 - vector52.X;
                    var num549 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector52.Y;
                    var num550 = (float)Math.Sqrt(num548 * num548 + num549 * num549);
                    num550 = num545 / num550;
                    num548 *= num550;
                    num549 *= num550;
                    if (NPC.velocity.X < num548)
                    {
                        NPC.velocity.X = NPC.velocity.X + num546;
                        if (NPC.velocity.X < 0f && num548 > 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X + num546;
                        }
                    }
                    else if (NPC.velocity.X > num548)
                    {
                        NPC.velocity.X = NPC.velocity.X - num546;
                        if (NPC.velocity.X > 0f && num548 < 0f)
                        {
                            NPC.velocity.X = NPC.velocity.X - num546;
                        }
                    }
                    if (NPC.velocity.Y < num549)
                    {
                        NPC.velocity.Y = NPC.velocity.Y + num546;
                        if (NPC.velocity.Y < 0f && num549 > 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y + num546;
                        }
                    }
                    else if (NPC.velocity.Y > num549)
                    {
                        NPC.velocity.Y = NPC.velocity.Y - num546;
                        if (NPC.velocity.Y > 0f && num549 < 0f)
                        {
                            NPC.velocity.Y = NPC.velocity.Y - num546;
                        }
                    }
                    NPC.ai[2] += 1f;
                    if (NPC.ai[2] >= 400f)
                    {
                        NPC.ai[1] = 1f;
                        NPC.ai[2] = 0f;
                        NPC.ai[3] = 0f;
                        NPC.target = 255;
                        NPC.netUpdate = true;
                    }
                    if (!Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
                    {
                        return;
                    }
                    NPC.localAI[2] += 1f;
                    if (NPC.localAI[2] > 22f)
                    {
                        NPC.localAI[2] = 0f;
                        SoundEngine.PlaySound(2, (int)NPC.position.X, (int)NPC.position.Y, 34);
                    }
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
                    if (NPC.localAI[1] > 8f)
                    {
                        //SecondStage = true;
                        NPC.localAI[1] = 0f;
                        var num551 = 6f;
                        vector52 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                        num548 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector52.X;
                        num549 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector52.Y;
                        num550 = (float)Math.Sqrt(num548 * num548 + num549 * num549);
                        num550 = num551 / num550;
                        num548 *= num550;
                        num549 *= num550;
                        num549 += Main.rand.Next(-40, 41) * 0.01f;
                        num548 += Main.rand.Next(-40, 41) * 0.01f;
                        num549 += NPC.velocity.Y * 0.5f;
                        num548 += NPC.velocity.X * 0.5f;
                        vector52.X -= num548 * 1f;
                        vector52.Y -= num549 * 1f;
                        int proj = Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), vector52.X, vector52.Y, num548, num549, ModContent.ProjectileType<Projectiles.WaterFlamethrower>(), 40, 0f, Main.myPlayer, 0f, 0f);
                        //Main.projectile[proj].GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
                        return;
                    }
                    return;
                }
                else
                {
                    if (NPC.ai[1] == 1f)
                    {
                        SoundEngine.PlaySound(15, (int)NPC.position.X, (int)NPC.position.Y, 0);
                        NPC.rotation = num526;
                        var num554 = 14f;
                        var vector53 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                        var num555 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector53.X;
                        var num556 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector53.Y;
                        var num557 = (float)Math.Sqrt(num555 * num555 + num556 * num556);
                        num557 = num554 / num557;
                        NPC.velocity.X = num555 * num557;
                        NPC.velocity.Y = num556 * num557;
                        NPC.ai[1] = 2f;
                        return;
                    }
                    if (NPC.ai[1] != 2f)
                    {
                        return;
                    }
                    NPC.ai[2] += 1f;
                    if (NPC.ai[2] >= 50f)
                    {
                        NPC.velocity.X = NPC.velocity.X * 0.93f;
                        NPC.velocity.Y = NPC.velocity.Y * 0.93f;
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
                    if (NPC.ai[2] < 80f)
                    {
                        return;
                    }
                    NPC.ai[3] += 1f;
                    NPC.ai[2] = 0f;
                    NPC.target = 255;
                    NPC.rotation = num526;
                    if (NPC.ai[3] >= 6f)
                    {
                        NPC.ai[1] = 0f;
                        NPC.ai[3] = 0f;
                        return;
                    }
                    NPC.ai[1] = 1f;
                    return;
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter < 7.0)
            {
                NPC.frame.Y = 0;
            }
            else if (NPC.frameCounter < 14.0)
            {
                NPC.frame.Y = frameHeight;
            }
            else if (NPC.frameCounter < 21.0)
            {
                NPC.frame.Y = frameHeight * 2;
            }
            else
            {
                NPC.frameCounter = 0.0;
                NPC.frame.Y = 0;
            }
            if (NPC.ai[0] > 1f)
            {
                NPC.frame.Y = NPC.frame.Y + frameHeight * 3;
            }
        }

        public override void OnKill()
        {
            NPC.SetEventFlagCleared(ref DownedBossSystem.downedWaterBoss, -1);
            if (DownedBossSystem.downedSaturationator && DownedBossSystem.downedWaterBoss && DownedBossSystem.downedHueshifter)
            {
                NPC.SetEventFlagCleared(ref DownedBossSystem.downedSaturationBoss, -1);
            }
        }
    }
}