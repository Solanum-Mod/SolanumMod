using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SolanumMod.Accessories
{
	public class AquaticPeril : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Aquatic Peril"); 
			base.Tooltip.SetDefault("Spawns healing orbs while submerged in water");
		}

		public override void SetDefaults()
		{
			base.item.width = 30;
			base.item.height = 56;
			item.value = Item.buyPrice(0, 4, 20, 0); //No idea how far into the game the item will be made, buy price is random
			base.item.rare = 6;
			base.item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.wet) //if you want the orbs to spawn ONLY if the player is fully submerged, then change if(player.wet) to if (Collision.DrownCollision(player.position, player.width, player.height, player.gravDir))
			{
				if (Main.rand.Next(50) == 0) //Change this if you want to change how regularly the orbs spawn?
				{
					int numxd = 0;
					for (int i = 0; i < 800; i++)
					{
						if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].type == base.mod.ProjectileType("AquaticPerilHealingOrb"))
						{
							numxd++;
						}
					}
					if (Main.rand.Next(30) >= numxd && numxd < 10) 
					{
						int numxd2 = 90; 
						int numxd3 = 45; //This I don't really know if you should change, friend helped with some of the nums and he said these numbers were prolly the best. 
						int numxd4 = 60;
						for (int j = 0; j < numxd2; j++)
						{
							int numxd5 = Main.rand.Next(200 - j * 2, 250 + j * 2); //Can be changed, changes how far the orbs can spawn
							Vector2 center = player.Center;
							center.X += (float)Main.rand.Next(-numxd5, numxd5 + 1);
							center.Y += (float)Main.rand.Next(-numxd5, numxd5 + 1);
							if (!Collision.SolidCollision(center, numxd3, numxd3))
							{
								center.X += (float)(numxd3 / 2);
								center.Y += (float)(numxd3 / 2);
								if (Collision.CanHit(new Vector2(player.Center.X, player.position.Y), 1, 1, center, 1, 1))
								{
									int numxd6 = (int)center.X / 16;
									int numxd7 = (int)center.Y / 16; 
									bool status = false;
									if (Main.rand.Next(3) == 0 && Main.tile[numxd6, numxd7] != null)
									{
										status = true;
									}
									else
									{
										center.X -= (float)(numxd4 / 2);
										
									}
									if (status)
									{
										for (int k = 0; k < 800; k++)
										{
											if (Main.projectile[k].active && Main.projectile[k].owner == player.whoAmI && Main.projectile[k].type == base.mod.ProjectileType("AquaticPerilHealingOrb") && (center - Main.projectile[k].Center).Length() < 42f)
											{
												status = false;
												break;
											}  
										}
										if (status && Main.myPlayer == player.whoAmI) //Spawn orb, makes this whole thing start again.
										{
											Projectile.NewProjectile(center.X, center.Y, 0f, 0f, base.mod.ProjectileType("AquaticPerilHealingOrb"), 1, 0f, player.whoAmI, 0f, 0f);
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
