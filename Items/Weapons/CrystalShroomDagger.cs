
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolanumMod.Items.Weapons
{
	public class CrystalShroomDagger : ModItem
	{


		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("This is a modded sword.");  //The (English) text shown below your weapon's name
		}

		public override void SetDefaults()
		{
			item.damage = 16;
			item.melee = true;
			item.width = 6;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 6;
			item.value = Item.buyPrice(gold: 1);
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 6;
			item.useStyle = 3;
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