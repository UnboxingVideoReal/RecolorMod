using RecolorMod;
//using CalamityMod.Items.Materials;
//using CalamityMod.Items.Weapons.Rogue;
using RecolorMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace RecolorMod.Items
{
	public class ExampleRogueWeapon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Example Rogue Weapon");
			Tooltip.SetDefault("Throws a disk that has a chance to generate several disks if enemies are near it");
		}

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.damage = 157;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Melee;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.useTime = 15;
			Item.knockBack = 9f;
			Item.UseSound = SoundID.Item1;
			Item.height = 38;
			Item.value = Item.buyPrice(platinum: 1, 20);
			Item.shoot = ModContent.ProjectileType<RogueWepProj>();
			Item.shootSpeed = 13f;
			//Item.Calamity().rogue = true;
			Item.rare = ItemRarityID.Gray;
		}

		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int proj = Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<RogueWepProj>(), damage, (int)knockback, player.whoAmI, 0, 0f/*source, new Vector2(velocity.X, velocity.Y), type, damage, (int)knockback, player.whoAmI, 0, 0f*/);
			//Main.projectile[proj].CalamityProj().forceRogue = true;
			//Main.projectile[proj].Calamity().stealthStrike = player.Calamity().StealthStrikeAvailable();
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<DropletiumBar>(120)
				.AddTile<Tiles.BismuthForgeTile>()
				.Register();
		}
	}

	public class RogueWepProj : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rogue Wep");
			ProjectileID.Sets.TrailCacheLength[Type] = 10;
			ProjectileID.Sets.TrailingMode[Type] = 1;
		}

		public override void SetDefaults()
		{
			Projectile.width = 56;
			Projectile.height = 56;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 6;
			Projectile.penetrate = -1;
			Projectile.aiStyle = 3;
			Projectile.timeLeft = 400;
			base.AIType = 52;
			Projectile.DamageType = DamageClass.Melee;
		}

		public override void AI()
		{
			if (Utils.NextBool(Main.rand, 3))
			{
				int rainbow = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 66, Projectile.direction * 2, 0f, 150, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 1.3f);
				Main.dust[rainbow].noGravity = true;
				Main.dust[rainbow].velocity *= 0f;
			}
			Lighting.AddLight(Projectile.Center, 0.15f, 1f, 0.25f);
			float maxDistance = 300f;
			bool homeIn = false;
			for (int j = 0; j < 200; j++)
			{
				NPC npc = Main.npc[j];
				if (npc.CanBeChasedBy(Projectile))
				{
					float extraDistance = npc.width / 2 + npc.height / 2;
					bool canHit = true;
					if (extraDistance < maxDistance)
					{
						canHit = Collision.CanHit(Projectile.Center, 1, 1, npc.Center, 1, 1);
					}
					if (Vector2.Distance(npc.Center, Projectile.Center) < maxDistance + extraDistance && canHit)
					{
						homeIn = true;
						break;
					}
				}
			}
			if (!Projectile.friendly)
			{
				homeIn = false;
			}
			if (!homeIn || Main.player[Projectile.owner].miscCounter % 50 != 0)
			{
				return;
			}
			int splitProj = ModContent.ProjectileType<RogueWep2>();
			if (Projectile.owner == Main.myPlayer && Main.player[Projectile.owner].ownedProjectileCounts[splitProj] < 25)
			{
				float spread = 0.783f;
				double startAngle = Math.Atan2(Projectile.velocity.X, Projectile.velocity.Y) - (double)(spread / 2f);
				double deltaAngle = spread / 8f;
				for (int i = 0; i < 4; i++)
				{
					double offsetAngle = startAngle + deltaAngle * (double)(i + i * i) / 2.0 + (double)(32f * (float)i);
					int disk = Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, (float)(Math.Sin(offsetAngle) * 5.0), (float)(Math.Cos(offsetAngle) * 5.0), splitProj, Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
					//Main.projectile[disk].Calamity().forceMelee = Projectile.melee;
					//Main.projectile[disk].CalamityProj().forceRogue = Projectile.CalamityProj().rogue;
					int disk2 = Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, (float)((0.0 - Math.Sin(offsetAngle)) * 5.0), (float)((0.0 - Math.Cos(offsetAngle)) * 5.0), splitProj, Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
					//Main.projectile[disk2].Calamity().forceMelee = Projectile.melee;
					//Main.projectile[disk2].CalamityProj().forceRogue = Projectile.CalamityProj().rogue;
				}
			}
		}

		public override bool PreDraw(ref Color lightColor)
		{
			DrawCenteredAndAfterimage(Projectile, lightColor, ProjectileID.Sets.TrailingMode[Projectile.type], 2);
			return false;
		}

		public static void DrawCenteredAndAfterimage(Projectile projectile, Color lightColor, int trailingMode, int typeOneDistanceMultiplier = 1, Texture2D texture = null, bool drawCentered = true)
		{
			if (texture == null)
			{
				texture = (Texture2D)Terraria.GameContent.TextureAssets.Projectile[projectile.type];
			}
			int frameHeight = texture.Height / Main.projFrames[projectile.type];
			int frameY = frameHeight * projectile.frame;
			float scale = projectile.scale;
			float rotation = projectile.rotation;
			Rectangle rectangle = new Rectangle(0, frameY, texture.Width, frameHeight);
			Vector2 origin = rectangle.Size() / 2f;
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
			//if (CalamityConfig.Afterimages)
			//{
			Vector2 centerOffset = (drawCentered ? (projectile.Size / 2f) : Vector2.Zero);
			switch (trailingMode)
			{
				case 0:
					{
						for (int i = 0; i < projectile.oldPos.Length; i++)
						{
							Vector2 drawPos = projectile.oldPos[i] + centerOffset - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
							Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - i) / (float)projectile.oldPos.Length);
							Main.spriteBatch.Draw(texture, drawPos, rectangle, color, rotation, origin, scale, spriteEffects, 0f);
						}
						break;
					}
				case 1:
					{
						Color drawColor = projectile.GetAlpha(lightColor);
						int afterimageCount = ProjectileID.Sets.TrailCacheLength[projectile.type];
						for (int k = 0; k < afterimageCount; k += typeOneDistanceMultiplier)
						{
							Vector2 drawPos2 = projectile.oldPos[k] + centerOffset - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
							if (k > 0)
							{
								float colorMult = afterimageCount - k;
								drawColor *= colorMult / ((float)afterimageCount * 1.5f);
							}
							Main.spriteBatch.Draw(texture, drawPos2, rectangle, drawColor, rotation, origin, scale, spriteEffects, 0f);
						}
						break;
					}
				case 2:
					{
						for (int j = 0; j < projectile.oldPos.Length; j++)
						{
							float afterimageRot = projectile.oldRot[j];
							SpriteEffects sfxForThisAfterimage = ((projectile.oldSpriteDirection[j] == -1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None);
							Vector2 drawPos3 = projectile.oldPos[j] + centerOffset - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
							Color color2 = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - j) / (float)projectile.oldPos.Length);
							Main.spriteBatch.Draw(texture, drawPos3, rectangle, color2, afterimageRot, origin, scale, sfxForThisAfterimage, 0f);
						}
						break;
					}
			}
			//}
			if (/*!CalamityConfig.Afterimages || */ProjectileID.Sets.TrailCacheLength[projectile.type] <= 0)
			{
				Vector2 startPos = (drawCentered ? projectile.Center : projectile.position);
				Main.spriteBatch.Draw(texture, startPos - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), rectangle, projectile.GetAlpha(lightColor), rotation, origin, scale, spriteEffects, 0f);
			}
		}
	}

	public class RogueWep2 : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rogue Qep");
			ProjectileID.Sets.TrailCacheLength[Type] = 10;
			ProjectileID.Sets.TrailingMode[Type] = 1;
		}

		public override void SetDefaults()
		{
			Projectile.width = 56;
			Projectile.height = 56;
			Projectile.alpha = 120;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.aiStyle = 3;
			Projectile.timeLeft = 60;
			base.AIType = 52;
			//Projectile.CalamityProj().rogue = true;
		}

		public override void AI()
		{
			if (Utils.NextBool(Main.rand, 10))
			{
				int num250 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 66, Projectile.direction * 2, 0f, 150, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 0.5f);
				Main.dust[num250].noGravity = true;
				Main.dust[num250].velocity *= 0f;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			//target.AddBuff(ModContent.BuffType<BrimstoneFlames>(), 120);
			//target.AddBuff(ModContent.BuffType<GlacialState>(), 120);
			//target.AddBuff(ModContent.BuffType<Plague>(), 120);
			//target.AddBuff(ModContent.BuffType<HolyFlames>(), 120);
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			//target.AddBuff(ModContent.BuffType<BrimstoneFlames>(), 120, true);
			//target.AddBuff(ModContent.BuffType<GlacialState>(), 120, true);
			//target.AddBuff(ModContent.BuffType<Plague>(), 120, true);
			//target.AddBuff(ModContent.BuffType<HolyFlames>(), 120, true);
		}

		public override bool PreDraw(ref Color lightColor)
		{
			DrawCenteredAndAfterimage(Projectile, lightColor, ProjectileID.Sets.TrailingMode[Projectile.type], 2);
			return false;
		}

		public static void DrawCenteredAndAfterimage(Projectile projectile, Color lightColor, int trailingMode, int typeOneDistanceMultiplier = 1, Texture2D texture = null, bool drawCentered = true)
		{
			if (texture == null)
			{
				texture = (Texture2D)Terraria.GameContent.TextureAssets.Projectile[projectile.type];
			}
			int frameHeight = texture.Height / Main.projFrames[projectile.type];
			int frameY = frameHeight * projectile.frame;
			float scale = projectile.scale;
			float rotation = projectile.rotation;
			Rectangle rectangle = new Rectangle(0, frameY, texture.Width, frameHeight);
			Vector2 origin = rectangle.Size() / 2f;
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
			//if (CalamityConfig.Afterimages)
			//{
			Vector2 centerOffset = (drawCentered ? (projectile.Size / 2f) : Vector2.Zero);
			switch (trailingMode)
			{
				case 0:
					{
						for (int i = 0; i < projectile.oldPos.Length; i++)
						{
							Vector2 drawPos = projectile.oldPos[i] + centerOffset - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
							Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - i) / (float)projectile.oldPos.Length);
							Main.spriteBatch.Draw(texture, drawPos, rectangle, color, rotation, origin, scale, spriteEffects, 0f);
						}
						break;
					}
				case 1:
					{
						Color drawColor = projectile.GetAlpha(lightColor);
						int afterimageCount = ProjectileID.Sets.TrailCacheLength[projectile.type];
						for (int k = 0; k < afterimageCount; k += typeOneDistanceMultiplier)
						{
							Vector2 drawPos2 = projectile.oldPos[k] + centerOffset - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
							if (k > 0)
							{
								float colorMult = afterimageCount - k;
								drawColor *= colorMult / ((float)afterimageCount * 1.5f);
							}
							Main.spriteBatch.Draw(texture, drawPos2, rectangle, drawColor, rotation, origin, scale, spriteEffects, 0f);
						}
						break;
					}
				case 2:
					{
						for (int j = 0; j < projectile.oldPos.Length; j++)
						{
							float afterimageRot = projectile.oldRot[j];
							SpriteEffects sfxForThisAfterimage = ((projectile.oldSpriteDirection[j] == -1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None);
							Vector2 drawPos3 = projectile.oldPos[j] + centerOffset - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
							Color color2 = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - j) / (float)projectile.oldPos.Length);
							Main.spriteBatch.Draw(texture, drawPos3, rectangle, color2, afterimageRot, origin, scale, sfxForThisAfterimage, 0f);
						}
						break;
					}
			}
			//}
			if (/*!CalamityConfig.Afterimages || */ProjectileID.Sets.TrailCacheLength[projectile.type] <= 0)
			{
				Vector2 startPos = (drawCentered ? projectile.Center : projectile.position);
				Main.spriteBatch.Draw(texture, startPos - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), rectangle, projectile.GetAlpha(lightColor), rotation, origin, scale, spriteEffects, 0f);
			}
		}
	}
}
