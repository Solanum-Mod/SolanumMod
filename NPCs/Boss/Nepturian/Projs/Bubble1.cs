﻿using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolanumMod.NPCs.Boss.Nepturian.Projs
{
    class Bubble1 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 34;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.damage = 40;
            projectile.timeLeft = 200;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }
        public override void AI()
        {
            Vector2 floatypos = new Vector2((float)Math.Cos(Main.GlobalTime / 1f) * .25f, (float)Math.Sin(Main.GlobalTime / 1.37f) * .25f);
            projectile.velocity = floatypos + new Vector2(0, -1);
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 36; i++)
            {
                float angle = MathHelper.ToRadians(10 * i);
                Vector2 vector = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                Dust dust = Dust.NewDustPerfect(projectile.Center + (vector * 40), DustID.Vortex, vector * 8f, 100, Color.Aquamarine);
                dust.noGravity = true;

            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            projectile.Kill();
        }
    }
}