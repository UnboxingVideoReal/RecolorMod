using Microsoft.Xna.Framework;
    public class AquamarinePlaced : ModTile
    {
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.CoordinatePadding = 2;
            //TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Aquamarine");
            AddMapEntry(Color.Cyan, name);

        // selects the map entry depending on the frameX
        //public override ushort GetMapOption(int i, int j)
        //{
        //    return (ushort)(Main.tile[i, j].frameX / 18);
        //}

        //public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        //{
        //    int toDrop = 0;
        //    //Main.NewText("" + Main.tile[i, j].frameX);
        //    switch (Main.tile[i, j].frameX / 18)
        //    {
        //        case 0:
        //            toDrop = ModContent.ItemType<Items.Opal>();
        //            break;
        //        case 1:
        //            toDrop = ModContent.ItemType<Items.Onyx>();
        //            break;
        //        case 2:
        //            toDrop = ModContent.ItemType<Items.Kunzite>();
        //            break;
        //        case 3:
        //            toDrop = ModContent.ItemType<Items.Tourmaline>();
        //            break;
        //        case 4:
        //            toDrop = ModContent.ItemType<Items.Peridot>();
        //            break;
        //    }
        //    if (toDrop > 0) Item.NewItem(i * 16, j * 16, 16, 16, toDrop);
        //}

        // copy from the vanilla tileframe for placed gems
        //public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)


        // needed so gems are only allowed to be placed on solid tiles
        public override bool CanPlace(int i, int j)
    }