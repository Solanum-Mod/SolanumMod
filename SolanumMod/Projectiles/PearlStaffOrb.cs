using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SolanumMod.Projectiles
{
	public class PearlStaffOrb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pearl Orb");
		}

		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.timeLeft = 40;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.aiStyle = 1;
			projectile.scale = 1.2f;
		}
		
		public override void AI()
		{
			int blueDust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 92, projectile.velocity.X, projectile.velocity.Y, 50, default(Color), 1.2f);
			Main.dust[blueDust].scale = 0.4f;
			Main.dust[blueDust].noGravity = true;
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item110, projectile.position);
			for (int num248 = 0; num248 < 20; num248++)
			{
				int num249 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 92, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 0.5f);
				Dust dust;
				if (Main.rand.Next(3) == 0)
				{
					Main.dust[num249].fadeIn = 0.75f + (float)Main.rand.Next(-8, 9) * 0.01f;
					Main.dust[num249].scale = 0.35f + (float)Main.rand.Next(-8, 9) * 0.01f;
					dust = Main.dust[num249];
					dust.type++;
				}
				else
				{
					Main.dust[num249].scale = 0.65f + (float)Main.rand.Next(-8, 9) * 0.01f;
				}
				Main.dust[num249].noGravity = true;
				dust = Main.dust[num249];
				dust.velocity *= 3f;
				dust = Main.dust[num249];
				dust.velocity -= projectile.oldVelocity / 10f;
			}
			if (Main.myPlayer == projectile.owner)
			{
				int num250 = 5;
				for (int num251 = 0; num251 < num250; num251++)
				{
					Vector2 vector11 = new Vector2(Main.rand.Next(-120, 121), Main.rand.Next(-120, 121));
					while (vector11.X == 0f && vector11.Y == 0f)
					{
						vector11 = new Vector2(Main.rand.Next(-120, 121), Main.rand.Next(-120, 121));
					}
					vector11.Normalize();
					vector11 *= (float)Main.rand.Next(80, 111) * 0.1f;
					Projectile.NewProjectile(projectile.oldPosition.X + (float)(projectile.width / 2), projectile.oldPosition.Y + (float)(projectile.height / 2), vector11.X, vector11.Y, mod.ProjectileType("PearlStaffShatter"), (int)((double)projectile.damage * 0.9), projectile.knockBack * 0.6f, projectile.owner);
				}
			}
		}
	}
}