using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace SolanumMod.Projectiles
{
	public class AquaticPerilHealingOrb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Healing Orb");
		}

		public override void SetDefaults()
		{
			base.projectile.width = 18;
			base.projectile.height = 18;
			base.projectile.friendly = true;
			base.projectile.penetrate = 1;
			base.projectile.tileCollide = false;
			base.projectile.timeLeft = 420; //Change how long they live for.
			base.projectile.extraUpdates = 1;
			base.projectile.hide = true;
		}
		
		public override void AI()
		{
			Projectile projectile = base.projectile;
			projectile.velocity.X = projectile.velocity.X * 0.985f;
			Projectile projectile2 = base.projectile;
			projectile2.velocity.Y = projectile2.velocity.Y * 0.985f;
			int num = (int)base.projectile.ai[0];
			Vector2 vector = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
			float num2 = Main.player[num].Center.X - vector.X;
			float num3 = Main.player[num].Center.Y - vector.Y;
			float num4 = (float)Math.Sqrt((double)(num2 * num2 + num3 * num3));
			if (num4 < 50f && base.projectile.position.X < Main.player[num].position.X + (float)Main.player[num].width && base.projectile.position.X + (float)base.projectile.width > Main.player[num].position.X && base.projectile.position.Y < Main.player[num].position.Y + (float)Main.player[num].height && base.projectile.position.Y + (float)base.projectile.height > Main.player[num].position.Y)
			{
				if (base.projectile.owner == Main.myPlayer) //The things in here make the healing work, it's a bit more complex than that, but that's the best way I can explain i guess
				{
					int num5 = Main.rand.Next(5, 7); // This is the amount that the orb heals for. You can do Main.rand.Next(number, biggernumber) if you want randomized healing
					Main.player[num].HealEffect(num5, false);
					Main.player[num].statLife += num5;
					if (Main.player[num].statLife > Main.player[num].statLifeMax2)
					{
						Main.player[num].statLife = Main.player[num].statLifeMax2;
					}
					NetMessage.SendData(66, -1, -1, null, num, (float)num5, 0f, 0f, 0, 0, 0);
				}
				base.projectile.Kill();
			}
			float num6 = base.projectile.velocity.X * 0.3f * 1f;
			float num7 = -(base.projectile.velocity.Y * 0.3f) * 1f;
			int num8 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 1f);
			Main.dust[num8].noGravity = true;
			Main.dust[num8].velocity *= 0.1f;
			Dust dust = Main.dust[num8];
			dust.position.X = dust.position.X - num6;
			Dust dust2 = Main.dust[num8];
			dust2.position.Y = dust2.position.Y - num7;
		}
	}
}
