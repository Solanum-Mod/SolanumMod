using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace SolanumMod.Projectiles
{
    public class Sl_ice_r_Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sl ice r Projectile");
            Main.projFrames[projectile.type] = 10;
        }
        public override void SetDefaults()
        {
            projectile.width = 56;
            projectile.height = 54;
            projectile.damage = 16;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.aiStyle = 75;
            projectile.scale *= 1.2f;
            projectile.tileCollide = false;
            projectile.ownerHitCheck = true;
            projectile.friendly = true;
        }
        int SoundTimer = 0;
        public override void AI()
        {
         Player player = Main.player[projectile.owner];
         float num1 = 1.570796f;
         Vector2 vector2_1 = player.RotatedRelativePoint(player.MountedCenter, true);   
            if (++projectile.frameCounter >= 6) {
				projectile.frameCounter = 0;
                
				if (++projectile.frame >= 10) {
					projectile.frame = 0;
				}
			}
           num1 = 0.0f;
        if (projectile.spriteDirection == -1)
          num1 = 3.141593f;
        if (++projectile.frame >= Main.projFrames[projectile.type])
          projectile.frame = 0;
        --projectile.soundDelay;
        if (projectile.soundDelay <= 0)
        {
          Main.PlaySound(SoundID.Item1, projectile.Center);
          projectile.soundDelay = 14;
        }
        if (Main.myPlayer == projectile.owner)
        {
          if (player.channel && !player.noItems && !player.CCed)
          {
            float num2 = 1f;
            if (player.inventory[player.selectedItem].shoot == projectile.type)
              num2 = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
            Vector2 vec = Main.MouseWorld - vector2_1;
            vec.Normalize();
            if (vec.HasNaNs())
              vec = Vector2.UnitX * (float) player.direction;
            vec *= num2;
            if ((double) vec.X != (double) projectile.velocity.X || (double) vec.Y != (double) projectile.velocity.Y)
              projectile.netUpdate = true;
            projectile.velocity = vec;
          }
          else
            projectile.Kill();
        }
        Vector2 position = projectile.Center + projectile.velocity * 3f; 

        projectile.direction = (projectile.spriteDirection = ((projectile.velocity.X > 0f) ? 1 : -1));
        projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(8);
        if (projectile.velocity.Y > 16f)
        {
        projectile.velocity.Y = 16f;
        }
        
        if (projectile.spriteDirection == -1)
        projectile.rotation += MathHelper.Pi; 
        }
    }
}
    
