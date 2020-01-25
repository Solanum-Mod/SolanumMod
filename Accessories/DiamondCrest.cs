using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace SolanumMod.Accessories
{
	public class DiamondCrest : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Diamond Crest");
			Tooltip.SetDefault("Increases magic damage by 7% and maximum mana by 40");
		}
		
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			base.item.rare = 3;
			base.item.accessory = true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.Diamond, 10);
			modRecipe.AddIngredient(ItemID.FallenStar, 5);
			modRecipe.AddRecipeGroup("GoldOrPlatinumBar", 3);
			modRecipe.AddTile(16); //Anvil
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicDamage += 0.07f;
			player.statManaMax2 += 40;
		}
	}
}
