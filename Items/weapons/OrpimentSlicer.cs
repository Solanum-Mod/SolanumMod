using Terraria.ID;
using Terraria.ModLoader;

namespace SolanumMod.Items.weapons
{
	public class OrpimentSlicer : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("the slice to sucess");
		}

		public override void SetDefaults() 
		{
			item.damage = 126;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 26000;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "OrpimentChunk", 12);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}