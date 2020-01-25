using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SolanumMod.NPCs
{
	public class SolanumModGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}

		public override void NPCLoot(NPC npc)
		{	
			if (npc.type == 370) // Duke Fishron
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("TorrentialFin"), Main.rand.Next(13, 16), false, 0, false, false);
			}
		}
	}
}
