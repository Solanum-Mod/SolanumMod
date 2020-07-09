using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolanumMod.NPCs.Boss.Nepturian.Projs
{
    class BubbleHoming2 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.timeLeft = 200;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;

        }
        public override void AI()
        {
            Vector2 floatypos = new Vector2((float)Math.Cos(Main.GlobalTime / 1f) * .45f, (float)Math.Sin(Main.GlobalTime / 1.37f) * .45f);
            Player player = Main.LocalPlayer;

            float shootToX = player.position.X + (float)player.width * 0.5f - projectile.Center.X;
            float shootToY = player.position.Y - projectile.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

            //If the distance between the live targeted npc and the projectile is less than 480 pixels
            if (player.active)
            {
                //Divide the factor, 3f, which is the desired velocity
                distance = 3f / distance;

                float speed = 1.3f;

                //Multiply the distance by a multiplier if you wish the projectile to have go faster
                shootToX *= distance * speed;
                shootToY *= distance * speed;

                //Set the velocities to the shoot values
                projectile.velocity.X = shootToX + floatypos.X;
                projectile.velocity.Y = shootToY + floatypos.Y - 1;
            }
            else projectile.Kill();
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 36; i++)
            {
                float angle = MathHelper.ToRadians(10 * i);
                Vector2 vector = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                Dust dust = Dust.NewDustPerfect(projectile.Center + (vector * 40), DustID.Vortex, vector * 8f, 100, Color.Aquamarine);
                dust.noGravity = true;

            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            projectile.Kill();
        }
    }
}
