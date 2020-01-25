
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SolanumMod.Items.Materials
{
    class TorrentialFin : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 24;
            item.maxStack = 999;
            item.value = 100;
            item.rare = 1;
        }
    }
}
