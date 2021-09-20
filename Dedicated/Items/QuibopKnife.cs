using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using RecolorMod.Items.Developer;
using RecolorMod.Items;
using System.Collections.Generic;
using Terraria.DataStructures;
using System;

namespace RecolorMod.Dedicated.Items
{
    public class QuibopKnife : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quibop's Knife");
            Tooltip.SetDefault("Critical Chance increased by 100\nRight-Click to shoot a barrage of knives");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            RecolorUtils.DedicatedItemStuff(tooltips);
        }
        public override void SetDefaults()
        {
            Item.damage = 151000;
            Item.crit += 100;
            Item.DamageType = DamageClass.Generic;
            Item.width = 30;
            Item.height = 32;
            Item.useTime = 1;
            Item.useAnimation = 3;
            Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 10f;
            Item.value = Item.buyPrice(1, 95);
            Item.rare = ModContent.RarityType<Quibop>();
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<UnboxingBar>(50)
                .AddIngredient<Aquamarine>(100)
                .AddIngredient(ItemID.ChainKnife)
                .AddIngredient(ItemID.FlyingKnife)
                .AddIngredient(ItemID.PoisonedKnife, 500)
                .AddIngredient(ItemID.PsychoKnife)
                .AddIngredient(ItemID.ShadowFlameKnife)
                .AddIngredient(ItemID.ThrowingKnife, 500)
                .AddTile<Tiles.BismuthForge>()
                .Register();
        }
        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Item.color = new Color(0.34f + 0.66f * (float)Main.DiscoR / 255f, 255, 0);
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                for (int num194 = 0; num194 < 5; num194++)
                {
                    float num195 = velocity.X;
                    float num196 = velocity.Y;
                    num195 += (float)Main.rand.Next(-40, 41) * 0.05f;
                    num196 += (float)Main.rand.Next(-40, 41) * 0.05f;
                    Projectile.NewProjectile(source, position.X, position.Y, num195, num196, ModContent.ProjectileType<QuibKnife>(), damage, knockback, player.whoAmI, 0, 0f);
                }
            }
            //else
            //{
            //    if (Main.rand.Next(10) == 0)
            //    {
            //        Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<QuibKnife>(), damage, knockback, player.whoAmI, 0, 0f);
            //    }
            //}
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            QuibopKnife knife = new QuibopKnife();
            if (player.altFunctionUse == 2)
            {
                Item.shootSpeed = 15f;
                Item.shoot = ModContent.ProjectileType<QuibKnife>();
            }
            else
            {
                Item.shootSpeed = 0f;
                Item.shoot = ProjectileID.None;
            }
            return base.CanUseItem(player);
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Item.color = new Color(0.34f + 0.66f * (float)Main.DiscoR / 255f, 255, 0);
        }
    }

    public class QuibKnife : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quibop's Knife");
        }
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = -1;
            Projectile.alpha = 0;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.penetrate = 50;
            Projectile.friendly = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 200);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            lightColor = new Color(0.34f + 0.66f * (float)Main.DiscoR / 255f, 255, 0);
            return base.PreDraw(ref lightColor);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
                if (Projectile.type == ModContent.ProjectileType<QuibKnife>())
                {
                    Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
                    Projectile.ai[0] += 1f;
                    if (Projectile.ai[0] >= 4f)
                    {
                        Projectile.position += Projectile.velocity;
                        Projectile.Kill();
                    }
                    else
                    {
                        if (Projectile.velocity.Y != oldVelocity.Y)
                        {
                            Projectile.velocity.Y = -oldVelocity.Y;
                        }
                        if (Projectile.velocity.X != oldVelocity.X)
                        {
                            Projectile.velocity.X = -oldVelocity.X;
                        }
                    }
                }
            return false;
        }
        public override void AI()
        {
            Projectile.rotation += 0.5f;
            if (Projectile.localAI[1] > 7f)
            {
                var num483 = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.velocity.X * 4f + 2f, Projectile.position.Y + 2f - Projectile.velocity.Y * 4f), 8, 8, DustID.Stone, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, new Color(0.34f + 0.66f * (float)Main.DiscoR / 255f, 255, 0), 1.5f);
                Main.dust[num483].velocity *= -0.25f;
                Main.dust[num483].noGravity = true;
                num483 = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.velocity.X * 4f + 2f, Projectile.position.Y + 2f - Projectile.velocity.Y * 4f), 8, 8, DustID.Stone, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, new Color(0.34f + 0.66f * (float)Main.DiscoR / 255f, 255, 0), 1.5f);
                Main.dust[num483].velocity *= -0.25f;
                Main.dust[num483].position -= Projectile.velocity * 0.5f;
                Main.dust[num483].noGravity = false;
            }
            //Projectile.ai[0] += 1f; // Use a timer to wait 15 ticks before applying gravity.
            //if (Projectile.ai[0] >= 15f)
            //{
            //    Projectile.ai[0] = 15f;
            //    Projectile.velocity.Y = Projectile.velocity.Y + 0.1f;
            //}
            //if (Projectile.velocity.Y > 16f)
            //{
            //    Projectile.velocity.Y = 16f;
            //}
        }
    }
}
