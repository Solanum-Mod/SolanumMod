using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
namespace SolanumMod.Items.Weapons
{
    public class BarnacleBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Barnacle Bow");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 26;
            item.useTurn = true;
            item.useStyle = 5;
            item.useTime = 18;
            item.useAnimation = 18;
            item.UseSound = SoundID.Item1;
            item.shootSpeed = 8f;
            item.damage = 38;
            item.autoReuse = true;
            item.rare = 2;
            item.ranged = true;
            item.knockBack = 2f;
            item.value = Item.buyPrice(0,0,80,40);
            item.shoot = ModContent.ProjectileType<Projectiles.BarnacleArrow>();
            item.useAmmo = AmmoID.Arrow;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3,0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = ModContent.ProjectileType<Projectiles.BarnacleArrow>();
            Projectile.NewProjectile(position,new Vector2(speedX,speedY).RotatedByRandom(MathHelper.ToRadians(12)),ModContent.ProjectileType<Projectiles.BarnacleArrow>(),23,2f);
            return true;
        }
    }
}