﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using RecolorMod.Items.Developer;
using Terraria.Audio;

namespace RecolorMod
{
    public class RecolorUtils
    {
        Item item = new Item();
        Player player = new Player();
        public float actualKnockback = 0f;
        public static bool stopTheFuckingSound = true;

        public static void PlayAchievementSound()
        {
            stopTheFuckingSound = true;
            if (stopTheFuckingSound)
            {
                Terraria.Audio.SoundEngine.PlaySound(SoundID.AchievementComplete);
                stopTheFuckingSound = false;
            }
        }

        public static int SecondsToFrames(float seconds)
        {
            return (int)(seconds * 60f);
        }

        public static void Inflict246DebuffsNPC(NPC target, int buff, float timeBase = 2f)
        {
            if (Utils.NextBool(Main.rand, 4))
            {
                target.AddBuff(buff, SecondsToFrames(timeBase * 3f));
            }
            else if (Utils.NextBool(Main.rand, 2))
            {
                target.AddBuff(buff, SecondsToFrames(timeBase * 2f));
            }
            else
            {
                target.AddBuff(buff, SecondsToFrames(timeBase));
            }
        }


        public static void GenerateOre(int firstThing, int secondThing, int whatIsThis, int whatIsThis2, ushort tileToGenerate)
        {
            WorldGen.OreRunner(firstThing, secondThing, whatIsThis, whatIsThis2, tileToGenerate);
        }

        public void GetItemGlowmaskInWorld(string glowTexturePath, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>(glowTexturePath).Value;
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }

        public static void RainbowTile(int i, int j, string texturePath, string texturePathDirt)
        {
            Tile tile = Main.tile[i, j];
            Texture2D texture;
            //if (Main.canDrawColorTile(i, j))
            //{
            texture = ModContent.Request<Texture2D>(texturePath).Value;
            //}
            //else
            //{
            //	texture = Textur;
            //}
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, 16), new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);

            Texture2D texture2 = ModContent.Request<Texture2D>(texturePathDirt).Value;
            Main.spriteBatch.Draw(texture2, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, 16), Color.White, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        }

        //public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        //{
        //	Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Items/Pickaxe/NebulaPicksaw_Glow").Value;
        //	spriteBatch.Draw
        //	(
        //		texture,
        //		new Vector2
        //		(
        //			Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
        //			Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
        //		),
        //		new Rectangle(0, 0, texture.Width, texture.Height),
        //		Color.White,
        //		rotation,
        //		texture.Size() * 0.5f,
        //		scale,
        //		SpriteEffects.None,
        //		0f
        //	);
        //}

        //public static void GetRarities()
        //{
        //    switch (2)
        //    {
        //        case ItemRarityID.among:
        //            ModContent.RarityType<Rarities.UltraBlueRarity>();
        //            break;
        //        case (int)CustomRarities.Debug:
        //            ModContent.RarityType<Rarities.DebugRarity>();
        //            break;
        //    }
        //}

        public static Color GetRandomRarity(int rarityId)
        {
            Color c = default(Color);
            if (rarityId == 1)
            {
                c = new Color(255, 255, 255);
            }
            else if (rarityId == 2)
            {
                c = new Color(150, 150, 255);
            }
            else if (rarityId == 3)
            {
                c = new Color(255, 200, 150);
            }
            else if (rarityId == 4)
            {
                c = new Color(255, 150, 150);
            }
            else if (rarityId == 5)
            {
                c = new Color(255, 150, 255);
            }
            else if (rarityId == 6)
            {
                c = new Color(210, 160, 255);
            }
            else if (rarityId == 7)
            {
                c = new Color(150, 255, 10);
            }
            else if (rarityId == 8)
            {
                c = new Color(255, 255, 10);
            }
            else if (rarityId == 9)
            {
                c = new Color(5, 200, 255);
            }
            else if (rarityId == 10)
            {
                c = new Color(130, 130, 130);
            }
            else if (rarityId == 11)
            {
                c = new Color(255, 175, 0);
            }
            else if (rarityId == 12)
            {
                c = new Color(220, 220, 198);
            }
            else if (rarityId == 13)
            {
                c = new Color(224, 201, 92);
            }
            else if (rarityId == 14)
            {
                c = new Color(181, 192, 193);
            }
            else if (rarityId == 15)
            {
                c = new Color(246, 138, 96);
            }
            else if (rarityId == 16)
            {
                c = Color.Lerp(Color.HotPink, Color.White, 0.1f);
            }
            else if (rarityId == 17)
            {
                c = new Color(1f, 0.6f, 0f);
            }
            else if (rarityId == 18)
            {
                c = new Color(1f, 0.15f, 0.1f);
            }
            else if (rarityId == 19)
            {
                c = new Color(0, 0, 0);
            }
            else if (rarityId == 20)
            {
                c = new Color(21, 0, 128);
            }
            return c;
        }

        public static void RandomQuote()
        {
            UnboxingEnchant.Counter++;
            if (UnboxingEnchant.Counter >= 130)
            {
                UnboxingEnchant.thing++;
                if (UnboxingEnchant.thing == 1)
                {
                    UnboxingEnchant.theString = (string)UnboxingEnchant.possibleQuotes.GetValue(1);
                }
                else if (UnboxingEnchant.thing == 2)
                {
                    UnboxingEnchant.theString = (string)UnboxingEnchant.possibleQuotes.GetValue(2);
                }
                else if (UnboxingEnchant.thing == 3)
                {
                    UnboxingEnchant.theString = (string)UnboxingEnchant.possibleQuotes.GetValue(3);
                }
                else if (UnboxingEnchant.thing == 4)
                {
                    UnboxingEnchant.theString = (string)UnboxingEnchant.possibleQuotes.GetValue(4);
                }
                else if (UnboxingEnchant.thing == 5)
                {
                    UnboxingEnchant.theString = (string)UnboxingEnchant.possibleQuotes.GetValue(5);
                }
                else if (UnboxingEnchant.thing == 6)
                {
                    UnboxingEnchant.theString = (string)UnboxingEnchant.possibleQuotes.GetValue(6);
                }
                else if (UnboxingEnchant.thing == 7)
                {
                    UnboxingEnchant.theString = (string)UnboxingEnchant.possibleQuotes.GetValue(7);
                }
                else if (UnboxingEnchant.thing == 8)
                {
                    UnboxingEnchant.theString = (string)UnboxingEnchant.possibleQuotes.GetValue(8);
                }
                else if (UnboxingEnchant.thing == 9)
                {
                    UnboxingEnchant.theString = (string)UnboxingEnchant.possibleQuotes.GetValue(9);
                }
                else if (UnboxingEnchant.thing == 10)
                {
                    UnboxingEnchant.theString = (string)UnboxingEnchant.possibleQuotes.GetValue(10);
                }
                if (UnboxingEnchant.thing > 10)
                {
                    UnboxingEnchant.thing = 0;
                }
                UnboxingEnchant.Counter = 0;
            }
        }

        public static void DisplayLocalizedText(string key, Color? textColor = null)
        {
            if (!textColor.HasValue)
            {
                textColor = Color.White;
            }
            if (Main.netMode == 0)
            {
                Main.NewText(Language.GetTextValue(key, textColor.Value, false));
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromKey(key), textColor.Value, -1);
            }
            //}
        }
    }
}