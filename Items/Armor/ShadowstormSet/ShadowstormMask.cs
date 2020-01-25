using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using SolanumMod.Items.Materials;

namespace SolanumMod.Items.Armor.ShadowstormSet
{
    [AutoloadEquip(EquipType.Head)]
    class ShadowstormMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Shadowstorm Mask");
            Tooltip.SetDefault("Set Bonus: Minions inflict the shadowflame debuff, summon damage +10%, move speed +5%. \nSummon damage increased by 10%. \nMax minions +1");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 18;
            item.value = 10000;
            item.rare = 3;
            item.defense = 9;

        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<ShadowstormCloak>() && legs.type == ItemType<ShadowstormBoots>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.GetModPlayer<SolanumPlayer>().shadowflameMinion = true;

            player.minionDamage += 0.10f;
            player.moveSpeed += 0.05f;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
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
