﻿using RecolorMod.Items;
using RecolorMod.Tiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace RecolorMod.Items
{
	public class BlueSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue Solution");
			Tooltip.SetDefault("Used by the Clentaminator\nSpreads the water");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}

		public override void SetDefaults()
		{
			Item.shoot = ModContent.ProjectileType<BlueSolutionProjectile>() - ProjectileID.PureSpray;
			Item.ammo = AmmoID.Solution;
			Item.width = 12;
			Item.height = 14;
			Item.value = Item.buyPrice(0, 0, 25, 0);
			Item.rare = 3;
			Item.maxStack = 999;
			Item.consumable = true;
		}

		public class BlueSolutionProjectile : ModProjectile
		{

			public ref float Progress => ref Projectile.ai[0];

			public override void SetStaticDefaults()
			{
				DisplayName.SetDefault("Blue Spray");
			}

			public override void SetDefaults()
			{
				Projectile.width = 6;
				Projectile.height = 6;
				Projectile.friendly = true;
				Projectile.alpha = 255;
				Projectile.penetrate = -1;
				Projectile.extraUpdates = 2;
				Projectile.tileCollide = false;
				Projectile.ignoreWater = true;
			}

			public override void AI()
			{
				int dustType = DustID.WaterCandle;

				if (Projectile.owner == Main.myPlayer)
				{
					Convert((int)(Projectile.position.X + (Projectile.width * 0.5f)) / 16, (int)(Projectile.position.Y + (Projectile.height * 0.5f)) / 16, 2);
				}

				if (Projectile.timeLeft > 133)
				{
					Projectile.timeLeft = 133;
				}

				if (Progress > 7f)
				{
					float dustScale = 1f;

					if (Progress == 8f)
					{
						dustScale = 0.2f;
					}
					else if (Progress == 9f)
					{
						dustScale = 0.4f;
					}
					else if (Progress == 10f)
					{
						dustScale = 0.6f;
					}
					else if (Progress == 11f)
					{
						dustScale = 0.8f;
					}

					Progress += 1f;

					int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, dustType, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100);
					Dust dust = Main.dust[dustIndex];
					dust.noGravity = true;
					dust.scale *= 1.75f;
					dust.velocity.X *= 2f;
					dust.velocity.Y *= 2f;
					dust.scale *= dustScale;
				}
				else
				{
					Progress += 1f;
				}

				Projectile.rotation += 0.3f * Projectile.direction;
			}

			private static void Convert(int i, int j, int size = 4)
			{
				for (int k = i - size; k <= i + size; k++)
				{
					for (int l = j - size; l <= j + size; l++)
					{
						if (WorldGen.InWorld(k, l, 1) && Math.Abs(k - i) + Math.Abs(l - j) < Math.Sqrt((size * size) + (size * size)))
						{
							int type = Main.tile[k, l].TileType;
							int wall = Main.tile[k, l].WallType;
							if (TileID.Sets.Conversion.Grass[type])
							{
								Main.tile[k, l].TileType = (ushort)ModContent.TileType<Watergrass>();
								WorldGen.SquareTileFrame(k, l);
								NetMessage.SendTileSquare(-1, k, l, 1);
							}
							//if (TileID.Sets.Conversion.Stone[type])
							//{
							//	Main.tile[k, l].type = (ushort)ModContent.TileType<Chunkstone>();
							//	WorldGen.SquareTileFrame(k, l);
							//	NetMessage.SendTileSquare(-1, k, l, 1);
							//}
							//if (TileID.Sets.Conversion.Sand[type])
							//{
							//	Main.tile[k, l].type = (ushort)ModContent.TileType<Snotsand>();
							//	WorldGen.SquareTileFrame(k, l);
							//	NetMessage.SendTileSquare(-1, k, l, 1);
							//}
							//if (TileID.Sets.Conversion.Sandstone[type])
							//{
							//	Main.tile[k, l].type = (ushort)ModContent.TileType<Snotsandstone>();
							//	WorldGen.SquareTileFrame(k, l);
							//	NetMessage.SendTileSquare(-1, k, l, 1);
							//}
							//if (TileID.Sets.Conversion.HardenedSand[type])
							//{
							//	Main.tile[k, l].type = (ushort)ModContent.TileType<HardenedSnotsand>();
							//	WorldGen.SquareTileFrame(k, l);
							//	NetMessage.SendTileSquare(-1, k, l, 1);
							//}
							//if (TileID.Sets.Conversion.Ice[type])
							//{
							//	Main.tile[k, l].type = (ushort)ModContent.TileType<YellowIce>();
							//	WorldGen.SquareTileFrame(k, l);
							//	NetMessage.SendTileSquare(-1, k, l, 1);
							//}
						}
					}
				}
			}
		}
	}
}