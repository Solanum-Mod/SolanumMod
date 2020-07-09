using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace SolanumMod.Accessories
{
    public class Golden_Pendant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Pendant");
            Tooltip.SetDefault("+2 Minion Slots \n All minions emit light");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 18;
            item.accessory = true;
            item.stack = 1;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<SolanumPlayer>().GoldenPendant = true;
            player.maxMinions += 2;
        }
    }
}