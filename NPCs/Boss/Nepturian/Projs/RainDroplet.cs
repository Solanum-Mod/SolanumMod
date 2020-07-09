using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace SolanumMod.NPCs.Boss.Nepturian.Projs
{
    class RainDroplet : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 20;
            projectile.timeLeft = 200;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }
        public override void AI()
        {
            projectile.velocity += new Vector2(0, 1.2f);
            int num4;
            for (int num97 = 0; num97 < 5; num97 = num4 + 1)
            {
                float num98 = projectile.velocity.X / 3f * (float)num97;
                float num99 = projectile.velocity.Y / 3f * (float)num97;
                int num100 = 4;
                int num101 = Dust.NewDust(new Vector2(projectile.position.X + (float)num100, projectile.position.Y + (float)num100), projectile.width - num100 * 2, projectile.height - num100 * 2, 172, 0f, 0f, 100, Color.MediumAquamarine, 1.2f);
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
        }
    }
}
