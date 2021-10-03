using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Microsoft.Xna.Framework;
using RecolorMod.Projectiles;

namespace RecolorMod
{
    public class RecolorPlayer : ModPlayer
    {
        public static bool playerPositionsOn;
        public static bool playerX;
        public static bool playerY;
        public static bool doItemStuff;
        public bool unboxingEnchInflicts;
        public bool stopSpawningTheFuckingPets = true; 
        Player player = new Player();
        public bool gsInferno;
        public bool starburn;
        public bool UnboxingEffectBool;
        public bool BismuthEffectBool;
        public bool PetsActive = true;

        public override void ResetEffects()
        {
            playerPositionsOn = false;
            playerX = false;
            playerY = false;
            gsInferno = false;
            starburn = false;
            unboxingEnchInflicts = false;
            UnboxingEffectBool = false;
            BismuthEffectBool = false;
            stopSpawningTheFuckingPets = false;
            doItemStuff = false;
        }

        public override void UpdateDead()
        {
            gsInferno = false;
            starburn = false;
            stopSpawningTheFuckingPets = false;
            doItemStuff = false;
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (gsInferno && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
            {
                damageSource = PlayerDeathReason.ByCustomReason(player.name + "'s soul was extinguished.");
            }
            return true;
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (unboxingEnchInflicts)
            {
                RecolorUtils.Inflict246DebuffsNPC(npc, ModContent.BuffType<Buffs.GodSlayerInferno>());
                RecolorUtils.Inflict246DebuffsNPC(npc, BuffID.Electrified);
                RecolorUtils.Inflict246DebuffsNPC(npc, BuffID.CursedInferno);
                RecolorUtils.Inflict246DebuffsNPC(npc, BuffID.OnFire);
                RecolorUtils.Inflict246DebuffsNPC(npc, BuffID.Venom);
            }
        }

        public void BismuthEffect()
        {
            BismuthEffectBool = true;

            int dmg = 400;

            //AddMinion(ModContent.ProjectileType<BismuthPickaxeSummon>(), (int)(dmg * player.GetDamage(DamageClass.Summon)), 0f);
            Projectile.NewProjectile(Projectile.GetNoneSource(), Player.Center.X, Player.Center.Y, 0f, -1f, ModContent.ProjectileType<BismuthPickaxeSummon>(), (int)(dmg * player.GetDamage(DamageClass.Summon)), 0f, Main.myPlayer);

            //AddMinion(ModContent.ProjectileType<BismuthAxeSummon>(), (int)(dmg * player.GetDamage(DamageClass.Summon)), 0f);
            Projectile.NewProjectile(Projectile.GetNoneSource(), Player.Center.X, Player.Center.Y, 0f, -1f, ModContent.ProjectileType<BismuthAxeSummon>(), (int)(dmg * player.GetDamage(DamageClass.Summon)), 0f, Main.myPlayer);

        }

        public void AddMinion(int proj, int damage, float knockback)
        {
            stopSpawningTheFuckingPets = true;
            if (stopSpawningTheFuckingPets/* && player.ownedProjectileCounts[proj] < 0 && player.whoAmI == Main.myPlayer*/)
            {
                Projectile pro = Main.projectile[Projectile.NewProjectile(Projectile.GetNoneSource(), Player.Center.X, Player.Center.Y, 0f, -1f, proj, damage, knockback, Main.myPlayer)];
                pro.netUpdate = true;
                stopSpawningTheFuckingPets = false;
            }
        }
        public override void UpdateEquips()
        {
            if (playerX && playerY)
                playerPositionsOn = true;
        }
        #region enchantment stuff here 
        public void UnboxingEffect()
        {
            UnboxingEffectBool = true;
            #region prism orb things
            int currentOrbs = (Player.ownedProjectileCounts[ModContent.ProjectileType<PrismOrb>()]);
            int max = ModContent.GetInstance<RecolorConfig>().prismOrbMax;
            if (currentOrbs == 0)
            {
                float rotation = (float)Math.PI * 2f / (float)max;
                for (int k = 0; k < max; k++)
                {
                    int p2 = Projectile.NewProjectile(Projectile.GetNoneSource(), Player.Center + new Vector2(60f, 0f).RotatedBy(rotation * (float)k), Vector2.Zero, ModContent.ProjectileType<PrismOrb>(), 0, 10f, Player.whoAmI, 0f, rotation * (float)k);                }
            }
            else
            {
                if (currentOrbs == max)
                {
                    return;
                }
                for (int j = 0; j < 1000; j++)
                {
                    Projectile proj = Main.projectile[j];
                    if (proj.active && proj.type == ModContent.ProjectileType<PrismOrb>() && proj.owner == Player.whoAmI)
                    {
                        proj.Kill();
                    }
                }
                float rotation = (float)Math.PI * 2f / (float)max;
                for (int i = 0; i < max; i++)
                {
                    int p = Projectile.NewProjectile(Projectile.GetNoneSource(), Player.Center + new Vector2(60f, 0f).RotatedBy(rotation * (float)i), Vector2.Zero, ModContent.ProjectileType<PrismOrb>(), 0, 10f, Player.whoAmI, 0f, rotation * (float)i);
                }
            }
            #endregion
            //#region bismuth ring
            //int dmg = 300;

            //const int max2 = 5;
            //float rotation2 = 2f * (float)Math.PI / max2;

            //for (int i = 0; i < max2; i++)
            //{
            //    Vector2 spawnPos = player.Center + new Vector2(60, 0f).RotatedBy(rotation2 * i);
            //    int p = Projectile.NewProjectile(Projectile.GetNoneSource(), spawnPos, Vector2.Zero, ModContent.ProjectileType<BismuthCrystal>(), dmg, 10f, player.whoAmI, 0, rotation2 * i);
            //    Main.projectile[p].netUpdate = true;
            //}
            //#endregion
        }
        #region other stuff
        public void UnboxingOtherEffect()
        {
            #region aura stuff
            UnboxingEffectBool = true;
            int dist = 1000;

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && !npc.friendly && npc.lifeMax > 5 && npc.Distance(player.Center) < dist)
                {
                    npc.AddBuff(ModContent.BuffType<Buffs.GodSlayerInferno>(), 15);
                    npc.AddBuff(BuffID.Electrified, 15);
                    npc.AddBuff(BuffID.CursedInferno, 15);
                    npc.AddBuff(BuffID.OnFire, 15);
                    npc.AddBuff(BuffID.Venom, 15);
                }

            }
            #endregion

            //for (int i = 0; i < 20; i++)
            //{
            //    Vector2 offset = new Vector2();
            //    double angle = Main.rand.NextDouble() * 2d * Math.PI;
            //    offset.X += (float)(Math.Sin(angle) * dist);
            //    offset.Y += (float)(Math.Cos(angle) * dist);
            //    if (!Collision.SolidCollision(player.Center + offset - new Vector2(4, 4), 0, 0))
            //    {
            //        Dust dust = Main.dust[Dust.NewDust(
            //          player.Center + offset - new Vector2(4, 4), 0, 0,
            //          DustID.Electric, 0, 0, 100, Color.White, 1f
            //          )];
            //        dust.velocity = player.velocity;
            //        if (Main.rand.Next(3) == 0)
            //            dust.velocity += Vector2.Normalize(offset) * -5f;
            //        dust.noGravity = true;
            //    }
            //}
        }
        #endregion
        #endregion
        public override void OnEnterWorld(Player player)
        {
            //RecolorUtils.GetRarities();
            RecolorUtils.stopTheFuckingSound = true;
        }
    }
}
