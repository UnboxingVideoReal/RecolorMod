using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace RecolorMod.Tiles{	public class BambiGrass : ModTile	{		public override void SetStaticDefaults()		{			AddMapEntry(new Color(0, 255, 0));            SetModTree(new PhonewoodTree());
            Main.tileSolid[Type] = true;			Main.tileBrick[Type] = true;			Main.tileBlockLight[Type] = true;            Main.tileBlendAll[Type] = true;            Main.tileMergeDirt[Type] = true;
            TileID.Sets.Conversion.Grass[Type] = true;            TileID.Sets.ForcedDirtMerging[Type] = true;
            ItemDrop = ItemID.DirtBlock;		}        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (fail && !effectOnly)
            {
                Main.tile[i, j].type = TileID.Dirt;
                WorldGen.SquareTileFrame(i, j);
            }
        }
    }}