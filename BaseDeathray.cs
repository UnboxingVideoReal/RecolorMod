using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace RecolorMod
{
    public abstract class BaseDeathray : ModProjectile
    {
        protected float maxTime;
        protected readonly string texture;
        protected readonly float transparency;
        protected readonly float hitboxModifier;
        //by default, real hitbox is slightly more than the "white" of a vanilla ray
        //remember that the value passed into function is total width, i.e. on each side the distance is only half the width

        protected BaseDeathray(float maxTime, string texture, float transparency = 0f, float hitboxModifier = 1f)
        {
            this.maxTime = maxTime;
            this.texture = texture;
            this.transparency = transparency;
            this.hitboxModifier = hitboxModifier;
        }

        public override void SetDefaults() //MAKE SURE YOU CALL BASE.SETDEFAULTS IF OVERRIDING
        {
            Projectile.width = 48;
            Projectile.height = 48;
            Projectile.hostile = true;
            Projectile.alpha = 255;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 600;

            Projectile.hide = true;
        }

        public override void PostAI()
        {
            Projectile.hide = false;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            if (Projectile.velocity == Vector2.Zero)
            {
                return false;
            }
            Texture2D texture2D19 = (Texture2D)TextureAssets.Projectile[Projectile.type];
            Texture2D texture2D20 = ModContent.Request<Texture2D>("RecolorMod/Dedicated/Items/TrueDedicatedStuff/" + texture + "2").Value;
            Texture2D texture2D21 = ModContent.Request<Texture2D>("RecolorMod/Dedicated/Items/TrueDedicatedStuff/" + texture + "3").Value;
            float num223 = Projectile.localAI[1];
            Microsoft.Xna.Framework.Color color44 = new Microsoft.Xna.Framework.Color(255, 255, 255, 0) * 0.95f;
            color44 = Color.Lerp(color44, Color.Transparent, transparency);
            SpriteBatch arg_ABD8_0 = Main.spriteBatch;
            Texture2D arg_ABD8_1 = texture2D19;
            Vector2 arg_ABD8_2 = Projectile.Center - Main.screenPosition;
            Microsoft.Xna.Framework.Rectangle? sourceRectangle2 = null;
            arg_ABD8_0.Draw(arg_ABD8_1, arg_ABD8_2, sourceRectangle2, color44, Projectile.rotation, texture2D19.Size() / 2f, Projectile.scale, SpriteEffects.None, 0f);
            num223 -= (float)(texture2D19.Height / 2 + texture2D21.Height) * Projectile.scale;
            Vector2 value20 = Projectile.Center;
            value20 += Projectile.velocity * Projectile.scale * (float)texture2D19.Height / 2f;
            if (num223 > 0f)
            {
                float num224 = 0f;
                Microsoft.Xna.Framework.Rectangle rectangle7 = new Microsoft.Xna.Framework.Rectangle(0, 16 * (Projectile.timeLeft / 3 % 5), texture2D20.Width, 16);
                while (num224 + 1f < num223)
                {
                    if (num223 - num224 < (float)rectangle7.Height)
                    {
                        rectangle7.Height = (int)(num223 - num224);
                    }
                    Main.spriteBatch.Draw(texture2D20, value20 - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(rectangle7), color44, Projectile.rotation, new Vector2((float)(rectangle7.Width / 2), 0f), Projectile.scale, SpriteEffects.None, 0f);
                    num224 += (float)rectangle7.Height * Projectile.scale;
                    value20 += Projectile.velocity * (float)rectangle7.Height * Projectile.scale;
                    rectangle7.Y += 16;
                    if (rectangle7.Y + rectangle7.Height > texture2D20.Height)
                    {
                        rectangle7.Y = 0;
                    }
                }
            }
            SpriteBatch arg_AE2D_0 = Main.spriteBatch;
            Texture2D arg_AE2D_1 = texture2D21;
            Vector2 arg_AE2D_2 = value20 - Main.screenPosition;
            sourceRectangle2 = null;
            arg_AE2D_0.Draw(arg_AE2D_1, arg_AE2D_2, sourceRectangle2, color44, Projectile.rotation, texture2D21.Frame(1, 1, 0, 0).Top(), Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }

        public override void CutTiles()
        {
            DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
            Vector2 unit = Projectile.velocity;
            Utils.PlotTileLine(Projectile.Center, Projectile.Center + unit * Projectile.localAI[1], (float)Projectile.width * Projectile.scale, new Utils.TileActionAttempt(DelegateMethods.CutTiles));
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (projHitbox.Intersects(targetHitbox))
            {
                return true;
            }
            float num6 = 0f;
            if (Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center, Projectile.Center + Projectile.velocity * Projectile.localAI[1], 22f * Projectile.scale * hitboxModifier, ref num6))
            {
                return true;
            }
            return false;
        }
    }
}
