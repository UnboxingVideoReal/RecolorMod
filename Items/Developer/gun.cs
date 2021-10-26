using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RecolorMod.Common.Systems;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod.Items.Developer
{
	public class gun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("gun");
			Tooltip.SetDefault("gun");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            RecolorUtils.OverrideDamage(tooltips, "2.3 quattuordecillion");

        }

        public override void SetDefaults()
		{
			Item.damage = 1;
			Item.width = 1000;
			Item.height = 1000;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.useTurn = true;
			Item.pick = -1;
			Item.useStyle = 1;
			Item.knockBack = -1f;
			Item.rare = ModContent.RarityType<Rarities.DebugRarity>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.tileBoost += -45;
			//Item.axe = 45;
		}

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            target.life = 1;
            target.life -= 1;
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
        //      public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        //      {
        //	Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Items/Pickaxe/SolarPicksaw_Glow").Value;
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
        //		texture.Size() * 0.5f,
        //		scale,
        //		SpriteEffects.None,
        //		0f
        //	);
        //	return true;
        //}
    }
    public class truegun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("true gun");
            Tooltip.SetDefault("cool gun");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            RecolorUtils.OverrideDamage(tooltips, "100.5 nonagintillion");

        }

        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.width = 1000;
            Item.height = 1000;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useTurn = true;
            Item.pick = -1;
            Item.useStyle = 1;
            Item.knockBack = -1f;
            Item.rare = ModContent.RarityType<Rarities.DebugRarity>();
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.tileBoost += -45;
            Item.shoot = ModContent.ProjectileType<Projectiles.BloodHoming>();
            Item.shootSpeed = 30;
            //Item.axe = 45;
        }

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            target.defense = 0;
            target.life -= 10000000;
            target.NPCLoot();
        }
        public override void UpdateInventory(Player player)
        {
            RecolorAchievements.AwardAchievement("cool gun", "get cool gun", RecolorUtils.AchievementColor, "has made the achievement");
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
        //      public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        //      {
        //	Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Items/Pickaxe/SolarPicksaw_Glow").Value;
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
        //		texture.Size() * 0.5f,
        //		scale,
        //		SpriteEffects.None,
        //		0f
        //	);
        //	return true;
        //}
    }
    public class terragun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("terra gun");
            Tooltip.SetDefault("coolest gun");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            RecolorUtils.OverrideDamage(tooltips, "1 googolplex");

        }

        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.width = 1000;
            Item.height = 1000;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useTurn = true;
            Item.pick = -1;
            Item.useStyle = 1;
            Item.knockBack = -1f;
            Item.rare = ModContent.RarityType<Rarities.DebugRarity>();
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.tileBoost += -45;
            Item.shoot = ModContent.ProjectileType<Projectiles.VileBulletP>();
            Item.shootSpeed = 30;
            //Item.axe = 45;
        }

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            target.defense = 0;
            target.life -= 10000000;
            target.NPCLoot();
        }
        public override void UpdateInventory(Player player)
        {
            RecolorAchievements.AwardAchievement("coolest gun wtf?!?!?", "even cooler gun", RecolorUtils.ChallengeColor, "has completed the challenge");
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
        //      public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        //      {
        //	Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Items/Pickaxe/SolarPicksaw_Glow").Value;
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
        //		texture.Size() * 0.5f,
        //		scale,
        //		SpriteEffects.None,
        //		0f
        //	);
        //	return true;
        //}
    }

    public class zenithgun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("zenith gun");
            Tooltip.SetDefault("wtf stop with the guns gun");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            RecolorUtils.OverrideDamage(tooltips, "2 tetrecontekillillion");

        }

        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.width = 1000;
            Item.height = 1000;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useTurn = true;
            Item.pick = -1;
            Item.useStyle = 1;
            Item.knockBack = -1f;
            Item.rare = ModContent.RarityType<Rarities.DebugRarity>();
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.tileBoost += -45;
            Item.shoot = ModContent.ProjectileType<Projectiles.RainbowLaser>();
            Item.shootSpeed = 30;
            //Item.axe = 45;
        }

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            target.defense = 0;
            target.life -= 10000000;
            target.NPCLoot();
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
        //      public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        //      {
        //	Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Items/Pickaxe/SolarPicksaw_Glow").Value;
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
        //		texture.Size() * 0.5f,
        //		scale,
        //		SpriteEffects.None,
        //		0f
        //	);
        //	return true;
        //}
    }

    
}
