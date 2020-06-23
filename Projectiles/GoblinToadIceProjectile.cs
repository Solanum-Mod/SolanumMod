using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace SolanumMod.Projectiles
{
    public class GoblinToadIceProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spikey Ice");
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.damage = 36;
            projectile.hostile = true;
            projectile.knockBack = 1;
            projectile.ranged = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 2;
            aiType = ProjectileID.SpikedSlimeSpike;
        }
    }
}