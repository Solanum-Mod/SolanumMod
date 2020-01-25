using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SolanumMod
{
	public class SolanumMod : Mod
	{
		public SolanumMod()
		{
			ModProperties properties = default(ModProperties);
			properties.Autoload = true;
			properties.AutoloadGores = true;
			properties.AutoloadSounds = true;
			properties.AutoloadBackgrounds = true;
			base.Properties = properties;
		}
		
		public override void AddRecipeGroups()
		{
			RecipeGroup recipeGroup = new RecipeGroup(() => "Gold or Platinum Bar", new int[]
			{
				19,
				706
			});
			RecipeGroup.RegisterGroup("GoldPlatinumBar", recipeGroup);
		}
	}
}
