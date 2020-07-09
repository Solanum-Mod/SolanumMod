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
            npc.aiStyle = 26;
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
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
                bool IsPlayerLooking = player.direction == -1 && npc.position.X < player.position.X || player.direction == 1 && npc.position.X > player.position.X;
            if(!player.active || player.dead)
            {
                npc.TargetClosest(true);
            }
            if(IsPlayerLooking)
            { 
                npc.defense = 30;
                shouldMakeDust = true;
                npc.velocity.X = 0;
                npc.spriteDirection = -player.direction;
            } else
            {
                if(shouldMakeDust)
                {
                    shouldMakeDust = false;
                    Dust.NewDust(npc.Center - new Vector2(Main.rand.Next(-2,2),Main.rand.Next(-3,3)),30,30,ModContent.DustType<GoblinToad_Dust>(),Main.rand.Next(-4,4),Main.rand.Next(-4,4));
                }
                bool IsWearingEye = player.GetModPlayer<SolanumPlayer>().IsWearingFrozenEye;
            if(!IsWearingEye)
            {
                if(npc.velocity.X > 4.2f)
                {
                    npc.velocity.X = 4.2f;
                }
                if(npc.velocity.X < -4.2f)
                {
                    npc.velocity.X = -4.2f;
                }
            } else 
            {
                if(npc.velocity.X > 2.1f)
                {
                    npc.velocity.X = 2.1f;
                }
                if(npc.velocity.X < -2.1f)
                {
                    npc.velocity.X = -2.1f;
                }
            }
                if(Vector2.Distance(player.Center,npc.Center) < 60)
                {
                    Explode();
                }
            npc.spriteDirection = npc.direction;
            }
        }
        private void Explode()
        {
            Main.PlaySound(SoundID.NPCDeath6);
            npc.active = false;
            npc.life = -1;
            Dust.NewDust(npc.Center,30,30,ModContent.DustType<GoblinToad_Dust>(),Main.rand.Next(-12,12),Main.rand.Next(-8,8));
            for(int i = 0;i<4;i++)
            {
                Vector2 velocity = new Vector2(Main.rand.Next(-10,10),Main.rand.Next(-10,-4));
                Projectile.NewProjectile(npc.Center,velocity,ModContent.ProjectileType<GoblinToadIceProjectile>(),1,1);
            }
        }
        public override void NPCLoot()
        {
            if(Main.rand.Next(11) > 9)
            {
                Item.NewItem(npc.Center,npc.width,npc.height,ModContent.ItemType<Accessories.FrozenEye>());
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if(spawnInfo.player.ZoneSnow && spawnInfo.player.ZoneRockLayerHeight)
            {
                return Main.hardMode ? 0.6f : 0.4f;
            }
            return 0;
        }
        public override void FindFrame(int frameHeight)
        {
            frameTimer++;
            Player player = Main.player[npc.target];
            bool IsWearingEye = player.GetModPlayer<SolanumPlayer>().IsWearingFrozenEye;
                bool IsPlayerLooking = player.direction == -1 && npc.position.X < player.position.X || player.direction == 1 && npc.position.X > player.position.X;
             if(!IsPlayerLooking)
            { 
                int Num1 = IsWearingEye ? 180 : 150;
                int Num2 = IsWearingEye ? 30 : 25;
                
              for(int i = 0;i<Num1;i++)
              {
                  if(i%Num2 == 0)
                  {
                      frame++;
                      if(frame == Main.npcFrameCount[npc.type])
                      {
                          frame = 1;
                      }
                  }
              }
            } else if(IsPlayerLooking) frame = 0;
            npc.frame.Y = frame * frameHeight;
        }
    }
}