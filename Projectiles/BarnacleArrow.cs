using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
namespace SolanumMod.Projectiles
{
    public class BarnacleArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Barnacle Arrow");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 32;
            projectile.damage = 20;
            projectile.knockBack = 0.5f;
            projectile.ranged = true;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.arrow = true;
            projectile.penetrate = 1;
            projectile.aiStyle = 1;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Dig,projectile.Center);
            Dust.NewDust(projectile.Center,6,6,DustID.BubbleBlock);
            int BubbleCount = 2 + Main.rand.Next(2);
            for(int i = 0;i<BubbleCount;i++)
            {
                Projectile.NewProjectile(projectile.Center,(-projectile.velocity).RotatedByRandom(MathHelper.ToRadians(30)),ModContent.ProjectileType<Projectiles.SmolHomingBubbles>(),20,1,projectile.owner);
            }
        }
    }
}