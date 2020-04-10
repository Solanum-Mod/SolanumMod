
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolanumMod.Items.Weapons
{
	public class GemShroomKnife : ModItem
	{


		public override void SetStaticDefaults()
		{
            Tooltip.SetDefault("how did you turn a few shrooms into this?");
		}

		public override void SetDefaults()
		{
			item.damage = 32;
			item.melee = true;
			item.width = 6;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 6;
            item.value = 2500;
            item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 6;
			item.useStyle = 3;
            item.useTurn = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GemMushroomItem", 15);
            recipe.AddIngredient(ItemID.GrayBrick, 10);
            recipe.AddIngredient(ItemID.PlatinumShortsword, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe.AddRecipe(); recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GemMushroomItem", 15);
            recipe.AddIngredient(ItemID.GrayBrick, 10);
            recipe.AddIngredient(ItemID.GoldShortsword, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            float wantedVelocity = 7f;
            Vector2 unit = Vector2.UnitX * wantedVelocity;

            for (int i = 0; i < 3; i++)
                Projectile.NewProjectile(target.position, unit.RotatedByRandom(MathHelper.Pi), mod.ProjectileType("CrystalDaggerP"), damage, knockback, player.whoAmI);
        }
    }
}