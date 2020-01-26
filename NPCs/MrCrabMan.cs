using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace SolanumMod.NPCs
{
    class MrCrabMan : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crabby");
            Main.npcFrameCount[npc.type] = 10;
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 50;
            npc.damage = 20;
            npc.defense = 12;
            npc.knockBackResist = 0.3f;
            npc.width = 26;
            npc.height = 26;
            npc.aiStyle = -1;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = Item.buyPrice(0, 0, 15, 0);
            npc.noGravity = false;
            //banner = npc.type;
            //bannerItem = ItemType<>();
        }

        private const int State_Hiding = 0;
        private const int State_Out = 1;
        private const int State_Moving = 2;
        private const int State_In = 3;

        private float State
        {
            get => npc.ai[0];
            set => npc.ai[0] = value;
        }

        private float Timer
        {
            get => npc.ai[1];
            set => npc.ai[1] = value;
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            if (State == State_Hiding)
            {
                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 240f)
                {
                    State = State_Out;
                }
            }
            else if (State == State_Out && ++Timer >= 20)
            {
                State = State_Moving;
                Timer = 0;
            }
            else if (State == State_Moving)
            {
                npc.velocity.X = MathHelper.Clamp(npc.velocity.X + npc.direction * 0.1f, -1, 1);
                if (!npc.HasValidTarget || Main.player[npc.target].Distance(npc.Center) > 240f)
                {
                    npc.velocity.X = 0;
                    State = State_In;
                }
            }
            else if (State == State_In && ++Timer >= 20)
            {
                State = State_Hiding;
                Timer = 0;
            }

        }

        public override void FindFrame(int frameHeight)
        {

            if (State == State_Hiding)
            {
                npc.frame.Y = 0;
            }
            else if (State == State_Out || State == State_In)
            {
                npc.frame.Y = frameHeight;
            }
            else if (State == State_Moving)
            {
                npc.spriteDirection = npc.direction;
                npc.frame.Y = (2 + (int)(npc.frameCounter / 10)) * frameHeight;
                if (++npc.frameCounter >= 80)
                {
                    npc.frameCounter = 0;
                }
            }
        }
    }
}
