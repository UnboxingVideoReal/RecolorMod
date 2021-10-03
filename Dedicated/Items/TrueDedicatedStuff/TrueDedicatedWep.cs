using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using RecolorMod.Items;
using RecolorMod.Items.Developer;
using RecolorMod.Tiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace RecolorMod.Dedicated.Items.TrueDedicatedStuff
{
	public class TrueDedicatedWep : ModItem
	{
        public override string Texture => ModContent.GetInstance<UnboxingEssence>().Texture;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ok");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1; // Configure the amount of this Item that's needed to research it in Journey mode.
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips.Add(new TooltipLine(RecolorMod.ModInstance, "TorraStuff", "Attacks inflict Starburn\nRight-Click + Down to charge a Starlight Beam"));
			tooltips.Add(new TooltipLine(RecolorMod.ModInstance, "QuibopStuff", "Attacks inflict Frostburn\nRight-Click + Up to shoot a barrage of knives"));
			tooltips.Add(new TooltipLine(RecolorMod.ModInstance, "BlahStuff", "Attacks inflict On Fire!\nRight-Click + Left to summon an Energy Blade"));
			tooltips.Add(new TooltipLine(RecolorMod.ModInstance, "GeoStuff", "Attacks inflict Electrified\nRight-Click + Right to create a beam of Geo Lasers"));
			tooltips.Add(new TooltipLine(RecolorMod.ModInstance, "UnboxingStuff", "Attacks inflict a variety of debuffs\nRight-Click to do something idk"));
			RecolorUtils.DedicatedItemStuff(tooltips);
			foreach (TooltipLine tooltipLine in tooltips)
			{
				if (tooltipLine.mod == "RecolorMod" && tooltipLine.Name == "TorraStuff")
				{
					tooltipLine.overrideColor = ModContent.GetInstance<Torra>().RarityColor;
				}
				if (tooltipLine.mod == "RecolorMod" && tooltipLine.Name == "QuibopStuff")
				{
					tooltipLine.overrideColor = ModContent.GetInstance<Rarities.CoolBlue>().RarityColor;
				}
				if (tooltipLine.mod == "RecolorMod" && tooltipLine.Name == "BlahStuff")
				{
					tooltipLine.overrideColor = ModContent.GetInstance<Blah>().RarityColor;
				}
				if (tooltipLine.mod == "RecolorMod" && tooltipLine.Name == "GeoStuff")
				{
					tooltipLine.overrideColor = ModContent.GetInstance<Geo>().RarityColor;
				}
				if (tooltipLine.mod == "RecolorMod" && tooltipLine.Name == "UnboxingStuff")
				{
					tooltipLine.overrideColor = ModContent.GetInstance<Rarities.Developer>().RarityColor;
				}
			}
		}

		public override void SetDefaults()
		{
			Item.width = 54; // Hitbox width of the Item.
			Item.height = 22; // Hitbox height of the Item.
			Item.rare = ModContent.RarityType<TrueDedicated>(); // The color that the Item's name will be in-game.

			// Use Properties
			Item.useTime = 10; // The Item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 2; // The length of the Item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the Item (swinging, holding out, etc.)
			Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
			Item.UseSound = SoundID.Item1; // The sound that this Item plays when used.

			// Weapon Properties
			Item.DamageType = ModContent.GetInstance<DedicatedClass>(); // Sets the damage type to ranged.
			Item.damage = 5400000; // Sets the Item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.knockBack = 50f; // Sets the Item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.

			Item.shootSpeed = 20f;
		}

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
			Item.useTurn = false;
			if (player.altFunctionUse == 2)
			{
				if (player.controlLeft)
				{
					int project = ModContent.ProjectileType<EnergyBlade>();
					Projectile pro = Main.projectile[Projectile.NewProjectile(Projectile.GetNoneSource(), player.Center.X, player.Center.Y, 0f, -1f, project, Item.damage, Item.knockBack, Main.myPlayer)];
					if (player.ownedProjectileCounts[project] > 0 && player.whoAmI == Main.myPlayer)
                    {
						pro.Kill();
					}
					Item.useTime = 50;
				}
				else if (player.controlDown)
				{
					Item.shoot = ModContent.ProjectileType<StarlightBeam>();
					Item.useTime = 100;
				}
				else if (player.controlRight)
				{
					Item.shoot = ModContent.ProjectileType<GeoBeam>();
					Item.useTime = 100;
				}
				else if (player.controlUp)
				{
					Item.shoot = ModContent.ProjectileType<QuibopStuff.QuibKnife>();
					Item.useTurn = true;
					Item.useTime = 10;
				}
				else
				{
					Item.shoot = ProjectileID.RainbowRodBullet;
					Item.useTime = 10;
				}
			}
            else
            {
				Item.shoot = ModContent.ProjectileType<UnboxingSickle>();
				Item.useTime = 10;
			}
			return true;
        }
        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if (player.altFunctionUse == 2) // Right-click
			{
				if (player.controlUp)
                {
					for (int num194 = 0; num194 < 8; num194++)
					{
						float num195 = velocity.X;
						float num196 = velocity.Y;
						num195 += (float)Main.rand.Next(-40, 41) * 0.05f;
						num196 += (float)Main.rand.Next(-40, 41) * 0.05f;
						Projectile.NewProjectile(source, position.X, position.Y, num195, num196, ModContent.ProjectileType<QuibopStuff.QuibKnife>(), damage, knockback, player.whoAmI, 0, 0f);
					}
				}
				else
				{
					for (int num194 = 0; num194 < 8; num194++)
					{
						float num195 = velocity.X;
						float num196 = velocity.Y;
						num195 += (float)Main.rand.Next(-40, 41) * 0.05f;
						num196 += (float)Main.rand.Next(-40, 41) * 0.05f;
						Projectile.NewProjectile(source, position.X, position.Y, num195, num196, ProjectileID.RainbowRodBullet, damage, knockback, player.whoAmI, 0, 0f);
					}
				}
			}
			else for (int num194 = 0; num194 < 8; num194++)
			{
				float num195 = velocity.X;
				float num196 = velocity.Y;
				num195 += (float)Main.rand.Next(-40, 41) * 0.05f;
				num196 += (float)Main.rand.Next(-40, 41) * 0.05f;
				Projectile.NewProjectile(source, position.X, position.Y, num195, num196, ModContent.ProjectileType<UnboxingSickle>(), damage, knockback, player.whoAmI, 0, 0f);
			}
			return true;
        }
        public override void AddRecipes()
		{
			CreateRecipe(2)
				.AddIngredient<Aquamarine>(15)
				.AddIngredient<UnboxingEssence>(15)
				.AddIngredient<GeoStuff.Geobliterator>()
				.AddIngredient<QuibopStuff.QuibopKnife>()
				.AddIngredient<TorraStuff.StarKey>()
				//.AddIngredient<UnboxingWep>()
				.AddIngredient<BlahStuff.BlahItem>()
				.AddIngredient<OmegaFragment>(15)
				.AddTile<BismuthForgeTile>()
				.Register();
		}

		public void AddMinion(int proj, int damage, float knockback)
		{
			Player player = new Player();
			if (player.whoAmI != Main.myPlayer) return;
			if (player.ownedProjectileCounts[proj] < 1 && player.whoAmI == Main.myPlayer)
			{
				Projectile pro = Main.projectile[Projectile.NewProjectile(Projectile.GetNoneSource(), player.Center.X, player.Center.Y, 0f, -1f, proj, damage, knockback, Main.myPlayer)];
				pro.netUpdate = true;
			}
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			target.AddBuff(BuffID.OnFire, 600);
			target.AddBuff(BuffID.Electrified, 600);
			target.AddBuff(BuffID.Frostburn, 600);
			target.AddBuff(ModContent.BuffType<Starburn>(), 600);
			target.AddBuff(BuffID.CursedInferno, 600);
			target.AddBuff(BuffID.ShadowFlame, 600);
			target.AddBuff(ModContent.BuffType<Buffs.GodSlayerInferno>(), 600);
			target.AddBuff(BuffID.Ichor, 600);
		}

        public override void OnHitPvp(Player player, Player target, int damage, bool crit)
        {
			target.AddBuff(BuffID.OnFire, 600);
			target.AddBuff(BuffID.Electrified, 600);
			target.AddBuff(BuffID.Frostburn, 600);
			target.AddBuff(ModContent.BuffType<Starburn>(), 600);
			target.AddBuff(BuffID.CursedInferno, 600);
			target.AddBuff(BuffID.ShadowFlame, 600);
			target.AddBuff(ModContent.BuffType<Buffs.GodSlayerInferno>(), 600);
			target.AddBuff(BuffID.Ichor, 600);
		}
    }

	public class Starburn : ModBuff
	{
		public static int DefenseReduction = 10;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starburn");
			Description.SetDefault("Your flesh is burning off");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			LongerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<RecolorPlayer>().starburn = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			RecolorGlobalNPC recolorGlobalNPC = npc.GetGlobalNPC<RecolorGlobalNPC>();
			if (RecolorGlobalNPC.starburn < npc.buffTime[buffIndex])
			{
				RecolorGlobalNPC.starburn = npc.buffTime[buffIndex];
			}
			npc.DelBuff(buffIndex);
			buffIndex--;
		}
	}
	public class StarlightBeam : BaseDeathray
	{
		public StarlightBeam() : base(100, "StarlightBeam") { }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starlight Beam");
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			Projectile.hostile = false;
			Projectile.friendly = true;
		}

		public override void AI()
		{

			Vector2? vector78 = null;
			if (Projectile.velocity.HasNaNs() || Projectile.velocity == Vector2.Zero)
			{
				Projectile.velocity = -Vector2.UnitY;
			}
			int ai1 = (int)Projectile.ai[1];
			if (Projectile.velocity.HasNaNs() || Projectile.velocity == Vector2.Zero)
			{
				Projectile.velocity = -Vector2.UnitY;
			}
			if (Projectile.localAI[0] == 0f)
			{
				Terraria.Audio.SoundEngine.PlaySound(SoundID.Zombie, (int)Projectile.position.X, (int)Projectile.position.Y, 104, 1f, 0f);
			}
			float num801 = 17f;
			Projectile.localAI[0] += 1f;
			if (Projectile.localAI[0] >= maxTime)
			{
				Projectile.Kill();
				return;
			}
			Projectile.scale = (float)Math.Sin(Projectile.localAI[0] * 3.14159274f / maxTime) * 5f * num801;
			if (Projectile.scale > num801)
				Projectile.scale = num801;
			float num804 = Projectile.velocity.ToRotation();
			num804 += Projectile.ai[0];
			Projectile.rotation = num804 - 1.57079637f;
			Projectile.velocity = num804.ToRotationVector2();
			float num805 = 3f;
			float num806 = (float)Projectile.width;
			Vector2 samplingPoint = Projectile.Center;
			if (vector78.HasValue)
			{
				samplingPoint = vector78.Value;
			}
			float[] array3 = new float[(int)num805];
			//Collision.LaserScan(samplingPoint, Projectile.velocity, num806 * Projectile.scale, 3000f, array3);
			for (int i = 0; i < array3.Length; i++)
				array3[i] = 3000f;
			float num807 = 0f;
			int num3;
			for (int num808 = 0; num808 < array3.Length; num808 = num3 + 1)
			{
				num807 += array3[num808];
				num3 = num808;
			}
			num807 /= num805;
			float amount = 0.5f;
			Projectile.localAI[1] = MathHelper.Lerp(Projectile.localAI[1], num807, amount);
			Vector2 vector79 = Projectile.Center + Projectile.velocity * (Projectile.localAI[1] - 14f);
			for (int num809 = 0; num809 < 2; num809 = num3 + 1)
			{
				float num810 = Projectile.velocity.ToRotation() + ((Main.rand.Next(2) == 1) ? -1f : 1f) * 1.57079637f;
				float num811 = (float)Main.rand.NextDouble() * 2f + 2f;
				Vector2 vector80 = new Vector2((float)Math.Cos((double)num810) * num811, (float)Math.Sin((double)num810) * num811);
				int num812 = Dust.NewDust(vector79, 0, 0, DustID.BlueCrystalShard, vector80.X, vector80.Y, 0, default(Color), 1f);
				Main.dust[num812].noGravity = true;
				Main.dust[num812].scale = 1.7f;
				num3 = num809;
			}
			if (Main.rand.Next(5) == 0)
			{
				Vector2 value29 = Projectile.velocity.RotatedBy(1.5707963705062866, default(Vector2)) * ((float)Main.rand.NextDouble() - 0.5f) * (float)Projectile.width;
				int num813 = Dust.NewDust(vector79 + value29 - Vector2.One * 4f, 8, 8, DustID.BlueCrystalShard, 0f, 0f, 100, default(Color), 1.5f);
				Dust dust = Main.dust[num813];
				dust.velocity *= 0.5f;
				Main.dust[num813].velocity.Y = -Math.Abs(Main.dust[num813].velocity.Y);
			}
			//DelegateMethods.v3_1 = new Vector3(0.3f, 0.65f, 0.7f);
			//Utils.PlotTileLine(Projectile.Center, Projectile.Center + Projectile.velocity * Projectile.localAI[1], (float)Projectile.width * Projectile.scale, new Utils.PerLinePoint(DelegateMethods.CastLight));

			const int increment = 100;
			for (int i = 0; i < array3[0]; i += increment)
			{
				if (Main.rand.Next(3) != 0)
					continue;
				float offset = i + Main.rand.NextFloat(-increment, increment);
				if (offset < 0)
					offset = 0;
				if (offset > array3[0])
					offset = array3[0];
				int d = Dust.NewDust(Projectile.position + Projectile.velocity * offset,
					Projectile.width, Projectile.height, DustID.Enchanted_Gold, 0f, 0f, 0, default, Main.rand.NextFloat(4f, 8f));
				Main.dust[d].noGravity = true;
				Main.dust[d].velocity += Projectile.velocity * 0.5f;
				Main.dust[d].velocity *= Main.rand.NextFloat(12f, 24f);
			}
		}
	}

	public class GeoBeam : BaseDeathray
	{
		public GeoBeam() : base(100, "GeoBeam") { }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Geo Beam");
		}

        public override void SetDefaults()
        {
            base.SetDefaults();
			Projectile.hostile = false;
			Projectile.friendly = true;
        }

        public override void AI()
		{

			Vector2? vector78 = null;
			if (Projectile.velocity.HasNaNs() || Projectile.velocity == Vector2.Zero)
			{
				Projectile.velocity = -Vector2.UnitY;
			}
			int ai1 = (int)Projectile.ai[1];
			if (Projectile.velocity.HasNaNs() || Projectile.velocity == Vector2.Zero)
			{
				Projectile.velocity = -Vector2.UnitY;
			}
			if (Projectile.localAI[0] == 0f)
			{
				Terraria.Audio.SoundEngine.PlaySound(SoundID.Zombie, (int)Projectile.position.X, (int)Projectile.position.Y, 104, 1f, 0f);
			}
			float num801 = 17f;
			Projectile.localAI[0] += 1f;
			if (Projectile.localAI[0] >= maxTime)
			{
				Projectile.Kill();
				return;
			}
			Projectile.scale = (float)Math.Sin(Projectile.localAI[0] * 3.14159274f / maxTime) * 5f * num801;
			if (Projectile.scale > num801)
				Projectile.scale = num801;
			float num804 = Projectile.velocity.ToRotation();
			num804 += Projectile.ai[0];
			Projectile.rotation = num804 - 1.57079637f;
			Projectile.velocity = num804.ToRotationVector2();
			float num805 = 3f;
			float num806 = (float)Projectile.width;
			Vector2 samplingPoint = Projectile.Center;
			if (vector78.HasValue)
			{
				samplingPoint = vector78.Value;
			}
			float[] array3 = new float[(int)num805];
			//Collision.LaserScan(samplingPoint, Projectile.velocity, num806 * Projectile.scale, 3000f, array3);
			for (int i = 0; i < array3.Length; i++)
				array3[i] = 3000f;
			float num807 = 0f;
			int num3;
			for (int num808 = 0; num808 < array3.Length; num808 = num3 + 1)
			{
				num807 += array3[num808];
				num3 = num808;
			}
			num807 /= num805;
			float amount = 0.5f;
			Projectile.localAI[1] = MathHelper.Lerp(Projectile.localAI[1], num807, amount);
			Vector2 vector79 = Projectile.Center + Projectile.velocity * (Projectile.localAI[1] - 14f);
			for (int num809 = 0; num809 < 2; num809 = num3 + 1)
			{
				float num810 = Projectile.velocity.ToRotation() + ((Main.rand.Next(2) == 1) ? -1f : 1f) * 1.57079637f;
				float num811 = (float)Main.rand.NextDouble() * 2f + 2f;
				Vector2 vector80 = new Vector2((float)Math.Cos((double)num810) * num811, (float)Math.Sin((double)num810) * num811);
				int num812 = Dust.NewDust(vector79, 0, 0, DustID.BlueCrystalShard, vector80.X, vector80.Y, 0, default(Color), 1f);
				Main.dust[num812].noGravity = true;
				Main.dust[num812].scale = 1.7f;
				num3 = num809;
			}
			if (Main.rand.Next(5) == 0)
			{
				Vector2 value29 = Projectile.velocity.RotatedBy(1.5707963705062866, default(Vector2)) * ((float)Main.rand.NextDouble() - 0.5f) * (float)Projectile.width;
				int num813 = Dust.NewDust(vector79 + value29 - Vector2.One * 4f, 8, 8, DustID.BlueCrystalShard, 0f, 0f, 100, default(Color), 1.5f);
				Dust dust = Main.dust[num813];
				dust.velocity *= 0.5f;
				Main.dust[num813].velocity.Y = -Math.Abs(Main.dust[num813].velocity.Y);
			}
			//DelegateMethods.v3_1 = new Vector3(0.3f, 0.65f, 0.7f);
			//Utils.PlotTileLine(Projectile.Center, Projectile.Center + Projectile.velocity * Projectile.localAI[1], (float)Projectile.width * Projectile.scale, new Utils.PerLinePoint(DelegateMethods.CastLight));

			const int increment = 100;
			for (int i = 0; i < array3[0]; i += increment)
			{
				if (Main.rand.Next(3) != 0)
					continue;
				float offset = i + Main.rand.NextFloat(-increment, increment);
				if (offset < 0)
					offset = 0;
				if (offset > array3[0])
					offset = array3[0];
				int d = Dust.NewDust(Projectile.position + Projectile.velocity * offset,
					Projectile.width, Projectile.height, DustID.Enchanted_Gold, 0f, 0f, 0, default, Main.rand.NextFloat(4f, 8f));
				Main.dust[d].noGravity = true;
				Main.dust[d].velocity += Projectile.velocity * 0.5f;
				Main.dust[d].velocity *= Main.rand.NextFloat(12f, 24f);
			}
		}
	}

	public class UnboxingSickle : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.DemonSickle);
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 300;
			Projectile.tileCollide = false;
		}

		public override void AI()
		{
			if (Projectile.localAI[0] == 0)
			{
				Projectile.localAI[0] = 1;
				Terraria.Audio.SoundEngine.PlaySound(SoundID.Item8, Projectile.Center);
			}
			if (Projectile.ai[1] == 0)
			{
				float rotation = Projectile.velocity.ToRotation();
				Vector2 vel = Main.npc[(int)Projectile.ai[0]].Center - Projectile.Center;
				float targetAngle = vel.ToRotation();
				Projectile.velocity = new Vector2(Projectile.velocity.Length(), 0f).RotatedBy(rotation.AngleLerp(targetAngle, Projectile.localAI[0]));

				if (Projectile.localAI[0] < 0.5f)
					Projectile.localAI[0] += 1f / 3000f;

				if (vel.Length() < 250 || !Main.player[(int)Projectile.ai[0]].active || Main.player[(int)Projectile.ai[0]].dead || Main.player[(int)Projectile.ai[0]].ghost)
				{
					Projectile.ai[1] = 1;
					Projectile.netUpdate = true;
					Projectile.timeLeft = 180;
					Projectile.velocity.Normalize();
				}
			}
			else if (Projectile.ai[1] > 0)
			{
				if (++Projectile.ai[1] < 120)
				{
					Projectile.velocity *= 1.03f;

					float rotation = Projectile.velocity.ToRotation();
					Vector2 vel = Main.npc[(int)Projectile.ai[0]].Center - Projectile.Center;
					float targetAngle = vel.ToRotation();
					Projectile.velocity = new Vector2(Projectile.velocity.Length(), 0f).RotatedBy(rotation.AngleLerp(targetAngle, 0.025f));
				}
			}
			else //ai1 below 0 rn
			{
				Projectile.ai[1]++;
			}
			Projectile.rotation += 0.8f;
			if (++Projectile.localAI[1] > 30 && Projectile.localAI[1] < 120)
				Projectile.velocity *= 1.03f;

			for (int i = 0; i < 3; i++)
			{
				Vector2 offset = new Vector2(0, -20).RotatedBy(Projectile.rotation);
				offset = offset.RotatedByRandom(MathHelper.Pi / 6);
				int d = Dust.NewDust(Projectile.Center, 0, 0, 1, 0f, 0f, 150, newColor: ModContent.GetInstance<Rarities.Developer>().RarityColor);
				Main.dust[d].position += offset;
				float velrando = Main.rand.Next(20, 31) / 10;
				Main.dust[d].velocity = Projectile.velocity / velrando;
				Main.dust[d].noGravity = true;
			}

			if (Projectile.timeLeft < 180)
				Projectile.tileCollide = true;
		}

        public override bool PreDraw(ref Color lightColor)
        {
			lightColor = ModContent.GetInstance<Rarities.Developer>().RarityColor;
            return base.PreDraw(ref lightColor);
        }

        public override void PostDraw(Color lightColor)
        {
			lightColor = ModContent.GetInstance<Rarities.Developer>().RarityColor;
		}

        public override Color? GetAlpha(Color lightColor)
		{
			return ModContent.GetInstance<Rarities.Developer>().RarityColor;
		}
	}

	public class EnergyBlade : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.CloneDefaults(ProjectileID.DeadlySphere);
			AIType = ProjectileID.DeadlySphere;
			Projectile.width = 90;
			Projectile.height = 90;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 18000;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.minionSlots = 0;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Energy Blade");
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];

			//dust!
			int dustId = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height + 5, 6, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
			Main.dust[dustId].noGravity = true;
			int dustId3 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height + 5, 6,
				Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
			Main.dust[dustId3].noGravity = true;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (Projectile.velocity.X != oldVelocity.X) Projectile.velocity.X = oldVelocity.X;
			if (Projectile.velocity.Y != oldVelocity.Y) Projectile.velocity.Y = oldVelocity.Y;
			return false;
		}
	}
}
