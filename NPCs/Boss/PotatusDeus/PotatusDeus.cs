using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.ID;


namespace SolanumMod.NPCs.Boss.PotatusDeus
{
    class PotatusDeus : ModNPC
    {
        public override void SetDefaults()
        {
            npc.width = 148;
            npc.height = 72;
            npc.boss = true;
            //npc.music = 0;
            npc.aiStyle = -1;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            //npc.rarity = 2;

            npc.damage = 100;

            npc.defense = 90;

            npc.lifeMax = 160000;


            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60000f;
            npc.knockBackResist = 0f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Potatus Deus");
            Main.npcFrameCount[npc.type] = 4;
        }
        public void Move(Vector2 TargetPosition, float MaxSpeed, float TurnResist)
        {

            float speed = MaxSpeed;
            Vector2 move = TargetPosition - npc.Center;
            float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = TurnResist; //the larger this is, the slower the npc will turn
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            npc.velocity = move;
        }
        public override void AI()
        {

            npc.TargetClosest(true);
            npc.TargetClosest(true);
            Player npctarget = Main.player[npc.target];
            if (!npctarget.active || npctarget.dead)
            {
                npc.TargetClosest(false);
                npctarget = Main.player[npc.target];
                if (!npctarget.active || npctarget.dead)
                {
                    npc.velocity = new Vector2(0f, 10f);
                    if (npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                    return;
                }
            }
            else
            {
                if (npc.timeLeft < 120)
                {
                    npc.timeLeft = 120;
                }
            }
            Move(npctarget.Center + new Vector2(0, -200), 55, 180);
        }
        public override void FindFrame(int frameHeight)
        {
            // This makes the sprite flip horizontally in conjunction with the npc.direction.
            npc.spriteDirection = npc.direction;

            npc.frameCounter++;
            if (npc.frameCounter < 10)
            {
                npc.frame.Y = 0 * frameHeight;
            }
            else if (npc.frameCounter < 20)
            {
                npc.frame.Y = 1 * frameHeight;
            }
            else if (npc.frameCounter < 30)
            {
                npc.frame.Y = 2 * frameHeight;
            }
            else if (npc.frameCounter < 40)
            {
                npc.frame.Y = 3 * frameHeight;
            }
            else
            {
                npc.frameCounter = 0;
            }

        }
    }
}
