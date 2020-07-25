using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolanumMod.Items.Weapons
{
	public class PearlStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Casts a pearl which explodes into shards");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 30;
			item.magic = true;
			item.mana = 15;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 2.4f;
			item.value = 25000;
			item.rare = 4;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PearlStaffOrb");
			item.shootSpeed = 14f;
                        item.noMelee = true;
		}
	}
}
