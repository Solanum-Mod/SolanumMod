using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SolanumMod.Items.Weapons
{
    public class sl_ice_r : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sl ice r");
            Tooltip.SetDefault("HAha tooltip go brr");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 34;
            item.damage = 12;
            item.useTime = 7;
            item.channel = true;
            item.noUseGraphic = true;
            item.knockBack = 3;
            item.melee = true;
            item.shoot = ModContent.ProjectileType<Projectiles.Sl_ice_r_Projectile>();
            item.shootSpeed = 10;
            item.value = Item.buyPrice(0,0,24,0);
            item.noMelee = true;
            item.useStyle = 5;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.autoReuse = true;
            item.rare = 1;
        }
    }
}
