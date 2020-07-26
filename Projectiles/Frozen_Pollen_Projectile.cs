using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
namespace SolanumMod.Projectiles
{
    public class Frozen_Pollen_Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Pollen");
        }
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 6;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 300;
            projectile.aiStyle = -1;
        }
        public override void AI()
        {
            projectile.alpha += 4;
            if(projectile.alpha > 245)
            {
                projectile.Kill();
            }
            projectile.velocity *= 0.85f;
            projectile.rotation = projectile.velocity.X * 0.1f;
            Player player = Main.player[Main.myPlayer];
            if(Vector2.Distance(projectile.Center,player.Center) < 160)
            {
                player.AddBuff(BuffID.Honey,120);
            }
        }
    }
}