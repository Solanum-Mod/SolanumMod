using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
namespace SolanumMod.NPCs
{
    public class Frozen_Pollen_Spitter : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Pollen Spitter");
            Main.npcFrameCount[npc.type] = 5;
        }
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.width = 30;
            npc.height = 30;
            npc.lifeMax = 200;
            npc.defense = 6;
            npc.value = Item.buyPrice(0,0,8,0);
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }
        bool Agressive = false;
        int PollenCounter = 0;
        int AttackCounter = 0;
        int JumpCounter = 0;
        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
            if(item.owner == player.whoAmI && !Agressive)
            {
                Agressive = true;
            }
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if(projectile.owner == player.whoAmI && !Agressive)
            {
                Agressive = true;
            }
        }
        public override void AI()
        {
            if(!Agressive)
            {
                npc.aiStyle = 7;
                if(++PollenCounter >= 160)
                {
                    for(int i = 18;i <= 36;i+=6)
                    {
                        float angle = MathHelper.ToRadians(10 * i);
                        Vector2 vector = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                        Projectile.NewProjectile(npc.position,vector * 10,ModContent.ProjectileType<Projectiles.Frozen_Pollen_Projectile>(),0,0);
                    }
                    PollenCounter = 0;
                }
            } else 
            {
                npc.TargetClosest(true);
                Player player = Main.player[npc.target];
                npc.velocity = Vector2.Normalize(player.Center - npc.Center) * new Vector2(3f, 0f);
                
                npc.velocity.Y += 6f;
                npc.damage = 10;
                if(++JumpCounter > 120 && !(npc.velocity.Y > 0))
                {
                    npc.velocity.Y = -20;
                }
                if(!npc.HasValidTarget)
                {
                    npc.aiStyle = 7;
                    Agressive = false;
                    npc.damage = 0;
                }
                if(++AttackCounter >= 40)
                {
                    Vector2 targetPos = Vector2.Normalize(player.Center - npc.Center);
                    Projectile.NewProjectile(npc.Center,targetPos * 10,ModContent.ProjectileType<Projectiles.Frozen_Pollen_Seed_Proj>(),10,0.5f);
                    AttackCounter = 0;
                }
            }
        }
        int frameNum = 0;
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            if(npc.velocity.X > 0 || npc.velocity.X < 0)
            {
                if(++npc.frameCounter >= 8)
                {
                    frameNum++;
                    if(frameNum == 5) frameNum = 0;
                }
            } else frameNum = 0;
            npc.frame.Y = frameHeight * frameNum;
            
        }
    }
}