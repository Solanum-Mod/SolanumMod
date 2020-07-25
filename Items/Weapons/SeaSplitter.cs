using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace SolanumMod.Items.Weapons
{
    public class SeaSplitter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sea Splitter");
            Tooltip.SetDefault("yes");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 20;
            item.noMelee = true;
            item.useStyle = 5;
            item.useAnimation = 40;
            item.useTime = 40;
            item.knockBack = 1.2f;
            item.damage = 126;
            item.noUseGraphic = true;
            item.shoot = ModContent.ProjectileType<Projectiles.SeaSplitterProj>();
            item.shootSpeed = 12f;
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.LightRed;
            item.melee = true;
            item.channel = true;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.SeaSplitterProj>()] < 1;
        }
    }
}