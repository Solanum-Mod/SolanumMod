using Terraria;
using Terraria.ModLoader;
namespace SolanumMod.Items.Placeables
{
    public class Painting2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Painting2");
            Tooltip.SetDefault("Potato");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 30;
            item.createTile = ModContent.TileType<Tiles.Painting2_Tile>();
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.sellPrice(0,0,4,20);
            item.useStyle = 1;
            item.rare = 3;
            item.consumable = true;
            item.maxStack = 10;
            item.autoReuse = true;
        }
    }
}