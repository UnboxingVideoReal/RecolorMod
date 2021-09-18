using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RecolorMod.Items
{
	public class PowerForce : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Force of Amongla");
			Tooltip.SetDefault($"[i:{ModContent.ItemType<Developer.UnboxingEnchant>()}] Effects of Unboxing's Enchantment\n" +
//$"[i:{ModContent.ItemType<ColorizerEnchant>()}] Attacks will periodically be accompanied by several snowballs\n" +
$"[i:{ModContent.ItemType<BismuthEnchant>()}] Summons Bismuth Tool familiars that scale with minion damage\n" +
//$"[i:{ModContent.ItemType<WaterEnchant>()}] You have an aura of water\n" +
$"'amongla swag'");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			RecolorUtils.RandomQuote();
			tooltips.Add(new TooltipLine(Mod, "Quote", $"{Developer.UnboxingEnchant.theString}"));
			foreach (TooltipLine tooltipLine in tooltips)
			{
				if (tooltipLine.mod == "RecolorMod" && tooltipLine.Name == "Quote")
				{
					tooltipLine.overrideColor = Color.HotPink;
				}
			}
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.accessory = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
			Item.rare = ItemRarityID.Purple;
			Item.value = Item.sellPrice(900, 900, 900, 999);
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient<UnboxingEssence>(50)
				.AddIngredient<Developer.UnboxingEnchant>()
				//.AddIngredient<ColorizerEnchant>()
				.AddIngredient<BismuthEnchant>()
				//.AddIngredient<WaterEnchant>()
				.AddTile<Tiles.BismuthForge>()
				.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<RecolorPlayer>().BismuthEffect();
			player.maxMinions += 5;
			player.GetDamage(DamageClass.Summon) += 0.1f;
			player.accCritterGuide = true;
			player.accWatch = 3;
			player.accDepthMeter = 1;
			player.accCompass = 1;
			player.accFishFinder = true;
			player.accDreamCatcher = true;
			player.accOreFinder = true;
			player.accStopwatch = true;
			player.accCritterGuide = true;
			player.accJarOfSouls = true;
			player.accThirdEye = true;
			player.accCalendar = true;
			player.accWeatherRadio = true;
			player.buffImmune[BuffID.WindPushed] = true;
			player.buffImmune[BuffID.Suffocation] = true;
			NPC npc = new NPC();
			player.GetModPlayer<RecolorPlayer>().UnboxingEffect();
			player.GetModPlayer<RecolorPlayer>().UnboxingOtherEffect();
			//Projectile.NewProjectile(Projectile.GetNoneSource(), player.Center, Vector2.Zero, ProjectileID.CrimsonHeart, 0, 10f, player.whoAmI);
			player.lifeRegen += 500;
			player.GetModPlayer<RecolorPlayer>().unboxingEnchInflicts = true;
			player.moveSpeed += 1f;
			player.GetDamage(DamageClass.Generic) += 5f;
			player.GetCritChance(DamageClass.Generic) += 80;
			player.statLifeMax2 += 5000;
			player.statManaMax2 += 1000;
			Main.cursorColor = new Color(Main.DiscoR, 0, Main.DiscoB);
			player.luck += 500;
			player.luckMaximumCap += 10f;
			player.manaCost -= 0.5f;
			npc.extraValue += 100000;
			RecolorPlayer.doItemStuff = true;
			player.statDefense += 1050;
			player.hairColor = Main.DiscoColor;
			player.eyeColor = Main.DiscoColor;
			player.pantsColor = Main.DiscoColor;
			player.shirtColor = Main.DiscoColor;
			player.shoeColor = Main.DiscoColor;
			player.underShirtColor = Main.DiscoColor;
			player.maxMinions += 20;
			player.maxTurrets += 10;
			player.counterWeight = 556 + Main.rand.Next(6);
			player.yoyoGlove = true;
			player.yoyoString = true;
			player.scope = true;
			player.manaFlower = true;
			player.manaMagnet = true;
			player.magicCuffs = true;
			player.statLifeMax2 *= 2;
			player.buffImmune[BuffID.ChaosState] = true;
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Items/PowerForce_Colorizer").Value;
			spriteBatch.Draw
			(
				texture,
				new Rectangle((int)Item.VisualPosition.X, (int)Item.VisualPosition.Y, texture.Width, texture.Height),
				lightColor
			);

			Texture2D texture2 = ModContent.Request<Texture2D>("RecolorMod/Items/PowerForce_Unboxing").Value;
			spriteBatch.Draw
			(
				texture2,
				new Rectangle(0, 0, texture.Width, texture.Height),
				lightColor
			);
		}
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
			Texture2D texture = ModContent.Request<Texture2D>("RecolorMod/Items/PowerForce_Colorizer").Value;
			spriteBatch.Draw
			(
				texture,
				frame,
				drawColor
			);

			Texture2D texture2 = ModContent.Request<Texture2D>("RecolorMod/Items/PowerForce_Unboxing").Value;
			spriteBatch.Draw
			(
				texture2,
				frame,
				drawColor
			);
			return true;
        }
    }
}
