using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.ID;
using System.Collections;
using System.Collections.Generic;
namespace SolanumMod.Projectiles
{
    public class SmolHomingBubbles : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Homing Bubble");
            Main.projFrames[projectile.type] = 3;
        }
        int bubbleState = Main.rand.Next(3);
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.damage = 20;
            projectile.knockBack = 0.5f;
            projectile.ranged = true;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.frame = bubbleState;
            projectile.timeLeft = 240;
            projectile.penetrate = 1;
        }
        bool foundTarget;
        Vector2 targetCenter;
        float distanceFromTarget;
        int npcAE;
        public override void AI()
        {
            Vector2 floatypos = new Vector2((float)Math.Cos(Main.GlobalTime / 1f) * .45f, (float)Math.Sin(Main.GlobalTime / 1.37f) * .45f);
            if(!foundTarget)
            {
                for(int i = 0;i<Main.maxNPCs;i++)
                {
                    NPC bruh = Main.npc[i];
                    if (bruh.CanBeChasedBy()) {
						bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height,bruh.position, bruh.width, bruh.height);

						if (bruh.active && !bruh.friendly && lineOfSight) {
							distanceFromTarget = Vector2.Distance(projectile.Center,bruh.Center);
                            npcAE = bruh.whoAmI;
                            foundTarget = true; 
						}
					}
                }
            }
            NPC npc = Main.npc[npcAE];
            float shootToX = npc.Center.X - projectile.Center.X;
            float shootToY = npc.Center.Y - projectile.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

            if (npc.active)
            {
                distance = 3f / distance;

                float speed = 2f;

                shootToX *= distance * speed;
                shootToY *= distance * speed;

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
                Dust dust = Dust.NewDustPerfect(projectile.Center + (vector * 40), DustID.Vortex, vector * 6f, 100, Color.Aquamarine,0.5f);
                dust.noGravity = true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.Kill();
        }
    }
}