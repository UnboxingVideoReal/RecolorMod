//using Microsoft.Xna.Framework;
//using Terraria.ID;
//using Terraria.ModLoader;
//using Terraria;
//using System;

//namespace RecolorMod
//{
//    public class SpawnDemoniteHouse
//    {
//        public static void AddDemoniteHouse()
//        {
//            int num = (int)((double)Main.maxTilesX * 0.25);
//            for (int i = 100; i < Main.maxTilesX - 100; i++)
//            {
//                if ((WorldGen.drunkWorldGen && i > num && i < Main.maxTilesX - num) || (!WorldGen.drunkWorldGen && (i < num || i > Main.maxTilesX - num)))
//                {
//                    continue;
//                }
//                int num2 = Main.maxTilesY - 40;
//                while (Main.tile[i, num2].IsActive || Main.tile[i, num2].LiquidType > 0)
//                {
//                    num2--;
//                }
//                if (Main.tile[i, num2 + 1].IsActive)
//                {
//                    ushort num3 = (ushort)WorldGen.genRand.Next(140);
//                    byte wallType = 13;
//                    if (WorldGen.genRand.Next(5) > 0)
//                    {
//                        num3 = TileID.DemoniteBrick;
//                    }
//                    if (num3 == TileID.DemoniteBrick)
//                    {
//                        wallType = (byte)WallID.DemoniteBrick;
//                    }
//                    if (WorldGen.getGoodWorldGen)
//                    {
//                        num3 = TileID.DemoniteBrick;
//                    }
//                    WorldGen.HellFort(i, num2, num3, wallType);
//                    i += WorldGen.genRand.Next(0, 1);
//                    if (WorldGen.genRand.Next(10) == 0)
//                    {
//                        i += WorldGen.genRand.Next(0, 1);
//                    }
//                }
//            }
//            float num4 = Main.maxTilesX / 4200;
//            for (int j = 0; (float)j < 200f * num4; j++)
//            {
//                int num5 = 0;
//                bool flag = false;
//                while (!flag)
//                {
//                    num5++;
//                    int num6 = WorldGen.genRand.Next((int)((double)Main.maxTilesX * 0.2), (int)((double)Main.maxTilesX * 0.8));
//                    int num7 = WorldGen.genRand.Next(Main.maxTilesY - 300, Main.maxTilesY - 20);
//                    if (Main.tile[num6, num7].IsActive && (Main.tile[num6, num7].type == (ushort)ModContent.TileType<Tiles.CorestoneBrick>() || Main.tile[num6, num7].type == (ushort)ModContent.TileType<Tiles.CorestoneBrick>()))
//                    {
//                        int num8 = 0;
//                        if (Main.tile[num6 - 1, num7].wall > 0)
//                        {
//                            num8 = -1;
//                        }
//                        else if (Main.tile[num6 + 1, num7].wall > 0)
//                        {
//                            num8 = 1;
//                        }
//                        if (!Main.tile[num6 + num8, num7].IsActive && !Main.tile[num6 + num8, num7 + 1].IsActive)
//                        {
//                            bool flag2 = false;
//                            for (int k = num6 - 8; k < num6 + 8; k++)
//                            {
//                                for (int l = num7 - 8; l < num7 + 8; l++)
//                                {
//                                    if (Main.tile[k, l].IsActive && TileID.Sets.Torch[Main.tile[k, l].type])
//                                    {
//                                        flag2 = true;
//                                        break;
//                                    }
//                                }
//                            }
//                            if (!flag2)
//                            {
//                                WorldGen.PlaceTile(num6 + num8, num7, 4, mute: true, forced: true, -1, 7);
//                                flag = true;
//                            }
//                        }
//                    }
//                    if (num5 > 1000)
//                    {
//                        flag = true;
//                    }
//                }
//            }
//            float num9 = 4200000f / (float)Main.maxTilesX;
//            for (int m = 0; (float)m < num9; m++)
//            {
//                int num10 = 0;
//                int num11 = WorldGen.genRand.Next(num, Main.maxTilesX - num);
//                int n = WorldGen.genRand.Next(Main.maxTilesY - 250, Main.maxTilesY - 20);
//                while ((Main.tile[num11, n].wall != 13 && Main.tile[num11, n].wall != 14) || Main.tile[num11, n].IsActive)
//                {
//                    num11 = WorldGen.genRand.Next(num, Main.maxTilesX - num);
//                    n = WorldGen.genRand.Next(Main.maxTilesY - 250, Main.maxTilesY - 20);
//                    if (WorldGen.drunkWorldGen)
//                    {
//                        num11 = ((WorldGen.genRand.Next(2) != 0) ? WorldGen.genRand.Next(Main.maxTilesX - num, Main.maxTilesX - 50) : WorldGen.genRand.Next(1, num));
//                    }
//                    num10++;
//                    if (num10 > 100000)
//                    {
//                        break;
//                    }
//                }
//                if (num10 > 100000 || (Main.tile[num11, n].wall != 13 && Main.tile[num11, n].wall != 14) || Main.tile[num11, n].IsActive)
//                {
//                    continue;
//                }
//                for (; !WorldGen.SolidTile(num11, n) && n < Main.maxTilesY - 20; n++)
//                {
//                }
//                n--;
//                int num12 = num11;
//                int num13 = num11;
//                while (!Main.tile[num12, n].IsActive && WorldGen.SolidTile(num12, n + 1))
//                {
//                    num12--;
//                }
//                num12++;
//                for (; !Main.tile[num13, n].IsActive && WorldGen.SolidTile(num13, n + 1); num13++)
//                {
//                }
//                num13--;
//                int num14 = num13 - num12;
//                int num15 = (num13 + num12) / 2;
//                if (Main.tile[num15, n].IsActive || (Main.tile[num15, n].wall != 13 && Main.tile[num15, n].wall != 14) || !WorldGen.SolidTile(num15, n + 1))
//                {
//                    continue;
//                }
//                int style = 16;
//                int style2 = 13;
//                int style3 = 14;
//                int style4 = 49;
//                int style5 = 4;
//                int style6 = 8;
//                int style7 = 15;
//                int style8 = 9;
//                int style9 = 10;
//                int style10 = 17;
//                int style11 = 25;
//                int style12 = 25;
//                int style13 = 23;
//                int style14 = 25;
//                int num16 = WorldGen.genRand.Next(13);
//                int num17 = 0;
//                int num18 = 0;
//                if (num16 == 0)
//                {
//                    num17 = 5;
//                    num18 = 4;
//                }
//                if (num16 == 1)
//                {
//                    num17 = 4;
//                    num18 = 3;
//                }
//                if (num16 == 2)
//                {
//                    num17 = 3;
//                    num18 = 5;
//                }
//                if (num16 == 3)
//                {
//                    num17 = 4;
//                    num18 = 6;
//                }
//                if (num16 == 4)
//                {
//                    num17 = 3;
//                    num18 = 3;
//                }
//                if (num16 == 5)
//                {
//                    num17 = 5;
//                    num18 = 3;
//                }
//                if (num16 == 6)
//                {
//                    num17 = 5;
//                    num18 = 4;
//                }
//                if (num16 == 7)
//                {
//                    num17 = 5;
//                    num18 = 4;
//                }
//                if (num16 == 8)
//                {
//                    num17 = 5;
//                    num18 = 4;
//                }
//                if (num16 == 9)
//                {
//                    num17 = 3;
//                    num18 = 5;
//                }
//                if (num16 == 10)
//                {
//                    num17 = 5;
//                    num18 = 3;
//                }
//                if (num16 == 11)
//                {
//                    num17 = 2;
//                    num18 = 4;
//                }
//                if (num16 == 12)
//                {
//                    num17 = 3;
//                    num18 = 3;
//                }
//                for (int num19 = num15 - num17; num19 <= num15 + num17; num19++)
//                {
//                    for (int num20 = n - num18; num20 <= n; num20++)
//                    {
//                        if (Main.tile[num19, num20].IsActive)
//                        {
//                            num16 = -1;
//                            break;
//                        }
//                    }
//                }
//                if ((double)num14 < (double)num17 * 1.75)
//                {
//                    num16 = -1;
//                }
//                switch (num16)
//                {
//                    case 0:
//                        {
//                            WorldGen.PlaceTile(num15, n, 14, mute: true, forced: false, -1, style2);
//                            int num22 = WorldGen.genRand.Next(6);
//                            if (num22 < 3)
//                            {
//                                WorldGen.PlaceTile(num15 + num22, n - 2, 33, mute: true, forced: false, -1, style12);
//                            }
//                            if (!Main.tile[num15, n].IsActive)
//                            {
//                                break;
//                            }
//                            if (!Main.tile[num15 - 2, n].IsActive)
//                            {
//                                WorldGen.PlaceTile(num15 - 2, n, 15, mute: true, forced: false, -1, style);
//                                if (Main.tile[num15 - 2, n].IsActive)
//                                {
//                                    Main.tile[num15 - 2, n].frameX += 18;
//                                    Main.tile[num15 - 2, n - 1].frameX += 18;
//                                }
//                            }
//                            if (!Main.tile[num15 + 2, n].IsActive)
//                            {
//                                WorldGen.PlaceTile(num15 + 2, n, 15, mute: true, forced: false, -1, style);
//                            }
//                            break;
//                        }
//                    case 1:
//                        {
//                            WorldGen.PlaceTile(num15, n, 18, mute: true, forced: false, -1, style3);
//                            int num21 = WorldGen.genRand.Next(4);
//                            if (num21 < 2)
//                            {
//                                WorldGen.PlaceTile(num15 + num21, n - 1, 33, mute: true, forced: false, -1, style12);
//                            }
//                            if (!Main.tile[num15, n].IsActive)
//                            {
//                                break;
//                            }
//                            if (WorldGen.genRand.Next(2) == 0)
//                            {
//                                if (!Main.tile[num15 - 1, n].IsActive)
//                                {
//                                    WorldGen.PlaceTile(num15 - 1, n, 15, mute: true, forced: false, -1, style);
//                                    if (Main.tile[num15 - 1, n].IsActive)
//                                    {
//                                        Main.tile[num15 - 1, n].frameX += 18;
//                                        Main.tile[num15 - 1, n - 1].frameX += 18;
//                                    }
//                                }
//                            }
//                            else if (!Main.tile[num15 + 2, n].IsActive)
//                            {
//                                WorldGen.PlaceTile(num15 + 2, n, 15, mute: true, forced: false, -1, style);
//                            }
//                            break;
//                        }
//                    case 2:
//                        WorldGen.PlaceTile(num15, n, 105, mute: true, forced: false, -1, style4);
//                        break;
//                    case 3:
//                        WorldGen.PlaceTile(num15, n, 101, mute: true, forced: false, -1, style5);
//                        break;
//                    case 4:
//                        if (WorldGen.genRand.Next(2) == 0)
//                        {
//                            WorldGen.PlaceTile(num15, n, 15, mute: true, forced: false, -1, style);
//                            Main.tile[num15, n].frameX += 18;
//                            Main.tile[num15, n - 1].frameX += 18;
//                        }
//                        else
//                        {
//                            WorldGen.PlaceTile(num15, n, 15, mute: true, forced: false, -1, style);
//                        }
//                        break;
//                    case 5:
//                        if (WorldGen.genRand.Next(2) == 0)
//                        {
//                            WorldGen.Place4x2(num15, n, 79, 1, style6);
//                        }
//                        else
//                        {
//                            WorldGen.Place4x2(num15, n, 79, -1, style6);
//                        }
//                        break;
//                    case 6:
//                        WorldGen.PlaceTile(num15, n, 87, mute: true, forced: false, -1, style7);
//                        break;
//                    case 7:
//                        WorldGen.PlaceTile(num15, n, 88, mute: true, forced: false, -1, style8);
//                        break;
//                    case 8:
//                        WorldGen.PlaceTile(num15, n, 89, mute: true, forced: false, -1, style9);
//                        break;
//                    case 9:
//                        WorldGen.PlaceTile(num15, n, 104, mute: true, forced: false, -1, style10);
//                        break;
//                    case 10:
//                        if (WorldGen.genRand.Next(2) == 0)
//                        {
//                            WorldGen.Place4x2(num15, n, 90, 1, style14);
//                        }
//                        else
//                        {
//                            WorldGen.Place4x2(num15, n, 90, -1, style14);
//                        }
//                        break;
//                    case 11:
//                        WorldGen.PlaceTile(num15, n, 93, mute: true, forced: false, -1, style13);
//                        break;
//                    case 12:
//                        WorldGen.PlaceTile(num15, n, 100, mute: true, forced: false, -1, style11);
//                        break;
//                }
//            }
//            num9 = 420000f / (float)Main.maxTilesX;
//            for (int num23 = 0; (float)num23 < num9; num23++)
//            {
//                int num24 = 0;
//                int num25 = WorldGen.genRand.Next(num, Main.maxTilesX - num);
//                int num26 = WorldGen.genRand.Next(Main.maxTilesY - 250, Main.maxTilesY - 20);
//                while ((Main.tile[num25, num26].wall != 13 && Main.tile[num25, num26].wall != 14) || Main.tile[num25, num26].IsActive)
//                {
//                    num25 = WorldGen.genRand.Next(num, Main.maxTilesX - num);
//                    num26 = WorldGen.genRand.Next(Main.maxTilesY - 250, Main.maxTilesY - 20);
//                    if (WorldGen.drunkWorldGen)
//                    {
//                        num25 = ((WorldGen.genRand.Next(2) != 0) ? WorldGen.genRand.Next(Main.maxTilesX - num, Main.maxTilesX - 50) : WorldGen.genRand.Next(50, num));
//                    }
//                    num24++;
//                    if (num24 > 100000)
//                    {
//                        break;
//                    }
//                }
//                if (num24 > 100000)
//                {
//                    continue;
//                }
//                int num27 = num25;
//                int num28 = num25;
//                int num29 = num26;
//                int num30 = num26;
//                int num31 = 0;
//                for (int num32 = 0; num32 < 2; num32++)
//                {
//                    num27 = num25;
//                    num28 = num25;
//                    while (!Main.tile[num27, num26].IsActive && (Main.tile[num27, num26].wall == 13 || Main.tile[num27, num26].wall == 14))
//                    {
//                        num27--;
//                    }
//                    num27++;
//                    for (; !Main.tile[num28, num26].IsActive && (Main.tile[num28, num26].wall == 13 || Main.tile[num28, num26].wall == 14); num28++)
//                    {
//                    }
//                    num28--;
//                    num25 = (num27 + num28) / 2;
//                    num29 = num26;
//                    num30 = num26;
//                    while (!Main.tile[num25, num29].IsActive && (Main.tile[num25, num29].wall == 13 || Main.tile[num25, num29].wall == 14))
//                    {
//                        num29--;
//                    }
//                    num29++;
//                    for (; !Main.tile[num25, num30].IsActive && (Main.tile[num25, num30].wall == 13 || Main.tile[num25, num30].wall == 14); num30++)
//                    {
//                    }
//                    num30--;
//                    num26 = (num29 + num30) / 2;
//                }
//                num27 = num25;
//                num28 = num25;
//                while (!Main.tile[num27, num26].IsActive && !Main.tile[num27, num26 - 1].IsActive && !Main.tile[num27, num26 + 1].IsActive)
//                {
//                    num27--;
//                }
//                num27++;
//                for (; !Main.tile[num28, num26].IsActive && !Main.tile[num28, num26 - 1].IsActive && !Main.tile[num28, num26 + 1].IsActive; num28++)
//                {
//                }
//                num28--;
//                num29 = num26;
//                num30 = num26;
//                while (!Main.tile[num25, num29].IsActive && !Main.tile[num25 - 1, num29].IsActive && !Main.tile[num25 + 1, num29].IsActive)
//                {
//                    num29--;
//                }
//                num29++;
//                for (; !Main.tile[num25, num30].IsActive && !Main.tile[num25 - 1, num30].IsActive && !Main.tile[num25 + 1, num30].IsActive; num30++)
//                {
//                }
//                num30--;
//                num25 = (num27 + num28) / 2;
//                num26 = (num29 + num30) / 2;
//                int num33 = num28 - num27;
//                num31 = num30 - num29;
//                if (num33 <= 7 || num31 <= 5)
//                {
//                    continue;
//                }
//                int num34 = 0;
//                if (WorldGen.nearPicture2(num25, num26))
//                {
//                    num34 = -1;
//                }
//                if (num34 == 0)
//                {
//                    Vector2 val = WorldGen.randHellPicture();
//                    int type = (int)val.X;
//                    int style15 = (int)val.Y;
//                    if (!WorldGen.nearPicture(num25, num26))
//                    {
//                        WorldGen.PlaceTile(num25, num26, type, mute: true, forced: false, -1, style15);
//                    }
//                }
//            }
//            int[] array = new int[3]
//            {
//        WorldGen.genRand.Next(16, 22),
//        WorldGen.genRand.Next(16, 22),
//        WorldGen.genRand.Next(16, 22)
//            };
//            while (array[1] == array[0])
//            {
//                array[1] = WorldGen.genRand.Next(16, 22);
//            }
//            while (array[2] == array[0] || array[2] == array[1])
//            {
//                array[2] = WorldGen.genRand.Next(16, 22);
//            }
//            num9 = 420000f / (float)Main.maxTilesX;
//            for (int num35 = 0; (float)num35 < num9; num35++)
//            {
//                int num36 = 0;
//                int num37;
//                int num38;
//                do
//                {
//                    num37 = WorldGen.genRand.Next(num, Main.maxTilesX - num);
//                    num38 = WorldGen.genRand.Next(Main.maxTilesY - 250, Main.maxTilesY - 20);
//                    if (WorldGen.drunkWorldGen)
//                    {
//                        num37 = ((WorldGen.genRand.Next(2) != 0) ? WorldGen.genRand.Next(Main.maxTilesX - num, Main.maxTilesX - 50) : WorldGen.genRand.Next(50, num));
//                    }
//                    num36++;
//                }
//                while (num36 <= 100000 && ((Main.tile[num37, num38].wall != 13 && Main.tile[num37, num38].wall != 14) || Main.tile[num37, num38].IsActive));
//                if (num36 > 100000)
//                {
//                    continue;
//                }
//                while (!WorldGen.SolidTile(num37, num38) && num38 > 10)
//                {
//                    num38--;
//                }
//                num38++;
//                if (Main.tile[num37, num38].wall != 13 && Main.tile[num37, num38].wall != 14)
//                {
//                    continue;
//                }
//                int num39 = WorldGen.genRand.Next(3);
//                int style16 = 32;
//                int style17 = 32;
//                int num40;
//                int num41;
//                switch (num39)
//                {
//                    default:
//                        num40 = 1;
//                        num41 = 3;
//                        break;
//                    case 1:
//                        num40 = 3;
//                        num41 = 3;
//                        break;
//                    case 2:
//                        num40 = 1;
//                        num41 = 2;
//                        break;
//                }
//                for (int num42 = num37 - 1; num42 <= num37 + num40; num42++)
//                {
//                    for (int num43 = num38; num43 <= num38 + num41; num43++)
//                    {
//                        Tile tile = Main.tile[num37, num38];
//                        if (num42 < num37 || num42 == num37 + num40)
//                        {
//                            if (tile.IsActive)
//                            {
//                                switch (tile.type)
//                                {
//                                    case 10:
//                                    case 11:
//                                    case 34:
//                                    case 42:
//                                    case 91:
//                                        num39 = -1;
//                                        break;
//                                }
//                            }
//                        }
//                        else if (tile.IsActive)
//                        {
//                            num39 = -1;
//                        }
//                    }
//                }
//                switch (num39)
//                {
//                    case 0:
//                        WorldGen.PlaceTile(num37, num38, 91, mute: true, forced: false, -1, array[WorldGen.genRand.Next(3)]);
//                        break;
//                    case 1:
//                        WorldGen.PlaceTile(num37, num38, 34, mute: true, forced: false, -1, style16);
//                        break;
//                    case 2:
//                        WorldGen.PlaceTile(num37, num38, 42, mute: true, forced: false, -1, style17);
//                        break;
//                }
//            }
//        }
//    }
//}