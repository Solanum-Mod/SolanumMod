using SolanumMod.Items;
using SolanumMod.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;


namespace SolanumMod
{
    class SolanumWorld : ModWorld
    {
        public override void PostUpdate()
        {
            if (Main.rand.Next(130) == 0)
            {
                int x = Main.rand.Next(100, Main.maxTilesX - 100);
                int y = Main.rand.Next((int)Main.worldSurface, Main.maxTilesY - 200);
                while (!TileID.Sets.Ore[Main.tile[x, y].type] || (Main.tile[x, y - 1].active() && Main.tileSolid[Main.tile[x, y - 1].type]))
                {
                    x = Main.rand.Next(100, Main.maxTilesX - 100);
                    y = Main.rand.Next((int)Main.worldSurface, Main.maxTilesY - 200);
                }
                WorldGen.PlaceTile(x, y - 1, TileType<Tiles.GemMushroom>(), true);
            }
        }
    }
}
