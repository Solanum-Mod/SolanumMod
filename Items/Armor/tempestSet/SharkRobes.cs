using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SolanumMod.Items.Armor.tempestSet
{
    [AutoloadEquip(EquipType.Body)]
    class SharkRobes : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Tempest Cloak");
            Tooltip.SetDefault("Magic damage is increased by 10%  \nIncreases maximum mana by 20 \nRestores mana when damaged");
        }
        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 32;
            item.value = 10000;
            item.rare = 2;
            item.defense = 60;
        }
        public override void UpdateEquip(Player player)
        {

            player.magicCuffs = true;
            player.magicDamage += 0.1f;
        }

    }
}
