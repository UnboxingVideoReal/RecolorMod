//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;
//using static Terraria.ModLoader.ModContent;

//namespace RecolorMod.Items.Developer
//{
//    public class UnboxingWhip : ModItem
//    {
//        public override void SetStaticDefaults()
//        {
//            DisplayName.SetDefault("Unboxing's Whip");
//            //Tooltip.SetDefault("Your minions will gain many buffs when attacking struck enemies");
//            ItemID.Sets.SummonerWeaponThatScalesWithAttackSpeed[Item.type] = true;
//        }
//        public override void SetDefaults()
//        {
//            Item.CloneDefaults(ItemID.RainbowWhip);
//            Item.autoReuse = true;
//            Item.useStyle = 1;
//            Item.useTime = Item.useAnimation = 20;
//            Item.width = 18;
//            Item.height = 18;
//            Item.shoot = ProjectileType<UnboxingWhipP>();
//            Item.UseSound = SoundID.Item152;
//            Item.noMelee = true;
//            Item.DamageType = DamageClass.Summon;
//            Item.noUseGraphic = true;
//            Item.damage = 167000;
//            Item.knockBack = 3f;
//            Item.shootSpeed = 4f;
//            Item.rare = 7;
//            Item.value = Item.sellPrice(51, 10, 0, 0);
//        }

//        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
//        {
//            Item.color = RecolorMod.UnboxingColor;
//        }

//        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
//        {
//            Item.color = RecolorMod.UnboxingColor;
//        }
//    }


//    public class UnboxingWhipP : ModProjectile
//    {
//        public override void SetStaticDefaults()
//        {
//            DisplayName.SetDefault("Unboxing's Whip");
//            //ProjectileID.Sets.IsAWhip[Type] = true;
//        }
//        //public override void WhipDefaults()
//        //{
//        //    originalColor = RecolorMod.UnboxingColor;
//        //    whipRangeMultiplier = 10f;
//        //    fallOff = 0.05f;
//        //    tag = BuffType<UnboxingTag>();
//        //}

//        public override void SetDefaults()
//        {
//            Projectile.CloneDefaults(ProjectileID.RainbowWhip);
//        }

//        public override bool PreDraw(ref Color lightColor)
//        {
//            lightColor = RecolorMod.UnboxingColor;
//            return true;
//        }
//    }
//    //public class UnboxingTag : ModBuff
//    //{
//    //    public override void SetStaticDefaults()
//    //    {
//    //        DisplayName.SetDefault("Blessed");
//    //        Description.SetDefault("Minions will gain many buffs");
//    //        Main.debuff[Type] = true;
//    //    }
//    //}
//}
