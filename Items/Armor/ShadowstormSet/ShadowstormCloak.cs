using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SolanumMod.Items.Armor.ShadowstormSet
{
    [AutoloadEquip(EquipType.Body)]
    class ShadowstormCloak : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Shadowstorm Cloak");
            Tooltip.SetDefault("Magic crit chance +1. \nMax summons +1.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.value = 10000;
            item.rare = 3;
            item.defense = 30;

        }
        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 1;
            player.maxMinions += 1;
        }
    }
}
