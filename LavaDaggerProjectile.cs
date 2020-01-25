using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Iampotatsslave
{
	public class LavaDaggerProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("LavaDagger");
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.alpha = 0;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.aiStyle = 1;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 60);
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, 694, (int)(projectile.damage * .5f), 0, projectile.owner);			
			return true;
		}
		

	}
}