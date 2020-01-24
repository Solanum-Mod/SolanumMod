using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SolanumMod.Items.Armor.tempestSet
{
    class SharkEyeBuff : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shark Eye");
            Description.SetDefault("Player moves faster when water is touched and provides swimming abilities.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {

            player.moveSpeed += 1.88f;
            player.allDamage += 0.05f;
            player.accFlipper = true;
            player.ignoreWater = true;
        }

    }
}
