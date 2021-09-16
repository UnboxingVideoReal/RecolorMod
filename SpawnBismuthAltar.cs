//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Terraria.ModLoader;
//using Terraria.WorldBuilding;
//using Terraria;
//using Terraria.ID;

//namespace RecolorMod
//{
//    public class SpawnBismuthAltar : ModSystem
//    {
//		Player player = new Player();
//        public static void SpawnAltar(int x, int y)
//        {
//			int[,] _structure = {
//				{0,1,1,0},
//				{1,1,1,1},
//				{5,5,5,5},
//				{5,5,5,5},
//				{5,2,5,5},
//				{1,1,1,1}
//			};
//			int PosX = x;  //spawnX and spawnY is where you want the anchor to be when this generates
//			int PosY = y;
//			//i = vertical, j = horizontal
//			for (int confirmPlatforms = 0; confirmPlatforms < 2; confirmPlatforms++)    //Increase the iterations on this outermost for loop if tabletop-objects are not properly spawning
//			{
//				for (int i = 0; i < _structure.GetLength(0); i++)
//				{
//					for (int j = _structure.GetLength(1) - 1; j >= 0; j--)
//					{
//						int k = PosX + j;
//						int l = PosY + i;
//						if (WorldGen.InWorld(k, l, 30))
//						{
//							Tile tile = Framing.GetTileSafely(k, l);
//							switch (_structure[i, j])
//							{
//								case 0:
//									if (confirmPlatforms == 0)
//									{
//										tile.IsActive = false;
//										tile.IsHalfBlock = false;
//										tile.Slope = 0;
//									}
//									break;
//								case 1:
//									tile.IsActive = true;
//									tile.type = 409;
//									tile.Slope = 0;
//									tile.IsHalfBlock = false;
//									break;
//								case 2:
//									if (confirmPlatforms == 1)
//									{
//										tile.IsActive = false;
//										tile.Slope = 0;
//										tile.IsHalfBlock = false;
//										WorldGen.PlaceTile(k, l, 21, true, true, -1, 48);
//									}
//									break;
//								case 3:
//									if (confirmPlatforms == 5)
//									{
//										tile.IsActive = false;
//										tile.IsHalfBlock = false;
//										tile.Slope = 0;
//										tile.type = WallID.LunarBrickWall;
//									}
//									break;
//							}
//						}
//					}
//				}
//			}
//		}
//    }
//}
