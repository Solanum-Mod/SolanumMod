
using Iampotatsslave;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace iampotatsslave
{
	public class LavaDagger : ModItem
	{
		public override void SetDefaults()
		{
			item.shootSpeed = 10f;
			item.damage = 23;
			item.knockBack = 5f;
			item.useStyle = 1;
			item.useAnimation = 25;
			item.useTime = 25;
			item.width = 30;
			item.height = 30;
			item.rare = 5;
			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 5);
			item.shoot = ModContent.ProjectileType<LavaDaggerProjectile>();
		}		

	}
}