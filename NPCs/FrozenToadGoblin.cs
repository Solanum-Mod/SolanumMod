using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using SolanumMod.Dusts;
using SolanumMod.Projectiles;
namespace SolanumMod.NPCs
{
    public class FrozenToadGoblin : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Toad Goblin");
            Main.npcFrameCount[npc.type] = 6;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 54;
            npc.width = 18;
            npc.height = 20;
            npc.knockBackResist = 0.1f;
            npc.buffImmune[BuffID.Frostburn] = true;
            npc.defense = 6;
            npc.aiStyle = -1;
            npc.value = Item.buyPrice(0,0,8,0);
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        int frame = 0;
        int frameTimer = 0;
        float speed = 0.1f;
        bool shouldMakeDust;
        public override void AI()
        {
            frameTimer++;
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            bool IsPlayerLooking = player.direction == -1 && npc.position.X < player.position.X || player.direction == 1 && npc.position.X > player.position.X && !(npc.position.Y > player.Center.Y);
            if(!player.active || player.dead)
            {
                npc.TargetClosest(true);
            }
            if(IsPlayerLooking)
            { 
                shouldMakeDust = true;
                npc.velocity = Vector2.Zero;
                speed = 0;
            } else
            {
                frame = 1;
                if(shouldMakeDust)
                {
                    shouldMakeDust = false;
                    Dust.NewDust(npc.Center - new Vector2(Main.rand.Next(-2,2),Main.rand.Next(-3,3)),15,15,ModContent.DustType<GoblinToad_Dust>(),Main.rand.Next(-4,4),Main.rand.Next(-4,4));
                }
                speed += 0.5f;
                if(speed > 20)
                    speed = 20;
                npc.velocity = Vector2.Normalize(player.Center - npc.Center) * new Vector2(3,1);
                if(Vector2.Distance(player.Center,npc.Center) < 55)
                {
                    Explode();
                }
                 if (npc.velocity.X > 0)
            {
                npc.spriteDirection = -1;
            }
            else
            {
                npc.spriteDirection = 1;
            }
            }
        }
        private void Explode()
        {
            Main.PlaySound(SoundID.NPCDeath6);
            npc.active = false;
            npc.life = -1;
            Dust.NewDust(npc.Center,30,30,ModContent.DustType<GoblinToad_Dust>(),Main.rand.Next(-12,12),Main.rand.Next(-8,8));
            for(int i = 0;i<3;i++)
            {
                Vector2 velocity = new Vector2(Main.rand.Next(-10,10),Main.rand.Next(-10,10));
                Projectile.NewProjectile(npc.Center,velocity,ModContent.ProjectileType<GoblinToadIceProjectile>(),36,1);
            }
        }
        public override void NPCLoot()
        {
            Item.NewItem(npc.position,npc.width,npc.height,ItemID.SilverCoin,Main.rand.Next(5,10));
        }
        public override void FindFrame(int frameHeight)
        {
            Player player = Main.player[npc.target];
            bool IsPlayerLooking = player.direction == -1 && npc.position.X < player.position.X || player.direction == 1 && npc.position.X > player.position.X && !(npc.position.Y > player.Center.Y);
             if(!IsPlayerLooking)
            { 
                frame = 1;
                if(frameTimer >= 8)
                {
                    frame++;
                    frameTimer = 0;
                    if(frame == Main.npcFrameCount[npc.type])
                        frame = 1;
                }
                npc.frame.Y = frame * frameHeight;
            } else frame = 0;
        }
    }
}