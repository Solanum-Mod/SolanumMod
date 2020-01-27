using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SolanumMod.Projectiles
{
	public class PearlStaffShatter : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pearl Shatter");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.timeLeft = 60;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
		}
		
		public override void AI()
		{
			projectile.rotation += 0.2f * (float)projectile.direction;
			projectile.ai[0] += 1f;
			if (projectile.ai[0] >= 11f)
			{
				projectile.ai[0] = 11f;
				projectile.velocity.Y = projectile.velocity.Y + 0.25f;
			}
			if (projectile.velocity.Y > 12f)
			{
				projectile.velocity.Y = 12f;
			}
			int num4;
			for (int num343 = 0; num343 < 2; num343 = num4 + 1)
			{
				int num344 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 92, projectile.velocity.X, projectile.velocity.Y, 50, default(Color), 1.1f);
				//Main.dust[num344].position = (Main.dust[num344].position + projectile.Center) / 2f;
				Main.dust[num344].noGravity = true;
				Main.dust[num344].scale = 0.35f;
				Dust dust3 = Main.dust[num344];
				dust3.velocity *= 0.3f;
				dust3 = Main.dust[num344];
				num4 = num343;
			}	
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item118, projectile.position);
			for (int num246 = 0; num246 < 10; num246++)
			{
				int num247 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 92, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 0.5f);
				Dust dust;
				if (Main.rand.Next(3) == 0)
				{
					Main.dust[num247].fadeIn = 0.75f + (float)Main.rand.Next(-10, 11) * 0.01f;
					Main.dust[num247].scale = 0.25f + (float)Main.rand.Next(-10, 11) * 0.005f;
					dust = Main.dust[num247];
					dust.type++;
				}
				else
				{
					Main.dust[num247].scale = 0.55f + (float)Main.rand.Next(-10, 11) * 0.01f;
				}
				Main.dust[num247].noGravity = true;
				dust = Main.dust[num247];
				dust.velocity *= 1.25f;
				dust = Main.dust[num247];
				dust.velocity -= projectile.oldVelocity / 10f;
			}
		}
	}
}