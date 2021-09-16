using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.ModLoader.Assets;
using RecolorMod;
using Terraria;
using Terraria.ID;

namespace RecolorMod.Tiles
{
    class WetTree : ModTree
    {
        private Mod mod
        {
            get
            {
                return ModLoader.GetMod("RecolorMod");
            }
        }

        public override int CreateDust()
        {
            return DustID.WaterCandle;
        }

        public override int GrowthFXGore()
        {
            return DustID.WaterCandle;
        }

        public override int DropWood()
        {
            return ModContent.ItemType<Items.Wetwood>();
        }

        public override Texture2D GetTexture()
        {
            return ModContent.Request<Texture2D>("Tiles/WetTree").Value;
        }

        public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
        {
            return ModContent.Request<Texture2D>("Tiles/WetTree_Branches").Value;
        }

        public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
        {
            frameWidth = 80;
            frameHeight = 80;
            yOffset += 2;
            //xOffsetLeft += 16;
            return ModContent.Request<Texture2D>("Tiles/WetTreeTree_Top").Value;
        }
    }
}
