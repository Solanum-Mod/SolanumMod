using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework;

namespace SolanumMod.Items.Weapons.Nothung
{
    class GamerSword3 : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 170;
            item.melee = true;
            item.width = 126;
            item.height = 126;
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
            player.itemLocation.X = player.itemLocation.X - 10f * (float)player.direction;
            player.itemLocation.Y = player.itemLocation.Y - 5f * (float)player.direction;
        }
        public override void HoldStyle(Player player)
        {
            player.itemLocation.X = player.itemLocation.X + 5f * (float)player.direction;
            player.itemLocation.Y = player.itemLocation.Y + 5f * player.gravDir;
        }
        public override bool UseItem(Player player)
        {

            if (NPC.downedMoonlord)
            {
                player.inventory[player.selectedItem].TurnToAir();
                player.PutItemInInventory(ModContent.ItemType<GamerSword4>(), player.selectedItem);
            }
            return true;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            int projectileAmmount = 2;
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
