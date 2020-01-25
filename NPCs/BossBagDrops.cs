using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolanumMod.NPCs
{
	public class BossBagDrops : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "bossBag" && arg == ItemID.FishronBossBag) {
				player.QuickSpawnItem(mod.ItemType("TorrentialFin"), Main.rand.Next(14, 18));
			}
		}
	}
}