using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolanumMod.NPCs
{

    public class NepturianSpawner : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Oceanic Beacon.");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
        }

        public override void SetDefaults()
        {
            item.width = 6;
            item.height = 24;
            item.maxStack = 20;
            //item.rare = ItemRarityID.Cyan; you can put one here if you want or just remove this comment 
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }      
        public override bool CanUseItem(Player player)
        {
         
            return !NPC.AnyNPCs(mod.NPCType("Nepturian")); 
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Nepturian"));
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
    }
}