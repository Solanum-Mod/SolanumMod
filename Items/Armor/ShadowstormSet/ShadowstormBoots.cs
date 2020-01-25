using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SolanumMod.Items.Armor.ShadowstormSet
{
    [AutoloadEquip(EquipType.Legs)]
    class ShadowstormBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Shadowstorm Boots");
            Tooltip.SetDefault("Increases move speed by 5% \nmagic damage increased by 10%.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.value = 10000;
            item.rare = 3;
            item.defense = 9;

        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.05f;
            player.magicDamage += 0.01f;
        }
    }
}
