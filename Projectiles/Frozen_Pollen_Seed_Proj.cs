using Terraria;
using Terraria.ModLoader;
namespace SolanumMod.Projectiles
{
    public class Frozen_Pollen_Seed_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Pollen Seed");
        }
        public override void SetDefaults()
        {
            projectile.damage = 10;
            projectile.timeLeft = 300;
            projectile.knockBack = 1f;
            projectile.width = projectile.height = 10;
            projectile.hostile = true;
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
            projectile.velocity *= 0.999f;
        }
    }
}