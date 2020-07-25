using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace SolanumMod.Projectiles
{
    public class SeaSplitterProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sea Splitter");
        }
        public override void SetDefaults()
        {
            projectile.damage = 126;
            projectile.knockBack = 2;
            projectile.penetrate = -1;
            projectile.aiStyle = -1;
            projectile.width = 15;
            projectile.width = 18;
            projectile.melee = true;
            projectile.friendly = true;
        }
        int NPC_Hit_Num = 0;
        int MaxDist = 500;
        bool ShouldReturn = false;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            NPC_Hit_Num++;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            NPC_Hit_Num++;
            return false;

        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            Vector2 position = Main.MouseWorld - player.position;
            if(Vector2.Distance(projectile.Center,player.Center) > MaxDist) ShouldReturn = true;
            if(player.channel && NPC_Hit_Num <= 0 && !ShouldReturn)
            {
                position.Normalize();
                projectile.velocity = position * 14;
                Vector2 mountedCenter = player.MountedCenter;
                Vector2 vector2_4 = mountedCenter - projectile.Center;
                float rotation = (float)Math.Atan2((double)vector2_4.Y, (double)vector2_4.X) - 1.57f;
                projectile.rotation = rotation;
            } else 
            {
            projectile.velocity = Vector2.Normalize(player.Center - projectile.Center) * 14;
            if(projectile.Hitbox.Intersects(player.Hitbox)) projectile.Kill();
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/SeaSplitterProj_Chain");
    
            Vector2 position = projectile.Center;
            Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
            Rectangle? sourceRectangle = new Rectangle?();
            Vector2 origin = new Vector2((float)texture.Width * 0.5f, (float)texture.Height * 0.5f);
            float num1 = (float)texture.Height;
            Vector2 vector2_4 = mountedCenter - position;
            float rotation = (float)Math.Atan2((double)vector2_4.Y, (double)vector2_4.X) - 1.57f;
            bool flag = true;
            if (float.IsNaN(position.X) && float.IsNaN(position.Y))
                flag = false;
            if (float.IsNaN(vector2_4.X) && float.IsNaN(vector2_4.Y))
                flag = false;
            while (flag)
            {
                if ((double)vector2_4.Length() < (double)num1 + 1.0)
                {
                    flag = false;
                }
                else
                {
                    Vector2 vector2_1 = vector2_4;
                    vector2_1.Normalize();
                    position += vector2_1 * num1;
                    vector2_4 = mountedCenter - position;
                    Color color2 = Lighting.GetColor((int)position.X / 16, (int)((double)position.Y / 16.0));
                    color2 = projectile.GetAlpha(color2);
                    spriteBatch.Draw(texture, position - Main.screenPosition, sourceRectangle, color2, rotation, origin, 1f, SpriteEffects.None, 0.0f);
                }
            }
            return true;
        }
    }
}