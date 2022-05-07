using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using RecolorMod.Tiles;
using RecolorMod.Items.Developer;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.Audio;

namespace RecolorMod.Dedicated.Items.GeoStuff
{
    public class Geobliterator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Geobliterator");
            Tooltip.SetDefault("Has a chance to convert bullets to Geo Bullets and lasers");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            RecolorUtils.DedicatedItemStuff(tooltips);
        }

        public override void SetDefaults()
        {
            Item.damage = 105000;
            Item.crit += 100;
            Item.width = 34;
            Item.height = 18;
            Item.useAnimation = 3;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.DamageType = ModContent.GetInstance<DedicatedClass>();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.buyPrice(2, 50);
            Item.UseSound = SoundID.Item11;
            Item.rare = ModContent.RarityType<Dedicated.Geo>();
            Item.shoot = ProjectileID.PurificationPowder; 
            Item.shootSpeed = 30f; 
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<UnboxingBar>(50)
                .AddIngredient(ItemID.SuperStarCannon)
                .AddIngredient<OmegaFragment>(500)
                .AddIngredient(ItemID.VortexBeater)
                .AddIngredient(ItemID.Celeb2)
                .AddIngredient(ItemID.LaserMachinegun)
                .AddIngredient(ItemID.PortalGun)
                .AddIngredient(ItemID.RainbowGun)
                .AddIngredient(ItemID.SpaceGun)
                .AddTile<BismuthForgeTile>()
                .Register();
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.Bullet)
            { // or ProjectileID.WoodenArrowFriendly
                type = ModContent.ProjectileType<GeoBullet>(); // or ProjectileID.FireArrow;
            }
            // Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
            type = Main.rand.Next(new int[] { type, ModContent.ProjectileType<GeoBullet>(), ModContent.ProjectileType<GeoLaser>() });
        }

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3 + Main.rand.Next(3); // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(50);

            position += Vector2.Normalize(velocity) * 45f;

            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }

            return false; // return false to stop vanilla from calling Projectile.NewProjectile.
        }
    }
    public class GeoBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Geo Bullet"); // Name of the Projectile. It can be appear in chat
            /*ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;*/ // Tell the game that it is a homing Projectile
        }

        // Setting the default parameters of the Projectile
        // You can check most of Fields and Properties here https://github.com/tModLoader/tModLoader/wiki/Projectile-Class-Documentation
        public override void SetDefaults()
        {
            Projectile.width = 2; // The width of Projectile hitbox
            Projectile.height = 20; // The height of Projectile hitbox

            Projectile.aiStyle = ProjectileID.MoonlordBullet; // The ai style of the Projectile (0 means custom AI). For more please reference the source code of Terraria
            Projectile.DamageType = ModContent.GetInstance<DedicatedClass>(); // What type of damage does this Projectile affect?
            Projectile.friendly = true; // Can the Projectile deal damage to enemies?
            Projectile.hostile = false; // Can the Projectile deal damage to the player?
            Projectile.ignoreWater = true; // Does the Projectile's speed be influenced by water?
            Projectile.light = 1f; // How much light emit around the Projectile
            Projectile.tileCollide = false; // Can the Projectile collide with tiles?
            Projectile.timeLeft = 600; //The live time for the Projectile (60 = 1 second, so 600 is 10 seconds)
            AIType = ProjectileID.MoonlordBullet;
        }
        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        }
        //public override void AI()
        //{
        //    //Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), (Vector2)Projectile.position.X, (float)Projectile.position.Y, ModContent.ProjectileType<HueBulletProjectile>(), Projectile.damage, Projectile.knockBack, 255, 0, 0);
        //    Projectile.ai[0] += 1f;
        //    if (Projectile.alpha < 170)
        //    {
        //        for (var num26 = 0; num26 < 10; num26++)
        //        {
        //            var x2 = Projectile.position.X - Projectile.velocity.X / 10f * num26;
        //            var y2 = Projectile.position.Y - Projectile.velocity.Y / 10f * num26;
        //            int num27;
        //            //num27 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 119, 0f, 0f, 0, default(Color), 1f);
        //            //Main.dust[num27].alpha = Projectile.alpha;
        //            //Main.dust[num27].position.X = x2;
        //            //Main.dust[num27].position.Y = y2;
        //            //Main.dust[num27].velocity *= 0f;
        //            //Main.dust[num27].noGravity = true;
        //        }
        //    }
        //    var num28 = (float)Math.Sqrt(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y);
        //    var num29 = Projectile.localAI[0];
        //    if (num29 == 0f)
        //    {
        //        Projectile.localAI[0] = num28;
        //        num29 = num28;
        //    }
        //    if (Projectile.alpha > 0)
        //    {
        //        Projectile.alpha -= 25;
        //    }
        //    if (Projectile.alpha < 0)
        //    {
        //        Projectile.alpha = 0;
        //    }
        //    var num30 = Projectile.position.X;
        //    var num31 = Projectile.position.Y;
        //    var num32 = 300f;
        //    var flag = false;
        //    var num33 = 0;
        //    if (Projectile.ai[1] == 0f)
        //    {
        //        for (var num34 = 0; num34 < 200; num34++)
        //        {
        //            if (Main.npc[num34].active && !Main.npc[num34].dontTakeDamage && !Main.npc[num34].friendly && Main.npc[num34].lifeMax > 5 && (Projectile.ai[1] == 0f || Projectile.ai[1] == num34 + 1))
        //            {
        //                var num35 = Main.npc[num34].position.X + Main.npc[num34].width / 2;
        //                var num36 = Main.npc[num34].position.Y + Main.npc[num34].height / 2;
        //                var num37 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num35) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num36);
        //                if (num37 < num32 && Collision.CanHit(new Vector2(Projectile.position.X + Projectile.width / 2, Projectile.position.Y + Projectile.height / 2), 1, 1, Main.npc[num34].position, Main.npc[num34].width, Main.npc[num34].height))
        //                {
        //                    num32 = num37;
        //                    num30 = num35;
        //                    num31 = num36;
        //                    flag = true;
        //                    num33 = num34;
        //                }
        //            }
        //        }
        //        if (flag)
        //        {
        //            Projectile.ai[1] = num33 + 1;
        //        }
        //        flag = false;
        //    }
        //    if (Projectile.ai[1] != 0f)
        //    {
        //        var num38 = (int)(Projectile.ai[1] - 1f);
        //        if (Main.npc[num38].active)
        //        {
        //            var num39 = Main.npc[num38].position.X + Main.npc[num38].width / 2;
        //            var num40 = Main.npc[num38].position.Y + Main.npc[num38].height / 2;
        //            var num41 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num39) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num40);
        //            if (num41 < 1000f)
        //            {
        //                flag = true;
        //                num30 = Main.npc[num38].position.X + Main.npc[num38].width / 2;
        //                num31 = Main.npc[num38].position.Y + Main.npc[num38].height / 2;
        //            }
        //        }
        //    }
        //    if (flag)
        //    {
        //        var num42 = num29;
        //        var vector = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
        //        var num43 = num30 - vector.X;
        //        var num44 = num31 - vector.Y;
        //        var num45 = (float)Math.Sqrt(num43 * num43 + num44 * num44);
        //        num45 = num42 / num45;
        //        num43 *= num45;
        //        num44 *= num45;
        //        var num46 = 8;
        //        Projectile.velocity.X = (Projectile.velocity.X * (num46 - 1) + num43) / num46;
        //        Projectile.velocity.Y = (Projectile.velocity.Y * (num46 - 1) + num44) / num46;
        //    }
        //    Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        //    if (Projectile.velocity.Y > 16f)
        //    {
        //        Projectile.velocity.Y = 16f;
        //    }
        //}

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item12, Projectile.position);
            Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.position, Projectile.velocity, ModContent.ProjectileType<GeoLaser>(), Projectile.damage, Projectile.knockBack);
        }
    }
    public class GeoLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Geo Laser");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.ZapinatorLaser);
            AIType = ProjectileID.ZapinatorLaser;
        }

        //public override bool OnTileCollide(Vector2 oldVelocity)
        //{
        //    if (Projectile.owner == Main.myPlayer)
        //    {
        //        for (int i = 0; i < 3; i++)
        //        {                                                                   // Spawn the Projectile.
        //            Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.position, Projectile.velocity, ModContent.ProjectileType<GeoLaserNoSplit>(), Projectile.damage, 0f, Projectile.owner, 0f, 0f);
        //        }
        //    }
        //    return base.OnTileCollide(oldVelocity);
        //}
    }

    public class GeoLaserNoSplit : ModProjectile
    {
        public override string Texture => "RecolorMod/Dedicated/Items/GeoStuff/GeoLaser";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Geo Laser");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.ZapinatorLaser);
            AIType = ProjectileID.ZapinatorLaser;
            SoundEngine.PlaySound(SoundID.Item12, Projectile.position);
        }
    }
}
