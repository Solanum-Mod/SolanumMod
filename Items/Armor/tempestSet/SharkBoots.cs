using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SolanumMod.Items.Armor.tempestSet
{
    [AutoloadEquip(EquipType.Legs)]
    class SharkBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Tempest boots");
            Tooltip.SetDefault("Increases magic damage by 10%. \nIncreases move speed by 9%.");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 16;
            item.value = 10000;
            item.rare = 2;
            item.defense = 45;
        }

        public override void UpdateEquip(Player player)
        {

            player.moveSpeed *= 0.9f;
            player.magicDamage += 0.1f;
        }
    }
}
