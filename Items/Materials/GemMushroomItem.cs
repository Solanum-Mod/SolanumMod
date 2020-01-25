using System;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SolanumMod.Items.Materials
{
    class GemMushroomItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gem Mushroom");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.maxStack = 99;
            item.value = 750;
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = TileType<Tiles.GemMushroom>();
            item.placeStyle = 0;

        }
    }
}