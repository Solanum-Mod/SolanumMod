using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SolanumMod.NPCs.Boss.Nepturian.Projs;
using System.Linq;

namespace SolanumMod.NPCs.Boss.Nepturian
{
    /* To: whoever is reading.
     * This code was rushed in a day and is kinda shit.
     * -Daim
     */ 
    public class Nepturian : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 12;
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 1000;
            npc.damage = 20;
            npc.defense = 12;
            npc.knockBackResist = 0f;
            npc.width = 108;
            npc.height = 136;
            npc.aiStyle = -1;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = Item.buyPrice(0, 0, 15, 0);
            npc.noGravity = true;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noTileCollide = true;

        }

        // Variables and shit
        private const int State_Stream = 0;
        private const int State_Leviathan = 1;
        private const int State_Dash = 2;
        private const int State_Rain = 3;
        private const int State_Choosing = 4;
        private const int State_Dive = 5;
        private const int State_Clone = 6;
        private const int State_Presentation = 7;

        // A good coder would only use one Timer
        private int StateTimer;
        private int BubTimer;
        private float State
        {
            get => npc.ai[0];
            set => npc.ai[0] = value;
        }
        private int Timer;

        // No idea where I got this from like 4 months ago, definitely not mine, maybe its seraphs thingy?
        public void Move(Player P, float speed)
        {
            int maxDist = 1000;
            if (Vector2.Distance(P.Center, npc.Center) >= maxDist)
            {
                float moveSpeed = 2f;
                Vector2 toTarget = new Vector2(P.Center.X - npc.Center.X, P.Center.Y - npc.Center.Y);
                toTarget = new Vector2(P.Center.X - npc.Center.X, P.Center.Y - npc.Center.Y);
                toTarget.Normalize();
                npc.velocity = toTarget * moveSpeed;
            }
            else
            {
                npc.spriteDirection = npc.direction;

                if (Main.expertMode)
                {
                    speed += 0.05f;
                    maxDist -= 100;
                }
                Vector2 vector75 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float playerX;
                float playerY;
                if(npc.life <= npc.lifeMax / 2)
                {
                     playerX = P.position.X + (float)(P.width / 2) + 300f - vector75.X;
                     playerY = P.position.Y + (float)(P.height / 2) + Main.rand.Next(-100, 100) - vector75.Y;
                } else
                {
                    playerX = P.position.X + (float)(P.width / 2) - vector75.X;
                    playerY = P.position.Y + (float)(P.height / 2) -300f + Main.rand.Next(-100, 100) - vector75.Y;
                }
                if (npc.velocity.X < playerX)
                {
                    npc.velocity.X = npc.velocity.X + speed;
                    {
                        npc.velocity.X = npc.velocity.X + speed;
                    }
                }
                else if (npc.velocity.X > playerX)
                {
                    npc.velocity.X = npc.velocity.X - speed;
                    {
                        npc.velocity.X = npc.velocity.X - speed;
                    }
                }
                if (npc.velocity.Y < playerY)
                {
                    npc.velocity.Y = npc.velocity.Y + speed;
                    if (npc.velocity.Y < 0f && playerY > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y + speed;
                        return;
                    }
                }
                else if (npc.velocity.Y > playerY)
                {
                    npc.velocity.Y = npc.velocity.Y - speed;
                    if (npc.velocity.Y > 0f && playerY < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y - speed;
                        return;
                    }
                }
            }
        }
        public override void AI()
        {
            Player player = Main.player[npc.target];
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.velocity = new Vector2(0f, 10f);
                    if (npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                    return;
                }
            }

            npc.TargetClosest(true);
            Move(player, 0.1f);

            Timer++;
            if(Timer == 1)
            {
                State = State_Presentation;
                Timer = 2;
            }
            if(State == State_Presentation)
            {
                npc.velocity = Vector2.Zero;
                StateTimer++;
                if(StateTimer == 1)
                {
                    SolanumMod.NepturianCinematics = true;
                }
                else if(StateTimer > 1 && StateTimer <= 300)
                {
                    npc.alpha = 255;
                    BubTimer++;
                    if(BubTimer == 3)
                    {
                        ChooseBubble(0);
                        BubTimer = 0;
                    }
                    SolanumMod.ShakeScreen(1.5f, 1);
                    npc.velocity = Vector2.Zero;
                    Vector2 dustPosition = npc.Center + new Vector2(Main.rand.Next(-60, 60), Main.rand.Next(-60, 60));
                    Dust dust = Dust.NewDustPerfect(dustPosition, 23, null, 100, Color.Aquamarine, 0.8f);
                    dust.velocity *= 0.3f;
                    dust.noGravity = true;

                    Vector2 vel = Vector2.One.RotatedByRandom(6.28f);
                    Dust dust2 = Dust.NewDustPerfect(npc.Center + vel * 60, DustID.Vortex, vel * -1, 100, Color.Aqua, 1);
                    dust2.noGravity = true;

                    Dust dust3 = Dust.NewDustPerfect(npc.Center + vel * 35, DustID.Vortex, vel * -1, 100, Color.Aqua, 1);
                    dust3.noGravity = true;
                }
                else if(StateTimer > 300 && StateTimer <= 600)
                {
                    npc.alpha -= 7;
                }
                else if(StateTimer == 601)
                {
                    SolanumMod.NepturianCinematics = false;
                    StateTimer = 0;
                    State = State_Choosing;
                }
            }
            else if (State == State_Choosing)
            {
                StateTimer++;
                if (StateTimer == 130)
                {
                    if (npc.life >= npc.lifeMax / 2)
                    {
                        int i = Main.rand.Next(3);
                        switch (i)
                        {
                            case 0:
                                State = State_Dash;
                                break;
                            case 1:
                                State = State_Choosing;
                                break;
                            case 2:
                                State = State_Stream;
                                break;
                        }
                    }
                    else
                    {
                        // second half
                        int i = Main.rand.Next(6);
                        switch (i)
                        {
                            case 0:
                                State = State_Dash;
                                break;
                            case 1:
                                State = State_Choosing;
                                break;
                            case 2:
                                State = State_Stream;
                                break;
                            case 3:
                                State = State_Leviathan;
                                break;
                            case 4:
                                State = State_Rain;
                                break;
                            case 5:
                                State = State_Clone;
                                break;
                        }
                    }
                    StateTimer = 0;
                }
            }
            else if (State == State_Dash)
            {
                // This code is kinda cringe
                StateTimer++;
                if (StateTimer <= 30)
                    npc.velocity = Vector2.Zero;
                else if(StateTimer == 31)
                {
                    // 20 is the speed here, play around with it for different results.
                    npc.velocity = npc.DirectionTo(player.Center) * 20f;
                }
                else if(StateTimer >= 32 && StateTimer < 70)
                {
                    BubTimer++;
                    if(BubTimer >= 4)
                    {
                        ChooseBubbleHoming(20);
                        for (int i = 0; i < 36; i++)
                        {
                            float angle = MathHelper.ToRadians(10 * i);
                            Vector2 vector = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                            Dust dust = Dust.NewDustPerfect(npc.Center + (vector * 40), DustID.Vortex, vector * 8f, 100, Color.Aquamarine);
                            dust.noGravity = true;

                        }
                        BubTimer = 0;
                    }
                }
                else if(StateTimer == 70)
                {
                    StateTimer = 0;
                    BubTimer = 0;
                    State = State_Choosing;
                }
            }
            else if (State == State_Leviathan)
            {
                StateTimer++;
                if (StateTimer <= 200)
                {
                    SolanumMod.ShakeScreen(1.5f, 1);
                    npc.velocity = Vector2.Zero;
                    Vector2 dustPosition = npc.Center + new Vector2(Main.rand.Next(-60, 60), Main.rand.Next(-60, 60));
                    Dust dust = Dust.NewDustPerfect(dustPosition, 23, null, 100, Color.Aquamarine, 0.8f);
                    dust.velocity *= 0.3f;
                    dust.noGravity = true;

                    Vector2 vel = Vector2.One.RotatedByRandom(6.28f);
                    Dust dust2 = Dust.NewDustPerfect(npc.Center + vel * 60, DustID.Vortex, vel * -1, 100, Color.Aqua, 1);
                    dust2.noGravity = true;

                    Dust dust3 = Dust.NewDustPerfect(npc.Center + vel * 35, DustID.Vortex, vel * -1, 100, Color.Aqua, 1);
                    dust3.noGravity = true;
                    if(StateTimer >= 100)
                    {
                        BubTimer++;
                        if(BubTimer == 14)
                        {
                            BubTimer = 0;
                            ChooseBubble(20);
                        }
                    }
                }
                else if (StateTimer == 201)
                {
                    SolanumMod.ShakeScreen(10f, 20);
                    // Shoot thingy
                    Projectile.NewProjectile(npc.Center, npc.velocity, ModContent.ProjectileType<LeviHead>(), 200, 2f, Main.myPlayer);
                    StateTimer = 0;
                    BubTimer = 0;
                    State = State_Choosing;
                }

            }
            else if (State == State_Rain)
            {
                // TODO: Shoots a large stream of water into the sky, making water projectiles rain from above
                StateTimer++;
                if(StateTimer <= 200)
                {
                    SolanumMod.ShakeScreen(1.5f, 1);
                    npc.velocity = Vector2.Zero;
                    Vector2 dustPosition = npc.Center + new Vector2(Main.rand.Next(-60, 60), Main.rand.Next(-60, 60));
                    Dust dust = Dust.NewDustPerfect(dustPosition, 23, null, 100, Color.Aquamarine, 0.8f);
                    dust.velocity *= 0.3f;
                    dust.noGravity = true;

                    Vector2 vel = Vector2.One.RotatedByRandom(6.28f);
                    Dust dust2 = Dust.NewDustPerfect(npc.Center + vel * 60, DustID.Vortex, vel * -1, 100, Color.Aqua, 1);
                    dust2.noGravity = true;

                    Dust dust3 = Dust.NewDustPerfect(npc.Center + vel * 35, DustID.Vortex, vel * -1, 100, Color.Aqua, 1);
                    dust3.noGravity = true;

                    // TODO Shoot Large water projectile to the sky.
                }
                else if (StateTimer > 200 && StateTimer <= 700)
                {
                    BubTimer++;
                    if(BubTimer == 2)
                    {
                        BubTimer = 0;
                        Vector2 spawnPos = new Vector2(player.Center.X + Main.rand.Next(-Main.screenWidth, Main.screenWidth), player.Center.Y - 500); ;
                        Projectile.NewProjectile(spawnPos, Vector2.Zero, ModContent.ProjectileType<RainDroplet>(), 5, 2f, Main.myPlayer);
                    }
                }
                else if(StateTimer == 701)
                {
                    StateTimer = 0;
                    BubTimer = 0;
                    State = State_Choosing;
                }
            }
            else if (State == State_Stream)
            {
                // TODO: Shoots several consecutive water streams at the player 
                StateTimer++;
                if(StateTimer == 320)
                {
                    State = State_Choosing;
                    StateTimer = 0;
                    BubTimer = 0;
                }
                BubTimer++;
                if(BubTimer == 10)
                {
                    BubTimer = 0;
                    Projectile.NewProjectile(npc.Center, npc.velocity, ModContent.ProjectileType<WaterStream>(), 15, 2f, Main.myPlayer);
                }
            }
            else if(State == State_Dive)
            {
                // TODO: Dives into the ground and creates several spikes of water under the character
            }
            else if(State == State_Clone)
            {
                if (GetCloneCount() <= 3)
                {
                    StateTimer++;
                    if (StateTimer <= 200)
                    {
                        SolanumMod.ShakeScreen(1.5f, 1);
                        npc.velocity = Vector2.Zero;
                        Vector2 dustPosition = npc.Center + new Vector2(Main.rand.Next(-60, 60), Main.rand.Next(-60, 60));
                        Dust dust = Dust.NewDustPerfect(dustPosition, 23, null, 100, Color.Aquamarine, 0.8f);
                        dust.velocity *= 0.3f;
                        dust.noGravity = true;

                        Vector2 vel = Vector2.One.RotatedByRandom(6.28f);
                        Dust dust2 = Dust.NewDustPerfect(npc.Center + vel * 60, DustID.Vortex, vel * -1, 100, Color.Aqua, 1);
                        dust2.noGravity = true;

                        Dust dust3 = Dust.NewDustPerfect(npc.Center + vel * 35, DustID.Vortex, vel * -1, 100, Color.Aqua, 1);
                        dust3.noGravity = true;
                    }
                    else if (StateTimer == 201)
                    {
                        SolanumMod.ShakeScreen(10f, 20);
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<NepturianClone>());
                        State = State_Choosing;
                        StateTimer = 0;
                    }
                }
                else State = State_Choosing;
            }
        }
        private int FrameThingy = 1;
        public override void FindFrame(int frameHeight)
        {
            // myes switches exist
            npc.spriteDirection = npc.direction;
            npc.frame.Y = frameHeight * FrameThingy;
            if(State == State_Clone || State == State_Leviathan)
            {
                if(StateTimer <= 100)
                {
                    npc.frameCounter++;
                    if (FrameThingy < 8)
                    {
                        if (npc.frameCounter == 10)
                        {
                            FrameThingy++;
                            npc.frameCounter = 0;
                        }
                    }
                    else { FrameThingy = 8; npc.frameCounter = 0; }
                }
                else if(StateTimer > 100 && StateTimer <= 200)
                {
                    if (FrameThingy < 11)
                    {
                        npc.frameCounter++;
                        if (npc.frameCounter == 10)
                        {
                            FrameThingy++;
                            npc.frameCounter = 0;
                        }
                    }
                    else { FrameThingy = 11; npc.frameCounter = 0; }
                }
                else if(StateTimer == 201)
                {
                    npc.frameCounter = 0;
                    FrameThingy = 1;
                }
            }
            else
            {
                npc.frameCounter++;
                if (npc.frameCounter == 10)
                {
                    FrameThingy++;
                    npc.frameCounter = 0;
                }
                if (FrameThingy >= 4)
                {
                    FrameThingy = 1;
                }
            }
        }
        // Chooses a random bubble, rn there are only 2 so its just an if else
        // TODO: Make a switch if more bubbles get added
        public void ChooseBubble(int damage)
        {
            int choice = Main.rand.Next(2);
            Projectile.NewProjectile(new Vector2(npc.Center.X + Main.rand.Next(-50, 50), npc.Center.Y + Main.rand.Next(-50, 50)),
                new Vector2(npc.velocity.X + Main.rand.Next(5, 10), npc.velocity.Y + Main.rand.Next(5, 10)),
                choice == 0 ? ModContent.ProjectileType<Bubble1>() : ModContent.ProjectileType<Bubble2>(), damage, 2f, Main.myPlayer);

        }
        public void ChooseBubbleHoming(int damage)
        {
            int choice = Main.rand.Next(2);
            Projectile.NewProjectile(new Vector2(npc.Center.X + Main.rand.Next(-50, 50), npc.Center.Y + Main.rand.Next(-50, 50)),
                new Vector2(npc.velocity.X + Main.rand.Next(5, 10), npc.velocity.Y + Main.rand.Next(5, 10)),
                choice == 0 ? ModContent.ProjectileType<BubbleHoming>() : ModContent.ProjectileType<BubbleHoming2>(), damage, 2f, Main.myPlayer);

        }
        public int GetCloneCount()
        {
            int Count = 0;
            foreach(NPC yes in Main.npc)
            {
                if(yes.type == ModContent.NPCType<NepturianClone>() && yes.active)
                {
                    Count++;
                }
            }
            return Count;
        }

        // Imagine nested classes, kinda cring if you ask me 
        class NepturianClone : ModNPC
        {
            public override void SetDefaults()
            {
                npc.lifeMax = 200;
                npc.damage = 20;
                npc.defense = 12;
                npc.knockBackResist = 0f;
                npc.width = 84;
                npc.height = 138;
                npc.aiStyle = -1;
                npc.noGravity = true;
                npc.HitSound = SoundID.NPCHit1;
                npc.DeathSound = SoundID.NPCDeath6;
                npc.value = Item.buyPrice(0, 0, 15, 0);
                npc.noGravity = true;
                npc.lavaImmune = true;
                npc.noTileCollide = true;

            }

            // Was gonna make a state machine but there is only one attack so no point
            private int AttackTimer;

            // Same move code, there probably is a way to make it so that I only have to have it once, but Im lazy.
            public void Move(Player P, float speed)
            {
                int maxDist = 1000;
                if (Vector2.Distance(P.Center, npc.Center) >= maxDist)
                {
                    float moveSpeed = 2f;
                    Vector2 toTarget = new Vector2(P.Center.X - npc.Center.X, P.Center.Y - npc.Center.Y);
                    toTarget = new Vector2(P.Center.X - npc.Center.X, P.Center.Y - npc.Center.Y);
                    toTarget.Normalize();
                    npc.velocity = toTarget * moveSpeed;
                }
                else
                {
                    npc.spriteDirection = npc.direction;

                    if (Main.expertMode)
                    {
                        speed += 0.05f;
                        maxDist -= 100;
                    }
                    Vector2 vector75 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float playerX;
                    float playerY;
                    if (npc.life <= npc.lifeMax / 2)
                    {
                        playerX = P.position.X + (float)(P.width / 2) + 300f - vector75.X;
                        playerY = P.position.Y + (float)(P.height / 2) + Main.rand.Next(-100, 100) - vector75.Y;
                    }
                    else
                    {
                        playerX = P.position.X + (float)(P.width / 2) - vector75.X;
                        playerY = P.position.Y + (float)(P.height / 2) - 300f + Main.rand.Next(-100, 100) - vector75.Y;
                    }
                    if (npc.velocity.X < playerX)
                    {
                        npc.velocity.X = npc.velocity.X + speed;
                        {
                            npc.velocity.X = npc.velocity.X + speed;
                        }
                    }
                    else if (npc.velocity.X > playerX)
                    {
                        npc.velocity.X = npc.velocity.X - speed;
                        {
                            npc.velocity.X = npc.velocity.X - speed;
                        }
                    }
                    if (npc.velocity.Y < playerY)
                    {
                        npc.velocity.Y = npc.velocity.Y + speed;
                        if (npc.velocity.Y < 0f && playerY > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y + speed;
                            return;
                        }
                    }
                    else if (npc.velocity.Y > playerY)
                    {
                        npc.velocity.Y = npc.velocity.Y - speed;
                        if (npc.velocity.Y > 0f && playerY < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y - speed;
                            return;
                        }
                    }
                }
            }
            public override void AI()
            {
                Player player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.TargetClosest(false);
                    player = Main.player[npc.target];
                    if (!player.active || player.dead)
                    {
                        npc.velocity = new Vector2(0f, 10f);
                        if (npc.timeLeft > 10)
                        {
                            npc.timeLeft = 10;
                        }
                        return;
                    }
                }
                npc.TargetClosest(true);
                // Move just a tad slower than the original man guy thing
                Move(player, 0.05f);

                AttackTimer++;
                if(AttackTimer == 120)
                {
                    // TODO: Shoot projectile lol
                    AttackTimer = 0;
                    if (Main.rand.NextBool())
                        ChooseBubbleHoming();
                }
            }
            public void ChooseBubbleHoming()
            {
                int choice = Main.rand.Next(2);
                Projectile.NewProjectile(new Vector2(npc.Center.X + Main.rand.Next(-50, 50), npc.Center.Y + Main.rand.Next(-50, 50)),
                    new Vector2(npc.velocity.X + Main.rand.Next(5, 10), npc.velocity.Y + Main.rand.Next(5, 10)),
                    choice == 0 ? ModContent.ProjectileType<BubbleHoming>() : ModContent.ProjectileType<BubbleHoming2>(), 20, 2f, Main.myPlayer);

            }
        }
    }
}
