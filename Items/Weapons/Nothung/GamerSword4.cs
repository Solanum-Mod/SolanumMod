using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework;

namespace SolanumMod.Items.Weapons.Nothung
{
    class GamerSword4 : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 241;
            item.melee = true;
            item.width = 170;
            item.height = 170;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 8;
            item.value = 1500000;
            item.rare = ItemRarityID.Red;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void UseStyle(Player player)
        {
            player.itemLocation.X = player.itemLocation.X - 40f * (float)player.direction;
            player.itemLocation.Y = player.itemLocation.Y + 15f * (float)player.direction;
        }
        public override bool UseItem(Player player)
        {

            return true;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            int projectileAmmount = 3;
            for (int i = 0; i < 360; i += 360 / projectileAmmount)
            {
                float distance = 100;
                float pX = distance * (float)Math.Cos(i) + (float)player.Center.X;
                float pY = distance * (float)Math.Sin(i) + (float)player.Center.Y;
                Vector2 spawnPos = new Vector2(pX, pY);
                Projectile.NewProjectile(spawnPos, Vector2.Zero, ModContent.ProjectileType<Projectiles.NothungP>(), damage, knockBack, player.whoAmI);
            }
        }
    }
}
