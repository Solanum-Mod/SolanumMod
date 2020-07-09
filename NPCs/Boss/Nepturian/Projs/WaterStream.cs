using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SolanumMod.NPCs.Boss.Nepturian.Projs
{
    class WaterStream : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.timeLeft = 150;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;

        }
        private int shootTimer;
        public override void AI()
        {
            shootTimer++;
            Player player = Main.LocalPlayer;

            if (shootTimer == 1)
            {
                projectile.velocity = projectile.DirectionTo(player.Center) * 6f;
            }
            else if (shootTimer > 1)
                shootTimer = 2;

            int num4;
            for (int num97 = 0; num97 < 5; num97 = num4 + 1)
            {
                float num98 = projectile.velocity.X / 3f * (float)num97;
                float num99 = projectile.velocity.Y / 3f * (float)num97;
                int num100 = 4;
                int num101 = Dust.NewDust(new Vector2(projectile.position.X + (float)num100, projectile.position.Y + (float)num100), projectile.width - num100 * 2, projectile.height - num100 * 2, 172, 0f, 0f, 100, Color.Aquamarine, 1.2f);
                Main.dust[num101].noGravity = true;
                Dust dust3 = Main.dust[num101];
                dust3.velocity *= 0.1f;
                dust3 = Main.dust[num101];
                dust3.velocity += projectile.velocity * 0.1f;
                Dust dust6 = Main.dust[num101];
                dust6.position.X = dust6.position.X - num98;
                Dust dust7 = Main.dust[num101];
                dust7.position.Y = dust7.position.Y - num99;
                num4 = num97;
            }
            if (Main.rand.Next(5) == 0)
            {
                int num102 = 4;
                int num103 = Dust.NewDust(new Vector2(projectile.position.X + (float)num102, projectile.position.Y + (float)num102), projectile.width - num102 * 2, projectile.height - num102 * 2, 172, 0f, 0f, 100, Color.MediumAquamarine, 0.6f);
                Dust dust3 = Main.dust[num103];
                dust3.velocity *= 0.25f;
                dust3 = Main.dust[num103];
                dust3.velocity += projectile.velocity * 0.5f;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            projectile.Kill();
        }
    }
}
