using Terraria.ID;
using Terraria.ModLoader;

namespace SolanumMod.Items.materials
{
	public class OrpimentChunk : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("This strange chunk of crystal originated from the deepest depths of reality");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 1200;
			item.rare = 6;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Topaz, 1);
            recipe.AddIngredient(ItemID.Ectoplasm, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
