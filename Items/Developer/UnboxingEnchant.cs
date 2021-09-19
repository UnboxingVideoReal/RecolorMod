using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.GameContent.Creative;

namespace RecolorMod.Items.Developer
{
    public class UnboxingEnchant : ModItem
    {
        public static int Counter = 1;
        public static int thing;
        public static string theString;

        public static String[] possibleQuotes = new String[]
        {
            "''It sounds really weird and weird'' -blahblahbal 2021",
            "''they're not pretty, but they're crunchy and fat'' - pause ghost background person",
            "''I'm not a bully, my chicken is scary'' - illuminati background person",
            "''it's cool I guess, but it's kinda cool I guess'' - blasfah, 2021",
            "''it's not even that funny, why is it funny'' - quibop, 2021",
            "''Why do I have a tentacle attached to me?'' -blahblahbal 2021",
            "''Hey guys i ‫(edited) this message'' - Geo 2021",
            "''no heck you'' -quibop 2021",
            "***Hey*** baby * ~~:chain:~~ ‫ (edited)jjj",
            "''i am currently looking for the corruption so i can find the corruption'' -ennway 2021"
        };
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unboxing's Enchantment");
            Tooltip.SetDefault(
@$"'Very broken, go cry about it.'
{ModContent.GetInstance<RecolorConfig>().prismOrbMax} Prism Orbs will orbit around you
Summons a ring of bismuth crystals to shoot at nearby enemies
+500% damage
+100% movement speed
+80% crit chance
+5k max life
+10k max luck
+500 luck
-50 mana cost 
+100000 extra value
+1050 defense 
+20 max minions 
+10 max turrets
Cursor color shifts through multiple colors
Greatly increased life regen
Hair, Eye, Shirt, Undershirt, Pants, and Shoe colors are rainbow
Effects inflict God Slayer Inferno, Electrified, Cursed Inferno, On Fire!, and Venom
You have an invisible aura of God Slayer Inferno, Electrified, Cursed Inferno, On Fire!, and Venom
Max life multiplied by 2
Does more stuff too
[c/ff0000:Does not work with Calamity Mod, Exxo Avalon Origins, or Mod of Redemption]
Master
");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            RecolorUtils.RandomQuote();
            tooltips.Add(new TooltipLine(Mod, "Quote", $"{theString}"));
            tooltips.Add(new TooltipLine(Mod, "RainbowText", "'bottom text lol'"));
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "RecolorMod" && tooltipLine.Name == "RainbowText")
                {
                    tooltipLine.overrideColor = Main.DiscoColor;
                }
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
            Item.rare = ModContent.RarityType<Rarities.Developer>();
            Item.value = Item.sellPrice(300, 500, 900, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
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
        public override void UpdateInventory(Player player)
        {
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
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient<UnboxingEssence>(50)
            .AddIngredient<Items.Aquamarine>(1700)
            .AddIngredient<ColoriteBar>(500)
            .AddTile<Tiles.BismuthForge>()
            .Register();
        }

        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Item.color = new Color(Main.DiscoR, 0, Main.DiscoB);
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Item.color = new Color(Main.DiscoR, 0, Main.DiscoB);
        }
    }
}
