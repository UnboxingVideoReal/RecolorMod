using Microsoft.Xna.Framework;
using RecolorMod.Common.Systems;
using Terraria.GameContent.Creative;

namespace RecolorMod.Items
			Tooltip.SetDefault("holy shit");

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
			RecolorUtils.OverrideDamage(tooltips, "32 trillion ranged");
        }

        public override void SetDefaults()
				return !NPC.AnyNPCs(ModContent.NPCType<NPCs.BambiBoss>());

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			RecolorUtils.LargeNumberDisplay(target, int.MaxValue - 2, target.targetRect, CombatText.OthersDamagedHostile, $"{Main.rand.Next(1, 16)} trillion");
		}
    }