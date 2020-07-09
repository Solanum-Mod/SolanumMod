using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace SolanumMod.NPCs.Boss.Nepturian.Projs
{
    class LeviHead : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 144;
            projectile.height = 296;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.damage = 100;
            projectile.timeLeft = 600;
        }
        public override void AI()
        {
            Player player = Main.LocalPlayer;

            projectile.rotation = projectile.velocity.ToRotation() + (MathHelper.Pi / 2);

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
                projectile.velocity.X = shootToX;
                projectile.velocity.Y = shootToY;
            } else projectile.Kill();
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            for (int i = 0; i < 8; i++) { ChooseBubble(); }

            projectile.Kill();

        }
        public void ChooseBubble()
        {
            int choice = Main.rand.Next(2);
            Projectile.NewProjectile(new Vector2(projectile.Center.X + Main.rand.Next(-50, 50), projectile.Center.Y + Main.rand.Next(-50, 50)),
                new Vector2(projectile.velocity.X + Main.rand.Next(5, 10), projectile.velocity.Y + Main.rand.Next(5, 10)),
                choice == 0 ? ModContent.ProjectileType<Bubble1>() : ModContent.ProjectileType<Bubble2>(), 20, 3f, Main.myPlayer);

        }
    }
}
