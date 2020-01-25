using System;
using Terraria;
using Terraria.ModLoader;
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
			item.width = 24;
			item.height = 24;
			npc.value = (float)Item.buyPrice(0, 0, 75, 0);
			base.item.rare = 3;
			base.item.accessory = true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.Diamond, 5);
			modRecipe.AddIngredient(ItemID.Bone, 25);
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
