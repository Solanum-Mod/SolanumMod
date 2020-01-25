﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace SolanumMod.Items.Armor.tempestSet
{
    [AutoloadEquip(EquipType.Head)]
    class SharkHoodie : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Tempest Hood");
            Tooltip.SetDefault("Set Bonus: Gives the Shark Eye Buff. \nmagic damage increased by 15%. \nmagic Crit chance by 10%.");
        }

        int HammerTime = 5 * 60;
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 26;
            item.value = 10000;
            item.rare = 3;
            item.defense = 8;

        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<SharkRobes>() && legs.type == ItemType<SharkBoots>();
        }

        public override void UpdateArmorSet(Player player)
        {
            if (Collision.DrownCollision(player.position, player.width, player.height, player.gravDir))
            {
                
                player.AddBuff(mod.BuffType("SharkEyeBuff"), HammerTime, false);
            }
        }

        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 1;
            player.magicDamage += 0.15f;
        }

    }
}
