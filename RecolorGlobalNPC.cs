using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod
{
	public class RecolorGlobalNPC : GlobalNPC
	{
        public static int gsInferno;

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
    }
}
