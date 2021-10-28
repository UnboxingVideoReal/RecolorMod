using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace RecolorMod.Classes
{
	public class ClericClass : DamageClass
	{
		public override void SetStaticDefaults() {
			// Make weapons with this damage type have a tooltip of 'X example damage'.
			ClassName.SetDefault($"[c/{RecolorUtils.ClericColor.Hex3()}:cleric] damage");
		}

		protected override float GetBenefitFrom(DamageClass damageClass) {
			// Make this damage class not benefit from any otherclass stat bonuses by default, but still benefit from universal/all-class bonuses.
			if (damageClass == Generic)
				return 2f;

			return 0;
		}

		public override bool CountsAs(DamageClass damageClass) {
			// Make this damage class not benefit from any otherclass effects (e.g. Spectre bolts, Magma Stone) by default.
			// Note that unlike GetBenefitFrom, you do not need to account for universal bonuses in this method.
			return false;
		}
	}
}
