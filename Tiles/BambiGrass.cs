using Microsoft.Xna.Framework;
            Main.tileSolid[Type] = true;
            TileID.Sets.Conversion.Grass[Type] = true;
            ItemDrop = ItemID.DirtBlock;
        {
            if (fail && !effectOnly)
            {
                Main.tile[i, j].type = TileID.Dirt;
                WorldGen.SquareTileFrame(i, j);
            }
        }
    }