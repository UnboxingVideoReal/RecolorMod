using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.Audio;
using RecolorMod.Common.Systems;
using Terraria.GameContent.Creative;

namespace RecolorMod.Items{	public class phonegun : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Phone Gun");
			Tooltip.SetDefault("holy shit");			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
			RecolorUtils.OverrideDamage(tooltips, "32 trillion ranged");
        }

        public override void SetDefaults()		{			Item.DamageType = DamageClass.Ranged;			Item.width = 42;			Item.damage = int.MaxValue - 2;			Item.useTime = 1;			Item.useStyle = 4;			Item.value = 0;			Item.autoReuse = true;  			Item.maxStack = 20;			Item.useAnimation = 1;			Item.height = 48;			Item.rare = ModContent.RarityType<Rarities.Bambi>();			Item.shootSpeed = 30f;			Item.shoot = ModContent.ProjectileType<Projectiles.BloodHoming>();        }        public override bool CanUseItem(Player player)        {
				return !NPC.AnyNPCs(ModContent.NPCType<NPCs.BambiBoss>());        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			RecolorUtils.LargeNumberDisplay(target, int.MaxValue - 2, target.targetRect, CombatText.OthersDamagedHostile, $"{Main.rand.Next(1, 16)} trillion");
		}
    }}