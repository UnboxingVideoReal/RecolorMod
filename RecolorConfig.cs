using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;
using Terraria;
using Terraria.ModLoader;
using System.ComponentModel;
using Microsoft.Xna.Framework;

namespace RecolorMod
{
    public class RecolorConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("General")]

        [Range(0, 500)]
        [Label("Bismuth Gen Strength")]
        [Tooltip("This sets the strength of the generation of bismuth ore to the number you input.")]
        [DefaultValue(50)]
        public int bismuthOreStrength;

        [Header("Enchantments")]

        [Range(0, 100)]
        [Label("Prism Orbs")]
        [Tooltip("This sets the max of how many Prism Orbs can spawn.")]
        [DefaultValue(15)]
        public int prismOrbMax;
    }
}
