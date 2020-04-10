
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SolanumMod.Items.Weapons
{
	public class GemShroomPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.damage = 8;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 18;
			item.useAnimation = 18;
			item.pick = 55;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 2500;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GemMushroomItem", 15);
            recipe.AddIngredient(ItemID.GrayBrick, 10);
            recipe.AddIngredient(ItemID.PlatinumPickaxe, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe.AddRecipe(); recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GemMushroomItem", 15);
            recipe.AddIngredient(ItemID.GrayBrick, 10);
            recipe.AddIngredient(ItemID.GoldPickaxe, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}