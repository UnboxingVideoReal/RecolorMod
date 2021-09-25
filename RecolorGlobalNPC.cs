using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod
{
	public class RecolorGlobalNPC : GlobalNPC
	{
        public static int gsInferno;
        public static string recolorsDirectory = "RecolorMod/NPCs/Recolors/";

        public override void OnKill(NPC npc)
        {
            if (npc.type == NPCID.MoonLordCore)
            {
                var type8 = 0;
                float num285 = 0;
                type8 = ModContent.TileType<Tiles.BismuthOre>();
                num285 = Main.maxTilesX * 0.2f;
                var num287 = WorldGen.genRand.Next(0, Main.maxTilesX);
                var num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
                while (Main.tile[num287, num288].type != 1)
                {
                    num287 = WorldGen.genRand.Next(0, Main.maxTilesX);
                    num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
                }
                RecolorUtils.GenerateOre(num287, num288, ModContent.GetInstance<RecolorConfig>().bismuthOreStrength/*WorldGen.genRand.Next(10, 20)*/, WorldGen.genRand.Next(3, 7), (ushort)type8);
                //WorldGen.OreRunner(num287, num288, 250/*WorldGen.genRand.Next(10, 20)*/, WorldGen.genRand.Next(3, 7), (ushort)type8);
                //RecolorUtils.DisplayLocalizedText("Your world has been blessed with Bismuth!", new Color(0, 0, 255));
            }
            if (npc.type == ModContent.NPCType<NPCs.Waterblaster>())
            {
                var obscuritium = 0;
                float num285 = 0;
                obscuritium = ModContent.TileType<Tiles.Obscuritium>();
                num285 = Main.maxTilesX * 0.2f;
                var num287 = WorldGen.genRand.Next(0, Main.maxTilesX);
                var num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
                while (Main.tile[num287, num288].type != 1)
                {
                    num287 = WorldGen.genRand.Next(0, Main.maxTilesX);
                    num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
                }
                RecolorUtils.GenerateOre(num287, num288, 30/*WorldGen.genRand.Next(10, 20)*/, WorldGen.genRand.Next(3, 7), (ushort)obscuritium);
                //WorldGen.OreRunner(num287, num288, 250/*WorldGen.genRand.Next(10, 20)*/, WorldGen.genRand.Next(3, 7), (ushort)type8);
                //RecolorUtils.DisplayLocalizedText("Your world has been blessed with Bismuth!", new Color(0, 0, 255));
            }
            if (npc.type == ModContent.NPCType<NPCs.Saturationator>())
            {
                var saturite = 0;
                float num285 = 0;
                saturite = ModContent.TileType<Tiles.Saturite>();
                num285 = Main.maxTilesX * 0.2f;
                var num287 = WorldGen.genRand.Next(0, Main.maxTilesX);
                var num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
                while (Main.tile[num287, num288].type != 1)
                {
                    num287 = WorldGen.genRand.Next(0, Main.maxTilesX);
                    num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
                }
                RecolorUtils.GenerateOre(num287, num288, 30/*WorldGen.genRand.Next(10, 20)*/, WorldGen.genRand.Next(3, 7), (ushort)saturite);
                //WorldGen.OreRunner(num287, num288, 250/*WorldGen.genRand.Next(10, 20)*/, WorldGen.genRand.Next(3, 7), (ushort)type8);
                //RecolorUtils.DisplayLocalizedText("Your world has been blessed with Bismuth!", new Color(0, 0, 255));
            }
            if (npc.type == ModContent.NPCType<NPCs.Hueshifter>())
            {
                var huetite = 0;
                float num285 = 0;
                huetite = ModContent.TileType<Tiles.Huetite>();
                num285 = Main.maxTilesX * 0.2f;
                var num287 = WorldGen.genRand.Next(0, Main.maxTilesX);
                var num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
                while (Main.tile[num287, num288].type != 1)
                {
                    num287 = WorldGen.genRand.Next(0, Main.maxTilesX);
                    num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
                }
                RecolorUtils.GenerateOre(num287, num288, 30/*WorldGen.genRand.Next(10, 20)*/, WorldGen.genRand.Next(3, 7), (ushort)huetite);
                //WorldGen.OreRunner(num287, num288, 250/*WorldGen.genRand.Next(10, 20)*/, WorldGen.genRand.Next(3, 7), (ushort)type8);
                //RecolorUtils.DisplayLocalizedText("Your world has been blessed with Bismuth!", new Color(0, 0, 255));
            }

        }

        public override void PostAI(NPC npc)
        {
            if (gsInferno > 0)
            {
                gsInferno--;
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (gsInferno > 0)
            {
                if (Main.rand.Next(5) < 4)
                {
                    int dust13 = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 173, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                    Main.dust[dust13].noGravity = true;
                    Main.dust[dust13].velocity *= 1.2f;
                    Main.dust[dust13].velocity.Y -= 0.15f;
                    if (Utils.NextBool(Main.rand, 4))
                    {
                        Main.dust[dust13].noGravity = false;
                        Main.dust[dust13].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0f, 0.135f);
            }
        }

        public void ApplyDPSDebuff(int debuff, int lifeRegenValue, int damageValue, ref int lifeRegen, ref int damage)
        {
            if (debuff > 0)
            {
                if (lifeRegen > 0)
                {
                    lifeRegen = 0;
                }
                lifeRegen -= lifeRegenValue;
                if (damage < damageValue)
                {
                    damage = damageValue;
                }
            }
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            ApplyDPSDebuff(gsInferno, 250, 50, ref npc.lifeRegen, ref damage);
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.MoonLordCore)
            {
                npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("Aquamarine").Type, 1, 25, 40));
            }
            if (npc.type == NPCID.MoonLordHand)
            {
                npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("Aquamarine").Type, 1, 5, 10));
            }
            if (npc.type == NPCID.MoonLordHead)
            {
                npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("Aquamarine").Type, 1, 10, 15));
            }
        }

        public override void SetDefaults(NPC npc)
        {
            LoadSprites(npc);
        }

        private void LoadSprites(NPC npc)
        {
            if (Main.dedServ || Main.netMode == NetmodeID.Server)
                return;

            bool recolor = ModContent.GetInstance<RecolorConfig>().Recolors && Main.getGoodWorld;
            if (recolor)
            {
                switch (npc.type)
                {
                    case NPCID.ServantofCthulhu:
                        TextureAssets.Npc[5] = ModContent.Request<Texture2D>(GetRecolor("NPC_5"));
                        break;
                    case NPCID.EaterofWorldsHead:
                        TextureAssets.Npc[13] = ModContent.Request<Texture2D>(GetRecolor("NPC_" + NPCID.EaterofWorldsHead.ToString()));
                        break;
                    case NPCID.EaterofWorldsBody:
                        TextureAssets.Npc[14] = ModContent.Request<Texture2D>(GetRecolor("NPC_" + NPCID.EaterofWorldsBody.ToString()));
                        break;
                    case NPCID.EaterofWorldsTail:
                        TextureAssets.Npc[15] = ModContent.Request<Texture2D>(GetRecolor("NPC_" + NPCID.EaterofWorldsTail.ToString()));
                        break;
                    case NPCID.Creeper:
                        TextureAssets.Npc[267] = ModContent.Request<Texture2D>(GetRecolor("NPC_" + NPCID.Creeper.ToString()));
                        break;
                    case NPCID.SkeletronHand:
                        TextureAssets.Npc[36] = ModContent.Request<Texture2D>(GetRecolor("NPC_" + NPCID.SkeletronHand.ToString()));
                        break;
                    case NPCID.WallofFleshEye:
                        TextureAssets.Npc[114] = ModContent.Request<Texture2D>(GetRecolor("NPC_" + NPCID.WallofFleshEye.ToString()));
                        break;
                    case NPCID.TheHungry:
                        TextureAssets.Npc[115] = ModContent.Request<Texture2D>(GetRecolor("NPC_" + NPCID.TheHungry.ToString()));
                        break;
                    case NPCID.TheHungryII:
                        TextureAssets.Npc[116] = ModContent.Request<Texture2D>(GetRecolor("NPC_" + NPCID.TheHungryII.ToString()));
                        break;
                    case NPCID.LeechHead:
                        TextureAssets.Npc[117] = ModContent.Request<Texture2D>(GetRecolor("NPC_" + NPCID.LeechHead.ToString()));
                        break;
                    case NPCID.LeechBody:
                        TextureAssets.Npc[118] = ModContent.Request<Texture2D>(GetRecolor("NPC_" + NPCID.LeechBody.ToString()));
                        break;
                    case NPCID.LeechTail:
                        TextureAssets.Npc[119] = ModContent.Request<Texture2D>(GetRecolor("NPC_" + NPCID.LeechTail.ToString()));
                        break;
                    case NPCID.TheDestroyerBody:
                    case NPCID.TheDestroyerTail:
                    case NPCID.WallofFlesh:
                        TextureAssets.Npc[113] = ModContent.Request<Texture2D>(GetRecolor("NPC_" + NPCID.WallofFlesh.ToString()));
                        break;
                    case NPCID.Probe:
                    case NPCID.PrimeCannon:
                    case NPCID.PrimeSaw:
                    case NPCID.PrimeVice:
                    case NPCID.PrimeLaser:
                    case NPCID.PlanterasHook:
                    case NPCID.PlanterasTentacle:
                    case NPCID.Spore:
                    case NPCID.GolemFistLeft:
                    case NPCID.GolemFistRight:
                    case NPCID.GolemHead:
                    case NPCID.GolemHeadFree:
                    case NPCID.Sharkron:
                    case NPCID.Sharkron2:
                    case NPCID.CultistBossClone:
                    case NPCID.MoonLordFreeEye:
                    case NPCID.MoonLordHand:
                    case NPCID.MoonLordHead:
                    case NPCID.MoonLordLeechBlob:
                    case NPCID.EyeofCthulhu:
                        TextureAssets.Npc[4] = ModContent.Request<Texture2D>(recolorsDirectory + "NPC_4");
                        //Main.npcHeadBossTexture[0] = Mod.GetTexture((recolor ? "NPCs/Resprites/" : "NPCs/Vanilla/") + "NPC_Head_Boss_0");
                        //Main.npcHeadBossTexture[1] = Mod.GetTexture((recolor ? "NPCs/Resprites/" : "NPCs/Vanilla/") + "NPC_Head_Boss_1");
                        //TextureAssets.Gore[6] = ModContent.Request<Texture2D>("RecolorMod/NPCs/Recolors/");
                        //TextureAssets.Gore[7] = Mod.GetTexture((recolor ? "NPCs/Resprites/Gores/" : "NPCs/Vanilla/Gores/") + "Gore_7");
                        //TextureAssets.Gore[8] = Mod.GetTexture((recolor ? "NPCs/Resprites/Gores/" : "NPCs/Vanilla/Gores/") + "Gore_8");
                        //TextureAssets.Gore[9] = Mod.GetTexture((recolor ? "NPCs/Resprites/Gores/" : "NPCs/Vanilla/Gores/") + "Gore_9");
                        //TextureAssets.Gore[10] = Mod.GetTexture((recolor ? "NPCs/Resprites/Gores/" : "NPCs/Vanilla/Gores/") + "Gore_10");
                        break;

                    default:
                        break;
                }
            }
        }

        public string GetRecolor(string thingToReplace)
        {
            return recolorsDirectory + thingToReplace;
        }
    }
}
