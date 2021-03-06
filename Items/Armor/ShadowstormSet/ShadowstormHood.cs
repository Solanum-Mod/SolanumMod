using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using SolanumMod.Items.Materials;

namespace SolanumMod.Items.Armor.ShadowstormSet
{
    [AutoloadEquip(EquipType.Head)]
    class ShadowstormHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowstorm Hood");
            Tooltip.SetDefault("Increases magic damage by 7%");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 26;
            item.value = 10000;
            item.rare = 3;
            item.defense = 6;

        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<ShadowstormCloak>() && legs.type == ItemType<ShadowstormBoots>();
        }

        public override void UpdateArmorSet(Player player)
        {
			player.setBonus = "Increases magic critical hit chance by 10% while having the Mana Sickness debuff \nIncreases magic damage by 10% and movement speed by 5%";
			
            if (Main.LocalPlayer.HasBuff(BuffID.ManaSickness)) {

                player.magicCrit += 10;
            }
            
            player.magicDamage += 0.10f;
            player.moveSpeed += 0.05f;
        }
        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.07f;
        }

        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.AddIngredient(ItemType<ShadowstormCloth>(), 6);
            modRecipe.AddTile(16); //Anvil
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
