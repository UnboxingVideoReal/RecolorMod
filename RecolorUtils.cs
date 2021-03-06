using System;
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
using Terraria.Graphics.Shaders;
using Terraria.Utilities;
using Terraria.UI.Chat;

namespace RecolorMod
{
    public class RecolorUtils
    {
        public static Color AchievementColor = new Color(0, 255, 0);
        public static Color ClericColor = new Color(0, 255, 255);
        public static Color GoalColor = new Color(0, 0, 255);
        public static Color ChallengeColor = new Color(255, 0, 0);
        Item item = new Item();
        public static string none = "RecolorMod/None";
        Player player = new Player();
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
        public static void LargeNumberDisplay(NPC npc, int damage, Rectangle rect, Color color, string text)
        {
            npc.life -= damage;
            CombatText.NewText(rect, color, text);
        }
        public static float GetBulletRotation(Projectile projectile)
        {
            return projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
        }

        public static int SecondsToFrames(float seconds)
        {
            return (int)(seconds * 60f);
        }

        public static bool FargosColorThing(DrawableTooltipLine line, ref int yOffset, Color useColor, Color colorSecondary, Color color2thing, string mod, string Name)
        {
            if (line.mod == mod && line.Name == Name)
            {
                Main.spriteBatch.End(); //end and begin main.spritebatch to apply a shader
                Main.spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
                var lineshader = GameShaders.Misc["PulseCircle"].UseColor(useColor).UseSecondaryColor(colorSecondary);
                lineshader.Apply(null);
                Utils.DrawBorderString(Main.spriteBatch, line.text, new Vector2(line.X, line.Y), color2thing, 1); //draw the tooltip manually
                Main.spriteBatch.End(); //then end and begin again to make remaining tooltip lines draw in the default way
                Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Main.UIScaleMatrix);
                return false;
            }
            return true;
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

        public static float Wave(float time, float minimum, float maximum)
        {
            return minimum + ((float)Math.Sin(time) + 1f) / 2f * (maximum - minimum);
        }

