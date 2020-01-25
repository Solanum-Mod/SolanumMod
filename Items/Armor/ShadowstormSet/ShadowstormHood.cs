using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SolanumMod.Items.Armor.ShadowstormSet
{
    [AutoloadEquip(EquipType.Head)]
    class ShadowstormHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Shadowstorm Hood");
            Tooltip.SetDefault("Set Bonus: Gives the Shark Eye Buff. \nmagic damage increased by 15%. \nmagic Crit chance by 10%.");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 26;
            item.value = 10000;
            item.rare = 3;
            item.defense = 30;

        }
    }
}
