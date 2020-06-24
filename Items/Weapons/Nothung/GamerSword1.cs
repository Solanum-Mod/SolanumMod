using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace SolanumMod.Items.Weapons.Nothung
{
    class GamerSword1 : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 52;
            item.melee = true;
            item.width = 92;
            item.height = 92;
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
            player.itemLocation.X = player.itemLocation.X - 1f * (float)player.direction;
            player.itemLocation.Y = player.itemLocation.Y - 1f * (float)player.direction;
        }
        public override bool UseItem(Player player)
        {
            if(NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                player.inventory[player.selectedItem].TurnToAir();
                player.PutItemInInventory(ModContent.ItemType<GamerSword2>(), player.selectedItem);
            }
            return true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3, 2);
        }
    }
}
