using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.ModLoader.Assets;
using RecolorMod;
using Terraria;

namespace RecolorMod.Tiles
{
    class PhonewoodTree : ModTree
    {
        private Mod mod
        {
            get
            {
                return ModLoader.GetMod("RecolorMod");
            }
        }

        public override int DropWood()
        {
            return ModContent.ItemType<Items.phone>();
        }

        public override Texture2D GetTexture()
        {
            return ModContent.Request<Texture2D>("Tiles/PhonewoodTree").Value;
        }

        public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
        {
            return ModContent.Request<Texture2D>("Tiles/PhonewoodTreeBranches").Value;
        }

        public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
        {
            frameWidth = 80;
            frameHeight = 80;
            yOffset += 2;
            //xOffsetLeft += 16;
            return ModContent.Request<Texture2D>("Tiles/PhonewoodTreeTop").Value;
        }
    }
}
