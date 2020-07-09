using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
namespace SolanumMod.Projectiles
{
    public class Frozen_Eye_Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Eye");
            Main.projPet[projectile.type] = true;
        }
        public override void SetDefaults()
        {
            projectile.ignoreWater = true;
            projectile.aiStyle = -1;
            projectile.tileCollide = false;
            projectile.manualDirectionChange = true;
            projectile.scale *= 1.15f;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];//Player
            if(player.GetModPlayer<SolanumPlayer>().IsWearingFrozenEye)//e
            {   
            Vector2 bruh = player.position - new Vector2(player.direction * 40,0);//bruh vector
            float projSpeed = 3;//sped
            projSpeed += Vector2.Distance(bruh,projectile.position) / 10;
                if(Vector2.Distance(bruh,projectile.position) < 3)//aeaeae
                {
                    projectile.position.X = bruh.X;
                    projectile.velocity.X = 0;
                } else projectile.velocity.X = Vector2.Normalize(bruh - projectile.position).X * projSpeed;

                projectile.position.Y = Vector2.SmoothStep(projectile.position,player.position,0.3f).Y;//biggest bruh moment
                projectile.spriteDirection = player.direction;//e
            } else projectile.Kill();
        }
    }
}