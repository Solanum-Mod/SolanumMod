using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using SolanumMod.Projectiles;
namespace SolanumMod.Accessories
{
    public class FrozenEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Eye");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 16;
            item.accessory = true;
            item.value = Item.buyPrice(0,0,5,0);
            item.rare = 2;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<SolanumPlayer>().IsWearingFrozenEye = true;
            if(player.ownedProjectileCounts[ModContent.ProjectileType<Frozen_Eye_Projectile>()] <= 0 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.Center,new Vector2(1,1),ModContent.ProjectileType<Frozen_Eye_Projectile>(),0,0,player.whoAmI,0,0);
            }
        }
    }
}