        public static void DedicatedItemStuff(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(RecolorMod.ModInstance, "Dedicated", "Dedicated"));
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "RecolorMod" && tooltipLine.Name == "Dedicated")
                {
                    tooltipLine.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
                }
            }
        }
        public static void OverrideDamage(List<TooltipLine> tooltips, string customDamage)
        {
            int dmg = tooltips.FindIndex(x => x.Name == "Damage");
            tooltips.RemoveAt(dmg);
            tooltips.Insert(dmg, new TooltipLine(RecolorMod.ModInstance, "Damage", customDamage + " damage"));
        }

        public static void DedicatedItemStuff(List<TooltipLine> tooltips, Color color)
        {
            tooltips.Add(new TooltipLine(RecolorMod.ModInstance, "Dedicated", "Dedicated"));
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "RecolorMod" && tooltipLine.Name == "Dedicated")
                {
                    tooltipLine.overrideColor = color;
                }
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

        public static void ColorTile(int i, int j, string texturePath, string texturePathDirt, Color color)
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
            Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, 16), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);

            Texture2D texture2 = ModContent.Request<Texture2D>(texturePathDirt).Value;
            Main.spriteBatch.Draw(texture2, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, 16), Color.White, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
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

        public static Color ColorSwap(Color firstColor, Color secondColor, float seconds)
        {
            float colorMePurple = (float)((Math.Sin((double)((float)Math.PI * 2f / seconds) * (double)Main.GlobalTimeWrappedHourly) + 1.0) * 0.5);
            return Color.Lerp(firstColor, secondColor, colorMePurple);
        }

        public static Color MultiColorSwap(Color[] colors, float seconds)
        {
            float colorMePurple = (float)((Math.Sin((double)((float)Math.PI * 2f / seconds) * (double)Main.GlobalTimeWrappedHourly) + 1.0) * 0.5);
            return MulticolorLerp(colorMePurple, colors);
        }

        public static Color QuadColorSwap(Color firstColor, Color secondColor, Color thirdColor, Color fourthColor/*, float seconds*/)
        {
            List<Color> colors = new List<Color>
                        {
                            firstColor,
                            secondColor,
                            thirdColor,
                            fourthColor
                        };
            int colorIndex2 = (int)(Main.GlobalTimeWrappedHourly / 2f % (float)colors.Count);
            Color currentColor = colors[colorIndex2];
            Color nextColor = colors[(colorIndex2 + 1) % colors.Count];
            return Color.Lerp(currentColor, nextColor, (Main.GlobalTimeWrappedHourly % 2f > 1f) ? 1f : (Main.GlobalTimeWrappedHourly % 1f));
        }

        public static Color QuintColorSwap(Color firstColor, Color secondColor, Color thirdColor, Color fourthColor, Color fifthColor/*, float seconds*/)
        {
            List<Color> colors = new List<Color>
                        {
                            firstColor,
                            secondColor,
                            thirdColor,
                            fourthColor,
                            fifthColor
                        };
            int colorIndex2 = (int)(Main.GlobalTimeWrappedHourly / 2f % (float)colors.Count);
            Color currentColor = colors[colorIndex2];
            Color nextColor = colors[(colorIndex2 + 1) % colors.Count];
            return Color.Lerp(currentColor, nextColor, (Main.GlobalTimeWrappedHourly % 2f > 1f) ? 1f : (Main.GlobalTimeWrappedHourly % 1f));
        }

        public static Color MulticolorLerp(float increment, params Color[] colors)
        {
            int currentColorIndex = (int)(increment * (float)colors.Length);
            Color value = colors[currentColorIndex];
            Color nextColor = colors[(currentColorIndex + 1) % colors.Length];
            return Color.Lerp(value, nextColor, increment * (float)colors.Length % 1f);
        }

        //public static void DrawNarrizuulText(DrawableTooltipLine line)
        //{
        //    DrawNarrizuulText(line.text, line.X, line.Y, line.rotation, line.origin, line.baseScale, line.overrideColor.GetValueOrDefault(line.color));
        //}

        //public static void DrawNarrizuulText(string text, int x, int y, float rotation, Vector2 origin, Vector2 baseScale, Color color)
        //{
        //    if (string.IsNullOrWhiteSpace(text)) // since you can rename items.
        //    {
        //        return;
        //    }
        //    var font = Terraria.Font;
        //    var size = font.MeasureString(text);
        //    var center = size / 2f;
        //    var transparentColor = color * 0.4f;
        //    transparentColor.A = 0;
        //    var texture = AQTextures.Lights[LightTex.Spotlight12x66];
        //    var spotlightOrigin = texture.Size() / 2f;
        //    float spotlightRotation = rotation + MathHelper.PiOver2;
        //    var spotlightScale = new Vector2(1.2f + (float)Math.Sin(Main.GlobalTime * 4f) * 0.145f, center.Y * 0.15f);

        //    // black BG
        //    Main.spriteBatch.Draw(texture, new Vector2(x, y - 6f) + center, null, Color.Black * 0.3f, rotation,
        //    spotlightOrigin, new Vector2(size.X / texture.Width * 2f, center.Y / texture.Height * 2.5f), SpriteEffects.None, 0f);
        //    ChatManager.DrawColorCodedStringShadow(Main.spriteBatch, font, text, new Vector2(x, y), Color.Black,
        //        rotation, origin, baseScale);

        //    // particles
        //    var rand = new UnifiedRandom(Main.LocalPlayer.name.GetHashCode() + text.GetHashCode());
        //    var particleTexture = AQTextures.Lights[LightTex.Spotlight15x15];
        //    var particleOrigin = particleTexture.Size() / 2f;
        //    int amt = rand.Next((int)size.X / 3, (int)size.X);
        //    for (int i = 0; i < amt; i++)
        //    {
        //        float lifeTime = rand.NextFloat(20f);
        //        int baseParticleX = rand.Next(4, (int)size.X - 4);
        //        int particleX = baseParticleX + (int)RecolorUtils.Wave(lifeTime + Main.GlobalTimeWrappedHourly * rand.NextFloat(2f, 5f), -rand.NextFloat(3f, 10f), rand.NextFloat(3f, 10f));
        //        lifeTime += Main.GlobalTimeWrappedHourly * 2f;
        //        lifeTime %= 20f;
        //        int particleY = rand.Next(10);
        //        float scale = rand.NextFloat(0.2f, 0.4f);
        //        if (baseParticleX > 14 && baseParticleX < size.X - 14 && rand.NextBool(6))
        //        {
        //            scale *= 2f;
        //        }
        //        if (lifeTime < 5f)
        //        {
        //            var clr = color;
        //            if (lifeTime < 0.3f)
        //            {
        //                clr *= lifeTime / 0.3f;
        //            }
        //            if (lifeTime > MathHelper.PiOver2)
        //            {
        //                float timeMult = (lifeTime - MathHelper.PiOver2) / MathHelper.PiOver2;
        //                scale -= timeMult * 0.4f;
        //                if (scale < 0f)
        //                {
        //                    continue;
        //                }


        //                //public static Color ThreeColorSwap()
        //                //{
        //                //    List<Color> colors = new List<Color>
        //                //                {
        //                //                    new Color(255, 99, 146),
        //                //                    new Color(255, 228, 94),
        //                //                    new Color(127, 200, 248)
        //                //                };
        //                //        int colorIndex2 = (int)(Main.GlobalTimeWrappedHourly / 2f % (float)colors.Count);
        //                //        Color currentColor = colors[colorIndex2];
        //                //        Color nextColor = colors[(colorIndex2 + 1) % colors.Count];
        //                //        return Color.Lerp(currentColor, nextColor, (Main.GlobalTimeWrappedHourly % 2f > 1f) ? 1f : (Main.GlobalTimeWrappedHourly % 1f));
        //                //}

        //                //public void DrawItemGlowmaskSingleFrame(SpriteBatch spriteBatch, float rotation, Texture2D glowmaskTexture)
        //                //{
        //                //    Item item = new Item();
        //                //    spriteBatch.Draw(origin: new Vector2((float)glowmaskTexture.Width / 2f, (float)glowmaskTexture.Height / 2f - 2f), texture: glowmaskTexture, position: item.Center - Main.screenPosition, sourceRectangle: null, color: Color.White, rotation: rotation, scale: 1f, effects: SpriteEffects.None, layerDepth: 0f);
        //                //}
        //            }
        //        }
        //    }
        //}
    }
}
