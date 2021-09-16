using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.Localization;

namespace RecolorMod.Tiles
{
    public class Aquamarine : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(0, 255, 255), LanguageManager.Instance.GetText("Aquamarine"));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            ItemDrop = ModContent.ItemType<Items.Aquamarine>();
            Main.tileMerge[TileID.Stone][Type] = true;
            Main.tileMerge[Type][TileID.Stone] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            SoundType = SoundID.Tink;
            SoundStyle = 1;
            MinPick = 200;
            DustType = 1;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}